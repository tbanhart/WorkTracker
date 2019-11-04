using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using WorkTracker2.Data;
using WorkTracker2.Utilities;

namespace WorkTracker2.Forms
{
    public partial class FormExcel : Form
    {
        JsonManager json = new JsonManager();
        public FormExcel()
        {
            InitializeComponent();
            var data = json.PullData(Constants.documentString, "Preferences.json");

        }
    }
}
