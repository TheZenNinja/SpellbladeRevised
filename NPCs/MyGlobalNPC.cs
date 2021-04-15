using SpellbladeRevised.Items.Weapons.Hardmode;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.NPCs
{
    public class MyGlobalNPC : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
            switch (npc.type)
            {
				case NPCID.EyeofCthulhu:
					if (SpellbladeWorld.weaponLevel < 1)
						SpellbladeWorld.weaponLevel = 1;
					break;
				case NPCID.SkeletronHead:
					if (SpellbladeWorld.weaponLevel < 2)
						SpellbladeWorld.weaponLevel = 2;
					break;

				case NPCID.WallofFlesh:
					if (SpellbladeWorld.weaponLevel < 3)
						SpellbladeWorld.weaponLevel = 3;
					if (Main.rand.Next(Main.expertMode ? 2 : 4) == 0)
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Caliburn>());
					break;
				case NPCID.SkeletronPrime:
				case NPCID.TheDestroyer:
				case NPCID.Spazmatism:
					if (SpellbladeWorld.weaponLevel < 4)
						SpellbladeWorld.weaponLevel = 4;
					break;
				case NPCID.Plantera:
					if (SpellbladeWorld.weaponLevel < 5)
						SpellbladeWorld.weaponLevel = 5;
					break;
				case NPCID.MoonLordCore:
					if (SpellbladeWorld.weaponLevel < 6)
						SpellbladeWorld.weaponLevel = 6;
					break;
			}
		}
		
	}
}
