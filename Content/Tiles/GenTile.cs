using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dungeondelvers.Core;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria;
using Terraria.ModLoader;

namespace dungeondelvers.Content.Tiles
{
    internal class GenTile : ModTile
    {
        public override string Texture => AssetDirectory.Tiles + "Invisible_Tile";

        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileLighted[Type] = true;

            LocalizedText name = CreateMapEntryName();
            AddMapEntry(Color.DarkOliveGreen, name);
        }
    }
}
