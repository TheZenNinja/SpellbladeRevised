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
    public class DimSlash : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sword Projection");
		}

		public override void SetDefaults()
		{
			projectile.width = 64;
			projectile.height = 64;
			projectile.Center = new Vector2(32,32);
			projectile.scale = 2;
			projectile.friendly = false;
			projectile.hostile = false;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.alpha = 255;
			projectile.light = 0.75f;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.rotation = (float)Main.rand.NextDouble() * 360;
		}
		public override void AI()
		{
			projectile.ai[0]++;

			//if (projectile.ai[0] < 5)
			//	projectile.alpha -= 50;
			//else

			if (projectile.ai[0] > 10)
			{
				projectile.alpha += 10;
				projectile.friendly = true;
			}
			else if (projectile.ai[0] > 0)
				projectile.alpha = 0;

			if (projectile.ai[0] > 30)
				projectile.Kill();
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
