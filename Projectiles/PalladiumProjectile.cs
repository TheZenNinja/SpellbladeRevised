using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Projectiles
{
    public class PalladiumProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            projectile.magic = true;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.width = 48;
            projectile.height = 48;
            projectile.timeLeft = 60 * 30;
        }
        static float dist = 128;

        public override void AI()
        {
            Player p = Main.player[projectile.owner];

            Vector2 dir = new Vector2((float)Math.Sin(projectile.ai[0]), (float)Math.Cos(projectile.ai[0]));
            projectile.rotation = dir.ToRotation() + MathHelper.ToRadians(45);
            projectile.position = p.Center - projectile.Size/2 + dir * dist; 

            projectile.ai[0] -= 0.05f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Vector2 dir = Vector2.Normalize(target.position - Main.player[projectile.owner].position);
            if (target.knockBackResist > 0)
            target.velocity += dir * knockback;
            base.OnHitNPC(target, damage, 0, crit);
        }
    }
}
