using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.ComponentModel;
using WorkTracker2.Data;
using WorkTracker2.Utilities;
using WorkTracker2.Printing;

namespace WorkTracker2.Core
{
    public partial class WorkTracker : Form
    {
        #region Declare private variables
        private static readonly DatabaseManager dbManager = new DatabaseManager();
        private static readonly JsonManager jsonManager = new JsonManager();
        private string SelectedClient { get => listClients.Text; }
        private string SelectedType { get => listTypes.Text; }
        private readonly BindingList<string> types = new BindingList<string>();
        private readonly BindingList<string> clients = new BindingList<string>();
        private readonly BindingList<string> recents = new BindingList<string>();
        private readonly Queue<string> recentItems = new Queue<string>();
        private string _updateString = string.Empty;
        public string Database { get => Preferences.Instance.Database; }
        public string User { get => Preferences.Instance.User; set => Preferences.Instance.User = value; }
        public string Initials { get => Preferences.Instance.Nickname; set => Preferences.Instance.Nickname = value; }
        private string[] updateLog = File.ReadAllLines(Constants.jsonPath + "UpdateLog.txt");
        #endregion

        public WorkTracker()
        {
            InitializeComponent();

            if (updateLog[0] == "unread")
            {
                ShowUpdates();
                Directory.CreateDirectory(Constants.documentString);
                jsonManager.PushData(Constants.documentString, "Preferences.json", new Dictionary<string, string>()
                {
                    {"Show Preferences", "false"}
                });
            }

            List<Dictionary<string, string>> temp;
            if((temp = jsonManager.PullData(Constants.documentString,"ClientList.json")) != null)
            {
                foreach (var item in temp) clients.Add(item["Client Name"]);
            }
            
            Preferences.Instance.Database = "DOP Reporting";
            User = Environment.UserName.ToUpper();
            var user = dbManager.PullEntry(Database, "Users", "Username",
                User);
            if (user.Count == 0)
            {
                AddUserInitials("Welcome to the Deferred Output WorkTracker\n\nTo begin, enter your initials\n(3 character max)");
                user = dbManager.PullEntry(Database, "Users", "Username", User);
            }
            Initials = user[0]["Initials"];

            UpdateBinding(clients, Constants.documentString + "ClientList.json", "Client Name");
            UpdateBinding(types, Constants.jsonPath + "Types.json", "Name");

            listTypes.DataSource = types;
            listClients.DataSource = clients;
            listRecent.DataSource = recents;
        }

        private void AddUserInitials(string labelText)
        {
            using (FormNewUser newUser = new FormNewUser(labelText, "New User"))
            {
                newUser.ShowDialog();
                if (newUser.DialogResult == DialogResult.OK)
                {
                    Initials = newUser.UserName.ToUpper();
                    User = Environment.UserName.ToUpper();
                    if (dbManager.PullEntry(Database, "Users", "Username", User).Count != 0)
                        dbManager.UpdateEntry(Database, "Users", "Username", new Dictionary<string, string>()
                    {
                        {"Username", User },
                        {"Initials", Initials }
                    });
                    dbManager.PushData(Preferences.Instance.Database, "Users", new Dictionary<string, string>()
                        {
                            {"Username", User },
                            {"Initials", Initials }
                        });
                }
            }
        }

        #region Handlers

        #region Main Handlers
        private void BAddQ_Click(object sender, EventArgs e)
        {
            var letter = CreateLetter();
            if(PushLetterToRecord(letter.LetterData) == true) PrintQueue.Instance.Add(letter);
        }

