using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyPals.Versioning
{
    public class ModPackage
    {
        public string Name { get; private set; }
        public bool Enabled { get; private set; }
        public bool Forced { get; private set; }
        public string Latest { get; private set; }
        public List<string> History { get; private set; }
        public ConfigPackage Config { get; private set; }

        [JsonConstructor]
        public ModPackage(string name, bool enabled, bool forced, string latest, ConfigPackage config, List<string> history)
        {
            Name = name;
            Enabled = enabled;
            Forced = forced;
            Latest = latest;
            Config = config;

            if (history.Count > 0)
            {
                History = new List<string>(history);
            }
            else
            {
                History = new List<string>();
            }
        }
    }
}
