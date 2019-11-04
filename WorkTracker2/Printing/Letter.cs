using System;
using System.Collections.Generic;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTracker2.Printing
{
    class Letter : IPrintJob
    {

        private readonly Dictionary<string, string> _letterData = 
            new Dictionary<string, string>();

        public Dictionary<string, string> LetterData => _letterData;

        public Letter(string encorr, string client, string user, 
            string type, string DCName, string tracking)
        {
            LetterData["Date"] = DateTime.Today.ToShortDateString();
            LetterData.Add("Encorr", encorr);
            LetterData["Client"] = client;
            LetterData["User"] = user;
            LetterData["Type"] = type;
            LetterData["DCName"] = DCName;
            LetterData["Tracking"] = tracking;
            LetterData["Status"] = "created";
        }

        public string GetLetterInfo(string info)
        {
            return LetterData[info];
        }

        public bool Print()
        {
            Console.WriteLine("Printing " + DisplayText);
            Dictionary<string, string> bookmarks = new Dictionary<string, string>();
            foreach(var item in this.LetterData)
            {
                if (item.Key == "Type") bookmarks.Add(item.Key + item.Value, "X");
                else bookmarks.Add(item.Key, item.Value);
            }

            var wordApp = new Word.Application();
            Word.Document doc = wordApp.Documents.Open(Directory.GetCurrentDirectory() + "\\" + "Template.dot");

            foreach(var item in bookmarks)
            {
                try
                {
                    if (doc.Bookmarks.Exists(item.Key)) doc.Bookmarks[item.Key].Range.Text = item.Value;
                    else if(item.Value == "X")
                    {
                        doc.Bookmarks["TypeOther"].Range.Text = "X";
                        doc.Bookmarks["OtherType"].Range.Text = "__" + LetterData["Type"] + "__";
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Could not write bookmark " + item.Key + " " + item.Value + "\n" + e);
                }
            }

            doc.PrintOut();
            doc.Close(SaveChanges: false);

            Console.WriteLine(DisplayText + " has been printed.");
            return true;
        }

        public string DisplayText
        {
            get
            {
                return $"{GetLetterInfo("Client")} " +
                    $"{GetLetterInfo("Type")} {GetLetterInfo("Encorr")}";
            }
        }
    }
}
