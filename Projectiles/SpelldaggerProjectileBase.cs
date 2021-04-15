using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Projectiles
{
    public abstract class SpelldaggerProjectileBase : CustomProjectileBase
	{
		public override string Texture => GetIDString();
		public string GetIDString()
		{
			Type t = GetType();
			string path = t.ToString();
			path = path.Replace(".", "/");
			path = path.Replace("Projectile", "Dagger");
			return path;
		}
		public override int size => 32;
        public virtual float scale { get; } = 1;
		public virtual float grav { get; } = 4;
		public virtual int hangTime { get; } = 20;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault(GetType().Name);
		}
        public override void SetDefaults()
        {
			aiType = 0;
			projectile.friendly = true;
			projectile.melee = false;
			projectile.magic = true;
			projectile.width = size;
			projectile.height = size;
			projectile.timeLeft = 600;
			projectile.scale = scale;
		}
        public override void AI()
        {
			projectile.ai[1] += 1;
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(45);
			if (grav != 0)
			{
				if (projectile.ai[1] > hangTime)
					projectile.velocity.Y += grav / 10;
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (projectile.spriteDirection == -1)
				spriteEffects = SpriteEffects.FlipHorizontally;

			Texture2D texture = Main.projectileTexture[projectile.type];
			Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
			Vector2 origin = sourceRectangle.Size() / 2;
			origin.X = projectile.spriteDirection == 1 ? (float)sourceRectangle.Width / 2 : 0;

			Main.spriteBatch.Draw
			(
				texture,
				projectile.Center - Main.screenPosition,
				sourceRectangle,
				lightColor,
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
