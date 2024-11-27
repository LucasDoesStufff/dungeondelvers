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
    internal class down : ModTile
    {
        public override string Texture => AssetDirectory.Tiles + Name + "_tile";

        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileLighted[Type] = true;

            LocalizedText name = CreateMapEntryName();
            AddMapEntry(Color.DarkOliveGreen, name);
        }
    }
}
