using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Localization;
using System;

namespace SpellbladeRevised
{
    public static class RecipeManager
    {
        public static void AddRecipies(Mod mod)
        {
            AddRecipeGroups();
            AddConversionRecipies(mod);
            AddQoLRecipies(mod);
        }
        public static void AddConversionRecipies(Mod mod)
        {
            ModRecipe recipe;
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CopperBar);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.TinBar);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TinBar);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.CopperBar);
            recipe.AddRecipe();
        }
        public static void AddRecipeGroups()
        {
            RecipeGroup group;
            //group = new RecipeGroup(() => "Any Copper Tier Blade", new int[]
            //{
            //    ModContent.ItemType<CopperBlade>(),
            //    ModContent.ItemType<TinBlade>(),
            //});
            //RecipeGroup.RegisterGroup("SpellbladeMod:CopperTierBlade", group);
        }
        public static void AddQoLRecipies(Mod mod)
        {
            ModRecipe recipe;
            //slime staff
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Gel, 25);
            recipe.AddIngredient(ItemID.Wood, 25);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.SlimeStaff);

            //rod of discord
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.AddIngredient(ItemID.SoulofLight, 12);
            recipe.AddIngredient(ItemID.CrystalShard, 12);
            recipe.AddIngredient(ItemID.TeleportationPotion, 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.RodofDiscord);

            #region Chlorophyte to Turtle
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteMask);
            recipe.AddIngredient(ItemID.TurtleShell);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.TurtleHelmet);

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophytePlateMail);
            recipe.AddIngredient(ItemID.TurtleShell);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.TurtleScaleMail);

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteGreaves);
            recipe.AddIngredient(ItemID.TurtleShell);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.TurtleLeggings);
            #endregion

            #region Chlorophyte to Spectre
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteHeadgear);
            recipe.AddIngredient(ItemID.Ectoplasm, 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.SpectreHood);
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteHeadgear);
            recipe.AddIngredient(ItemID.Ectoplasm, 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.SpectreMask);

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophytePlateMail);
            recipe.AddIngredient(ItemID.Ectoplasm, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.SpectreRobe);

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteGreaves);
            recipe.AddIngredient(ItemID.Ectoplasm, 9);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.SpectreBoots);
            #endregion

            #region Chlorophyte to Turtle
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteHelmet);
            recipe.AddIngredient(ItemID.GlowingMushroom, 180);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.ShroomiteHeadgear);
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteHelmet);
            recipe.AddIngredient(ItemID.GlowingMushroom, 180);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.ShroomiteHelmet);
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteHelmet);
            recipe.AddIngredient(ItemID.GlowingMushroom, 180);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.ShroomiteMask);

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophytePlateMail);
            recipe.AddIngredient(ItemID.GlowingMushroom, 360);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.ShroomiteBreastplate);

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteGreaves);
            recipe.AddIngredient(ItemID.GlowingMushroom, 270);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.ShroomiteLeggings);
            #endregion
        }
    }
}
