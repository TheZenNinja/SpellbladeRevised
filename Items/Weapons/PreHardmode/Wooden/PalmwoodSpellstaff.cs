using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using SpellbladeRevised.Projectiles;

namespace SpellbladeRevised.Items.Weapons.PreHardmode.Wooden
{
    public class PalmwoodSpellstaffProj : SpellstaffProjectileBase
    {
        public override void Kill(int timeLeft)
        {
            Player player = Main.player[projectile.owner];
            Vector2 dir = Vector2.Normalize(Main.MouseWorld - player.position);
            Projectile.NewProjectile(projectile.Center, dir * 10, ProjectileID.Typhoon, projectile.damage, 1, player.whoAmI);
        }
    }
    public class PalmwoodSpellspearProj : SpellspearProjectileBase
    {
        public override float extendSpeed => .8f;
        public override float retractSpeed => .4f;
        public override int size => 16;
        
    }
    public class PalmwoodSpellstaff : SpellstaffBase
    {
        protected override int value => Item.sellPrice(copper: 50);
		protected override int rarity => ItemRarityID.White;

        protected override int primaryDmg => 4;
        protected override float primaryKnockback => 4;
        protected override int primaryUseTime => 30;
        protected override int primaryUseDelay => 30;
        protected override int manaCost => 10;
        public override StaffAttackType primaryAttackType => StaffAttackType.spinOnce;

        protected override int altDmg => 10;
        protected override float altKnockback => 6;
        protected override int altUseTime => 30;
        public override StaffAttackType altAttackType => StaffAttackType.spear;

        protected override int onHitManaRegen => ManaRegen[0];

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Palmwood Oar");
		}
	}
}
