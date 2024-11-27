using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dungeondelvers.Core;
using Terraria.ID;
using Terraria.ModLoader;

namespace dungeondelvers.Content.Items.DungeonGen
{
    internal class down : ModItem
    {
        public override string Texture => AssetDirectory.Items + Name;

        public override void SetDefaults()
        {
            Item.createTile = ModContent.TileType<Tiles.down>();
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
