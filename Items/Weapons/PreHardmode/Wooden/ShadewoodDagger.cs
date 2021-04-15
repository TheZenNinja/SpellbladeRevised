using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using SpellbladeRevised.Buffs;
using SpellbladeRevised.Minions;
using SpellbladeRevised.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Items.Weapons.PreHardmode.Wooden
{
    public class ShadewoodBuff : DaggerBuffBase { }
    public class ShadewoodMinion : SpelldaggerMinionBase { }
    public class ShadewoodProjectile : SpelldaggerProjectileBase
    {
        public override void PostAI()
        {
            if (projectile.timeLeft < 600 && projectile.timeLeft % 20 == 0)
            {
                Vector2 pos = projectile.Center + new Vector2(16 * MathHelper.Clamp(projectile.velocity.X, -1, 1), 16);
                Projectile.NewProjectile(pos, new Vector2(0, 4), ProjectileID.BloodRain, SpellbladeRevised.RoundToInt(projectile.damage / 4), 1, projectile.owner);
            }
        }
    }
    public class ShadewoodDagger : SpelldaggerBase
    {
        protected override int value => Item.sellPrice(copper: 50);
		protected override int rarity => ItemRarityID.White;

        protected override int primaryDmg => 8;
        protected override float primaryKnockback => 4;
        protected override int primaryUseTime => 20;
        public override float projPrimarySpeed => projectileSpeed[0];
        protected override int onHitManaRegen => ManaRegen[0];

        protected override int manaCost => 4;
        protected override int altUseTime => 16;
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2,21);
        protected override int altDmg => 8;
        protected override float altKnockback => 4;

        public override void SetStaticDefaults()
		{
            base.SetStaticDefaults();
			Tooltip.SetDefault("Showers enemies with blood");
		}
	}
}
