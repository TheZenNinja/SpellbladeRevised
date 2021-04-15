using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Projectiles
{
    public class LuminiteDagger : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Luminite Dagger");     //The English name of the projectile
		}
		public override void SetDefaults()
		{
			projectile.alpha = 0;
			projectile.width = 16;               //The width of projectile hitbox
			projectile.height = 16;              //The height of projectile hitbox
			projectile.friendly = true;         //Can the projectile deal damage to enemies?
			projectile.hostile = false;         //Can the projectile deal damage to the player?
			projectile.magic = true;           
			projectile.penetrate = -1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 60;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.scale = 1.5f;
		}
		public override void AI()
        {
			projectile.rotation = Vector2.Normalize(projectile.velocity).ToRotation() + MathHelper.ToRadians(45);
			projectile.velocity *= 0.99f;
		}

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

			//Color drawColor = projectile.GetAlpha(lightColor);
			Main.spriteBatch.Draw
			(
				texture,
				projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY),
				sourceRectangle,
				Color.GhostWhite,
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
