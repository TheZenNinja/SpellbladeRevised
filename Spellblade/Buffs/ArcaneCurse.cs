using Terraria;
using Terraria.ModLoader;

namespace SpellbladeRevised.Spellblade.Buffs
{
	/// <summary>
	/// Add a red X over mana potions like when mana sickness is active
	/// </summary>
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
