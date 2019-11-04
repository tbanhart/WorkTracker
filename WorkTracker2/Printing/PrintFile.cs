using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTracker2.Printing
{
    public class PrintFile : IPrintJob
    {
        private readonly string filePath;

        public string DisplayText
        {
            get
            {
                return filePath;
            }
        }

        public PrintFile(string path)
        {
            filePath = $"{path}";
        }

        public bool Print()
        {
            try
            {
                using (Process p = new Process
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        CreateNoWindow = true,
                        Verb = "print",
                        FileName = filePath
                    }
                })
                {
                    p.Start();
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    Console.WriteLine("Process starting...");

                    int counter = 0;
                    while (!p.HasExited)
                    {
                        p.WaitForExit(10000);
                        counter++;
                        if (counter == 10) break;
                    }
                    if (!p.HasExited)
                    {
                        p.CloseMainWindow();
                        p.Kill();
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(filePath);
                Console.WriteLine("Could not print file. \n" + e);
                return false;
            }
        }
    }
}
