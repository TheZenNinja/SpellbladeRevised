using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using SpellbladeRevised.Spellblade;

namespace SpellbladeRevised
{
	public enum ModMessageType : byte
	{
		SyncPlayer,
	}
	public class SpellbladeRevised : Mod
	{
		public static SpellbladeRevised instance;
		public override void Load()
		{
			instance = this;
		}
		public override void Unload()
		{
			instance = null;
		}

		public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
			ModMessageType msgType = (ModMessageType)reader.ReadByte();
			switch (msgType)
			{
				//divide sync player for each subclass if poor performance
				case ModMessageType.SyncPlayer:
					// SyncPlayer will be called automatically, so there is no need to forward this data to other clients.
					byte playernumber = reader.ReadByte();

					SpellbladePlayer sbPlayer = Main.player[playernumber].GetModPlayer<SpellbladePlayer>();
					sbPlayer.arcaneCurse = reader.ReadBoolean();
					


					break;
				default:
					Logger.WarnFormat("Spellblade Revised: Unknown Message type: {0}", msgType);
					break;
			}
		}

		public override void AddRecipes() => RecipeManager.AddRecipies(this);

		public static Vector2 RaycastToPosition(Vector2 position1, Vector2 size1, Vector2 position2, Vector2 size2)
		{
			Vector2 dir = Vector2.Normalize(position2 - position1);
			int maxDist = (int)Vector2.Distance(position2, position1);

			for (int i = 0; i < maxDist; i++)
				if (!Collision.CanHit(position1, (int)size1.X, (int)size1.Y, position2 + dir * i, (int)size2.X, (int)size2.Y))
					return position1 + dir * i;

			return position2;
		}
    }
}