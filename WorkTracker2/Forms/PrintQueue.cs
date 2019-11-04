using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkTracker2.Printing;

namespace WorkTracker2.Core
{
    public sealed partial class PrintQueue : Form
    {
        #region Singleton Code
        private PrintQueue()
        {
            InitializeComponent();
            listPrintJobs.DataSource = displayList;
            this.Show();
        }
        private static readonly Lazy<PrintQueue> instance = 
            new Lazy<PrintQueue>(() => new PrintQueue());

        public static PrintQueue Instance
        {
            get
            {
                return instance.Value;
            }
        }
        #endregion

        private int state = 0;

        private Queue<IPrintJob> printList = new Queue<IPrintJob>();

        private BindingList<string> displayList = new BindingList<string>();

        public void Add(IPrintJob job)
        {
            printList.Enqueue(job);
            UpdateDisplay();
            Console.WriteLine("state " + state);
            if (state == 0) this.backgroundWorker1.RunWorkerAsync();
        }

        public void Remove()
        {
            printList.Dequeue();
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            displayList.Clear();
            foreach(var item in printList)
            {
                displayList.Add(item.DisplayText);
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            Console.WriteLine("print list count " + printList.Count);
            if (printList.Count > 0)
            {
                state = 1;
                while (printList.Count > 0)
                {
                    var nextItem = printList.Peek();
                    nextItem.Print();
                    Remove();
                    UpdateDisplay();
                }
            }
            else state = 0;
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Print queue finished");
            UpdateDisplay();
            state = 0;
        }
    }
}
