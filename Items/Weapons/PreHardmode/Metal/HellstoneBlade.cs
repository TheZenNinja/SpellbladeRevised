using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;

namespace SpellbladeRevised.Items.Weapons.PreHardmode.Metal
{
    public class HellstoneBlade : SpellbladeBase
    {
        protected override float scale => 1.1f;
        protected override int value => Item.sellPrice(silver: 75);
        protected override int rarity => ItemRarityID.Orange;
        protected override int primaryDmg => 35;
        protected override float primaryKnockback => 5;
        protected override int primaryUseTime => 24;
        protected override int onHitManaRegen => ManaRegenT3;

        protected override int manaCost => 24;
        protected override int altUseTime => 6;
        protected override int castUseAnimationTime => 30;
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2,34);
        protected override int projectileID => ProjectileID.Flames;
        protected override int altDmg => 15;
        protected override float altKnockback => 1;
        protected override int projectileSpeed => 6;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellstone Spellblade");
            Tooltip.SetDefault("Shoots fire with <right>.");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            base.OnHitNPC(player, target, damage, knockBack, crit);
                if (Main.rand.NextBool(2))
                    target.AddBuff(BuffID.OnFire, Main.rand.Next(60, 90));
        }
    }
}
