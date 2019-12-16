using System;
using System.Collections.Generic;
using System.IO;
using BuddyPals.Versioning;

namespace BuddyPals
{
    public static class Library
    {
        public const string MOD_ID = "mods";
        public const string CONFIG_ID = "config";
        public const string RESOURCEPACK_ID = "resourcePacks";
        public const string SHADERS_ID = "shaderPacks";
        public const string SCRIPTS_ID = "scripts";
        public const string FORGEFILES_ID = "forgeFiles";

        public const string MOD_BIN_PATH = "BuddyPals\\bin\\mods\\";
        public const string CONFIG_BIN_PATH = "BuddyPals\\bin\\config\\";
        public const string RESOURCEPACK_BIN_PATH = "BuddyPals\\bin\\resourcepacks\\";
        public const string SHADERS_BIN_PATH = "BuddyPals\\bin\\shaderpacks\\";
        public const string SCRIPTS_BIN_PATH = "BuddyPals\\bin\\scripts\\";
        public const string JAR_BIN_PATH = "BuddyPals\\bin\\forge\\libraries";
        public const string JSON_BIN_PATH = "BuddyPals\\bin\\forge\\versions";

        public const string JAR_ROOT_ID = "forgeJarRoot";
        public const string JSON_ROOT_ID = "forgeJsonRoot";

        public static string MOD_SRC_FOLDER, CONFIG_SRC_FOLDER, RESOURCEPACK_SRC_FOLDER, SHADERS_SRC_FOLDER, SCRIPTS_SRC_FOLDER;

        public static string MOD_DST_FOLDER = "mods";
        public static string CONFIG_DST_FOLDER = "config";
        public static string RESOURCEPACK_DST_FOLDER = "resourcepacks";
        public static string SHADERS_DST_FOLDER = "shaderpacks";
        public static string SCRIPTS_DST_FOLDER = "scripts";
        public static string JAR_DST_FOLDER = "libraries";
        public static string JSON_DST_FOLDER = "versions";

        public const string FORGE_VERSION_1_12_2_2772 = "1.12.2-forge1.12.2-14.23.5.2772";
        public const string FORGE_VERSION_1_12_2_2779 = "1.12.2-forge1.12.2-14.23.5.2779";
        public const string FORGE_VERSION_1_12_2_2838 = "1.12.2-forge1.12.2-14.23.5.2838";
        public const string FORGE_VERSION_1_12_2_2847 = "1.12.2-forge1.12.2-14.23.5.2847";

        public static string BuddyPalsAppDataDirectory { get; private set; }
        public static string UpdaterConfigFilePath { get; private set; }
        public static string ModpackVersionFilePath { get; private set; }
        public static string LogFilePath { get; private set; }
        public static string ClientAgentFile { get; private set; }
        public static string LatestForgeVersion { get; private set; }

        public static List<ModPackage> Mods { get; private set; }

        public const string CLIENTCODEXURL = "ftp://mc.mlcgaming.com/ADMIN/clientcodex.aes";

        public static void Initialize()
        {
            InitializePaths();
            InitializeMods();
            LatestForgeVersion = FORGE_VERSION_1_12_2_2847;
        }

