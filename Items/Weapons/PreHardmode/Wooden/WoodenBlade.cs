using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Items.Weapons.PreHardmode.Wooden
{
    public class WoodenBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(copper: 50);
		protected override int rarity => ItemRarityID.White;

        protected override int primaryDmg => 6;
        protected override float primaryKnockback => 3;
        protected override int primaryUseTime => 22;
        protected override int onHitManaRegen => ManaRegenT1;

        protected override int manaCost => 2;
        protected override int altUseTime => 26;
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2,8);
        protected override int projectileID => ProjectileID.Spark;
        protected override int altDmg => 10;
        protected override float altKnockback => 2;
        protected override int projectileSpeed => 6;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wooden Spellblade");
			Tooltip.SetDefault("Shoots sparks with <right>.");
		}

		public override void SetDefaults()
		{
			SetBasicCustomDefaults();
		}
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            base.OnHitNPC(player, target, damage, knockBack, crit);
            if (Main.rand.NextBool(3))
                target.AddBuff(BuffID.OnFire, Main.rand.Next(20, 40));
        }
	}
}
