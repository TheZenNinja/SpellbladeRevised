using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SpellbladeRevised
{
    public class SpellbladeWorld : ModWorld
    {
        /// <summary>
        /// 0 = none
        /// 1 = eye
        /// 2 = skele
        /// 3 = wof/hardmode
        /// 4 = mech
        /// 5 = plantera
        /// 6 = moonlord
        /// </summary>
        public static int weaponLevel = 0;
        public override void Initialize()
        {
            weaponLevel = 0;
        }
        public override TagCompound Save()
        {
            return new TagCompound
            {
                [nameof(weaponLevel)] = weaponLevel,
            };
        }
        public override void Load(TagCompound tag)
        {
            weaponLevel = tag.GetInt(nameof(weaponLevel));
            Main.NewText($"Current Weapon Level: {weaponLevel}");
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(weaponLevel);
        }
        public override void NetReceive(BinaryReader reader)
        {
            weaponLevel = reader.ReadInt32();
        }
    }
}
