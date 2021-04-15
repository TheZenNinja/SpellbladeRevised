using Microsoft.Xna.Framework;
using SpellbladeRevised.Items.Weapons;
using SpellbladeRevised.Items.Weapons.Hardmode.Hallowed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised
{
	public class SpellbladePlayer : ModPlayer
    {
		public static SpellbladePlayer ModPlayer(Player player)
		{
			return player.GetModPlayer<SpellbladePlayer>();
		}

		// Here we include a custom resource, similar to mana or health.
		// Creating some variables to define the current value of our example resource as well as the current maximum value. We also include a temporary max value, as well as some variables to handle the natural regeneration of this resource.

		public bool arcaneCurse = false;
		public bool swordProtect = false;

		public bool swordTargetMouse = false;

		public int arcanePowerCurrent;
		public const int DefaulArcanePower = 5;
		public int arcanePowerMax;
		public int arcanePowerMax2;

		public int arcanePowerGainRate;
		public bool canGainArcane;
		public float arcaneGainCooldownMulti = 1;
		public int arcaneGainCooldownTimer = 0;

		public int arcaneLossTimer = 0;
		public int arcaneLossTimerMax = 60*5;

		public bool altWeaponFunc = false;
		//public static readonly Color HealExampleResource = new Color(187, 91, 201); // We can use this for CombatText, if you create an item that replenishes exampleResourceCurrent.

		/*
		In order to make the Example Resource example straightforward, several things have been left out that would be needed for a fully functional resource similar to mana and health. 
		Here are additional things you might need to implement if you intend to make a custom resource:
		- Multiplayer Syncing: The current example doesn't require MP code, but pretty much any additional functionality will require this. ModPlayer.SendClientChanges and clientClone will be necessary, as well as SyncPlayer if you allow the user to increase exampleResourceMax.
		- Save/Load and increased max resource: You'll need to implement Save/Load to remember increases to your exampleResourceMax cap.
		- Resouce replenishment item: Use GlobalNPC.NPCLoot to drop the item. ModItem.OnPickup and ModItem.ItemSpace will allow it to behave like Mana Star or Heart. Use code similar to Player.HealEffect to spawn (and sync) a colored number suitable to your resource.
		*/
		public override void Initialize()
		{
			arcanePowerMax = DefaulArcanePower;
		}

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
			canGainArcane = false;
			arcanePowerGainRate = 1;
			arcaneGainCooldownMulti = 1f;
			arcanePowerMax2 = arcanePowerMax;
			arcaneCurse = false;
			swordProtect = false;
		}
        public override void PostUpdateMiscEffects()
		{
			UpdateResource();
		}
        public override void PostUpdateBuffs()
        {
			int buffID = ModContent.BuffType<HallowedControlledSwordSummonBuff>();
			if (!(player.HeldItem.modItem is HallowedSpellblade))
				if (player.HasBuff(buffID))
					player.DelBuff(player.FindBuffIndex(buffID));

		}
        // Lets do all our logic for the custom resource here, such as limiting it, increasing it and so on.
        private void UpdateResource()
		{
			if (arcanePowerCurrent > 0)
			{
				if (arcaneLossTimer >= arcaneLossTimerMax)
				{
					arcanePowerCurrent--;
					arcaneLossTimer = 0;
				}
				arcaneLossTimer++;
			}

			// For our resource lets make it regen slowly over time to keep it simple, let's use exampleResourceRegenTimer to count up to whatever value we want, then increase currentResource.
			if (!canGainArcane)
			{
				arcaneGainCooldownTimer++; //Increase it by 60 per second, or 1 per tick.

				// A simple timer that goes up to 1 seconds, increases the exampleResourceCurrent by 1 and then resets back to 0.
				if (arcaneGainCooldownTimer > 180 * (2-arcaneGainCooldownMulti))
					canGainArcane = true;
			}

			arcanePowerCurrent = Utils.Clamp(arcanePowerCurrent, 0, arcanePowerMax2);
		}
		public override void clientClone(ModPlayer clientClone)
		{
			SpellbladePlayer clone = clientClone as SpellbladePlayer;
			// Here we would make a backup clone of values that are only correct on the local players Player instance.
			// Some examples would be RPG stats from a GUI, Hotkey states, and Extra Item Slots
			clone.arcanePowerCurrent = arcanePowerCurrent;
			clone.arcanePowerMax = arcanePowerMax;
			clone.arcanePowerMax2 = arcanePowerMax2;
			clone.altWeaponFunc = altWeaponFunc;
			clone.arcaneCurse = arcaneCurse;
			clone.swordProtect = swordProtect;
		}

		public void ForceAltUse()
		{
			player.altFunctionUse = 2;
			player.HeldItem.modItem.CanUseItem(player);
		}
		public static void SetItemAltUse(Player player, bool forcePush)
		{
			SpellbladePlayer p = player.GetModPlayer<SpellbladePlayer>();

			p.altWeaponFunc = player.altFunctionUse == 2;

			if (Main.netMode != NetmodeID.SinglePlayer)
			{
				ModPacket packet = p.mod.GetPacket();
				packet.Write((byte)ModMessageType.AltFuncUpdate);
				packet.Write((byte)player.whoAmI);
				packet.Write(p.altWeaponFunc);
				packet.Send();

				if (forcePush && p.altWeaponFunc)
				{
					packet = p.mod.GetPacket();
					packet.Write((byte)ModMessageType.ForceAltUse);
					packet.Write((byte)player.whoAmI);
					packet.Send();
				}
			}
		}
        public override void GetHealMana(Item item, bool quickHeal, ref int healValue)
        {
			if (arcaneCurse)
				healValue *= 0;

            base.GetHealMana(item, quickHeal, ref healValue);
        }
        public static void SwapItemAltUse(Player player, bool forcePush)
		{
			SpellbladePlayer p = player.GetModPlayer<SpellbladePlayer>();

			p.altWeaponFunc = !p.altWeaponFunc;

			if (Main.netMode != NetmodeID.SinglePlayer)
			{
				ModPacket packet = p.mod.GetPacket();
				packet.Write((byte)ModMessageType.AltFuncUpdate);
				packet.Write((byte)player.whoAmI);
				packet.Write(p.altWeaponFunc);
				packet.Send();

				if (forcePush && p.altWeaponFunc)
				{
					packet = p.mod.GetPacket();
					packet.Write((byte)ModMessageType.ForceAltUse);
					packet.Write((byte)player.whoAmI);
					packet.Send();
				}
			}
		}
		
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
		{
			ModPacket packet = mod.GetPacket();
			packet.Write((byte)ModMessageType.SyncPlayer);
			packet.Write((byte)player.whoAmI);
			packet.Write(arcanePowerCurrent); 
			packet.Write(arcanePowerMax);
			packet.Write(arcanePowerMax2);
			packet.Write(altWeaponFunc);
			packet.Write(arcaneCurse);
			packet.Write(swordProtect);
			packet.Send(toWho, fromWho);
		}

		public static bool debug = false;
		public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
		{
			if (!debug)
				return;

			if (altWeaponFunc && drawInfo.shadow == 0f && Main.rand.NextBool(6)) // checking shadow == 0 helps avoid spawning extra dust because of extra shadow draws.
			{
				int dustIndex = Dust.NewDust(drawInfo.position + new Vector2(drawInfo.drawPlayer.width / 2 - 2, -30), 4, 4, 219, 0f, 0f, 100, default(Color), 1f);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = Main.rand.NextFloat(-1f, 1f);
				dust.velocity.Y = Main.rand.NextFloat(-3, -1.5f);
				dust.scale = 1f + Main.rand.NextFloat(-.030f, .031f);
				Main.playerDrawDust.Add(dustIndex);
			}
		}
		/// <summary>
		/// Tests if the player can gain arcane power and adds it if they can
		/// </summary>
		public void TryToGainArcane()
		{
			if (canGainArcane)
			{
				arcaneLossTimer = 0;
				arcanePowerCurrent += arcanePowerGainRate;
				arcanePowerCurrent = Utils.Clamp(arcanePowerCurrent, 0, arcanePowerMax2);
				arcaneGainCooldownTimer = 0;
			}
		}
		public List<ModProjectile> GetMinionsOfType(int projID)
		{
			List<ModProjectile> projectiles = new List<ModProjectile>();
			foreach (var p in Main.projectile)
				if (p.type == projID)
					projectiles.Add(p.modProjectile);

			return projectiles;
		}
		public bool HasMinion(int type)
		{
			for (int i = 0; i < Main.maxProjectiles; i++)
			{
				// Fix overlap with other minions
				Projectile other = Main.projectile[i];
				if (other.active && other.owner == player.whoAmI && other.type == type)
					return true;
			}
			//otherMinions.Sort((x, y) => x.minionPos - y.minionPos);
			return false;
		}
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (SpellbladeRevised.WeaponArtKey.JustPressed)
			{
				if (!(Main.LocalPlayer.HeldItem.modItem is SpellbladeBase))
					return;
				var s = player.HeldItem.modItem as SpellbladeBase;
				if (!s.hasWeaponArt)
					return;
				if (ModPlayer(player).arcanePowerCurrent < s.arcaneCost)
					return;
				ModPlayer(player).arcanePowerCurrent -= s.arcaneCost;

				s.WeaponArt(player);
			}
		}
    }
}
