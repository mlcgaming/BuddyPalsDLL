using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyPals.Versioning
{
    public class ForgePackage
    {
        public string InstallationName { get; private set; }
        public string ForgeVersionID { get; private set; }

        public ForgePackage(string installationName, string forgeVersionId)
        {
            InstallationName = installationName;
            ForgeVersionID = forgeVersionId;
        }
    }
}
