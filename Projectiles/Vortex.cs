using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Projectiles
{
	public class Vortex : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Water Vortex");     //The English name of the projectile
		}
		//fix rotation using custom ai?
		public override void SetDefaults()
		{
			//projectile.CloneDefaults(ProjectileID.VortexVortexPortal);
			projectile.scale = 1.2f;
			projectile.width = 60;
			projectile.height = 60;
			projectile.friendly = true;        
			projectile.hostile = false;        
			projectile.magic = true;
			projectile.penetrate = -1;     
			projectile.timeLeft = 300;      
			projectile.light = 0.5f;
			projectile.alpha = 255;
			projectile.ignoreWater = true;     
			projectile.tileCollide = false;
			projectile.aiStyle = 0;
			projectile.light = 0.25f;
		}
        public override void AI()
        {
			if (projectile.alpha > 0)
				projectile.alpha -= 10;
			projectile.rotation += MathHelper.ToRadians(1f);
			if (projectile.ai[0] > 30)
			{
				if (projectile.velocity.LengthSquared() > 0.25f)
					projectile.velocity *= 0.95f;
			}
			else
				projectile.ai[0]++;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			if (target.boss == false && target.knockBackResist != 0)
			{
				if (projectile.velocity.LengthSquared() > 4f)
					target.velocity = SpellbladeRevised.ClampMagnitude(projectile.velocity, 1) * knockback;
				else
					target.velocity = SpellbladeRevised.ClampMagnitude(projectile.position - target.position, 1) * knockback/2;
			}
			base.OnHitNPC(target, damage, 0, crit);
        }
    }
}