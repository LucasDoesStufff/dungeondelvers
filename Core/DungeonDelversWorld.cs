using Terraria;
using Terraria.ModLoader;
using System;
using dungeondelvers.Core;
using dungeondelvers.Core.Systems.ForegroundSystem;

namespace dungeondelvers.Core
{
    public class dungeondelversWorld : ModSystem
    {
        public static float visualTimer;
        public static float timer;

        public override void PreUpdateWorld()
		{
			visualTimer += (float)Math.PI / 60;

			if (visualTimer >= Math.PI * 2)
				visualTimer = 0;

            

		}
    }
}