namespace BuddyPals.Versioning
{
    public class ForgePackage
    {
        public string LauncherDisplayName { get; private set; }
        public string Version { get; private set; }

        public ForgePackage(string launcherDisplayName, string version)
        {
            LauncherDisplayName = launcherDisplayName;
            Version = version;
        }
    }
}
