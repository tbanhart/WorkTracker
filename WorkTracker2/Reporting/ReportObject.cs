using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkTracker2.Reporting
{
    sealed class ReportObject
    {
        #region Singleton Code
        private ReportObject()
        {
            Data = new List<Dictionary<string, string>>();
        }
        private static readonly Lazy<ReportObject> instance =
            new Lazy<ReportObject>(() => new ReportObject());

        public static ReportObject Instance
        {
            get
            {
                return instance.Value;
            }
        }
        #endregion

        private List<Dictionary<string, string>> _reportData;

        public List<Dictionary<string, string>> Data
            { get => _reportData; set => _reportData = value; }

        public void ClearData()
        {
            Data.Clear();
        }

        public Dictionary<string, string> Search(string key, string value)
        {
            foreach(var dictionary in Data)
            {
                if(dictionary[key] == value)
                {
                    return dictionary;
                }
            }
            return default;
        }

        public void AddValueToRecord(Dictionary<string, string> inputDictionary)
        {
            var newDictionary = new Dictionary<string, string>();
            foreach(var keyValue in inputDictionary)
            {
                if (keyValue.Value == string.Empty) newDictionary.Add(keyValue.Key, "N/A");
                else newDictionary.Add(keyValue.Key, keyValue.Value);
            }
            _reportData.Add(newDictionary);
            Console.WriteLine(_reportData.Count());
        }
    }
}
