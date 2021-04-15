using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Projectiles
{
    public class MagicSwordProjectile : ModProjectile
    {
		protected Vector2 velDir;
		protected float speed;
		public int shootDelay;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sword Projection");     //The English name of the projectile
			//ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
			//ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
		}
		//fix rotation using custom ai?
		public override void SetDefaults()
		{
			projectile.width = 8;               //The width of projectile hitbox
			projectile.height = 8;              //The height of projectile hitbox
			projectile.friendly = true;         //Can the projectile deal damage to enemies?
			projectile.hostile = false;         //Can the projectile deal damage to the player?
			projectile.magic = true;           
			projectile.penetrate = 1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 60;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.alpha = 55;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
			projectile.light = 0.5f;            //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = false;          //Can the projectile collide with tiles?

		}
		public override void AI()
        {
			if (projectile.ai[0] == 0)
			{
				projectile.ai[0] = 1;
				velDir = Vector2.Normalize(projectile.velocity);
				projectile.velocity = Vector2.Zero;
				speed = 0;
			}
			projectile.rotation = velDir.ToRotation() + MathHelper.ToRadians(45);

			projectile.ai[1] += 1f;

			if (projectile.ai[1] >= 15 + shootDelay)
			{
				if (projectile.ai[1] == 15 + shootDelay)
					Main.PlaySound(new LegacySoundStyle(2,8), projectile.position);
				if (speed < 30)
					speed += 1;

				Dust dust = Main.dust[Dust.NewDust(projectile.Center, 31, 16, 15, -projectile.velocity.X, -projectile.velocity.Y, 0, Color.Lime, 1f)];
				dust.noGravity = true;

				projectile.velocity = velDir * speed;
			}
		}

		public void SetDelay(int delay) => shootDelay = delay;
		public void SetLifetime(int frames) => projectile.timeLeft = frames;

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (projectile.spriteDirection == -1)
				spriteEffects = SpriteEffects.FlipHorizontally;

			Texture2D texture = Main.projectileTexture[projectile.type];
			Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
			Vector2 origin = Vector2.Zero;
			origin.X = (projectile.spriteDirection == 1 ? sourceRectangle.Width - projectile.width/2 : projectile.width/2);
			origin.Y = projectile.height/2;

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
			Texture2D texture = mod.GetTexture("Projectiles/MagicSwordProjectile");

			Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
			Vector2 origin = Vector2.Zero;
			origin.X = (projectile.spriteDirection == 1 ? sourceRectangle.Width - projectile.width / 2 : projectile.width / 2);
			origin.Y = projectile.height / 2;

			spriteBatch.Draw
			(
				texture,
				projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY),
				sourceRectangle,
				Color.Lime,
				projectile.rotation,
				origin,
				projectile.scale,
				SpriteEffects.None,
				0f
			);
			base.PostDraw(spriteBatch, lightColor);
        }

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(new LegacySoundStyle(3, 3), projectile.position);
			Dust dust;
			// You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
			Vector2 position = projectile.Center;
			dust = Main.dust[Dust.NewDust(position, 31, 16, 15, projectile.velocity.X, projectile.velocity.Y, 0, Color.Lime, 1f)];
			dust.noGravity = true;
		}
	}
}
