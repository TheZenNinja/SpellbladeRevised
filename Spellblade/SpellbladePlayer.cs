using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SpellbladeRevised.Spellblade
{
	public class SpellbladePlayer : ModPlayerBase
    {
		public override Color classTextColor => new Color(25, 140, 230);
		public override string classTitleText => "-Spellblade Class-";

		public bool arcaneCurse = false;

		/*
		In order to make the Example Resource example straightforward, several things have been left out that would be needed for a fully functional resource similar to mana and health. 
		Here are additional things you might need to implement if you intend to make a custom resource:
		- Multiplayer Syncing: The current example doesn't require MP code, but pretty much any additional functionality will require this. ModPlayer.SendClientChanges and clientClone will be necessary, as well as SyncPlayer if you allow the user to increase exampleResourceMax.
		- Save/Load and increased max resource: You'll need to implement Save/Load to remember increases to your exampleResourceMax cap.
		- Resouce replenishment item: Use GlobalNPC.NPCLoot to drop the item. ModItem.OnPickup and ModItem.ItemSpace will allow it to behave like Mana Star or Heart. Use code similar to Player.HealEffect to spawn (and sync) a colored number suitable to your resource.
		*/

		public override void ResetEffects()
		{
			ResetVariables();
		}

		public override void UpdateDead()
		{
			ResetVariables();
		}

		private void ResetVariables()
		{
			arcaneCurse = false;
		}
		public override void clientClone(ModPlayer clientClone)
		{
			SpellbladePlayer clone = clientClone as SpellbladePlayer;
			// Here we would make a backup clone of values that are only correct on the local players Player instance.
			// Some examples would be RPG stats from a GUI, Hotkey states, and Extra Item Slots
			clone.arcaneCurse = arcaneCurse;
		}

		public void ForceAltUse()
		{
			player.altFunctionUse = 2;
			player.HeldItem.modItem.CanUseItem(player);
		}
        public override void GetHealMana(Item item, bool quickHeal, ref int healValue)
        {
			if (!arcaneCurse)
				base.GetHealMana(item, quickHeal, ref healValue);
        }
		
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
		{
			ModPacket packet = mod.GetPacket();
			packet.Write((byte)ModMessageType.SyncPlayer);
			packet.Write((byte)player.whoAmI);
			packet.Write(arcaneCurse);
			packet.Send(toWho, fromWho);
		}
    }
}
