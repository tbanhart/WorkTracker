using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using WorkTracker2.Reporting;
using WorkTracker2.Data;
using WorkTracker2.Utilities;
using WorkTracker2.Printing;

namespace WorkTracker2.Core
{
    public partial class FormReportGenerator : Form
    {
        public FormReportGenerator()
        {
            InitializeComponent();
            using (JsonManager jsonManager = new JsonManager())
            {
                profiles = jsonManager.PullData<Dictionary<string, Dictionary<string, List<string>>>>
                    (Constants.jsonPath, "Reporting Profiles.json");
                Console.WriteLine(profiles + " has been imported.");
            }


            dtStart.MaxDate = dtEnd.Value;
            dtEnd.MinDate = dtEnd.Value;

            listTables.DataSource = tables;
            listProfiles.DataSource = profileNames;
            textComments.DataSource = new BindingList<string>{
                "Wrong Form",
                "Wrong Pulled Pages",
                "Missing Stamp",
                "Missing Date",
                "TSP Sheet Not Filled Out",
                "Missing Death Cert",
                "Missing Information Sheet"
            };

            GetProfiles();

            GetDateRange(dtStart.Value, dtEnd.Value);
        }

        #region vars & properties
        private List<string> selectedDates = new List<string>() { DateTime.Today.ToShortDateString() };

        private List<Dictionary<string, string>> Report
        {
            get => ReportObject.Instance.Data;
        }

        private readonly DatabaseManager dataManager = new DatabaseManager();

        private readonly BindingList<string> profileNames = new BindingList<string>();

        private readonly BindingList<string> tables = new BindingList<string>();

        private readonly Dictionary<string, Dictionary<string, List<string>>> profiles = new Dictionary<string, Dictionary<string, List<string>>>();
        private string SelectedProfile { get => profileNames[listProfiles.SelectedIndex]; }
        private string SelectedTable { get => tables[listTables.SelectedIndex]; }
        private string Database { get => Preferences.Instance.Database; }
        #endregion

        #region Handlers

        #region List changes
        private void DtStart_ValueChanged(object sender, EventArgs e)
        {
            dtEnd.MinDate = dtStart.Value;
            selectedDates = GetDateRange(dtStart.Value, dtEnd.Value);
        }

        private void DtEnd_ValueChanged(object sender, EventArgs e)
        {
            dtStart.MaxDate = dtEnd.Value;
            selectedDates = GetDateRange(dtStart.Value, dtEnd.Value);
        }

        private void ListTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProfiles();
        }
        #endregion

        #region Button clicks
        private void BGenerate_Click(object sender, EventArgs e)
        {
            RefreshReportList();
            GenerateTreeList();
        }

        private void BSearchAll_Click(object sender, EventArgs e)
        { 
            RefreshReportList();
            ConvertTreeSearch();
        }

        private void BApprove_Click(object sender, EventArgs e)
        {
            DoQC("passed");
        }

        private void BDeny_Click(object sender, EventArgs e)
        {
            DoQC("failed");
        }

        private void BRemoved_Click(object sender, EventArgs e)
        {
            DoQC("removed");
        }
        #endregion

        #endregion

        #region Date functions
        private List<string> GetDateRange(DateTime dt1, DateTime dt2)
        {
            var range = new List<string>();
            for (DateTime date = dt1; date <= dt2; date = date.AddDays(1))
            {
                range.Add(date.ToShortDateString());
            }
            return range;
        }

        private void GetReportFromDates()
        {
            Report.Clear();

            foreach (var item in selectedDates)
            {
                var dictionaryList = dataManager.LimitedPull(
                    $"'{Database}'", $"{SelectedTable}", "Date", item);
                if (dictionaryList != null)
                {
                    foreach (var dictionary in dictionaryList)
                    {
                        //Console.WriteLine(dictionary);
                        if(selectedDates.Contains(dictionary["Date"])) ReportObject.Instance.AddValueToRecord(dictionary);
                    }
                }
            }
        }
        #endregion

        #region Treeview functions
        private void GenerateTreeList()
        {
            var profile = profiles[SelectedProfile];
            var nodeOrder = profile["tree"];
            var counts = profile["count"];
            var filteredItems = new List<List<string>>();
            var bgw = new BackgroundWorker();

            for(var xx=0; xx < nodeOrder.Count; xx++)
            {
                //Change this loop if filters for entries should be applied.
                filteredItems.Add(new List<string>());
                //Console.WriteLine("Filter list added " + nodeOrder[xx] + " new count " +
                    //filteredItems.Count());
            }

            foreach (var dictionary in Report)
            {
                
                //Console.WriteLine("Attempting to add values to report...");

                var current = treeReport.Nodes;
                var isNull = false;

                foreach (var node in nodeOrder) if (dictionary[node] == "N/A") isNull = true;
                if (isNull != true)
                    for (var yy = 0; yy < nodeOrder.Count; yy++)
                    {

                        var currentFilter = nodeOrder[yy];
                        var nodeName = dictionary[currentFilter];
                        if (!current.ContainsKey(dictionary[currentFilter]))
                        {
                            try
                            {
                                var filterString = currentFilter + ": ";
                                if (currentFilter == "Encorr") filterString = string.Empty;
                                //Console.WriteLine(dictionary[currentFilter] + " " +
                                //"is being added to nodes");
                                current.Add(nodeName, filterString + nodeName);
                                if (counts.Contains(currentFilter))
                                {
                                    string countString;
                                    if (yy > 0) countString = nodeName + "   " + Report.Count(c =>
                                       c[currentFilter] == nodeName &&
                                       c[nodeOrder[yy - 1]] == current[nodeName].Parent.Name);
                                    else countString = nodeName + "   " + Report.Count(c => c[currentFilter] == nodeName);
                                    current[nodeName].Text = countString;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e + "\nUnable to write value to node.");
                            }
                        }
                        current = current[dictionary[currentFilter]].Nodes;
                    }
            }

            treeReport.Sort();
        }

