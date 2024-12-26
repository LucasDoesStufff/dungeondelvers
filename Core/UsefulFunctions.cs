using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Vector2 = Microsoft.Xna.Framework.Vector2;


namespace dungeondelvers.Core
{
    internal static class UsefulFunctions
    {
        /// <summary>
        /// Handles the vanilla multiple projectile shot shuch as shotguns
        /// </summary>
        /// <param name="player"></param>
        /// <param name="source"></param>
        /// <param name="position"></param>
        /// <param name="velocity"></param>
        /// <param name="type"></param>
        /// <param name="damage"></param>
        /// <param name="knockback"></param>
        /// <param name="numberProjectiles"></param>
        /// <param name="rotationAmount"></param>
        /// <param name="randomSpread"></param>
        public static void MultipleShot(Player player, IEntitySource source, Vector2 position, Vector2 velocity, int type, int damage, float knockback, int numberProjectiles, float rotationAmount, bool randomSpread)
        {
            position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 45f;
            float rotation = MathHelper.ToRadians(rotationAmount);
            Vector2 perturbedSpeed;
            for (int i = 0; i < numberProjectiles; i++)
            {
                switch (randomSpread)
                {
                    case true:
                        perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .4f;
                        break;
                    case false:
                        perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .4f;
                        break;
                }
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
            }
        }
        /// <summary>
        /// Adds the dust ring effect from TSOTRC bosses
        /// </summary>
        /// <param name="center">Center of the ring</param>
        /// <param name="radius">Radius of the ring</param>
        /// <param name="dustID"></param>
        /// <param name="dustCount">Maximum amount of dust</param>
        /// <param name="dustSpeed">Dust rotation speed</param>
        public static void DustRing(Vector2 center, float radius, int dustID, int dustCount = 5, float dustSpeed = 2f)
        {
            for (int i = 0; i < dustCount; i++)
            {
                Vector2 dir = Utils.NextVector2CircularEdge(Main.rand, radius, radius);
                Vector2 val = center + dir;
                Vector2 dustVel = Utils.RotatedBy(new Vector2(dustSpeed, 0f), (double)(Utils.ToRotation(dir) + (float)Math.PI / 2f), default(Vector2));
                Dust.NewDustPerfect(val, dustID, (Vector2?)dustVel, 200, default(Color), 1f).noGravity = true;
            }
        }
        /// <summary>
        /// Checks if the player is standing on a solid block
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool IsGrounded(this Player player)
        {
            return player.velocity.Y >= 0f && Collision.SolidCollision(player.BottomLeft, 32, 8, true);
        }
        /// <summary>
        /// Checks if the given position is on the screen
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static bool OnScreen(Vector2 pos)
		{
			return pos.X > -16 && pos.X < Main.screenWidth + 16 && pos.Y > -16 && pos.Y < Main.screenHeight + 16;
		}

        /// <summary>
        /// For advanced collision checking EXPERIMENTAL
        /// </summary>
        /// <param name="targets"></param>
        /// <param name="mains"></param>
        /// <param name="maxRange"></param>
        /// <returns></returns>
        public static bool CheckMultipleRange(Vector2[] targets, Vector2[] mains, float maxRange)
        {
            return mains.All(p => targets.All(z => p.WithinRange(z,maxRange)));
        }
    }
}
