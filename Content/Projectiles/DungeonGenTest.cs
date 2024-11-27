/*using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.DataStructures;
using dungeondelvers.Core;
using Microsoft.CodeAnalysis;
using System.Collections;



///     
///     its too complex so I m shelving this
///

namespace dungeondelvers.Content.Projectiles
{
    public class DungeonGenTest : ModProjectile
    {
        public override string Texture => AssetDirectory.Debug + "PHwand";
        public string seed
        {
            get => seed;
            set => Seed = value.GetHashCode();
        }
        public bool isRandom = true;
        public int Seed;
        public int max = 100;
        public int spawned = 0;

        public List<(Projectile, float)> projs;
        public List<(Projectile, float)> projsToRemove;
        
        public override void SetDefaults()
        {
            Projectile.height = Main.rand.Next( 3, 5) * 16;
            Projectile.width = Main.rand.Next( 5, 7) * 16;

            Projectile.aiStyle = -1;
            Projectile.timeLeft = int.MaxValue;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;

        }
        public override void OnSpawn(IEntitySource source)
        {
            projs = new List<(Projectile, float)>();
            SpawnMultiple();
        }
        public override void AI()
        {
            Sorting();
            Main.NewText(projs.Count);
        }
        /// <summary>
        /// Checks if the spawned room count is reached the max amount and orders them to room size (height * width)
        /// removes the last 60% of the rooms and deletes them
        /// </summary>
        private void Sorting()
        {
            Projectile.ai[1]++;
            if (projs.Count == max)
            {
                Projectile.ai[0]++;
                if (Projectile.ai[0] > 4 * 60)
                {
                    projsToRemove = projs.OrderByDescending(p => p.Item2).TakeLast((int)(projs.Count * 0.6f)).ToList();
                    projs = projs.OrderByDescending(p => p.Item2).Take((int)(projs.Count * 0.4f)).ToList();
                    if (Projectile.ai[1] >= 30)
                    {
                        Projectile.ai[1] = 0;
                        foreach (var item in projsToRemove)
                        {
                            item.Item1.Kill();
                            Projectile.Kill();
                        }
                        Main.NewText(projsToRemove.Count);
                    }
                    Main.NewText(projsToRemove.Count);
                }
            }
            
        }
        private void SpawnMultiple()
        {
            for (int k = 0; spawned < max; k++)
            {
                spawned++;

                Projectile proj = Projectile.NewProjectileDirect(Projectile.GetSource_FromAI(),Projectile.Center + Main.rand.NextVector2Circular(400,50), Vector2.Zero, ModContent.ProjectileType<DungeonGenTest1>(), 0, 0, Main.LocalPlayer.whoAmI);

                if(proj != null && proj.active)
                    projs.Add((proj, proj.Size.X * proj.Size.Y));   
            }
        }
    }
    public class DungeonGenTest1 : ModProjectile
    {
        public override string Texture => AssetDirectory.Debug + "PHwand";
        public float radius;
        public Rectangle uniqueSpace;

        public override void SetDefaults()
        {
            Projectile.height = Main.rand.Next(15, 21) * 16;
            Projectile.width = Main.rand.Next(30, 41) * 16;

            Projectile.aiStyle = -1;
            Projectile.timeLeft = int.MaxValue;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
        }
        
        public override void OnSpawn(IEntitySource source)
        {
            Projectile.velocity = new Vector2(Main.rand.NextFloat(-2,2),Main.rand.NextFloat(-2,2));
            radius = Hypotenuse(Projectile.Hitbox);

            uniqueSpace = new((int)(Projectile.position.X + radius), (int)(Projectile.position.Y + (int)radius), Projectile.width + (int)radius, Projectile.height + (int)radius);
        }

        public override void AI()
        {
            SocialDistancing();
            Stop();
            ClearUp();
        }

        void Stop()
        {
            if (MathF.Abs(Projectile.velocity.X) <= 0.05f) Projectile.velocity.X = 0;
            if (MathF.Abs(Projectile.velocity.Y) <= 0.05f) Projectile.velocity.Y = 0;
        }
        /// <summary>
        /// clears the jittering rooms that wont stop even after the first sorting
        /// </summary>
        void ClearUp()
        {
            Projectile.ai[0]++;
            if (Projectile.ai[0] >= 10 * 60 && (MathF.Abs(Projectile.velocity.X) > 0 || MathF.Abs(Projectile.velocity.Y) > 0))
            {
                Projectile.Kill();
                // SET UP A CLEARUP COMPLETED MESSAGE
            }
        }
        /// <summary>
        /// Searches for other rooms and checks if they are in their "unique space" which uses their hypotenuse as a radius times 2 to check if
        /// other rooms are close, if they are inside that unique space, they get pushed back
        /// </summary>
        void SocialDistancing()
        {
            Projectile projToCheck;
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                projToCheck = Main.projectile[i];
                if (!projToCheck.active || i == Projectile.whoAmI || projToCheck.type != Projectile.type || projToCheck.position.Distance(Projectile.position) > radius * 2)
                    continue;
                Projectile.velocity += Vector2.Normalize(Projectile.Center - projToCheck.Center);
            }
                Projectile.velocity *= 0.8f;
        }
        private float Hypotenuse(Rectangle rect)
        {
            return MathF.Sqrt(rect.Width * rect.Width + rect.Height * rect.Height);
        }
    }
}*/