        private static void InitializePaths()
        {
            BuddyPalsAppDataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BuddyPals\\");
            UpdaterConfigFilePath = Path.Combine(BuddyPalsAppDataDirectory, "updater.conf");
            ModpackVersionFilePath = Path.Combine(BuddyPalsAppDataDirectory, "modpack.ver");
            LogFilePath = Path.Combine(BuddyPalsAppDataDirectory, "updater.log");
            ClientAgentFile = Path.Combine(BuddyPalsAppDataDirectory, "client.aes");

            MOD_SRC_FOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), MOD_BIN_PATH);
            CONFIG_SRC_FOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), CONFIG_BIN_PATH);
            RESOURCEPACK_SRC_FOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), RESOURCEPACK_BIN_PATH);
            SHADERS_SRC_FOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), SHADERS_BIN_PATH);
            SCRIPTS_SRC_FOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), SCRIPTS_BIN_PATH);
        }
        private static void InitializeMods()
        {
            ModPackage abyssalcraftIntegration = new ModPackage("AbyssalCraft Integration", true, false, "AbyssalCraft+Integration-1.12.2-1.9.0.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "acintegration.cfg"), new List<string>());

            ModPackage abyssalcraft = new ModPackage("AbyssalCraft", true, false, "AbyssalCraft-1.12.2-1.9.14.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "abyssalcraft.cfg"), new List<string>
                {
                    "AbyssalCraft-1.12.2-1.9.12.jar"
                });

            ModPackage appleCore = new ModPackage("AppleCore", true, false, "AppleCore-mc1.12.2-3.2.0.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Null, ""), new List<string>());

            ModPackage appleSkin = new ModPackage("AppleSkin", true, false, "AppleSkin-mc1.12-1.0.9.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "appleskin.cfg"), new List<string>());

            ModPackage aquaculture2 = new ModPackage("AquaCulture2", true, false, "Aquaculture-1.12.2-1.6.8.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "aquaculture.cfg"), new List<string>());

            ModPackage basicNetherOres = new ModPackage("Basic Nether Ores", true, false, "BasicNetherOres-1.12.2-1.0.4.0.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "BasicNetherOres"), new List<string>());

            ModPackage baubles = new ModPackage("Baubles", true, false, "Baubles-1.12-1.5.2.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "baubles.cfg"), new List<string>());

            ModPackage betterAdvancements = new ModPackage("Better Advancements", true, false, "BetterAdvancements-1.12.2-0.1.0.77.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "betteradvancements"), new List<string>());

            ModPackage betterAnimals = new ModPackage("Better Animals", true, false, "betteranimals-5.2.1.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "betteranimals.cfg"), new List<string>());

            ModPackage betterAnimalsPlus = new ModPackage("Better Animals Plus", true, false, "betteranimalsplus-1.12.2-8.0.0.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "betteranimalsplus.cfg"), new List<string>
                {
                    "betteranimalsplus-1.12.2-7.1.1.jar"
                });

            ModPackage betterDiving = new ModPackage("Better Diving", true, false, "BetterDiving-1.12.2-1.4.14.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "better_diving.cfg"), new List<string>
                {
                    "BetterDiving-1.12.2-1.4.01.jar"
                });

            ModPackage betterFoliage = new ModPackage("Better Foliage", true, false, "BetterFoliage-MC1.12-2.2.0.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "betterfoliage.cfg"), new List<string>());

            ModPackage betterFPS = new ModPackage("Better FPS", true, false, "BetterFps-1.4.8.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "betterfoliage.cfg"), new List<string>());

            ModPackage bewitchment = new ModPackage("Bewitchment", true, false, "bewitchment-1.12.2-0.0.21.3.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "bewitchment.cfg"), new List<string>
                {
                    "bewitchment-1.12.2-0.0.20.8.jar"
                });

            ModPackage bibliocraft = new ModPackage("Bibliocraft", true, false, "BiblioCraft[v2.4.5][MC1.12.2].jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "bibliocraft.cfg"), new List<string>());

            ModPackage biomesOPlenty = new ModPackage("Biomes O Plenty", true, false, "BiomesOPlenty-1.12.2-7.0.1.2441-universal.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "biomesoplenty"), new List<string>());

            ModPackage bloodmoon = new ModPackage("Bloodmoon", true, false, "Bloodmoon-MC1.12.2-1.5.3.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "bloodmoon.cfg"), new List<string>());

            ModPackage botania = new ModPackage("Botania", true, false, "Botania+r1.10-362.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "botania.cfg"), new List<string>());

            ModPackage bountiful = new ModPackage("Bountiful", true, false, "Bountiful-2.2.1.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "bountiful"), new List<string>());

            ModPackage bountifulBaubles = new ModPackage("Bountiful Baubles", true, false, "Bountiful+Baubles-1.12.2-0.1.4.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "bountifulbaubles.cfg"), new List<string>());

            ModPackage buildcraft = new ModPackage("Buildcraft", true, false, "buildcraft-all-7.99.24.3.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "buildcraft"), new List<string>());

            ModPackage cameraObscura = new ModPackage("Camera Obscura", true, false, "CameraObscura-1.0.3.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Null, ""), new List<string>());

            ModPackage cavern = new ModPackage("Cavern", true, false, "Cavern_1.12.2-v1.10.6.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "cavern"), new List<string>());

            ModPackage chameleon = new ModPackage("Chameleon", true, false, "Chameleon-1.12-4.1.3.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Null, ""), new List<string>());

            ModPackage chinjufuMod = new ModPackage("Chinjufu Mod", true, false, "ChinjufuMod[1.12.2]3.2.2.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "chinjufumod.cfg"), new List<string>());

            ModPackage chisel = new ModPackage("Chisel", true, false, "Chisel-MC1.12.2-0.2.1.35.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "chisel.cfg"), new List<string>());

            ModPackage comforts = new ModPackage("Comforts", true, false, "comforts-1.12.2-1.4.1.2.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "comforts.cfg"), new List<string>());

            ModPackage coroUtil = new ModPackage("CoroUtil", true, false, "coroutil-1.12.1-1.2.32.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "CoroUtil"), new List<string>());

            ModPackage craftTweaker = new ModPackage("CraftTweaker2", true, false, "CraftTweaker2-1.12-4.1.19.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Null, ""), new List<string>());

            ModPackage ctm = new ModPackage("CTM", true, false, "CTM-MC1.12.2-1.0.0.29.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "ctm.cfg"), new List<string>());

            ModPackage cyclopsCore = new ModPackage("Cyclops Core", true, false, "CyclopsCore-1.12.2-1.5.0.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "cyclopscore.cfg"), new List<string>());

            ModPackage decocraft = new ModPackage("DecoCraft", true, false, "Decocraft-2.6.3_1.12.2.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "decocraft.cfg"), new List<string>());

            ModPackage evilcraft = new ModPackage("EvilCraft", true, false, "EvilCraft-1.12.2-0.10.78.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "evilcraft.cfg", "evilcraftcompat.cfg"), new List<string>
                {
                    "EvilCraft-1.12.2-0.10.17.jar"
                });

            ModPackage familiarFauna = new ModPackage("Familiar Fauna", true, false, "FamiliarFauna-1.12.2-1.0.11.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "familiarfauna"), new List<string>());

            ModPackage fastFurnace = new ModPackage("Fast Furnace", true, false, "FastFurnace-1.12.2-1.3.1.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "fastfurnace.cfg"), new List<string>());

            ModPackage fastWorkbench = new ModPackage("Fast Workbench", true, false, "FastWorkbench-1.12.2-1.7.3.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "fastworkbench.cfg"), new List<string>());

            ModPackage foamFix = new ModPackage("FoamFix", true, false, "foamfix-0.10.9-1.12.2.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "foamfix.cfg"), new List<string>());

            ModPackage forgelin = new ModPackage("Forgelin", true, false, "Forgelin-1.8.4.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Null, ""), new List<string>());

            ModPackage grimoireOfGaia = new ModPackage("Grimoire of Gaia 3", true, false, "GrimoireOfGaia3-1.12.2-1.6.9.3.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "grimoireofgaia.cfg"), new List<string>());

            ModPackage hardcoreDarkness = new ModPackage("Hardcore Darkness", true, false, "HardcoreDarkness-MC1.12.2-2.0.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "hardcoredarkness.cfg"), new List<string>());

            ModPackage hats = new ModPackage("Hats", true, false, "Hats-1.12.2-7.1.0.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "hats.cfg"), new List<string>());

            ModPackage hiddenArmor = new ModPackage("Hidden Armor", true, false, "hiddenarmor-1.12.2-1.0.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "hiddenarmor.cfg"), new List<string>());

            ModPackage hungerOverhaul = new ModPackage("Hunger Overhaul", true, false, "HungerOverhaul-1.12.2-1.3.3.jenkins148.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "hungeroverhaul"), new List<string>());

            ModPackage hwyla = new ModPackage("HWYLA", true, false, "Hwyla-1.8.26-B41_1.12.2.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "waila"), new List<string>());

            ModPackage ichunUtil = new ModPackage("iChunUtil", true, false, "iChunUtil-1.12.2-7.1.4.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "ichunutil.cfg"), new List<string>());

            ModPackage industrialcraft2 = new ModPackage("IndustrialCraft2", true, false, "industrialcraft-2-2.8.170-ex112.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "IC2.ini"), new List<string>());

            ModPackage inventoryTweaks = new ModPackage("InventoryTweaks", true, false, "InventoryTweaks-1.63.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "InvTweaks.cfg", "InvTweaksRules.txt", "InvTweaksTree.txt"), new List<string>());

            ModPackage jei = new ModPackage("JEI", true, false, "jei_1.12.2-4.15.0.268.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "jei"), new List<string>());

            ModPackage jeiIntegration = new ModPackage("JEI Integration", true, false, "jeiintegration_1.12.2-1.5.1.36.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "jeiintegration.cfg"), new List<string>());

            ModPackage justEnoughHarvestcraft = new ModPackage("Just Enough HarvestCraft", true, false, "just-enough-harvestcraft-1.12.2-1.6.6.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Null, ""), new List<string>());

            ModPackage justEnoughIDs = new ModPackage("Just Enough IDs", true, false, "JustEnoughIDs-1.0.3-48.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Null, ""), new List<string>());

            ModPackage justEnoughResources = new ModPackage("Just Enough Resources", true, false, "JustEnoughResources-1.12.2-0.9.2.60.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "jeresources"), new List<string>());

            ModPackage libraryEx = new ModPackage("LibraryEx", true, false, "LibraryEx-1.12.2-1.0.11.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Null, ""), new List<string>());

            ModPackage lootbags = new ModPackage("Lootbags", true, false, "LootBags-1.12.2-2.5.8.5.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "lootbags.cfg", "Lootbags_BagConfig.cfg"), new List<string>());

            ModPackage lycanitesMobs = new ModPackage("Lycanites Mobs", true, false, "lycanitesmobs-1.12.2-2.0.1.1.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "lycanitesmobs"), new List<string>
                {
                    "lycanitesmobs-1.12.2-2.0.0.12.jar"
                });

            ModPackage magmaMonsters = new ModPackage("Magma Monsters", true, false, "MagmaMonsters-0.3.0.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "magma_monsters.cfg"), new List<string>());

            ModPackage mantle = new ModPackage("Mantle", true, false, "Mantle-1.12-1.3.3.55.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Null, ""), new List<string>());

            ModPackage mca = new ModPackage("Minecraft Comes Alive", true, false, "MCA-1.12.2-6.1.0-universal.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "mca.cfg"), new List<string>());

            ModPackage mobends = new ModPackage("MoBends", true, false, "mobends-0.24_for_MC-1.12.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "mobends.cfg"), new List<string>());

            ModPackage mysticalLib = new ModPackage("MysticalLib", true, false, "mysticallib-1.12.2-1.4.0.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Null, ""), new List<string>());

            ModPackage mysticalWorld = new ModPackage("Mystical World", true, false, "mysticalworld-1.12.2-1.5.0.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "mysticalworld.cfg"), new List<string>());

            ModPackage natura = new ModPackage("Natura", true, false, "natura-1.12.2-4.3.2.69.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "natura.cfg"), new List<string>());

            ModPackage netherEx = new ModPackage("NetherEx", true, false, "NetherEx-1.12.2-2.0.15.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "netherex"), new List<string>());

            ModPackage noRecipeBook = new ModPackage("No Recipe Book", true, false, "noRecipeBook_v1.2.2formc1.12.2.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Null, ""), new List<string>());

            ModPackage openGlider = new ModPackage("Open Glider", true, false, "OpenGlider-1.12.1-1.1.0.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "openglider.cfg"), new List<string>());

            ModPackage pamsHarvestcraft = new ModPackage("Pam's HarvestCraft", true, false, "Pam's+HarvestCraft+1.12.2zf.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "harvestcraft.cfg", "harvestcraft_fruittree.cfg"), new List<string>());

            ModPackage patchouli = new ModPackage("Patchouli", true, false, "Patchouli-1.0-20.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "patchouli.cfg"), new List<string>());

            ModPackage phosphor = new ModPackage("Phosphor", true, false, "phosphor-1.12.2-0.2.6+build50-universal.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "phosphor.json"), new List<string>());

            ModPackage ptrLib = new ModPackage("PTR Lib", true, false, "PTRLib-1.0.4.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "ptrmodellib.cfg"), new List<string>());

            ModPackage railcraft = new ModPackage("Railcraft", true, false, "railcraft-12.0.0.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "railcraft"), new List<string>());

            ModPackage randomPatches = new ModPackage("Random Patches", true, false, "randompatches-1.12.2-1.19.1.1.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "randompatches.cfg"), new List<string>());

            ModPackage removeMouseoverHighlight = new ModPackage("Remove Mouseover Highlight", true, false, "RemoveMouseoverHighlight-1.0.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "RemoveMouseoverHighlight.cfg"), new List<string>());

            ModPackage roguelikeDungeons = new ModPackage("Roguelike Dungeons", true, false, "RoguelikeDungeons-1.12.2-1.8.0.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "roguelike_dungeons"), new List<string>());

            ModPackage roots = new ModPackage("Roots", true, false, "Roots-1.12.2-3.0.21.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "roots"), new List<string>());

            ModPackage scalingHealth = new ModPackage("Scaling Health", true, false, "ScalingHealth-1.12.2-1.3.42+147.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "scalinghealth"), new List<string>());

            ModPackage scalingWealth = new ModPackage("Scaling Wealth", true, false, "ScalingWealth-1.0.1.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "scalingwealth"), new List<string>());

            ModPackage sereneSeaons = new ModPackage("Serene Seasons", true, false, "SereneSeasons-1.12.2-1.2.18-universal.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "sereneseasons"), new List<string>());

            ModPackage signpost = new ModPackage("Signpost", true, false, "signpost-1.12-1.06.1.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "signpost"), new List<string>());

            ModPackage silentLib = new ModPackage("SilentLib", true, false, "SilentLib-1.12.2-3.0.13+167.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Null), new List<string>());

            ModPackage slashblade = new ModPackage("Slashblade", true, false, "SlashBlade-mc1.12-r28.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "flammpfeil.slashblade.cfg"), new List<string>());

            ModPackage slashbladeTinkers = new ModPackage("Slashblade - Tinkers", true, false, "SlashBladeTic-V1.1.0-MC1.12.2.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "slashbladetic.cfg"), new List<string>());

            ModPackage storageDrawers = new ModPackage("Storage Drawers", true, false, "StorageDrawers-1.12.2-5.4.0.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "storagedrawers.cfg"), new List<string>());

            ModPackage storageDrawersExtra = new ModPackage("Storage Drawers Extra", true, false, "StorageDrawersExtras-1.12-3.1.0.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "storagedrawersextra.cfg"), new List<string>());

            ModPackage tconstruct = new ModPackage("Tinker's Construct", true, false, "TConstruct-1.12.2-2.13.0.171.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "tconstruct.cfg"), new List<string>
                {
                    "TConstruct-1.12.2-2.12.0.157.jar"
                });

            ModPackage thaumcraft = new ModPackage("Thaumcraft", true, false, "Thaumcraft-1.12.2-6.1.BETA26.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "thaumcraft_world.cfg", "thaumcraft_misc.cfg", "thaumcraft_graphics.cfg"), new List<string>());

            ModPackage thaumicJEI = new ModPackage("Thaumic JEI", true, false, "ThaumicJEI-1.12.2-1.6.0-27.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "thaumicjei.cfg", "thaumicjei_itemstack_aspects.json"), new List<string>());

            ModPackage thaumicTinkerer = new ModPackage("Thaumic Tinkerer", true, false, "thaumictinkerer-1.12.2-5.0-353c71c.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "thaumictinkerer.cfg"), new List<string>());

            ModPackage theMidnight = new ModPackage("The Midnight", true, false, "themidnight-0.3.5.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "midnight.cfg"), new List<string>());

            ModPackage tinkerToolLeveling = new ModPackage("Tinker Tool Leveling", true, false, "TinkerToolLeveling-1.12.2-1.1.0.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "TinkerModules.cfg", "TinkerToolLeveling.cfg"), new List<string>());

            ModPackage twilightForest = new ModPackage("Twilight Forest", true, false, "twilightforest-1.12.2-3.8.689-universal.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "twilightforest.cfg"), new List<string>());

            ModPackage uTeamCore = new ModPackage("UTeamCore", true, false, "u_team_core-1.12.2-2.2.4.133.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "uteamcore"), new List<string>());

            ModPackage usefulBackpacks = new ModPackage("Useful Backpacks", true, false, "useful_backpacks-1.12.2-1.5.1.42.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "usefulbackpacks.cfg"), new List<string> 
                {
                    "useful_backpacks-1.12.2-1.5.1.40.jar"
                });

            ModPackage w2w = new ModPackage("Waystones to Waypoints", true, false, "w2w-1.1.1.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "waystones2waypoints.cfg"), new List<string>());

            ModPackage wawla = new ModPackage("WAWLA", true, false, "Wawla-1.12.2-2.5.273.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "wawla.cfg"), new List<string>());

            ModPackage waystones = new ModPackage("Waystones", true, false, "Waystones_1.12.2-4.0.72.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "Waystones.cfg"), new List<string>());

            ModPackage weather2 = new ModPackage("Weather2", true, false, "weather2-1.12.1-2.6.12.jar",
                new ConfigPackage(ConfigPackage.ConfigType.Directory, "Weather2"), new List<string>());

            ModPackage xaeroMinimap = new ModPackage("Xaero's Minimap", true, false, "Xaeros_Minimap_1.19.0_Forge_1.12.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "xaerominimap.txt"), new List<string>
                {
                    "Xaeros_Minimap_1.18.6_Forge_1.12.jar"
                });

            ModPackage xaeroWorldMap = new ModPackage("Xaero's World Map", true, false, "XaerosWorldMap_1.5.1_Forge_1.12.jar",
                new ConfigPackage(ConfigPackage.ConfigType.File, "xaeroworldmap.txt"), new List<string>
                {
                    "XaerosWorldMap_1.5.0_Forge_1.12.jar"
                });

            Mods = new List<ModPackage>
            {
                abyssalcraftIntegration,
                abyssalcraft,
                appleCore,
                appleSkin,
                aquaculture2,
                basicNetherOres,
                baubles,
                betterAdvancements,
                betterAnimals,
                betterAnimalsPlus,
                betterDiving,
                betterFoliage,
                betterFPS,
                bewitchment,
                bibliocraft,
                biomesOPlenty,
                bloodmoon,
                botania,
                bountiful,
                bountifulBaubles,
                buildcraft,
                cameraObscura,
                cavern,
                chameleon,
                chinjufuMod,
                chisel,
                comforts,
                coroUtil,
                craftTweaker,
                ctm,
                cyclopsCore,
                decocraft,
                evilcraft,
                familiarFauna,
                fastFurnace,
                fastWorkbench,
                foamFix,
                forgelin,
                grimoireOfGaia,
                hardcoreDarkness,
                hats,
                hiddenArmor,
                hungerOverhaul,
                hwyla,
                ichunUtil,
                industrialcraft2,
                inventoryTweaks,
                jei,
                jeiIntegration,
                justEnoughHarvestcraft,
                justEnoughIDs,
                justEnoughResources,
                libraryEx,
                lootbags,
                lycanitesMobs,
                magmaMonsters,
                mantle,
                mca,
                mobends,
                mysticalLib,
                mysticalWorld,
                natura,
                netherEx,
                noRecipeBook,
                openGlider,
                pamsHarvestcraft,
                patchouli,
                phosphor,
                ptrLib,
                railcraft,
                randomPatches,
                removeMouseoverHighlight,
                roguelikeDungeons,
                roots,
                scalingHealth,
                scalingWealth,
                sereneSeaons,
                signpost,
                silentLib,
                slashblade,
                slashbladeTinkers,
                storageDrawers,
                storageDrawersExtra,
                tconstruct,
                thaumcraft,
                thaumicJEI,
                thaumicTinkerer,
                theMidnight,
                tinkerToolLeveling,
                twilightForest,
                uTeamCore,
                usefulBackpacks,
                w2w,
                wawla,
                waystones,
                weather2,
                xaeroMinimap,
                xaeroWorldMap
            };
        }

        /// <summary>
        /// Sets all static directory strings for destination folders.
        /// </summary>
        /// <param name="workingDirectoryRoot">Either Options.MinecraftDirectory or Options.PTRDirectory</param>
        /// <param name="forgeDirectoryRoot">Usually Options.MineCraftDiretory (C:/Users/USER/AppData/.minecraft/)</param>
        public static void UpdateDestinationFolderPaths(string workingDirectoryRoot, string forgeDirectoryRoot)
        {
            MOD_DST_FOLDER = Path.Combine(workingDirectoryRoot, "mods");
            CONFIG_DST_FOLDER = Path.Combine(workingDirectoryRoot, "config");
            RESOURCEPACK_DST_FOLDER = Path.Combine(workingDirectoryRoot, "resourcepacks");
            SHADERS_DST_FOLDER = Path.Combine(workingDirectoryRoot, "shaderpacks");
            SCRIPTS_DST_FOLDER = Path.Combine(workingDirectoryRoot, "scripts");

            JAR_DST_FOLDER = Path.Combine(forgeDirectoryRoot, "libraries");
            JSON_DST_FOLDER = Path.Combine(forgeDirectoryRoot, "versions");
        }
    }
}
