using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using SpellbladeRevised.UI;
using SpellbladeRevised.Minions;

namespace SpellbladeRevised
{
	public enum ModMessageType : byte
	{
		SyncPlayer,
		AltFuncUpdate,
		ForceAltUse,
		WeaponArt
	}
	public class SpellbladeRevised : Mod
	{
		public static readonly Color classTextColor = new Color(25, 140, 230);
		public static readonly string classTitleText = "-Spellblade Class-";

		public static List<int> spelldaggerMinionIDs;

		public static ModHotKey WeaponArtKey;

		public static SpellbladeRevised instance;

		private UserInterface _arcaneBarUserInterface;

		internal ArcaneResourceUI ArcaneBar;
		public override void Load()
		{
			instance = this;

			WeaponArtKey = RegisterHotKey("Weapon Art", "V");

			spelldaggerMinionIDs = GetAllIDs();
			Main.NewText(spelldaggerMinionIDs);

			if (!Main.dedServ)
			{
				ArcaneBar = new ArcaneResourceUI();
				_arcaneBarUserInterface = new UserInterface();
				_arcaneBarUserInterface.SetState(ArcaneBar);
			}
		}
		public static List<int> GetAllIDs()
		{
			var i = new List<int>();

			var a = System.Reflection.Assembly.GetAssembly(typeof(SpelldaggerMinionBase));
			Type[] types = a.GetTypes();
			foreach (var t in types)
				if (t.IsSubclassOf(typeof(SpelldaggerMinionBase)))
					i.Add(instance.ProjectileType(t.Name));

			i.RemoveAll(x => x == 0);
			return i;
		}
		public override void Unload()
		{
			instance = null;
			WeaponArtKey = null;

			ArcaneBar = null;
			_arcaneBarUserInterface = null;
			spelldaggerMinionIDs = null;
		}

		public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
			ModMessageType msgType = (ModMessageType)reader.ReadByte();
			switch (msgType)
			{
				case ModMessageType.SyncPlayer:
					byte playernumber = reader.ReadByte();
					SpellbladePlayer player = Main.player[playernumber].GetModPlayer<SpellbladePlayer>();

					player.arcanePowerCurrent = reader.ReadInt32();
					player.arcanePowerMax = reader.ReadInt32();
					player.arcanePowerMax2 = reader.ReadInt32();
					player.altWeaponFunc = reader.ReadBoolean();
					player.arcaneCurse = reader.ReadBoolean();
					player.swordProtect = reader.ReadBoolean();
					// SyncPlayer will be called automatically, so there is no need to forward this data to other clients.
					break;
				case ModMessageType.AltFuncUpdate:
					playernumber = reader.ReadByte();
					player = Main.player[playernumber].GetModPlayer<SpellbladePlayer>();
					player.altWeaponFunc = reader.ReadBoolean();
					if (Main.netMode == NetmodeID.Server)
					{
						var packet = GetPacket();
						packet.Write((byte)ModMessageType.AltFuncUpdate);
						packet.Write(playernumber);
						packet.Write(player.altWeaponFunc);
						packet.Send(-1, playernumber);
					}
					break;
				case ModMessageType.ForceAltUse:
					playernumber = reader.ReadByte();
					player = Main.player[playernumber].GetModPlayer<SpellbladePlayer>();
					player.ForceAltUse();
					if (Main.netMode == NetmodeID.Server)
					{
						var packet = GetPacket();
						packet.Write((byte)ModMessageType.ForceAltUse);
						packet.Write(playernumber);
						packet.Send(-1, playernumber);
					}
					break;
				default:
					Logger.WarnFormat("ExampleMod: Unknown Message type: {0}", msgType);
					break;
			}
		}

		/// <summary>
		/// From the developer of WeaponOut
		/// Registers a glowmask texture to the game's array, and returns that value.
		/// The file should be located under Glow/ItemName_Glow. Make sure to register
		/// the returned value under item.glowMask in SetDefaults.
		/// </summary>
		/// <param name="modItem">The mod item to register. </param>
		/// <returns></returns>
		public static short SetStaticDefaultsGlowMask(ModItem modItem)
		{
			if (!Main.dedServ)
			{
				Texture2D[] glowMasks = new Texture2D[Main.glowMaskTexture.Length + 1];
				for (int i = 0; i < Main.glowMaskTexture.Length; i++)
				{
					glowMasks[i] = Main.glowMaskTexture[i];
				}
				glowMasks[glowMasks.Length - 1] = instance.GetTexture("Glow/" + modItem.GetType().Name + "_Glow");
				Main.glowMaskTexture = glowMasks;
				return (short)(glowMasks.Length - 1);
			}
			else return 0;
		}


		public override void UpdateUI(GameTime gameTime)
		{
			_arcaneBarUserInterface?.Update(gameTime);
		}
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
			if (resourceBarIndex != -1)
			{
				layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
					"Spellblade: Arcane Resource Bar",
					delegate
					{
						_arcaneBarUserInterface.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
		public override void AddRecipes()
		{
			RecipeManager.AddRecipeGroups();
			RecipeManager.AddQOLRecipies(this);
			RecipeManager.AddConversionRecipies(this);
			RecipeManager.AddIngredientRecipies(this);
			RecipeManager.AddWoodenRecipies(this);
			RecipeManager.AddMetalRecipies(this);
			RecipeManager.AddMiscPreHardRecipies(this);
			RecipeManager.AddHardmodeMetals(this);
			RecipeManager.AddExoticHardMetals(this);
			RecipeManager.AddMasterBlades(this);
			Mod thorium = ModLoader.GetMod("Thorium");
			if (thorium != null)
				RecipeManager.AddThoriumItems(this, thorium);
		}


		public static Vector2 RaycastToPosition(Vector2 position1, Vector2 size1, Vector2 position2, Vector2 size2)
		{
			Vector2 dir = Vector2.Normalize(position2 - position1);
			int maxDist = (int)Vector2.Distance(position2, position1);

			for (int i = 0; i < maxDist; i++)
				if (!Collision.CanHit(position1, (int)size1.X, (int)size1.Y, position2 + dir * i, (int)size2.X, (int)size2.Y))
					return position1 + dir * i;

			return position2;
		}

		public static float SquareMagnitude(Vector2 vector)
		{
			return vector.X * vector.X + vector.Y * vector.Y;
		}
		public static Vector2 ClampMagnitude(Vector2 vector, int maxMagnitude)
		{
			if (SquareMagnitude(vector) > maxMagnitude * maxMagnitude)
				return Vector2.Normalize(vector) * maxMagnitude;

			return vector;
		}
		public static int RoundToInt(float f) => (int)Math.Round(f);
		public static int RoundToIntClamped(float f) => (int)MathHelper.Clamp((float)Math.Round(f), 1, float.MaxValue);
	}
}