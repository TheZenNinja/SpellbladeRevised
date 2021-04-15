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
    public class OrichalcumSpellblade : SpellbladeBase
    {
        protected override int primaryDmg => 45;
        protected override float primaryKnockback => 4;
        protected override int primaryUseTime => 24;
        protected override int onHitManaRegen => ManaRegenT4;

        protected override int manaCost => 10;
        protected override int altUseTime => 14;
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2,64);
        protected override int projectileID => ModContent.ProjectileType<SakuraPetal>();
        protected override int altDmg => 20;
        protected override float altKnockback => 5;
        protected override int projectileSpeed => 10;
        protected override int value => Item.sellPrice(gold:5);
        protected override int rarity => ItemRarityID.LightRed;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orichalcum Spellblade");
            Tooltip.SetDefault("Shoots a barrage of petals");
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 48;
            item.height = 48;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            // Fix the speedX and Y to point them horizontally.
            speedX = new Vector2(speedX, speedY).Length() * (speedX > 0 ? 1 : -1);
            speedY = 0;

            // Add random Rotation
            Vector2 speed = new Vector2(speedX, speedY);
            speed = speed.RotatedBy(player.itemRotation);
            speed = speed.RotatedByRandom(MathHelper.ToRadians(projectileSpread));

            Projectile.NewProjectile(position, speed, projectileID, altDmg, altKnockback, player.whoAmI, Main.rand.Next(-5, 5));

            return false;
        }
    }
}
