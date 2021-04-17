using Microsoft.Xna.Framework;
using System;
using Terraria.ModLoader;

namespace SpellbladeRevised.Technomancer
{
    public class TechnomancerPlayer : ModPlayerBase
    {
        public override Color classTextColor => new Color(161, 37, 186);
        public override string classTitleText => "-Technomancer Class-";

        //if stacks >= max stacks give the player a buff that allows them to spawn a drone
        public byte spawnStacks;
        public static readonly byte spawnStacksMax = 4;

        /// <summary>
        /// Adds a stack of spawnStacks
        /// </summary>
        public void TryToGainStacks()
        {
            if (spawnStacks < spawnStacksMax)
                spawnStacks++;
        }
        public void RemoveStacks()
        {
            spawnStacks = 0;
        }
        public bool CanSpawnDrone()
        {
            return spawnStacks >= spawnStacksMax;
        }

        public override void ResetVariables()
        {
            spawnStacks = 0;
        }

        public override void clientClone(ModPlayer clientClone)
        {
            TechnomancerPlayer clone = clientClone as TechnomancerPlayer;
            // Here we would make a backup clone of values that are only correct on the local players Player instance.
            // Some examples would be RPG stats from a GUI, Hotkey states, and Extra Item Slots
            clone.spawnStacks = spawnStacks;
        }
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();
            packet.Write((byte)ModMessageType.SyncPlayer);
            packet.Write((byte)player.whoAmI);
            packet.Write(spawnStacks);
            packet.Send(toWho, fromWho);
        }
    }
}
