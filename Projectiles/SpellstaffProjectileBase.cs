using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Projectiles
{
    public abstract class SpellstaffProjectileBase : CustomProjectileBase
    {
		public virtual float scale { get; } = 2.4f;
		public virtual float spearRotationOffset { get; } = 135;
        public override int size => 48;
        public int type // Change this value to alter how fast the spear moves
		{
			get => SpellbladeRevised.RoundToInt(projectile.ai[1]);
			set => projectile.ai[1] = Utils.Clamp(value, 0, float.MaxValue);
		}
		public float init // Change this value to alter how fast the spear moves
        {
            get => projectile.ai[2];
            set => projectile.ai[2] = Utils.Clamp(value,0,float.MaxValue);
        }
        public override void SetDefaults()
        {
			projectile.aiStyle = 0;
			projectile.width = size;
            projectile.height = size;
			projectile.scale = scale;
            projectile.penetrate = -1;
            projectile.timeLeft = 30;

            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
			projectile.melee = true;
            projectile.magic = true;
		}
		public override bool CanDamage() => true;
        public override void AI()
		{
			Player player = Main.player[projectile.owner];
			if (projectile.ai[1] == 0)
			if (type == 0)
				SpinOnceAI(player);
			else if (type == 1)
				SpinHoldAI(player);
		}
		public void SpinOnceAI(Player player)
		{
			if (player.itemAnimation == 0)
			{
				projectile.Kill();
				return;
			}

			projectile.direction = player.direction;
			player.heldProj = projectile.whoAmI;
			

			projectile.position.X += (player.width / 2 - 8) * player.direction;  //this is the projectile width sptrite direction from the player
			projectile.spriteDirection = player.direction;
			projectile.Center = player.MountedCenter;

			if (!player.frozen)
			{
				projectile.timeLeft = player.itemAnimationMax;
				projectile.netUpdate = true;
				//if (movementFactor == 0f) // When initially thrown out, the ai0 will be 0f
				//{
				//	projectile.aiStyle = 0;
				//	projectile.width = width;
				//	projectile.height = height;
				//	movementFactor = 1f;
				//	projectile.timeLeft = player.itemAnimationMax;
				//	projectile.netUpdate = true; // Make sure to netUpdate this spear
				//}
				float percent = (float)player.itemAnimation / player.itemAnimationMax;
				projectile.rotation = percent * MathHelper.TwoPi * -player.direction;
			}
		}
		public void SpinHoldAI(Player player)
		{
			if (Main.myPlayer == projectile.owner)
				if (!player.channel || player.noItems || player.CCed)
				{
					projectile.Kill();
					return;
				}

			projectile.direction = player.direction;
			projectile.Center = player.MountedCenter;

			projectile.position.X += (player.width / 2-8) * player.direction;  //this is the projectile width sptrite direction from the player
			projectile.spriteDirection = player.direction;

			projectile.rotation += 0.3f * player.direction; //this is the projectile rotation/spinning speed
			if (projectile.rotation > MathHelper.TwoPi)
				projectile.rotation -= MathHelper.TwoPi;
			else if (projectile.rotation < 0)
				projectile.rotation += MathHelper.TwoPi;

			player.heldProj = projectile.whoAmI;

			player.itemTime = 2;
			player.itemAnimation = 2;
			projectile.timeLeft = 2;
			//player.itemRotation = projectile.rotation;
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
		{
			Texture2D texture = Main.projectileTexture[projectile.type];
			spriteBatch.Draw(
				texture,
				projectile.Center - Main.screenPosition,
				null,
				Color.White,
				projectile.rotation,
				new Vector2(texture.Width / 2, texture.Height / 2),
				projectile.scale, 
				projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally,
				0f
			);
			return false;
		}
	}
}
