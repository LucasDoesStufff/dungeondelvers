using dungeondelvers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace dungeondelvers.Content.Items.DungeonGen
{
    internal class left : ModItem
    {
        public override string Texture => AssetDirectory.Items + Name;

        public override void SetDefaults()
        {
            Item.createTile = ModContent.TileType<Tiles.left>();
            Item.width = 32;
            Item.height = 32;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 999;
            Item.autoReuse = true;
        }
    }
}
