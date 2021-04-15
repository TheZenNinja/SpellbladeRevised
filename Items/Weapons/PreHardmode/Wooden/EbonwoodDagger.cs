using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using SpellbladeRevised.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using SpellbladeRevised.Buffs;
using SpellbladeRevised.Minions;

namespace SpellbladeRevised.Items.Weapons.PreHardmode.Wooden
{
    public class EbonwoodBuff : DaggerBuffBase { }
    public class EbonwoodMinion : SpelldaggerMinionBase { }
    public class EbonwoodProjectile : SpelldaggerProjectileBase
    {
        private int killTime = 600 - 30;
        private float angle = 10;
        public override void PostAI()
        {
            if (projectile.timeLeft == killTime)
            {
                Vector2 vel1 = projectile.velocity.RotatedBy(MathHelper.ToRadians(angle));
                var p1 = Projectile.NewProjectileDirect(projectile.position, vel1, ModContent.ProjectileType<EbonwoodProjectile>(), projectile.damage, projectile.knockBack, projectile.owner, SpellbladeRevised.RoundToIntClamped((float)ManaRegen/2));
                p1.timeLeft = killTime-1;
                Vector2 vel2 = projectile.velocity.RotatedBy(MathHelper.ToRadians(-angle));
                var p2 = Projectile.NewProjectileDirect(projectile.position, vel2, ModContent.ProjectileType<EbonwoodProjectile>(), projectile.damage, projectile.knockBack, projectile.owner, SpellbladeRevised.RoundToIntClamped((float)ManaRegen/2));
                p2.timeLeft = killTime - 1;

                projectile.Kill();
            }
        }
    }
    public class EbonwoodDagger : SpelldaggerBase
    {
        protected override int value => Item.sellPrice(copper: 50);
		protected override int rarity => ItemRarityID.White;

        protected override int primaryDmg => 8;
        protected override float primaryKnockback => 4;
        protected override int primaryUseTime => 20;
        protected override int onHitManaRegen => ManaRegen[0];

        protected override int manaCost => 10;
        protected override int altUseTime => 26;
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2,65);
        protected override int altDmg => 12;
        protected override float altKnockback => 6;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ebonwood Spellblade");
			Tooltip.SetDefault("Shoots a Corrupt glob with <right>.");
		}

		public override void SetDefaults()
		{
			SetBasicCustomDefaults();
		}
	}
}
