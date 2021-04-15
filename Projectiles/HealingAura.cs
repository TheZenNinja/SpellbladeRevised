using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Projectiles
{
    public class HealingAura : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Healing Aura");
		}

		public override void SetDefaults()
		{
			projectile.width = 448;
			projectile.height = 448;
			projectile.friendly = false;
			projectile.hostile = false;
			projectile.tileCollide = false;
		}
        public override void AI()
        {
			projectile.rotation += 0.025f;
			
			for (int i = 0; i < Main.maxPlayers; i++)
			{
				Player p = Main.player[i];
				if (p.active && !p.dead)
					if (Vector2.Distance(projectile.Center, p.Center) <= projectile.Size.X / 2 + 32)
						p.AddBuff(BuffID.RapidHealing, 60 * 5);
			}
        }
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (projectile.spriteDirection == -1)
				spriteEffects = SpriteEffects.FlipHorizontally;

			Texture2D texture = Main.projectileTexture[projectile.type];
			Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
			Vector2 origin = sourceRectangle.Size() / 2f;
			//origin.X = projectile.spriteDirection == 1 ? sourceRectangle.Width : 0;

			Color drawColor = projectile.GetAlpha(lightColor);
			Main.spriteBatch.Draw
			(
				texture,
				projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY),
				sourceRectangle,
				drawColor,
				projectile.rotation,
				origin,
				projectile.scale,
				spriteEffects,
				0f
			);

			return false;
		}
	}
}
