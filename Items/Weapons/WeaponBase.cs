using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using SpellbladeRevised.Buffs;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace SpellbladeRevised.Items.Weapons
{
    public abstract class WeaponBase : ModItem
    {
		#region basic attribues
		protected virtual string GetName() => GetType().Name; 
		public virtual int[] ManaRegen { get; } = new int[]
			{
				8,
				12,
				20,
				30,
				40,
				50,
				75,
				100,
			};

		protected virtual int additiveCritChance { get; } = 0;
		protected virtual float scale { get; } = 1f;
		protected virtual int width { get; } = 32;
		protected virtual int height { get; } = 32;
		protected abstract int value { get; }
		protected abstract int rarity { get; }

		public override void HoldItem(Player player)
		{
			base.HoldItem(player);
			player.AddBuff(ModContent.BuffType<ArcaneCurse>(), 60);
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			//tooltips = new List<TooltipLine>();
			//TooltipLine line = new TooltipLine(mod, "Face", SpellbladeMod.classTitleText)
			//{
			//	overrideColor = SpellbladeMod.classTextColor
			//};
			//tooltips.Add(line);


			TooltipLine line = new TooltipLine(mod, "Face", SpellbladeRevised.classTitleText)
			{
				overrideColor = SpellbladeRevised.classTextColor
			};
			tooltips.Insert(1, line);

			Player p = Main.player[Main.myPlayer];
			//Main.NewText(p.name);
			TooltipLine damageReplacement = new TooltipLine(mod, "Damage", $"{GetPrimaryDamage(p)} ({GetAltDamage(p)}) Conjuration Damage");
			int dmgIndex = tooltips.FindIndex(t => t.Name == "Damage");
			tooltips[dmgIndex] = damageReplacement;


			if (tooltips.Find(t => t.Name == "UseMana") != null)
				tooltips.RemoveAll(t => t.Name == "UseMana");
			item.mana = manaCost;
			int cost = p.GetManaCost(item);
			TooltipLine manaData = new TooltipLine(mod, "UseMana", $"Uses {cost} mana\nRestores {onHitManaRegen} Mana on Melee Hit");
			tooltips.Insert(6, manaData);

			//if (tooltips.Find(t => t.Name == "UseMana") != null)
			//{
			//	int manaIndex = tooltips.FindIndex(t => t.Name == "UseMana");
			//	int cost = p.GetManaCost(item);
			//	TooltipLine manaData = new TooltipLine(mod, "UseMana", $"Uses {cost} mana\nRestores {onHitManaRegen} Mana on Melee Hit");
			//	tooltips[manaIndex] = manaData;
			//}
		}

		public override void GetWeaponCrit(Player player, ref int crit) => crit += player.magicCrit;

		protected virtual void SetBasicCustomDefaults()
		{
			item.mana = manaCost;
			item.width = width;
			item.height = height;
			item.scale = scale;

			item.value = value;
			item.rare = rarity;

			item.damage = primaryDmg;
			item.knockBack = primaryKnockback;
			item.crit = additiveCritChance;

			item.useTime = primaryUseTime;
			item.useAnimation = primaryUseTime;
			item.useStyle = ItemUseStyleID.SwingThrow;

			item.noMelee = true;
			item.autoReuse = true;
		}
		#endregion
		public virtual int GetPrimaryDamage(Player p)
		{
			item.damage = primaryDmg;
			int dmg = p.GetWeaponDamage(item);
			return dmg;
		}
		public virtual int GetAltDamage(Player p)
		{
			item.damage = altDmg;
			return p.GetWeaponDamage(item);
		}
		#region Primary
		protected abstract int primaryDmg { get; }
		protected abstract float primaryKnockback { get; }
		protected abstract int primaryUseTime { get; }
		protected virtual int primaryUseAnimation { get; } = 0;
		protected virtual int primaryUseDelay { get; } = 0;
		protected virtual LegacySoundStyle primarySound { get; } = new LegacySoundStyle(2, 1);
		protected abstract int onHitManaRegen { get; }
		#endregion

		#region Alt Func
		protected abstract int manaCost { get; }
		protected abstract int altDmg { get; }
		protected abstract float altKnockback { get; }
		protected abstract int altUseTime { get; }
		protected virtual int altUseAnimation { get; } = 0;
		protected virtual int altUseDelay { get; } = 0;
		protected virtual LegacySoundStyle altSound { get; } = SoundID.Item8;
		#endregion

		#region Weapon Arts
		public virtual int arcaneCost { get; } = 0;
		public virtual bool hasWeaponArt { get; } = false;
		protected virtual LegacySoundStyle weaponArtSound { get; } = null;
		public virtual void WeaponArt(Player player)
		{
			if (!hasWeaponArt)
				return;
		}
		#endregion
		
		#region Legendary Weapon
		public virtual bool isLegendaryWeapon { get; } = false;
		public virtual int[] legendaryWeaponDmg { get; }
        #endregion
        public override bool CloneNewInstances => true;

		#region On Item Use
		public override bool AltFunctionUse(Player player) => true;
		public override bool CanUseItem(Player player)
		{
			SpellbladePlayer sp = player.GetModPlayer<SpellbladePlayer>();
			SpellbladePlayer.SetItemAltUse(player, Main.myPlayer == player.whoAmI);

			if (sp.altWeaponFunc)
				OnRightClick(player);
			else
				OnLeftClick(player);

			//Main.NewText($"-Spellblade- Player: {Main.player[player.whoAmI].name} AltFunc = {sp.altWeaponFunc}");
			if (player.GetManaCost(item) > player.statMana)
				return false;

			return true;
		}
		public virtual void OnLeftClick(Player player)
		{
			item.damage = altDmg;
			item.knockBack = primaryKnockback;

			item.useTime = primaryUseTime;
			item.useAnimation = (primaryUseAnimation == 0 ? primaryUseTime : primaryUseAnimation);
			item.reuseDelay = primaryUseDelay;

			item.UseSound = primarySound;

			item.autoReuse = true;
		}
		public virtual void OnRightClick(Player player)
		{
			item.damage = altDmg;
			item.knockBack = altKnockback;

			item.useTime = altUseTime;
			item.useAnimation = (altUseAnimation == 0 ? altUseTime : altUseAnimation);
			item.reuseDelay = altUseDelay;

			item.UseSound = altSound;

			item.autoReuse = true;
		}
		#endregion
	}
}
