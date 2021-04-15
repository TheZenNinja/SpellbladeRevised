using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpellbladeRevised.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Items.Weapons.Hardmode.Metal
{
    public class CobaltSpellblade : SpellbladeBase
    {
        protected override int additiveCritChance => 4;
        protected override int primaryDmg => 35;
        protected override float primaryKnockback => 3;
        protected override int primaryUseTime => 20;
        protected override int onHitManaRegen => ManaRegenT4;

        protected override int manaCost => 20;
        protected override int castUseStyle => ItemUseStyleID.SwingThrow;
        protected override int altUseTime => 35;
        protected override int projectileID => ModContent.ProjectileType<CobaltProjectile>();
        protected override int altDmg => 70;
        protected override float altKnockback => 5;
        protected override int projectileSpeed => 25;

        protected override int value => Item.sellPrice(gold:3);
        protected override int rarity => ItemRarityID.LightRed;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cobalt Spellblade");
            Tooltip.SetDefault("Throws the sword with <right>.");
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 48;
            item.height = 48;
        }
        public override void OnLeftClick(Player player)
        {
            base.OnLeftClick(player);
            item.alpha = 255;
        }
        public override void OnRightClick(Player player)
        {
            base.OnRightClick(player);
            item.alpha = 0;
        }
        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Main.spriteBatch.Draw
            (
                Main.itemTexture[item.type],
                position,
                frame,
                Color.White,
                0,
                origin,
                scale,
                SpriteEffects.None,
                0
            );
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 dir = Vector2.Normalize(Main.MouseWorld - player.position);
            Projectile.NewProjectile(player.position, dir * projectileSpeed, projectileID, altDmg, altKnockback, player.whoAmI);
            return false;
        }
    }
}
