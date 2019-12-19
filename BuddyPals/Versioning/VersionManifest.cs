using System.Collections.Generic;
using Newtonsoft.Json;

namespace BuddyPals.Versioning
{
    public class VersionManifest
    {
        public List<VersionPackage> Versions { get; protected set; }

        public VersionManifest(params VersionPackage[] versions)
        {
            Versions = new List<VersionPackage>();
            foreach(VersionPackage version in versions)
            {
                Versions.Add(version);
            }
        }

        [JsonConstructor]
        public VersionManifest(List<VersionPackage> versions)
        {
            Versions = new List<VersionPackage>(versions);
        }
    }
}