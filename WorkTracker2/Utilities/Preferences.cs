using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTracker2.Utilities
{
    class Preferences
    {
        #region Singleton Code
        private Preferences() { }
        private static readonly Lazy<Preferences> instance =
            new Lazy<Preferences>(() => new Preferences());

        public static Preferences Instance
        {
            get
            {
                return instance.Value;
            }
        }
        #endregion

        private string _user;
        private string _database;
        private string _initials;

        public string User { get => _user; set => _user = value; }
        public string Nickname { get => _initials; set => _initials = value; }

        public string Database { get => _database; set => _database = value; }
    }
}
