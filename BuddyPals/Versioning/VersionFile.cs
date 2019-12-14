﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyPals.Versioning
{
    public class VersionFile
    {
        public int ID { get; private set; }
        public int Format { get; private set; }
        public bool IsActive { get; private set; }
        public string DisplayID { get; private set; }
        public string VersionName { get; private set; }
        public string FileName { get; private set; }
        public string URL { get; private set; }
        public Dictionary<string, bool> UpdatePackages { get; private set; }
        public Manifest Manifest { get; private set; }


        public VersionFile(int id, bool isActive, string displayID, string versionName, string fileName, string url, 
            Dictionary<string,bool> updatePackages, Manifest manifest)
        {
            ID = id;
            Format = 3;
            IsActive = isActive;
            DisplayID = displayID;
            VersionName = versionName;
            FileName = fileName;
            URL = url;
            UpdatePackages = new Dictionary<string, bool>(updatePackages);
            Manifest = manifest;
        }

        public VersionFile(int id, bool isActive, string displayID, string versionName, string fileName, string url, bool updateMods, 
            bool updateScripts, bool updateForge, bool updateResourcePacks, bool updateShaderPacks, Manifest manifest)
        {
            ID = id;
            Format = 3;
            IsActive = isActive;
            DisplayID = displayID;
            VersionName = versionName;
            FileName = fileName;
            URL = url;
            UpdatePackages = new Dictionary<string, bool>
            {
                {Library.MOD_ID, updateMods },
                {Library.SCRIPTS_ID, updateScripts },
                {Library.FORGEFILES_ID, updateForge },
                {Library.RESOURCEPACK_ID, updateResourcePacks },
                {Library.SHADERS_ID, updateShaderPacks }
            };
            Manifest = manifest;
        }
    }
}