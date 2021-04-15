using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Items.Weapons.Hardmode
{
    public class PearlwoodBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(gold: 1);
        protected override int rarity => ItemRarityID.LightRed;

        protected override int primaryDmg => 30;
        protected override float primaryKnockback => 4;
        protected override int primaryUseTime => 24;
        protected override int onHitManaRegen => ManaRegenT2;

        protected override int manaCost => 8;
        protected override int altUseTime => 4;
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2, 9);
        protected override int projectileID => ProjectileID.CrystalStorm;
        protected override int altDmg => 24;
        protected override float altKnockback => 4;
        protected override int projectileSpeed => 18;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pearlwood Spellblade");
            Tooltip.SetDefault("Holy wood overrun by crystals");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }

    }
}
