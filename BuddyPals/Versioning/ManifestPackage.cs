using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyPals.Versioning
{
    public class ManifestPackage
    {
        public bool Forced { get; private set; }
        public List<string> Files { get; private set; }

        [JsonConstructor]
        public ManifestPackage(bool isForced, List<string> files)
        {
            Forced = isForced;
            if(files.Count > 0)
            {
                Files = new List<string>(files);
            }
            else
            {
                Files = new List<string>();
            }
        }
        public ManifestPackage(bool isForced, params string[] files)
        {
            Forced = isForced;
            Files = new List<string>();
            if(files.Count() > 0)
            {
                foreach(string file in files)
                {
                    Files.Add(file);
                }
            }
        }
    }
}
