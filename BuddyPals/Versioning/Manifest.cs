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
        public ModPackage Mods { get; private set; }
        public ManifestPackage ResourcePacks { get; private set; }
        public ManifestPackage ShaderPacks { get; private set; }
        public ManifestPackage Scripts { get; private set; }
        public ForgePackage Forge { get; private set; }

        public Manifest(ModPackage mods, ManifestPackage scripts = null, ForgePackage forge = null, ManifestPackage resourcePacks = null, ManifestPackage shaderPacks = null)
        {
            Mods = mods;
            Scripts = scripts;
            Forge = forge;
            ResourcePacks = resourcePacks;
            ShaderPacks = shaderPacks;
        }
    }
}
