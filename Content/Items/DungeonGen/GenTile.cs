using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dungeondelvers.Content.Tiles;
using dungeondelvers.Core;
using StructureHelper;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.WorldBuilding;

namespace dungeondelvers.Content.Items.DungeonGen
{
    internal class GenTile : ModItem
    {
        public override string Texture => AssetDirectory.Blocks + "InvisibleTileItem";

        private int left;
        private int right;
        private int up;
        private int down;
        private int rooms;

        public override void SetDefaults()
        {
            //Item.createTile = ModContent.TileType<Tiles.GenTile>();
            Item.width = 32;
            Item.height = 32;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 999;
            Item.autoReuse = true;
            left = ModContent.TileType<Tiles.left>();
            right = ModContent.TileType<Tiles.right>();
            up = ModContent.TileType<Tiles.up>();
            down = ModContent.TileType<Tiles.down>();

        }

        public override bool? UseItem(Player player)
        {
            if (player.altFunctionUse == 2 && rooms < 30)
            {
                for (int i = 0; i < Main.maxTilesX; i++)
                {
                    for (int j = 0; j < Main.maxTilesY; j++)
                    {
                        Tile tile = Main.tile[i, j];

                        if (tile.HasTile && tile != null)
                        {
                            // LRUD
                            //Main.NewText("corridor placed");
                            if(tile.TileType == ModContent.TileType<Content.Tiles.left>())
                            {
                                
                                rooms++;
                                Generator.GenerateMultistructureRandom(AssetDirectory.StructureFolder + "CorridorsBasic", new(i - 25, j - 12), dungeondelvers.Instance);
                                tile.HasTile = false;
                            }
                            if (tile.TileType == ModContent.TileType<Content.Tiles.right>())
                            {
                                rooms++;
                                Generator.GenerateMultistructureRandom(AssetDirectory.StructureFolder + "CorridorsBasic", new(i + 1, j - 12), dungeondelvers.Instance);
                                tile.HasTile = false;
                            }
                            if (tile.TileType == ModContent.TileType<Content.Tiles.up>())
                            {
                                rooms++;
                                Generator.GenerateMultistructureRandom(AssetDirectory.StructureFolder + "CorridorsBasic", new(i - 12, j - 25), dungeondelvers.Instance);
                                tile.HasTile = false;
                            }
                            if (tile.TileType == ModContent.TileType<Content.Tiles.down>())
                            {

                                rooms++;
                                Generator.GenerateMultistructureRandom(AssetDirectory.StructureFolder + "CorridorsBasic", new(i - 12, j + 1), dungeondelvers.Instance);
                                tile.HasTile = false;
                            }
                        }
                    }
                }
            }
            else
            {
                rooms = 0;
            }
            return true;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
    }
}
