using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyPals.Versioning
{
    public class Manifest
    {
        public bool Forced { get; private set; }
        public List<ModPackage> Mods { get; private set; }
        public List<ManifestPackage> ResourcePacks { get; private set; }
        public List<ManifestPackage> ShaderPacks { get; private set; }
        public List<ManifestPackage> Scripts { get; private set; }
        public ForgePackage Forge { get; private set; }

        [JsonConstructor]
        public Manifest(bool isForced, List<ModPackage> mods, List<ManifestPackage> scripts = null, ForgePackage forge = null, List<ManifestPackage> resourcePacks = null, List<ManifestPackage> shaderPacks = null)
        {
            Forced = isForced;
            Mods = mods;
            Scripts = scripts;
            Forge = forge;
            ResourcePacks = resourcePacks;
            ShaderPacks = shaderPacks;
            Forge = forge;
        }
    }
}
