using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTracker2.Data
{
    public interface IDataManager
    {
        List<Dictionary<string, string>> PullData(string location, string identifier, params string[] args);
        bool PushData(string location, string identifier,
            Dictionary<string, string> data);
        void UpdateEntry(string location, string identifier, string searchTerm, Dictionary<string, string> data);
    }
}
