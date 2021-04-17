using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Technomancer.Buffs
{
    public class CanSpawnDroneBuff : ModBuff
    {
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Drone Ready");
			Description.SetDefault("You are able to construct a drone ally");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			canBeCleared = false;
		}
		public override void Update(Player player, ref int buffIndex)
		{
			var tPlayer = player.GetModPlayer<TechnomancerPlayer>();
			if (tPlayer.CanSpawnDrone())
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
}
