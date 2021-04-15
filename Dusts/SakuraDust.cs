using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Dusts
{
	public class SakuraDust : ModDust
	{

		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.frame = new Rectangle(0, 0, 8, 8);
			//If our texture had 2 different dust on top of each other (a 30x60 pixel image), we might do this:
			//dust.frame = new Rectangle(0, Main.rand.Next(2) * 30, 30, 30);
		}
		int timer = 0;
		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			timer++;
			if (Math.Abs(dust.velocity.X) > 0.1f)
				dust.velocity *= 0.99f;

			if (timer > 300)
				dust.scale -= 0.01f;
			if (dust.scale < 0.5f)
				dust.active = false;
			/*else
			{
				dust.scale -= 0.01f;
				if (dust.scale < 0.5f)
				{
					dust.active = false;
				}
			}*/
			if (dust.velocity.Y < 0.25f)
				dust.velocity.Y += 0.01f;

			return false;
		}
	}
}
