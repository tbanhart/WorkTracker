using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace WorkTracker2.Data
{
    public class JsonManager : IDataManager, IDisposable
    {
        public void Dispose() { }

        public string GetDateString(DateTime date, string filename)
        {
            return $"{date.Month}\\{date.Day}\\{filename}";
        }

        public List<Dictionary<string, string>> PullData(string path, string filename, params string[] args)
        {
            string filePath = path + filename;
            if (!File.Exists(filePath))
            {
                Console.WriteLine("file does not exist: " + filePath);
                Console.WriteLine("Creating new file at " + filePath);
                CreateFile(path, filename);
            }
            
            string json = string.Empty;
            using (StreamReader r = new StreamReader(filePath))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    json += line;
                }
            }
            List<Dictionary<string, string>> t = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
            if (t == null) Console.WriteLine("Could not process file.");
            return t;
            
        }

        public T PullData<T>(string location, string filename, params string[] args)
        {
            string filePath = location + filename;
            if (!File.Exists(filePath))
            {
                Console.WriteLine("file does not exist: " + filePath);
                return default;
            }
            else
            {
                string json = string.Empty;
                using (StreamReader r = new StreamReader(filePath))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        json += line;
                    }
                }
                T t = JsonConvert.DeserializeObject<T>(json);
                if (t == null) Console.WriteLine("Could not process file.");
                return t;
            }
        }

        public void ClearData(string pathWithFilename)
        {
            var fileData = PullData(pathWithFilename, string.Empty);
            fileData.Clear();
            File.WriteAllText(pathWithFilename, JsonConvert.SerializeObject(
                fileData, Formatting.Indented));
        }

        public bool PushData(string path, string filename, Dictionary<string, string> data)
        {
            List<Dictionary<string, string>> fileData =
                PullData(path + filename, string.Empty);

            fileData.Add(data);
            File.WriteAllText(path + filename, JsonConvert.SerializeObject(
                fileData, Formatting.Indented));

            return true;
        }

        public void CreateFile(string path, string filename)
        {
            var file = File.Create(path + filename);
            
            using (var sw = new StreamWriter(file))
            {
                sw.WriteLine("[");
                sw.WriteLine("]");
            }
        }

        public void UpdateEntry(string path, string filename, string filter, Dictionary<string, string> data)
        {
        }
    }
}
