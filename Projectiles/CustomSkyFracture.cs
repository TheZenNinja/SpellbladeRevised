using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Projectiles
{
	public class CustomSkyFracture : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sky Fracture Clone");
		}

		public override void SetDefaults()
		{
			//projectile.CloneDefaults(ProjectileID.SkyFracture);
			projectile.width = 8;
			projectile.height = 8;
			projectile.magic = true;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.light = 0.75f;
			projectile.penetrate = 1;
			projectile.timeLeft = 300;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			aiType = 14;
			projectile.light = 0.25f;
			projectile.gfxOffY = 16;
			projectile.frame = Main.rand.Next(14);
			projectile.scale = 1.25f;
		}

		public Color GetColor()
		{
			return new Color(150, 255, 255, 155);
		}

		public override void AI()
		{
            switch (projectile.ai[0])
            {
				case 1:
					projectile.tileCollide = false;
					break;
            }

            if (projectile.ai[1] == 0f)
			{
				projectile.ai[1] = 1f;
				Main.PlaySound(SoundID.Item9, projectile.Center);
				//alpha = 0;
				//scale = 1.1f;
				projectile.frame = Main.rand.Next(14);
				float num101 = 16f;
				for (int num102 = 0; (float)num102 < num101; num102++)
				{
					Vector2 spinningpoint5 = Vector2.UnitX * 0f;
					spinningpoint5 += -Vector2.UnitY.RotatedBy((float)num102 * ((float)Math.PI * 2f / num101)) * new Vector2(1f, 4f);
					spinningpoint5 = spinningpoint5.RotatedBy(projectile.velocity.ToRotation());
					int num103 = Dust.NewDust(projectile.Center, 0, 0, /*180*/261, newColor: GetColor());
					Main.dust[num103].scale = 1.5f;
					Main.dust[num103].noGravity = true;
					Main.dust[num103].position = projectile.Center + spinningpoint5;
					Main.dust[num103].velocity = spinningpoint5.SafeNormalize(Vector2.UnitY) * 1f;
				}
			}

			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(45);
		}
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (projectile.spriteDirection == -1)
				spriteEffects = SpriteEffects.FlipHorizontally;

			Texture2D texture = Main.projectileTexture[projectile.type];
			int frameWidth = Main.projectileTexture[projectile.type].Width / 14;
			int startX = frameWidth * projectile.frame;
			Rectangle sourceRectangle = new Rectangle(startX, 0, frameWidth, texture.Height);
			Vector2 origin = sourceRectangle.Size() / 2;
			origin.X = projectile.spriteDirection == 1 ? sourceRectangle.Width / 2 : 0;

			Color baseColor = GetColor();

			Main.spriteBatch.Draw
			(
				texture,
				projectile.Center - Main.screenPosition,
				sourceRectangle,
				GetColor(),
				projectile.rotation,
				origin,
				projectile.scale,
				spriteEffects,
				0
			);

			Main.spriteBatch.Draw
			(
				texture,
				projectile.Center - Main.screenPosition,
				sourceRectangle,
				new Color(baseColor.R, baseColor.G, baseColor.G, 200),
				projectile.rotation,
				origin - new Vector2(-1, 1) * Vector2.Distance(projectile.position, -projectile.oldPosition) * 1.25f,//MathHelper.Clamp(Vector2.Distance(projectile.position, projectile.oldPos[0]), 1, 8),
				projectile.scale * 1.1f,
				spriteEffects,
				0
			);
			/*Main.spriteBatch.Draw
			(
				texture,
				projectile.Center - Main.screenPosition,
				sourceRectangle,
				new Color(baseColor.R, baseColor.G, baseColor.G, 55),
				projectile.rotation,
				origin - new Vector2(-1, 1) * MathHelper.Clamp(Vector2.Distance(projectile.oldPos[0], projectile.oldPos[1]), 1, 8),
				projectile.scale * 1.25f,
				spriteEffects,
				0
			);*/

			return false;
		}
		/*public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (projectile.spriteDirection == -1)
				spriteEffects = SpriteEffects.FlipHorizontally;

			Texture2D texture = Main.projectileTexture[projectile.type];
			int frameWidth = Main.projectileTexture[projectile.type].Width / 14;
			int startX = frameWidth * projectile.frame;
			Rectangle sourceRectangle = new Rectangle(startX, 0, frameWidth, texture.Height);
			Vector2 origin = sourceRectangle.Size() / 2;
			origin.X = projectile.spriteDirection == 1 ? sourceRectangle.Width / 2 : 0;

			//Color drawColor = projectile.GetAlpha(lightColor);

			Main.spriteBatch.Draw
			(
				texture,
				projectile.Center - Main.screenPosition,// + sourceRectangle.Size() / 2 - projectile.Size/2,//new Vector2(32,0),
				sourceRectangle,
				GetColor(),
				projectile.rotation,
				origin,
				projectile.scale,
				spriteEffects,
				0f
			);
			base.PostDraw(spriteBatch, GetColor());
		}*/
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
			int num569 = Main.rand.Next(4, 10);
			for (int num570 = 0; num570 < num569; num570++)
			{
				int num571 = Dust.NewDust(projectile.Center, 0, 0, 180, 0f, 0f, 100);
				Dust dust171 = Main.dust[num571];
				Dust dust2 = dust171;
				dust2.velocity *= 1.6f;
				Main.dust[num571].velocity.Y -= 1f;
				dust171 = Main.dust[num571];
				dust2 = dust171;
				dust2.velocity += -projectile.velocity * (Main.rand.NextFloat() * 2f - 1f) * 0.5f;
				Main.dust[num571].scale = 2f;
				Main.dust[num571].fadeIn = 0.5f;
				Main.dust[num571].noGravity = true;
			}

			return base.OnTileCollide(oldVelocity);
		}
	}
}