        private void ConvertTreeSearch()
        {
            var profile = profiles[SelectedProfile];
            var nodeOrder = profile["tree"];
            var text = textSearch.Text;

            var report = from value in Report
                         where value.Any(kvp => kvp.Value.Contains(text))
                         select value;

            foreach (var dictionary in report)
            {
                string key;
                key = dictionary.FirstOrDefault(k => k.Value.Contains(text)).Key;
                TreeNode node;
                switch (key)
                {
                    case "Encorr":
                        node = treeReport.Nodes.Add(dictionary["Encorr"], dictionary["Encorr"]);
                        foreach (var item in dictionary)
                        {
                            if (item.Key != "Encorr") node.Nodes.Add(item.Key, item.Key + ": " + item.Value);
                            else node.Nodes.Add(item.Key, item.Value);
                        }
                        break;

                    default:
                        if (!treeReport.Nodes.ContainsKey(dictionary[key])) node = treeReport.Nodes.Add(dictionary[key], dictionary[key]);
                        else node = treeReport.Nodes[dictionary[key]];
                        node.Nodes.Add(dictionary["Encorr"], dictionary["Encorr"]);
                        break;
                }
            }

            treeReport.Sort();
        }

        private bool ValidateNode(TreeNode node)
        {
            if (profiles[SelectedProfile] == null) return false;
            var profile = profiles[SelectedProfile];
            int acceptedIndex;
            try { acceptedIndex = profile["tree"].IndexOf("Encorr"); } 
            catch(Exception e)
            {
                MessageBox.Show(e + "\nNo Encorr in profile");
                return false;
            }
            if (node == null) return false;
            if (node.Level == acceptedIndex) return true;
            else return false;
        }

        private void QCUpdate(string newStatus)
        {

            var selected = ReportObject.Instance.Search(
                "Encorr", treeReport.SelectedNode.Text);
            var textbox = textComments.Text.Replace("'", "''");

            //do qc update script
            dataManager.PushData(Database, "[QC History]", new Dictionary<string, string>()
                        {
                        { "[New Status]", newStatus },
                        { "[User]", Preferences.Instance.Nickname},
                        { "Encorr", selected["Encorr"] },
                        { "[Old Status]", selected["Status"] },
                        { "Date", DateTime.Today.ToShortDateString() },
                        { "Comments", textbox }
                        });

            if (newStatus != "passed" && newStatus != "removed")
            {
                //change status in main db
                selected["Status"] = newStatus;
                dataManager.UpdateEntry(Database, "[Active Letters]", "Encorr", selected);
            }

            if(newStatus == "failed")
            {
                var letter = new Letter(selected["Encorr"], selected["Client"], selected["User"], selected["Type"], selected["DCName"], selected["Tracking"]);
                letter.LetterData.Add("Comments", textbox);
                letter.LetterData.Add("QCUser", Preferences.Instance.Nickname);
                //letter.Print();
            }

            treeReport.SelectedNode.Remove();

        }

        private void RefreshReportList()
        {
            treeReport.Nodes.Clear();
            GetReportFromDates();
        }
        #endregion

        private void DoQC(string status)
        {
            if (ValidateNode(treeReport.SelectedNode) == true)
            {
                if (status == "passed" || status == "removed") ArchiveLetter();
                if (textComments.Text == string.Empty && status != "passed")
                {
                    MessageBox.Show(
                        "No entry in comments, please add comments to QC fail.");
                    return;
                }
                else QCUpdate(status);
               // if (status == "passed" || status == "removed") dataManager.RemoveEntry(Database, "[ActiveLetters]")
            }
        }

        private void ArchiveLetter()
        {
            dataManager.RemoveEntry(Database, "[Active Letters]", "Encorr", treeReport.SelectedNode.Text);
            dataManager.PushData(Database, "Archive", Report.Find(e => e.ContainsValue(treeReport.SelectedNode.Text)));
        }

        private void GetProfiles()
        {
            profileNames.Clear();
            foreach (var profile in profiles)
            {
                var profileData = profiles[profile.Key];
                var table = profileData["table"];
                if (!tables.Contains(table[0]))
                {
                    tables.Add(table[0]);
                }
                if (table[0] == SelectedTable)
                {
                    profileNames.Add(profile.Key);
                }
            }
        }
    }
}