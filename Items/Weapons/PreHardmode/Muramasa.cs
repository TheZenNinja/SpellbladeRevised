using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using SpellbladeRevised.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Items.Weapons.PreHardmode
{
    public class Muramasa : SpellbladeBase
    {
        protected override int value => Item.sellPrice(gold: 2);
        protected override int rarity => ItemRarityID.Orange;
        protected override int primaryDmg => 24;
        protected override float primaryKnockback => 4;
        protected override int primaryUseTime => 16;
        protected override int onHitManaRegen => SpellbladeBase.ManaRegenT3/2;

        protected override int manaCost => 24;
        protected override int altUseTime => 40;
        protected override int projectileID => ModContent.ProjectileType<Vortex>();
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2, 92);
        protected override int altDmg => 12;
        protected override float altKnockback => 8;
        protected override int projectileSpeed => 10;

        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Suijin");
            Tooltip.SetDefault("Shoots a water vortex");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 48;
            item.height = 48;
        }
    }
}
