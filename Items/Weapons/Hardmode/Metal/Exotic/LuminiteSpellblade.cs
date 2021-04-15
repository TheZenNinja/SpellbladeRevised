using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using SpellbladeRevised.Projectiles;

namespace SpellbladeRevised.Items.Weapons.Hardmode.Metal.Exotic
{
    public class LuminiteSpellblade : SpellbladeBase
    {
        protected override int value => Item.buyPrice(gold:25);
        protected override int rarity => ItemRarityID.Cyan;

        protected override int primaryDmg => 110;
        protected override float primaryKnockback => 6;
        protected override int primaryUseTime => 14;

        protected override int onHitManaRegen => ManaRegenT8;
        protected override int manaCost => 5;
        protected override int altUseTime => 4;

        protected override int projectileID => ModContent.ProjectileType<LuminiteDagger>();
        protected override int altDmg => 80;
        protected override float altKnockback => 2;
        protected override int projectileSpeed => 20;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Luminite Spellblade");
            Tooltip.SetDefault("Unleash a barrage of lunar knives");
        }
        public override void OnRightClick(Player player)
        {
            base.OnRightClick(player);
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 32;
            item.height = 32;
            item.scale = 2;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int vertOffset = Main.rand.Next(-48, 48);

            Vector2 dir = Vector2.Normalize(Main.MouseWorld - player.position);

            position = player.itemLocation + new Vector2(0,vertOffset).RotatedBy(dir.ToRotation());

            Vector2 speed = dir * projectileSpeed;
            speed = speed.RotatedByRandom(MathHelper.ToRadians(projectileSpread));

            speedX = speed.X;
            speedY = speed.Y;

            damage = altDmg;

            Projectile.NewProjectile(position, speed, projectileID, altDmg, altKnockback, player.whoAmI);

            return false;
        }
    }
}
