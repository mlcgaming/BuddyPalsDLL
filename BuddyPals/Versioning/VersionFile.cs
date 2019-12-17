using Newtonsoft.Json;
using System.Collections.Generic;

namespace BuddyPals.Versioning
{
    public class VersionFile
    {
        public int ID { get; private set; }
        public string DisplayID { get; private set; }
        public bool IsActive { get; private set; }
        public string VersionName { get; private set; }
        public string FileName { get; private set; }
        public string URL { get; private set; }
        public Dictionary<string, bool> UpdatePackages { get; private set; }
        public ForgePackage Forge { get; private set; }
        public Manifest Manifest { get; private set; }

        [JsonConstructor]
        public VersionFile(int id, string displayID, bool isActive, string versionName, string fileName, string url, 
            Dictionary<string,bool> updatePackages, ForgePackage forge, Manifest manifest)
        {
            ID = id;
            DisplayID = displayID;
            IsActive = isActive;
            VersionName = versionName;
            FileName = fileName;
            URL = url;
            UpdatePackages = new Dictionary<string, bool>(updatePackages);
            Forge = forge;
            Manifest = manifest;
        }

        public VersionFile(int id, string displayID, bool isActive, string versionName, string fileName, string url, bool updateMods, 
            bool updateConfigs, bool updateScripts, bool updateResourcePacks, bool updateShaderPacks, string forgeRequiredVersion, Manifest manifest)
        {
            ID = id;
            DisplayID = displayID;
            IsActive = isActive;
            VersionName = versionName;
            FileName = fileName;
            URL = url;
            UpdatePackages = new Dictionary<string, bool>
            {
                {Library.MOD_ID, updateMods },
                {Library.CONFIG_ID, updateConfigs },
                {Library.SCRIPTS_ID, updateScripts },
                {Library.RESOURCEPACK_ID, updateResourcePacks },
                {Library.SHADERS_ID, updateShaderPacks }
            };
            Forge = CreateForgePackage(forgeRequiredVersion);
            Manifest = manifest;
        }

        private ForgePackage CreateForgePackage(string forgeVersion)
        {
            return new ForgePackage("BuddyPals " + DisplayID + " LIVE", forgeVersion);
        }
    }
}