        private void TxtEncorrNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar))
            {
                TextBox Box = (sender as TextBox);

                if (Box.SelectionLength > 0) { Box.SelectedText = e.KeyChar.ToString(); e.Handled = true; }
                else if (Box.SelectionStart < Box.TextLength)
                {
                    int CacheSelectionStart = Box.SelectionStart;
                    StringBuilder sb = new StringBuilder(Box.Text);
                    sb[Box.SelectionStart] = e.KeyChar;
                    Box.Text = sb.ToString();
                    Box.SelectionStart = CacheSelectionStart + 1;
                    e.Handled = true;
                }
            }
        }
        private void ListRecent_SelectedIndexChanged(object sender, EventArgs e)
        {
            var letterData = dbManager.PullEntry(Database, "[Active Letters]",
                "Encorr", listRecent.Text)[0];
            if (letterData == null)
            {
                recents.Remove(letterData["Encorr"]);
                return;
            }
            this.txtEncorrNumber.Text = letterData["Encorr"];
            if (types.Contains(letterData["Type"]))
                listTypes.SelectedItem = (letterData["Type"]);
            else listTypes.SelectedItem = "Other";
            if (letterData["DCName"] != "N/A")
                textDCName.Text = letterData["DCName"];
            if (letterData["Tracking"] != "N/A")
                textTracking.Text = letterData["Tracking"];
            if (clients.Contains(letterData["Client"]))
                listClients.SelectedItem = letterData["Client"];
            else listClients.Text = letterData["Client"];
            _updateString = letterData["Encorr"];
        }

        #endregion

        #region Toolbar Buttons
        private void ToolReportGenerator_Click(object sender, EventArgs e)
        {
            FormReportGenerator reportGenerator = new FormReportGenerator();
            reportGenerator.Show();
        }

        private void ToolExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ToolClients_Click_1(object sender, EventArgs e)
        {
            using (ClientUpdater clientUpdater = new ClientUpdater())
            {
                clientUpdater.ShowDialog();
                if (clientUpdater.DialogResult == DialogResult.OK)
                {
                    UpdateBinding(clients, Constants.documentString+"ClientList.json", "Client Name");
                }
            }

        }

        private void ToolUser_Click(object sender, EventArgs e)
        {
            AddUserInitials("\nEnter your initials below\n(3 character max)");
        }

        private void ToolAddTest_Click(object sender, EventArgs e)
        {
            PushLetterToRecord(CreateLetter().LetterData);
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + "\\Pages\\Start.html");
            //System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + "\\Pages\\Start.cshtml");
        }
        #endregion

        #endregion

        #region PrintJob creation
        private Letter CreateLetter()
        {
            var type = string.Empty;

            if (SelectedType == "Other")
            {
                using (FormNewUser formText = new FormNewUser("A type must be entered if Other is selected.", "Enter letter type"))
                {
                    formText.SetMinAndMax(3, 10);

                    formText.ShowDialog();
                    if (formText.DialogResult == DialogResult.OK)
                    {
                        type = formText.UserName;
                        type = char.ToUpper(type[0]) + type.Substring(1);
                    }
                }
            }
            else type = SelectedType;
            return new Letter(txtEncorrNumber.Text, SelectedClient,
                Initials, type, textDCName.Text.ToUpper(), textTracking.Text);
        }
        #endregion

        private void UpdateBinding(BindingList<string> list, string path, string keyword)
        {
            list.Clear();
            using (var manager = new JsonManager())
            {
                var temp = manager.PullData(path, "");
                if (temp != null)
                    foreach (var dictionary in temp)
                    {
                        list.Add(dictionary[keyword]);
                    }
                else manager.PushData(path, "", new Dictionary<string, string>());
            }
        }

        private bool PushLetterToRecord(Dictionary<string, string> letterData)
        {
            if (letterData["Client"] == string.Empty || letterData["Type"] == string.Empty || letterData["User"] == string.Empty)
            {
                MessageBox.Show("A required entry is invalid. Please ensure a reference number, user, and client are all designated.");
                return false;
            }
            else
            {
                Dictionary<string, string> oldLetter;
                if (dbManager.FindDuplicates(Database, "[Active Letters]", "Encorr", letterData["Encorr"]) == true)
                {
                    if (MessageBox.Show("Letter already exists in record, update information?",
                        "Duplicate Letter", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        oldLetter = dbManager.PullEntry(
                            Database, "[Active Letters]", "Encorr", letterData["Encorr"])[0];
                        dbManager.UpdateEntry(Database, "[Active Letters]", "Encorr", letterData);
                    }
                    else return false; ;
                    dbManager.PushData(Database, "[QC History]", new Dictionary<string, string>()
                    { 
                    {"Date" , letterData["Date"] },
                    {"Encorr", letterData["Encorr"] },
                    {"User", Initials },
                    {"[Old Status]", oldLetter["Status"] },
                    {"[New Status]", letterData["Status"] },
                    {"Comments", "letter updated to new" }
                    });
                }
                else
                {
                    dbManager.PushData(Database, "[Active Letters]", letterData);
                    dbManager.PushData(Database, "[QC History]", new Dictionary<string, string>()
                    {
                    {"Date" , letterData["Date"] },
                    {"Encorr", letterData["Encorr"] },
                    {"User", letterData["User"]},
                    {"[Old Status]", "" },
                    {"[New Status]", letterData["Status"] },
                    {"Comments", "letter created" }
                    });
                }

                if (_updateString == string.Empty)
                    UpdateRecents(null, letterData["Encorr"]);
                else
                {
                    UpdateRecents(_updateString, letterData["Encorr"]);
                    _updateString = string.Empty;
                }
                textDCName.Text = string.Empty;
                textTracking.Text = string.Empty;
                return true;
            }
        }

        private void UpdateRecents(string oldEntry, 
            string newEntry)
        {
            if (oldEntry != null)
            {
                string[] arr = new string[recentItems.Count];
                recentItems.CopyTo(arr, 0);
                recentItems.Clear();
                for(var xx = 0; xx < arr.Length; xx++)
                {
                    if (arr[xx] != oldEntry) recentItems.Enqueue(arr[xx]);
                }
            }
            while (recentItems.Count >= 3) recentItems.Dequeue();

            recentItems.Enqueue(newEntry);

            recents.Clear();
            foreach(var item in recentItems)
            {
                recents.Add(item);
            }
        }

        private void ShowUpdates()
        {
            var display = string.Empty;
            for (var xx = 1; xx < updateLog.Length; xx++) display += updateLog[xx] + "\n";
            MessageBox.Show(display, "Update Notes");
            updateLog[0] = "read";
            using (StreamWriter sw = new StreamWriter(Constants.jsonPath + "UpdateLog.txt"))
            {
                foreach (var line in updateLog) sw.WriteLine(line);
            }
        }

        private void UpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUpdates();
        }
    }
}