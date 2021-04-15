using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpellbladeRevised.Buffs;
using SpellbladeRevised.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Items.Weapons.Hardmode.Metal
{
    public class PalladiumSpellblade : SpellbladeBase
    {
        protected override int primaryDmg => 35;
        protected override float primaryKnockback => 3;
        protected override int primaryUseTime => 25;
        protected override int onHitManaRegen => ManaRegenT4;

        protected override int manaCost => 40;
        protected override int castUseStyle => ItemUseStyleID.HoldingUp;
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2,113);
        protected override int altUseTime => 20;
        protected override int projectileID => ModContent.ProjectileType<PalladiumProjectile>();
        protected override int altDmg => 40;
        protected override float altKnockback => 5;
        protected override int projectileSpeed => 0;

        protected override int value => Item.sellPrice(gold:3);
        protected override int rarity => ItemRarityID.LightRed;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Palladium Spellblade");
            Tooltip.SetDefault("Defends the player with swords");
        }
        public override bool CanUseItem(Player player)
        {
            SpellbladePlayer sp = player.GetModPlayer<SpellbladePlayer>();
            SpellbladePlayer.SetItemAltUse(player, Main.myPlayer == player.whoAmI);

            if (sp.altWeaponFunc)
                OnRightClick(player);
            else
                OnLeftClick(player);

            //Main.NewText($"-Spellblade- Player: {Main.player[player.whoAmI].name} AltFunc = {sp.altWeaponFunc}");
            if (player.GetManaCost(item) > player.statMana )
                return false;
            if (sp.altWeaponFunc == false && player.HasBuff(ModContent.BuffType<SwordProtection>()))
                return false;

            return true;
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 48;
            item.height = 48;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(ModContent.BuffType<SwordProtection>(), 60 * 30);
            float angleBase = MathHelper.ToRadians(360) / 8;
            for (int i = 0; i < 8; i++)
            {
                Projectile.NewProjectile(player.position, Vector2.Zero, projectileID, altDmg, altKnockback, player.whoAmI, angleBase * i);
            }


            return false;
        }
    }
}
