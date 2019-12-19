namespace BuddyPals.Versioning
{
    public class VersionPackage
    {
        public string DisplayID { get; private set; }
        public string VersionName { get; protected set; }
        public ForgePackage ForgeRequirement { get; protected set; }
        public string DownloadURL { get; protected set; }

        public VersionPackage(string displayID, string versionName, ForgePackage forgeRequirement, string downloadURL)
        {
            DisplayID = displayID;
            VersionName = versionName;
            ForgeRequirement = forgeRequirement;
            DownloadURL = downloadURL;
        }
    }
}
