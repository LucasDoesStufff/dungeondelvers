﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.ID;

using static Terraria.ModLoader.ModContent;

namespace dungeondelvers.Core
{
	public class ParticleSystem
	{
		public enum AnchorOptions
		{
			Screen,
			World
		}

		public delegate void Update(Particle particle);

		public readonly List<Particle> Particles = new();
		private Texture2D Texture;
		private readonly Update UpdateDelegate;

		private readonly AnchorOptions Anchor;
		/// <summary>
		/// Creates a new particle layer with the given texture, new particle textures can be added with the AddParticle method. Warning! adding a new particle texture will only add the texture, current way of implementation doesn't let it change the behaviour of the new particle
		/// </summary>
		/// <param name="texture">This should include your mods name and the texture path, example: "ModName/Assets/Textures/Particle"</param>
		/// <param name="updateDelegate">The main update method for particle AI and behaviour</param>
		/// <param name="anchor">The anchor point of the particles. Making it world will make it inside the world, making it Screen makes it stay inside the screen</param>
		public ParticleSystem(string texture, Update updateDelegate, AnchorOptions anchor = AnchorOptions.Screen)
		{
			Texture = Request<Texture2D>(texture, ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
			UpdateDelegate = updateDelegate;
			Anchor = anchor;
		}

		public void DrawParticles(SpriteBatch spriteBatch)
		{
				for (int k = 0; k < Particles.Count; k++)
				{
					Particle particle = Particles[k];

					if (particle is null)
						continue;

					if (!Main.gameInactive)
						UpdateDelegate(particle);

					Vector2 pos = particle.Position;
					if (Anchor == AnchorOptions.World)
						pos -= Main.screenPosition;

					if (UsefulFunctions.OnScreen(pos))
						spriteBatch.Draw(Texture, pos, particle.Frame == new Rectangle() ? Texture.Bounds : particle.Frame, particle.Color * particle.Alpha, particle.Rotation, particle.Frame.Size() / 2, particle.Scale, 0, 0);
				}

				Particles.RemoveAll(n => n is null || n.Timer <= 0);
		}

		public void AddParticle(Particle particle)
		{
			if (!Main.gameInactive)
				Particles.Add(particle);
		}

		public void ClearParticles()
		{
			Particles.Clear();
		}

		public void SetTexture(Texture2D texture)
		{
			Texture = texture;
		}
	}

	public class Particle
	{
		internal Vector2 Position;
		internal Vector2 Velocity;
		internal Vector2 StoredPosition;
		internal float Rotation;
		internal float Scale;
		internal float Alpha;
		internal Color Color;
		internal int Timer;
		internal int Type;
		internal Rectangle Frame;

		public Particle(Vector2 position, Vector2 velocity, float rotation, float scale, Color color, int timer, Vector2 storedPosition, Rectangle frame = new Rectangle(), float alpha = 1, int type = 0)
		{
			Position = position;
			Velocity = velocity;
			Rotation = rotation;
			Scale = scale;
			Color = color;
			Timer = timer;
			StoredPosition = storedPosition;
			Frame = frame;
			Alpha = alpha;
			Type = type;
		}
	}
}