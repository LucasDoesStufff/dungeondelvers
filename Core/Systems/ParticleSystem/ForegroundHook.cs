﻿using dungeondelvers.Content.CustomHooks;
using Microsoft.Xna.Framework;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System.Linq;
using System;
using System.IO;
using Terraria.ID;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

	/*
     *  Big thanks to starlight river for this!
     */

namespace dungeondelvers.Core.Systems.ForegroundSystem
{
	class ForegroundHook : HookGroup
	{
		//just drawing, nothing to see here.
		public override void Load()
		{
			if (Main.dedServ)
				return;

			On_Main.DrawInterface += DrawForeground;
			On_Main.DoUpdate += ResetForeground;
		}

		public void DrawForeground(On_Main.orig_DrawInterface orig, Main self, GameTime gameTime)
		{
			Main.spriteBatch.Begin(default, default, Main.DefaultSamplerState, default, default);//Main.spriteBatch.Begin()

			foreach (Foreground fg in ForegroundSystem.Foregrounds) //TODO: Perhaps create some sort of ActiveForeground list later? especially since we iterate twice for the over UI ones
			{
				if (fg != null && !fg.OverUI)
					fg.Render(Main.spriteBatch);
			}
			Main.spriteBatch.End();

			orig(self, gameTime);

			Main.spriteBatch.Begin(default, default, Main.DefaultSamplerState, default, default);

			foreach (Foreground fg in ForegroundSystem.Foregrounds)
			{
				if (fg != null && fg.OverUI)
					fg.Render(Main.spriteBatch);
			}

			Main.spriteBatch.End();
		}

		private void ResetForeground(On_Main.orig_DoUpdate orig, Main self, ref GameTime gameTime)
		{
			if (Main.gameMenu)
			{
				orig(self, ref gameTime);
				return;
			}

			foreach (Foreground fg in ForegroundSystem.Foregrounds)
			{
				fg?.Reset();
			}

			orig(self, ref gameTime);
		}
	}
}