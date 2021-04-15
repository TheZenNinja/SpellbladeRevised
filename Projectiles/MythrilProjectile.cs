using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Projectiles
{
    public class MythrilProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mythril Bolt");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.EmeraldBolt);
            aiType = ProjectileID.LostSoulFriendly;
            projectile.aiStyle = 51;
            //projectile.alpha = 0;
        }

        /*public override void AI()
        {
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].active && !Main.npc[i].dontTakeDamage && !Main.npc[i].friendly)
                {
                    Vector2 newMove = Main.npc[i].Center - projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < 16 * 1000)
                    {
                        Vector2 direction = Vector2.Normalize(newMove - projectile.position);

                        //projectile.velocity = direction * projectile.stepSpeed;
                    }
                }
            }
        }*/
    }
}
