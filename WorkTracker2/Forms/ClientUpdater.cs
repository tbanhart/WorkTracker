using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using WorkTracker2.Data;
using WorkTracker2.Utilities;

namespace WorkTracker2.Core
{
    public partial class ClientUpdater: Form
    {
        private readonly DatabaseManager _dbManager = new DatabaseManager();
        private readonly JsonManager _jsonManager = new JsonManager();
        private readonly BindingList<string> _allClientsDisplay = new BindingList<string>();
        private readonly BindingList<string> _currentClientsDisplay = new BindingList<string>();
        private readonly BindingList<string> _prods = new BindingList<string>();
        private readonly List<Dictionary<string, string>> _allClients;
        private readonly List<Dictionary<string, string>> _currentClients;

        public BindingList<string> ClientList { get => _currentClientsDisplay; }

        public ClientUpdater()
        {
            InitializeComponent();

            listProds.DataSource = _prods;
            listAllClients.DataSource = _allClientsDisplay;
            listSelectedClients.DataSource = _currentClientsDisplay;

            _allClients = _dbManager.PullData("DOP Reporting", "Clients");
            _currentClients = _jsonManager.PullData(Constants.documentString, "ClientList.json");

            foreach (var dictionary in _allClients)
            {
                //Console.WriteLine(dictionary["Client Name"] + "   " + dictionary["Prod"]);
                if (!_prods.Contains(dictionary["Prod"]))
                    _prods.Add(dictionary["Prod"]);
            }

            foreach(var dictionary in _currentClients)
            {
                _currentClientsDisplay.Add(dictionary["Client Name"]);
            }

            RefreshClients(_prods[0]);

        }

        private void RefreshClients(string prod)
        {
            _allClientsDisplay.Clear();
            var list = new List<string>();
            foreach(var dictionary in _allClients)
            {
                //Console.WriteLine("Checking to add " + prod + " client " + dictionary["Client Name"]);
                if (dictionary["Prod"] == prod)
                {
                    list.Add(dictionary["Client Name"]);
                    //Console.WriteLine("Client added to list " + dictionary["Client Name"]);
                }
            }
            list.Sort();
            foreach (var item in list) _allClientsDisplay.Add(item);
        }

        private void BAddClient_Click(object sender, EventArgs e)
        {
            var selected = listAllClients.Text;
            if (!_currentClientsDisplay.Contains(selected))
            {
                _currentClientsDisplay.Add(selected);
                var newData = _allClients.Find(
                    d => d["Client Name"] == selected);
                _currentClients.Add(newData);
            }
            else MessageBox.Show("Client already added to list.");
        }

        private void BRemoveClient_Click(object sender, EventArgs e)
        {
            var selected = listSelectedClients.Text;
            _currentClientsDisplay.Remove(selected);
            _currentClients.Remove(_currentClients.Find(d => d["Client Name"] == selected));
        }

        private void ListProds_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshClients(listProds.Text);
        }

        private void BDone_Click(object sender, EventArgs e)
        {
            _jsonManager.ClearData(Constants.documentString + "ClientList.json");
            foreach(var dictionary in _currentClients)
            {
                _jsonManager.PushData(Constants.documentString, "ClientList.json", dictionary);
            }
        }
    }
}
