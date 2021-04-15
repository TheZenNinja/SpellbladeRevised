using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Items.Weapons.Hardmode.Hallowed
{
    /*
	 * This file contains all the code necessary for a minion
	 * - ModItem
	 *     the weapon which you use to summon the minion with
	 * - ModBuff
	 *     the icon you can click on to despawn the minion
	 * - ModProjectile 
	 *     the minion itself
	 *     
	 * It is not recommended to put all these classes in the same file. For demonstrations sake they are all compacted together so you get a better overwiew.
	 * To get a better understanding of how everything works together, and how to code minion AI, read the guide: https://github.com/tModLoader/tModLoader/wiki/Basic-Minion-Guide
	 * This is NOT an in-depth guide to advanced minion AI
	 */

    
	public class HallowedSpellblade : SpellbladeBase
	{
		protected override int value => Item.buyPrice(gold: 25);
		protected override int rarity => ItemRarityID.LightPurple;

		protected override int primaryDmg => 45;
		protected override float primaryKnockback => 2;
		protected override int primaryUseTime => 10;
		protected override int onHitManaRegen => 0;

		protected override int manaCost => 100;
		protected override int altUseTime => 10;
		protected override int castUseStyle => ItemUseStyleID.HoldingOut;
		protected override LegacySoundStyle primarySound => new LegacySoundStyle(2, 46);
        protected override int projectileID => ModContent.ProjectileType<HallowedSpellbladeSummon>();
		protected override int altDmg => 45;
		protected override float altKnockback => 3;
		protected override int projectileSpeed => 20;

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine line = new TooltipLine(mod, "Face", SpellbladeRevised.classTitleText)
			{
				overrideColor = SpellbladeRevised.classTextColor
			};
			tooltips.Insert(1, line);

			Player p = Main.player[Main.myPlayer];

			TooltipLine damageReplacement = new TooltipLine(mod, "Damage", $"{p.GetWeaponDamage(item)} Magic Damage");
			int dmgIndex = tooltips.FindIndex(t => t.Name == "Damage");
			tooltips[dmgIndex] = damageReplacement;

			if (tooltips.Find(t => t.Name == "PrefixUseMana") != null)
				tooltips.RemoveAll(t => t.Name == "PrefixUseMana");

			item.mana = manaCost;
			int cost = p.GetManaCost(item);
			TooltipLine manaData = new TooltipLine(mod, "PrefixUseMana", $"Uses {cost} mana");
			tooltips.Insert(6, manaData);
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hallowed Spellblade");
			Tooltip.SetDefault("Summons an enchanted blade at your command");
		}

		public override void SetDefaults()
		{
			SetBasicCustomDefaults();
			item.mana = 50;
			item.width = 48;
			item.height = 48;
			item.damage = altDmg;

			item.buffType = ModContent.BuffType<HallowedControlledSwordSummonBuff>();
		}
		int currentProjID = -1;

		public override void HoldItem(Player player)
		{
			if (Main.netMode != NetmodeID.SinglePlayer)
				if (player.whoAmI != Main.myPlayer)
					return;

			if (!player.HasBuff(item.buffType))
			{
				player.AddBuff(item.buffType, 2, true);
				Vector2 position = player.Center + new Vector2(player.direction * 64, -32);
				currentProjID = Projectile.NewProjectile(position, Vector2.Zero, projectileID, player.GetWeaponDamage(item), item.knockBack, player.whoAmI);
				Main.PlaySound(new LegacySoundStyle(2, 30), player.Center);
			}
			else
			{
				if (Main.projectile[currentProjID] != null && Main.projectile[currentProjID].damage != player.GetWeaponDamage(item))
				{
					//Main.NewText("Respawned Projectile");
					//Main.NewText($"{Main.projectile[currentProjID].damage}, {player.GetWeaponDamage(item)}");
					Vector2 position = Main.projectile[currentProjID].position;
					float rotation = Main.projectile[currentProjID].rotation;
					Main.projectile[currentProjID].Kill();
					currentProjID = Projectile.NewProjectile(position, Vector2.Zero, projectileID, player.GetWeaponDamage(item), item.knockBack, player.whoAmI);
					Main.projectile[currentProjID].rotation = rotation;
				}
			}
			var sp = player.GetModPlayer<SpellbladePlayer>();
			if (Main.myPlayer != player.whoAmI)
				return;
			{
				sp.swordTargetMouse = Main.mouseLeft;
				if (!player.HasBuff(ModContent.BuffType<HallowedSwordSummonBuff>()) && player.CheckMana(item))
					if (Main.mouseRight)
					{
						int time = 10 * 60;
						player.AddBuff(ModContent.BuffType<HallowedSwordSummonBuff>(), time);
						for (int i = 0; i < 2; i++)
						{
							int id = Projectile.NewProjectile(player.position + Main.rand.NextVector2Circular(32, 32), Vector2.Zero, projectileID, player.GetWeaponDamage(item), item.knockBack, player.whoAmI, 1);
							Main.projectile[id].timeLeft = time;
						}
						Main.PlaySound(primarySound, player.Center);
					}
			}
			base.HoldItem(player);
		}
		public override bool CanUseItem(Player player) => false;
	}
}
