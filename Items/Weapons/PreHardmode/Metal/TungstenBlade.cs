using Microsoft.Xna.Framework;
using SpellbladeRevised.Projectiles;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Items.Weapons.PreHardmode.Metal
{
    class TungstenBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(silver: 25);
        protected override int rarity => ItemRarityID.Blue;

        protected override int primaryDmg => 10;
        protected override float primaryKnockback => 4.5f;
        protected override int primaryUseTime => 24;
        protected override int onHitManaRegen => ManaRegenT2;

        protected override int manaCost => 40;
        protected override int altUseTime => 20;
        protected override int projectileID => ProjectileID.EnchantedBeam;
        protected override int altDmg => 20;
        protected override float altKnockback => 6;
        protected override int projectileSpeed => 12;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tungsten Spellblade");
            Tooltip.SetDefault("Shoots a mana bolt with <right>.");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
    }
}