using System.Collections.Generic;

namespace BuddyPals.Versioning
{
    public class ConfigPackage
    {
        public ConfigType Type { get; private set; }
        public List<string> PathName { get; private set; }

        public enum ConfigType
        {
            File,
            Directory,
            Null
        }

        public ConfigPackage(ConfigType type, params string[] pathName)
        {
            Type = type;
            PathName = new List<string>();

            foreach(string path in pathName)
            {
                PathName.Add(path);
            }
        }
    }
}
