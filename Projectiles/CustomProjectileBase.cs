using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Projectiles
{
    public abstract class CustomProjectileBase : ModProjectile
    {
        public abstract int size { get; }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(GetType().Name);
        }
        public int ManaRegen
        {
            get => SpellbladeRevised.RoundToInt(projectile.ai[0]);
            set => projectile.ai[0] = Utils.Clamp(SpellbladeRevised.RoundToInt(value), 0, int.MaxValue);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
                player.statMana += ManaRegen;
                if (player.whoAmI == Main.myPlayer && ManaRegen > 0)
                    player.ManaEffect(ManaRegen);
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}
