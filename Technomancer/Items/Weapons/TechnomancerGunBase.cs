using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Technomancer.Items.Weapons
{
    public abstract class TechnomancerGunBase : ModItem
    {
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(mod, "Face", TechnomancerPlayer.classTitleText)
            {
                overrideColor = TechnomancerPlayer.classTextColor
            };
            tooltips.Insert(1, line);
        }
        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.HoldingOut;

            item.summon = true;
            item.melee = false;
            item.ranged = false;
            item.thrown = false;
            item.magic = false;

            item.autoReuse = true;
            item.noMelee = true;
        }
        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
        {
            var p = player.GetModPlayer<TechnomancerPlayer>();
            base.ModifyWeaponDamage(player, ref add, ref mult, ref flat);
            mult += .1f * (player.maxMinions - p.getMinionCount());
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            var tp = player.GetModPlayer<TechnomancerPlayer>();
            tp.TryToGainStacks();
        }
        public override void GetWeaponCrit(Player player, ref int crit)
        {
            base.GetWeaponCrit(player, ref crit);
            crit += player.magicCrit;
        }
    }
}
