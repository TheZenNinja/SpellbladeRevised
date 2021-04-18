using Microsoft.Xna.Framework;
using SpellbladeRevised.Technomancer.Buffs;
using SpellbladeRevised.Technomancer.Minions;
using Terraria;
using Terraria.ModLoader;

namespace SpellbladeRevised.Technomancer
{
    public class TechnomancerPlayer : ModPlayerBase
    {
        public static Color classTextColor => new Color(161, 37, 186);
        public static string classTitleText => "-Technomancer Class-";

        //if stacks >= max stacks give the player a buff that allows them to spawn a drone
        public int spawnStacks;
        public static readonly int spawnStacksMax = 4;
        /// <summary>
        /// Adds a stack of spawnStacks
        /// </summary>
        public void TryToGainStacks()
        {
            if (spawnStacks < spawnStacksMax)
            {
                spawnStacks += 1;
            }
            else if (!player.HasBuff(ModContent.BuffType<CanSpawnDroneBuff>()))
            {
                player.AddBuff(ModContent.BuffType<CanSpawnDroneBuff>(), 180);
            }
        }
        public void RemoveStacks()
        {
            spawnStacks = 0;
        }
        public bool CanSpawnDrone()
        {
            return spawnStacks >= spawnStacksMax;
        }

        public float getMinionCount()
        {
            float minions = 0;

            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile p = Main.projectile[i];

                if (p.GetType() == typeof(TechnoMinionBase))
                    continue;

                if (p.active && p.owner == player.whoAmI && p.minionSlots > 0)
                    minions += p.minionSlots;
            }

            return minions;
        }
        public override void PostUpdateMiscEffects()
        {
            UpdateResource();
        }

        private void UpdateResource()
        {

            spawnStacks = Utils.Clamp(spawnStacks, 0, spawnStacksMax);
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

        public override void ResetVariables()
        {
        }
    }
}
