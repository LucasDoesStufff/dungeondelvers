global using Terraria.ModLoader;
global using dungeondelvers.Core;

namespace dungeondelvers
{
    // Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
    public class dungeondelvers : Mod
	{
        public static dungeondelvers Instance { get; set; }
        public override void Load()
        {
            Instance = this;
        }

        public override void Unload()
        {
            Instance = null;
        }
    }
}
