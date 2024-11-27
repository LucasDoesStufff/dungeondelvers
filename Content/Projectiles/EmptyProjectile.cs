using System;
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

namespace dungeondelvers.Content.Projectiles
{
    public class EmptyProjectile : ModProjectile
    {
        public override string Texture => AssetDirectory.Debug + "PHwand";
        
        public override void SetDefaults()
        {
            Projectile.height = 7*16;
            Projectile.width = 16*16;

            Projectile.aiStyle = -1;
            Projectile.timeLeft = int.MaxValue;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
        }
    }
}