using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace SpellbladeRevised.Projectiles
{
    public class MegaSword : ModProjectile
	{
		Player p;
		int dir;
		Vector2 hitboxOffset;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sword Projection");
		}

		public override void SetDefaults()
		{
			projectile.width = 180;               
			projectile.height = 320;
			projectile.scale = 1.5f;
			hitboxOffset = new Vector2(projectile.width/2, 0);
			projectile.friendly = true;        
			projectile.hostile = false;        
			projectile.magic = true;
			projectile.penetrate = -1;     
			projectile.timeLeft = 600;     
			projectile.alpha = 55;         
			projectile.light = 0.55f;      
			projectile.ignoreWater = true; 
			projectile.tileCollide = false;
		}
		public override void AI()
		{
			if (Main.myPlayer == projectile.owner)
			{
				projectile.netUpdate = true;
			}
				if (projectile.timeLeft <= 10)
				projectile.ai[0] += MathHelper.ToRadians(2f) * dir;
				else if (projectile.timeLeft <= 40)
				projectile.ai[0] += MathHelper.ToRadians(6f) * dir;
				else if (projectile.timeLeft <= 45)
				projectile.ai[0] += MathHelper.ToRadians(2f) * dir;

				Player player = Main.player[projectile.owner];
				projectile.Center = player.MountedCenter + hitboxOffset * dir;
				projectile.position.X += player.width / 2 * dir;
				projectile.spriteDirection = dir;
				projectile.rotation = projectile.ai[0];
			//int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire);  //this is the dust that this projectile will spawn
			//Main.dust[dust].velocity /= 1f;
		}

		public void SetData(Player player, int lifetime)
		{
			p = player;
			dir = p.direction;
			projectile.ai[0] = dir == -1 ? MathHelper.ToRadians(0) : MathHelper.ToRadians(180); // MathHelper.ToRadians(-60) : MathHelper.ToRadians(-120);
			projectile.timeLeft = lifetime + 15;
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = Main.projectileTexture[projectile.type];
			Rectangle rect = new Rectangle(0, 0, (int)(texture.Width), (int)(texture.Height));
			spriteBatch.Draw(
				texture, 
				projectile.Center - hitboxOffset * dir - Main.screenPosition, 
				rect,
				new Color(255, 55, 55), 
				projectile.rotation, 
				new Vector2(-32, texture.Height / 2), 
				projectile.scale, 
				SpriteEffects.None,
				0f
			);
			return false;
		}
		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = Main.projectileTexture[projectile.type];
			Rectangle rect = new Rectangle(0, 0, (int)(texture.Width), (int)(texture.Height));
			spriteBatch.Draw(
				texture, 
				projectile.Center - hitboxOffset * dir - Main.screenPosition, 
				rect,
				new Color(255, 55, 55), 
				projectile.rotation, 
				new Vector2(-32, texture.Height / 2), 
				projectile.scale, 
				SpriteEffects.None,
				0f
			);
			base.PostDraw(spriteBatch, lightColor);
		}
		/*public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
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
		}*/




	}
}