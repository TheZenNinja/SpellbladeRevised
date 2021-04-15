using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Projectiles
{
    public class CorruptBall : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corrupt Glob");
		}
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.DirtBall);
			//projectile.width = 14;               //The width of projectile hitbox
			//projectile.height = 14;              //The height of projectile hitbox
			projectile.aiStyle = 1;             //The ai style of the projectile, please reference the source code of Terraria
			projectile.friendly = true;         //Can the projectile deal damage to enemies?
			projectile.hostile = false;         //Can the projectile deal damage to the player?
			projectile.magic = true;           //Is the projectile shoot by a ranged weapon?
			projectile.penetrate = 1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 600;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.ignoreWater = false;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = true;          //Can the projectile collide with tiles?
			aiType = ProjectileID.DiamondBolt;
		}
        public override void AI()
        {
            base.AI();
			Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Dirt, 0f, 0f, 0, Color.White, 1f);
		}

		/*public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (projectile.spriteDirection == -1)
				spriteEffects = SpriteEffects.FlipHorizontally;

			Texture2D texture = Main.projectileTexture[projectile.type];
			Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
			Vector2 origin = Vector2.Zero;
			origin.X = (projectile.spriteDirection == 1 ? sourceRectangle.Width - projectile.width / 2 : projectile.width / 2);
			origin.Y = projectile.height / 2;

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
		}*/

		public override bool OnTileCollide(Vector2 oldVelocity)
		{

			return base.OnTileCollide(oldVelocity);
		}
	}
}
