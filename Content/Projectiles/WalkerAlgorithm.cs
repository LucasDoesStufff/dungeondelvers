using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using dungeondelvers.Core;
using Terraria.Utilities;

namespace dungeondelvers.Content.Projectiles
{
    public class Walker : ModProjectile
    {
        int tilesToKill;
        private int airTime;
        Vector2 spawnposition;
        public override string Texture => AssetDirectory.Debug + "PHwand";
        public override void SetDefaults()
        {
            Projectile.height = Main.rand.Next( 3*16, 5*16 );
            Projectile.width = Main.rand.Next( 5*16, 7*16 );

            Projectile.aiStyle = -1;
            Projectile.timeLeft = int.MaxValue;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
        }
        public override void OnSpawn(IEntitySource source)
        {
            spawnposition = Projectile.position;
            airTime = 300;
            tilesToKill = Main.rand.Next(20, 30);


            switch (Main.rand.Next(1,7))
            {
                case 1:
                    Projectile.velocity.X = 60 / 16;
                    Projectile.velocity.Y = 0;
                    break;
                case 2:
                    Projectile.velocity.X = -60 / 16;
                    Projectile.velocity.Y = 0;
                    break;
                case 3:
                    Projectile.velocity.X = 0;
                    Projectile.velocity.Y = 60 / 16;
                    break;
                case 4:
                    Projectile.velocity.X = 0;
                    Projectile.velocity.Y = -60 / 16;
                    break;
                case 5:
                    Projectile.velocity.X = 0;
                    Projectile.velocity.Y = 60 / 16;
                    break;
                case 6:
                    Projectile.velocity.X = 0;
                    Projectile.velocity.Y = -60 / 16;
                    break;
            }
        }
        public override void AI()
        {
            Behaviour();

            double rotation = Main.rand.NextBool(2) ? Math.PI / 4 : -Math.PI / 4;

            if(Main.rand.NextBool(50))
            {
                Projectile.velocity = Projectile.velocity.RotatedBy(rotation);
            }

            if(Projectile.Distance(spawnposition) > 1000 || tilesToKill == 0)
            {
                Projectile.Kill();
            }
        }

        private void Behaviour()
        {
            Tile tile = Main.tile[Projectile.position.ToTileCoordinates()];
            Tile upTile = Main.tile[Projectile.position.ToTileCoordinates().X, Projectile.position.ToTileCoordinates().Y - 1];
            Tile downTile = Main.tile[Projectile.position.ToTileCoordinates().X, Projectile.position.ToTileCoordinates().Y + 1];
            Tile lefTile = Main.tile[Projectile.position.ToTileCoordinates().X - 1, Projectile.position.ToTileCoordinates().Y];
            Tile rightTile = Main.tile[Projectile.position.ToTileCoordinates().X + 1, Projectile.position.ToTileCoordinates().Y];

            if (tile != null && tile.HasTile)
            {
                WorldGen.KillTile(Projectile.position.ToTileCoordinates().X, Projectile.position.ToTileCoordinates().Y, false, false, true);
                tilesToKill--;
            }

            if (!tile.HasTile && !upTile.HasTile && !downTile.HasTile && !lefTile.HasTile && !rightTile.HasTile)
            {
                airTime--;
            }
            if(airTime <= 0) Projectile.Kill();
        }
    }
}