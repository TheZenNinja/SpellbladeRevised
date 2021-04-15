using Microsoft.Xna.Framework;
using SpellbladeRevised.Projectiles;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Items.Weapons.PreHardmode.Metal
{
    public class PlatinumBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(silver: 30);
        protected override int rarity => ItemRarityID.Green;

        protected override int primaryDmg => 12;
        protected override float primaryKnockback => 4.5f;
        protected override int primaryUseTime => 20;
        protected override int onHitManaRegen => ManaRegenT2;

        protected override int manaCost => 12;
        protected override int altUseTime => 10;
        protected override int castUseAnimationTime => 20;
        protected override int castReuseDelay => 32;
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2, 9);
        protected override int projectileID => ModContent.ProjectileType<CustomSkyFracture>();
        protected override int altDmg => 26;
        protected override float altKnockback => 3;
        protected override int projectileSpeed => 16;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Platinum Spellblade");
            Tooltip.SetDefault("Shoots a barrage of swords with <right>.");
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 mousePosition = Main.MouseWorld;

            Vector2 randPos = new Vector2(Main.rand.Next(-64, 64), Main.rand.Next(-64, 0));
            Vector2 pos = randPos + player.position;

            Vector2 velDir = Vector2.Normalize(mousePosition - pos);

            int id = Projectile.NewProjectile(pos, velDir * projectileSpeed, projectileID, damage, knockBack, Main.myPlayer);
            Main.projectile[id].tileCollide = true;
            return false;
        }
        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int width = 7 * 16;
            int height = 20 * 16;
            Vector2 mousePosition = Main.MouseWorld;

            for (int i = -2; i < 4; i++)
            {
                Vector2 pos = new Vector2((i) * width - width / 2, -height) + mousePosition;

                Vector2 velDir = Vector2.Normalize(mousePosition - pos);

                int id = Projectile.NewProjectile(pos, velDir * projectileSpeed, projectileID, projectileDamage, projectileKockback, Main.myPlayer);
                //Projectile proj = Main.projectile[id];
            }
            return false;
            //return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }*/
    }
}