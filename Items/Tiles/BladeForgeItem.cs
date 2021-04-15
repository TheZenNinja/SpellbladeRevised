using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using SpellbladeRevised.Tiles;
using Terraria.ModLoader;
using Terraria.ObjectData;


namespace SpellbladeRevised.Items.Tiles
{
    public class BladeForgeItem : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blade Forge");
			Tooltip.SetDefault("This is a modded workbench.");
		}

		public override void SetDefaults()
		{
			item.rare = ItemRarityID.Orange;
			item.width = 28;
			item.height = 14;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = Item.sellPrice(gold:2);
			item.createTile = ModContent.TileType<BladeForge>();
		}

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronAnvil);
            recipe.AddIngredient(ItemID.SharpeningStation);
            recipe.AddIngredient(ItemID.Hellforge);
            recipe.AddIngredient(TileID.HeavyWorkBench);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
