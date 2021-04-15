using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Projectiles
{
    public class RottedForkProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.magic = true;
			projectile.width = 16;
            projectile.height = 16;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.timeLeft = 60;
			projectile.penetrate = 1;
		}
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135);
        }
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (projectile.spriteDirection == -1)
				spriteEffects = SpriteEffects.FlipHorizontally;

			Texture2D texture = Main.projectileTexture[projectile.type];
			Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
			Vector2 origin = texture.Size()/2;// - Vector2.UnitX * 3;
			origin.X = projectile.spriteDirection == 1 ? sourceRectangle.Width / 2 : 0;

			Color drawColor = projectile.GetAlpha(lightColor);
			Main.spriteBatch.Draw
			(
				texture,
				projectile.Center - Main.screenPosition,
				sourceRectangle,
				drawColor,
				projectile.rotation,
				origin,
				projectile.scale,
				spriteEffects,
				0
			);
			return false;
		}
	}
}
