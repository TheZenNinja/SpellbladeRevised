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
	public class SakuraPetal : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sakura Petal");     //The English name of the projectile
		}
		//fix rotation using custom ai?
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;        
			projectile.hostile = false;        
			projectile.magic = true;
			projectile.penetrate = -1;     
			projectile.timeLeft = 300;      
			projectile.alpha = 0;
			projectile.aiStyle = 0;
		}
		public override void AI()
		{
			if (projectile.ai[1] > 30 + projectile.ai[0])
			{
				if (projectile.velocity.LengthSquared() > 0.25f)
					projectile.velocity *= 0.95f;
				projectile.rotation += MathHelper.ToRadians(Main.rand.NextBool() ? -1 : 1);
				projectile.velocity.Y += 0.075f;
				projectile.alpha += 1;
				if (projectile.alpha == 255)
					projectile.Kill();
			}
			else
			{
				projectile.ai[1]++;
				projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(45);
			}
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
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			projectile.velocity *= 0.95f;
            return false;
		}
    }
}