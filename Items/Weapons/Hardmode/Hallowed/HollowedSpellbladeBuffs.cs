using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Items.Weapons.Hardmode.Hallowed
{
	public class HallowedControlledSwordSummonBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Hallowed Blade");
			Description.SetDefault("A sentient blade is at your command");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<HallowedSpellbladeSummon>()] > 0)
			{
				player.buffTime[buffIndex] = 18000;
			}
			else
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
	public class HallowedSwordSummonBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Hallowed Blade");
			Description.SetDefault("Sentient blade assist you");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}
	}

}
