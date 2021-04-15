using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Items.Weapons.PreHardmode.Metal
{
    class TinBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(silver: 5);
        protected override int rarity => ItemRarityID.Blue;

        protected override int primaryDmg => 6;
        protected override float primaryKnockback => 4.5f;
        protected override int primaryUseTime => 24;
        protected override int onHitManaRegen => ManaRegenT2;

        protected override int manaCost => 12;
        protected override int altUseTime => 34;
        protected override int projectileID => ProjectileID.BallofFire;
        protected override int altDmg => 12;
        protected override float altKnockback => 2;
        protected override int projectileSpeed => 6;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tin Spellblade");
            Tooltip.SetDefault("Shoots a Fireball with <right>.");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
    }
}