using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace SpellbladeRevised.Buffs
{
    class ArcaneCurse : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Arcane Curse");
			Description.SetDefault("Mana potions have no effect");
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<SpellbladePlayer>().arcaneCurse = true;
		}

	}
}
