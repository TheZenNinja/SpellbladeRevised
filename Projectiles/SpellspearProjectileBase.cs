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
    public abstract class SpellspearProjectileBase : CustomProjectileBase
	{
		public virtual float startingExtention { get; } = 4f;
		public virtual float extendSpeed { get; } = 2.5f;
		public virtual float retractSpeed { get; } = 1;
		public virtual float scale { get; } = 2.4f;
		public virtual float spearRotationOffset { get; } = 135;
		public override string Texture => GetTexture();
        protected string GetTexture()
		{
			Type t = GetType();
			string path = t.ToString();
			path = path.Replace(".", "/");
			path = path.Replace("spear", "staff");
			return path;
		}
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault(GetType().Name);
        }
		//public int type // Change this value to alter how fast the spear moves
		//{
		//	get => SpellbladeMod.RoundToInt(projectile.ai[1]);
		//	set => projectile.ai[1] = Utils.Clamp(value, 0, float.MaxValue);
		//}
		public float movementFactor // Change this value to alter how fast the spear moves
        {
            get => projectile.ai[1];
            set => projectile.ai[1] = Utils.Clamp(value,0,float.MaxValue);
        }
        public override void SetDefaults()
        {
			projectile.aiStyle = 19;
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
			// When we reach the end of the animation, we can kill the spear projectile
			if (player.itemAnimation == 1)
			{
				projectile.Kill();
				return;
			}

			// Here we set some of the projectile's owner properties, such as held item and itemtime, along with projectile direction and position based on the player
			Vector2 ownerMountedCenter = player.RotatedRelativePoint(player.MountedCenter, true);
			//projectile.direction = projOwner.direction;
			player.heldProj = projectile.whoAmI;
			player.itemTime = player.itemAnimation;
			projectile.position = ownerMountedCenter - projectile.Size / 2;

			// As long as the player isn't frozen, the spear can move
			if (!player.frozen)
			{
				if (movementFactor == 0f) // When initially thrown out, the ai0 will be 0f
				{
					movementFactor = startingExtention; // Make sure the spear moves forward when initially thrown out
					projectile.timeLeft = player.itemAnimationMax;
					projectile.netUpdate = true; // Make sure to netUpdate this spear
				}
				if (player.itemAnimation < player.itemAnimationMax * 2f / 3) // Somewhere along the item animation, make sure the spear moves back
				{
					movementFactor -= retractSpeed;
				}
				else // Otherwise, increase the movement factor
				{
					movementFactor += extendSpeed;
				}
			}
			// Change the spear position based off of the velocity and the movementFactor
			projectile.position += projectile.velocity * movementFactor;
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(spearRotationOffset);
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

			if (!player.channel || player.noItems || player.CCed)
			{
				projectile.Kill();
				return;
			}

			//if (movementFactor == 0f) // When initially thrown out, the ai0 will be 0f
			//{
			//	projectile.aiStyle = 0;
			//	movementFactor = 1f; // Make sure the spear moves forward when initially thrown out
			//	projectile.width = width;
			//	projectile.height = height;
			//	projectile.netUpdate = true; // Make sure to netUpdate this spear
			//}


			projectile.direction = player.direction;
			player.heldProj = projectile.whoAmI;

			
			player.itemTime = 2;
			player.itemAnimation = 2;
			projectile.timeLeft = 2;
			//player.itemRotation = projectile.rotation;
			projectile.Center = player.MountedCenter;

			projectile.position.X += (player.width / 2 - 8) * player.direction;  //this is the projectile width sptrite direction from the player
			projectile.spriteDirection = player.direction;

			projectile.rotation += 0.3f * player.direction; //this is the projectile rotation/spinning speed
			if (projectile.rotation > MathHelper.TwoPi)
				projectile.rotation -= MathHelper.TwoPi;
			else if (projectile.rotation < 0)
				projectile.rotation += MathHelper.TwoPi;
		}

    }
}
