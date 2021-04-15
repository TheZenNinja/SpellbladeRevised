using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace SpellbladeRevised.Buffs
{
    class SwordProtection : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Sword's Protection");
			Description.SetDefault("You are defended by many blades");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<SpellbladePlayer>().swordProtect = true;
		}
	}
}
