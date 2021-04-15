using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Items.Weapons.PreHardmode.Metal
{
    public class IronBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(silver:5);
        protected override int rarity => ItemRarityID.Blue;
        protected override int primaryDmg => 8;
        protected override float primaryKnockback => 5;
        protected override int primaryUseTime => 20;
        protected override int onHitManaRegen => ManaRegenT2;

        protected override int manaCost => 10;
        protected override int altUseTime => 24;
        protected override int projectileID => ProjectileID.SapphireBolt;
        protected override int altDmg => 16;
        protected override float altKnockback => 3.5f;
        protected override int projectileSpeed => 10;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iron Spellblade");
            Tooltip.SetDefault("Shoots an enchanted sword with <right>.");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
    }
}
