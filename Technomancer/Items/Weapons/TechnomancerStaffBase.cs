using Microsoft.Xna.Framework;
using SpellbladeRevised.Technomancer.Buffs;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Technomancer.Items.Weapons
{
    public abstract class TechnomancerStaffBase : ModItem
    {
        public abstract int MinionProjectileID { get; }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(mod, "Face", TechnomancerPlayer.classTitleText)
            {
                overrideColor = TechnomancerPlayer.classTextColor
            };
            tooltips.Insert(1, line);
        }
        public override void SetStaticDefaults()
        {
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.noMelee = true;
            item.summon = true;

            item.useStyle = ItemUseStyleID.SwingThrow;

            item.shoot = MinionProjectileID;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.HasBuff(ModContent.BuffType<CanSpawnDroneBuff>()))
                return base.CanUseItem(player);
            else
                return false;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            damage = (int)MathHelper.Clamp(damage, 1, int.MaxValue);
            position = Main.MouseWorld;
            player.GetModPlayer<TechnomancerPlayer>().RemoveStacks();
            return true;
        }
    }
}
