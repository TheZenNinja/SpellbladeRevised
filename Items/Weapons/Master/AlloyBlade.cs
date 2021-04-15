using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using SpellbladeRevised.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Items.Weapons.Master
{
    public class AlloyBlade : SpellbladeBase
    {
        protected override int value => Item.buyPrice(copper: 50);
		protected override int rarity => ItemRarityID.White;

        protected override int primaryDmg => 40;
        protected override float primaryKnockback => 3;
        protected override int primaryUseTime => 22;
        protected override int onHitManaRegen => ManaRegenT6;

        public override bool hasWeaponArt => true;
        protected override LegacySoundStyle weaponArtSound => new LegacySoundStyle(2, 117);
        public override int arcaneCost => 3;

        protected override int manaCost => 2;
        protected override int altUseTime => 26;
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2,8);
        protected override int projectileID => ModContent.ProjectileType<CustomSkyFracture>();
        protected override int altDmg => 30;
        protected override float altKnockback => 2;
        protected override int projectileSpeed => 24;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alloy Soul");
			Tooltip.SetDefault("The essence of the underground power this weapon");
		}

		public override void SetDefaults()
		{
			SetBasicCustomDefaults();
            item.width = 64;
            item.height = 64;
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

        public override void WeaponArt(Player player)
        {
            if (!hasWeaponArt)
                return;

            Vector2 pos;
            Vector2 mousePosition = Main.MouseWorld;
            Main.PlaySound(weaponArtSound, mousePosition);

            int orbitRadius = 10 * 16;
            int count = 8;
            float angleRate = 360 / count;
            for (int i = 0; i < count; i++)
            {
                MagicSwordProjectile projectile = new MagicSwordProjectile();

                float angle = MathHelper.ToRadians(i * angleRate);

                Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                pos.X = mousePosition.X + (direction.X * orbitRadius) - projectile.projectile.width / 2;
                pos.Y = mousePosition.Y + (direction.Y * orbitRadius) - projectile.projectile.height;

                Vector2 velDir = Vector2.Normalize(mousePosition - pos);

                int id = Projectile.NewProjectile(pos, velDir * 10, ModContent.ProjectileType<MagicSwordProjectile>(), 10, 2, Main.myPlayer);

                MagicSwordProjectile proj = Main.projectile[id].modProjectile as MagicSwordProjectile;
                proj.SetDelay(i * 10);
                proj.SetLifetime(60 + (i+1) * 15);
            }

        }
    }
}
