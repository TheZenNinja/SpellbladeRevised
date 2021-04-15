using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Projectiles
{
    public class FriendlyLightning : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lightning Bolt");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.MartianTurretBolt);
			projectile.friendly = true;
			projectile.hostile = false;
			aiType = 14;
		}
		public override void AI()
		{
			projectile.ai[0]++;
			if (projectile.ai[0] >= 3)
				projectile.ai[0] = 0;

			if (projectile.ai[0] == 0)
			{
				projectile.ai[1]++;
				if (projectile.ai[1] >= 4)
					projectile.ai[1] = 0;
				projectile.frame = (int)projectile.ai[1];
			}

			projectile.rotation = projectile.velocity.ToRotation();
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (projectile.spriteDirection == -1)
				spriteEffects = SpriteEffects.FlipHorizontally;

			Texture2D texture = Main.projectileTexture[projectile.type];
			int frameHeight = Main.projectileTexture[projectile.type].Height / 4;
			int startY = frameHeight * projectile.frame;
			Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
			Vector2 origin = sourceRectangle.Size() / 2f;
			origin.X = projectile.spriteDirection == 1 ? sourceRectangle.Width : 0;

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
		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)	
		{
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (projectile.spriteDirection == -1)
				spriteEffects = SpriteEffects.FlipHorizontally;

			Texture2D texture = Main.projectileTexture[projectile.type];
			int frameHeight = Main.projectileTexture[projectile.type].Height / 4;
			int startY = frameHeight * projectile.frame;
			Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
			Vector2 origin = sourceRectangle.Size() / 2f;
			origin.X = projectile.spriteDirection == 1 ? sourceRectangle.Width : 0;

			Main.spriteBatch.Draw
			(
				texture,
				projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY),
				sourceRectangle,
				Color.LightCyan,
				projectile.rotation,
				origin,
				projectile.scale,
				spriteEffects,
				0f
			);
			base.PostDraw(spriteBatch, lightColor);
		}
    }
}
