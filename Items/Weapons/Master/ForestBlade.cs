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
    public class ForestBlade : SpellbladeBase
    {
        protected override int value => Item.buyPrice(copper: 50);
		protected override int rarity => ItemRarityID.White;

        protected override int primaryDmg => 35;
        protected override float primaryKnockback => 3;
        protected override int primaryUseTime => 22;
        protected override int onHitManaRegen => ManaRegenT6;

        public override bool isLegendaryWeapon => true;
        public override int[] legendaryWeaponDmg => new int[]
            {

            };
        public override bool hasWeaponArt => true;
        protected override LegacySoundStyle weaponArtSound => new LegacySoundStyle(2, 117);
        public override int arcaneCost => 5;

        protected override int manaCost => 10;
        protected override int altUseTime => 16;
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2,8);
        protected override int projectileID => ProjectileID.TerraBeam;
        protected override int altDmg => 25;
        protected override float altKnockback => 2;
        protected override int projectileSpeed => 18;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heart of The Forest");
			Tooltip.SetDefault("The root of nature");
		}

		public override void SetDefaults()
		{
			SetBasicCustomDefaults();
            item.width = 64;
            item.height = 64;
        }

        public override void WeaponArt(Player player)
        {
            if (!hasWeaponArt)
                return;

            Projectile.NewProjectile(player.Center, Vector2.Zero, ModContent.ProjectileType<HealingAura>(), 0, 0, Main.myPlayer);

            Main.PlaySound(weaponArtSound, player.Center);
        }
    }
}
