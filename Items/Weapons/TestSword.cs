using System;
using System.Diagnostics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using SpellbladeRevised.Projectiles;

namespace SpellbladeRevised.Items.Weapons
{
	/*
	public class TestProjectile : SpellbladeProjectileBase 
	{
        public override int maxBounces => 2;
    }

	public class TestSword : SpellbladeBase
    {
		protected override int value => Item.sellPrice(copper: 50);
		protected override int rarity => ItemRarityID.White;

		protected override int swingDamage => 8;
		protected override float swingKnockback => 4;
		protected override int swingUseTime => 20;
		protected override int onHitManaRegen => ManaRegenT1;

		protected override int manaCost => 5;
		protected override int castUseTime => 26;
		protected override LegacySoundStyle castSound => new LegacySoundStyle(2, 30);
		protected override int projectileID => ProjectileID.IceBolt;
		protected override int projectileDamage => 14;
		protected override float projectileKockback => 4;
		protected override int projectileSpeed => 10;

		public override void SetDefaults()
		{
			SetBasicCustomDefaults();
		}
        public override void OnLeftClick(Player player)
        {
            base.OnLeftClick(player);
			item.alpha = 0;
		}
		public override void OnRightClick(Player player)
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.alpha = 255;
			item.useTime = swingUseTime;
			item.useAnimation = swingUseTime;
			item.UseSound = swingSound;
			item.damage = swingDamage;
			item.reuseDelay = 0;
			item.noMelee = true;
			item.knockBack = swingKnockback;
			item.mana = 0;

			item.shoot = ModContent.ProjectileType<TestProjectile>();
			item.useTurn = true;
			item.autoReuse = autoSwing;

			//if (Main.myPlayer == player.whoAmI)
				//player.direction = player.Center.X > Main.MouseWorld.X ? -1 : 1;

		}
	}*/
}
