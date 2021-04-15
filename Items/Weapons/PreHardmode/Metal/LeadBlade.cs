using Microsoft.Xna.Framework;
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
    class LeadBlade : SpellbladeBase
    {
        protected override int value => Item.buyPrice(silver: 5);
        protected override int rarity => ItemRarityID.Blue;
        protected override int primaryDmg => 8;
        protected override float primaryKnockback => 5.5f;
        protected override int primaryUseTime => 20;
        protected override int onHitManaRegen => ManaRegenT2;

        protected override int manaCost => 10;
        protected override int altUseTime => 30;
        protected override int projectileID => ProjectileID.EmeraldBolt;
        protected override int altDmg => 14;
        protected override float altKnockback => 2f;
        protected override int projectileSpeed => 8;

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);
            TooltipLine extra = new TooltipLine(mod, "Tooltip0", "Poisons enemies")
            {
                overrideColor = Color.Lime
            };
            tooltips.Insert(8, extra);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lead Spellblade");
            Tooltip.SetDefault("Shoots an enchanted sword with <right>.");
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            //if (Main.rand.NextBool(4))
            target.AddBuff(BuffID.Poisoned, Main.rand.Next(30, 60));
            base.OnHitNPC(player, target, damage, knockBack, crit);
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
    }
}
