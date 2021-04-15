using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using SpellbladeRevised.Minions;

namespace SpellbladeRevised.Buffs
{
    public class DaggerBuffBase : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault(GetType().Name.Replace("Buff", " Dagger"));
			Description.SetDefault("You have a bladed ally");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
		public override bool Autoload(ref string name, ref string texture)
		{
			string path = "SpellbladeMod/Buffs/DaggerBuffBase";
			texture = path;
			return base.Autoload(ref name, ref texture);
		}
		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[mod.ProjectileType(GetType().Name.Replace("Buff", "Minion"))] > 0)
			{
				player.buffTime[buffIndex] = 18000;
			}
			else
			{
				Main.NewText("No Summon Found:");
				//Main.NewText($"{GetType().Name.Replace("Buff", "Minion")}, {mod.ProjectileType(GetType().Name.Replace("Buff", "Minion"))}");
				Main.NewText($"Buff: {Type}");
				//Main.NewText($"Player (b): {player.whoAmI}");
				//Main.NewText("Owned Projectiles (A): " + player.ownedProjectileCounts[mod.ProjectileType(GetType().Name.Replace("Buff", "Minion"))]);
				Main.NewText("Owned Projectiles (A): " + player.GetModPlayer<SpellbladePlayer>().HasMinion(mod.ProjectileType(GetType().Name.Replace("Buff", "Minion"))));
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}
