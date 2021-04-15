using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using SpellbladeRevised.Items.Weapons.PreHardmode;
using SpellbladeRevised.Items.Weapons.PreHardmode.Metal;
using SpellbladeRevised.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Items.Weapons.Master
{
    public class ShadowsBrink : SpellbladeBase
    {
        protected override int value => Item.buyPrice(copper: 50);
        protected override int rarity => ItemRarityID.White;

        protected override int primaryDmg => 45;
        protected override float primaryKnockback => 3;
        protected override int primaryUseTime => 22;
        protected override int onHitManaRegen => ManaRegenT6;

        public override bool hasWeaponArt => true;
        protected override LegacySoundStyle weaponArtSound => new LegacySoundStyle(2, 117);
        public override int arcaneCost => 5;

        protected override int manaCost => 15;
        protected override int altUseTime => 20;
        protected override int castUseStyle => ItemUseStyleID.HoldingOut;
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2, 9);
        protected override int projectileID => ModContent.ProjectileType<DimSlash>();
        protected override int altDmg => 35;
        protected override float altKnockback => 2;
        protected override int projectileSpeed => 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow's Brink");
            Tooltip.SetDefault("Sharp enough to cut light");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 64;
            item.height = 64;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            Vector2 goalPos = Main.MouseWorld;

            int maxDist = (int)Vector2.Distance(Main.MouseWorld, player.position);
            Vector2 dir = Vector2.Normalize(Main.MouseWorld - player.position);

            for (int i = 32; i < maxDist; i++)
            {
                if (!Collision.CanHit(player.position, 1, 1, player.position + dir * i, 1, 1))
                {
                    goalPos = player.position + dir * i;
                    break;
                }
            }
            item.damage = altDmg;
            Projectile.NewProjectile(goalPos, Vector2.Zero, projectileID, player.GetWeaponDamage(item), altKnockback, Main.myPlayer, 0);

            return false;
        }

        public override void WeaponArt(Player player)
        {
            int radius = 640;
            if (!hasWeaponArt)
                return;
            Main.PlaySound(weaponArtSound, player.position);
            for (int i = 0; i < 50; i++)
            {
                Vector2 pos = player.position + Main.rand.NextVector2Circular(radius, radius);
                item.damage = altDmg;
                Projectile.NewProjectile(pos, Vector2.Zero, projectileID, (int)(player.GetWeaponDamage(item) * 1.5f), altKnockback, Main.myPlayer, i * -2);
            }

        }
    }
}
