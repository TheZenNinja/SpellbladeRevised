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
    public class CactusBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(copper: 50);
		protected override int rarity => ItemRarityID.White;

        protected override int primaryDmg => 8;
        protected override float primaryKnockback => 4;
        protected override int primaryUseTime => 20;
        protected override int onHitManaRegen => ManaRegenT1;

        protected override int manaCost => 3;
        protected override int altUseTime => 4;
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2,17);
        protected override int projectileID => ModContent.ProjectileType<CactusNeedle>();
        protected override int altDmg => 4;
        protected override float altKnockback => 1;
        protected override int projectileSpeed => 10;
        protected override int projectileSpread => 8;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cactus Spellblade");
			Tooltip.SetDefault("Shoots a needle with <right>.");
		}

		public override void SetDefaults()
		{
			SetBasicCustomDefaults();
		}
	}
}
