using Terraria.ID;
using Terraria.ModLoader;
using SpellbladeRevised.Items.Weapons;
using SpellbladeRevised.Items.Weapons.PreHardmode.Wooden;
using SpellbladeRevised.Items.Weapons.PreHardmode.Metal;
using SpellbladeRevised.Items;
using SpellbladeRevised.Items.Tiles;
using SpellbladeRevised.Items.Materials;
using SpellbladeRevised.Items.Weapons.PreHardmode;
using SpellbladeRevised.Items.Weapons.Hardmode.Metal;
using SpellbladeRevised.Items.Weapons.Hardmode.Hallowed;
using SpellbladeRevised.Items.Weapons.Hardmode;
using SpellbladeRevised.Tiles;
using SpellbladeRevised.Items.Weapons.Master;
using Terraria;
using Terraria.Localization;

namespace SpellbladeRevised
{
    public static class RecipeManager
    {
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
        public static void AddIngredientRecipies(Mod mod)
        {
            ModRecipe recipe;

            //blade forge
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddIngredient(ItemID.IronAnvil);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<BladeForgeItem>());

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddIngredient(ItemID.LeadAnvil);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(ModContent.ItemType<BladeForgeItem>());

            #region Arcane Fragments
            //lesser
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 2);
            recipe.SetResult(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddRecipe();
            //basic
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 4);
            recipe.AddIngredient(ItemID.Bone, 4);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.SetResult(ModContent.ItemType<BasicArcaneFragment>());
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 4);
            recipe.AddIngredient(ItemID.Bone, 4);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.SetResult(ModContent.ItemType<BasicArcaneFragment>());
            recipe.AddRecipe();
            //greater
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MythrilBar, 4);
            recipe.AddIngredient(ItemID.SoulofLight, 4);
            recipe.AddIngredient(ItemID.SoulofNight, 4);
            recipe.SetResult(ModContent.ItemType<GreaterArcaneFragment>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar, 4);
            recipe.AddIngredient(ItemID.SoulofLight, 4);
            recipe.AddIngredient(ItemID.SoulofNight, 4);
            recipe.SetResult(ModContent.ItemType<GreaterArcaneFragment>());
            recipe.AddRecipe();
            //complex
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 4);
            recipe.AddIngredient(ItemID.SoulofFright, 1);
            recipe.AddIngredient(ItemID.SoulofMight,  1);
            recipe.AddIngredient(ItemID.SoulofSight,  1);
            recipe.SetResult(ModContent.ItemType<ComplexArcaneFragment>());
            recipe.AddRecipe();
            //mystic
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 4);
            recipe.AddIngredient(ItemID.AncientBattleArmorMaterial); //forbidden fragment
            recipe.SetResult(ModContent.ItemType<MysticArcaneFragment>());
            recipe.AddRecipe();
            #endregion
            //Fusion Core
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ManaCrystal, 1);
            recipe.AddIngredient(ItemID.JungleSpores, 4);
            recipe.AddIngredient(ItemID.DemoniteBar, 4);
            recipe.AddTile(ModContent.TileType<BladeForge>());
            recipe.SetResult(ModContent.ItemType<ArcaneCore>());

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ManaCrystal, 1);
            recipe.AddIngredient(ItemID.JungleSpores, 4);
            recipe.AddIngredient(ItemID.CrimtaneBar, 4);
            recipe.AddTile(ModContent.TileType<BladeForge>());
            recipe.SetResult(ModContent.ItemType<ArcaneCore>());

            //arcane core
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LargeDiamond);
            recipe.AddIngredient(ItemID.ManaCrystal, 4);
            recipe.AddIngredient(ItemID.Hellstone, 4);
            recipe.AddIngredient(ItemID.JungleSpores, 4);
            recipe.AddIngredient(ItemID.DemoniteBar, 4);
            recipe.AddTile(ModContent.TileType<BladeForge>());
            recipe.SetResult(ModContent.ItemType<ArcaneCore>());

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LargeDiamond);
            recipe.AddIngredient(ItemID.ManaCrystal, 4);
            recipe.AddIngredient(ItemID.Hellstone, 4);
            recipe.AddIngredient(ItemID.JungleSpores, 4);
            recipe.AddIngredient(ItemID.CrimtaneBar, 4);
            recipe.AddTile(ModContent.TileType<BladeForge>());
            recipe.SetResult(ModContent.ItemType<ArcaneCore>());
        }
        public static void AddWoodenRecipies(Mod mod)
        {
            ModRecipe recipe;
            //normal wood
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.AddIngredient(ItemID.Acorn, 5);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<WoodenBlade>());
            recipe.AddRecipe();
            //shadewood
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Shadewood, 20);
            recipe.AddIngredient(ItemID.Vertebrae, 5);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<ShadewoodDagger>());
            recipe.AddRecipe();
            //ebonwood
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ebonwood, 20);
            recipe.AddIngredient(ItemID.RottenChunk, 5);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<EbonwoodDagger>());
            recipe.AddRecipe();
            //mahogany
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RichMahogany, 20);
            recipe.AddIngredient(ItemID.Stinger, 5);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<MahoganyBlade>());
            recipe.AddRecipe();
            //palm
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalmWood, 20);
            recipe.AddIngredient(ItemID.Coral, 5);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<PalmwoodSpellstaff>());
            recipe.AddRecipe();
            //boreal
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BorealWood, 20);
            recipe.AddIngredient(ItemID.IceBlock, 5);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<BorealDagger>());
            recipe.AddRecipe();

            //dynasty
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DynastyWood, 20);
            recipe.AddIngredient(ItemID.IceBlock, 5);
            recipe.AddIngredient(ModContent.ItemType<BasicArcaneFragment>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<DynastyDagger>());
            recipe.AddRecipe();

            //Pearlwood
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Pearlwood, 20);
            recipe.AddIngredient(ItemID.PixieDust, 5);
            recipe.AddIngredient(ItemID.CrystalShard, 25);
            recipe.AddIngredient(ModContent.ItemType<BasicArcaneFragment>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<PearlwoodBlade>());
            recipe.AddRecipe();
            //spooky
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpookyWood, 20);
            recipe.AddIngredient(ItemID.LivingFireBlock, 10);
            recipe.AddIngredient(ModContent.ItemType<GreaterArcaneFragment>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<SpookyBlade>());
            recipe.AddRecipe();

        }
        public static void AddMetalRecipies(Mod mod)
        {
            ModRecipe recipe;
            //iron
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 12);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<IronBlade>());
            recipe.AddRecipe();
            //lead
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LeadBar, 12);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<LeadBlade>());
            recipe.AddRecipe();
            //copper
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CopperBar, 12);
            recipe.AddIngredient(ItemID.Amethyst, 4);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<CopperBlade>());
            recipe.AddRecipe();
            //tin
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TinBar, 12);
            recipe.AddIngredient(ItemID.Topaz, 4);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<TinBlade>());
            recipe.AddRecipe();
            //Silver
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SilverBar, 12);
            recipe.AddIngredient(ItemID.Sapphire, 4);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<SilverDagger>());
            recipe.AddRecipe();
            //Tungsten
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TungstenBar, 12);
            recipe.AddIngredient(ItemID.Emerald, 4);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<TungstenBlade>());
            recipe.AddRecipe();
            //gold
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBar, 12);
            recipe.AddIngredient(ItemID.Ruby, 4);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<GoldBlade>());
            recipe.AddRecipe();
            //platinum
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PlatinumBar, 12);
            recipe.AddIngredient(ItemID.Diamond, 4);
            recipe.AddIngredient(ModContent.ItemType<LesserArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<PlatinumBlade>());
            recipe.AddRecipe();

            //demonite
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 12);
            recipe.AddIngredient(ItemID.Vilethorn);
            recipe.AddIngredient(ModContent.ItemType<BasicArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<DemoniteBlade>());
            recipe.AddRecipe();
            //demonite
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 12);
            recipe.AddIngredient(ItemID.TheRottedFork);
            recipe.AddIngredient(ModContent.ItemType<BasicArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<CrimtaneBlade>());
            recipe.AddRecipe();

            //Hellstone
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 12);
            recipe.AddIngredient(ItemID.Gel, 50);
            recipe.AddIngredient(ItemID.Fireblossom, 1);
            recipe.AddIngredient(ModContent.ItemType<BasicArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<HellstoneBlade>());
            recipe.AddRecipe();
            //meteorite
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Meteorite, 20);
            recipe.AddIngredient(ItemID.Ruby, 4);
            recipe.AddIngredient(ModContent.ItemType<BasicArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<MeteoriteBlade>());
            recipe.AddRecipe();
        }
        public static void AddMiscPreHardRecipies(Mod mod)
        {
            ModRecipe recipe;
            //cactus
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Cactus, 20);
            recipe.AddIngredient(ItemID.AntlionMandible, 4);
            recipe.AddIngredient(ModContent.ItemType<BasicArcaneFragment>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ModContent.ItemType<CactusBlade>());
            recipe.AddRecipe();
            //amber
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DesertFossil, 20);
            recipe.AddIngredient(ItemID.Amber, 4);
            recipe.AddIngredient(ModContent.ItemType<BasicArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<AmberBlade>());
            recipe.AddRecipe();
            //obsidian
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Obsidian, 20);
            recipe.AddIngredient(ItemID.DemonScythe);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddIngredient(ModContent.ItemType<BasicArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<ObsidianBlade>());
            recipe.AddRecipe();
            //bee/jungle
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.JungleSpores, 12);
            recipe.AddIngredient(ItemID.Stinger, 6);
            recipe.AddIngredient(ItemID.Hive, 8);
            recipe.AddIngredient(ModContent.ItemType<BasicArcaneFragment>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<BeeBlade>());
            recipe.AddRecipe();
            //Granite
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GraniteBlock, 50);
            recipe.AddIngredient(ItemID.SpecularFish, 5);
            recipe.AddIngredient(ModContent.ItemType<BasicArcaneFragment>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<GraniteBlade>());
            recipe.AddRecipe();
            //marble
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MarbleBlock, 50);
            recipe.AddIngredient(ItemID.Javelin, 50);
            recipe.AddIngredient(ModContent.ItemType<BasicArcaneFragment>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<MarbleBlade>());
            recipe.AddRecipe();
        }
        public static void AddHardmodeMetals(Mod mod)
        { 
            ModRecipe recipe;
            //cobalt
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 12);
            recipe.AddIngredient(ItemID.SoulofFlight, 5);
            recipe.AddIngredient(ModContent.ItemType<GreaterArcaneFragment>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<CobaltSpellblade>());
            recipe.AddRecipe();
            //palladium
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumBar, 12);
            recipe.AddIngredient(ItemID.SoulofFlight, 5);
            recipe.AddIngredient(ModContent.ItemType<GreaterArcaneFragment>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ModContent.ItemType<PalladiumSpellblade>());
            recipe.AddRecipe();
            //mythril
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MythrilBar, 12);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(ModContent.ItemType<GreaterArcaneFragment>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<MythrilSpellblade>());
            recipe.AddRecipe();
            //orichalcum
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar, 12);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ModContent.ItemType<GreaterArcaneFragment>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<OrichalcumSpellblade>());
            recipe.AddRecipe();
            //adamantite
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar, 12);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ModContent.ItemType<GreaterArcaneFragment>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<AdamantiteSpellblade>());
            recipe.AddRecipe();
            //titanium
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 12);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ModContent.ItemType<GreaterArcaneFragment>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<TitaniumSpellblade>());
            recipe.AddRecipe();
        }
        public static void AddExoticHardMetals(Mod mod)
        { 
            ModRecipe recipe;
            //titanium
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.AddIngredient(ItemID.SoulofFlight, 5);
            recipe.AddIngredient(ModContent.ItemType<ComplexArcaneFragment>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<HallowedSpellblade>());
            recipe.AddRecipe();
        }
        public static void AddRecipeGroups()
        {
            RecipeGroup group;
            group = new RecipeGroup(() => "Any Copper Tier Blade", new int[]
            {
                ModContent.ItemType<CopperBlade>(),
                ModContent.ItemType<TinBlade>(),
            });
            RecipeGroup.RegisterGroup("SpellbladeMod:CopperTierBlade", group);

            group = new RecipeGroup(() => "Any Iron Tier Blade", new int[]
            {
                ModContent.ItemType<IronBlade>(),
                ModContent.ItemType<LeadBlade>(),
            });
            RecipeGroup.RegisterGroup("SpellbladeMod:IronTierBlade", group);

            group = new RecipeGroup(() => "Any Silver Tier Blade", new int[]
            {
                ModContent.ItemType<SilverDagger>(),
                ModContent.ItemType<TungstenBlade>(),
            });
            RecipeGroup.RegisterGroup("SpellbladeMod:SilverTierBlade", group);

            group = new RecipeGroup(() => "Any Gold Tier Blade", new int[]
            {
                ModContent.ItemType<GoldBlade>(),
                ModContent.ItemType<PlatinumBlade>(),
            });
            RecipeGroup.RegisterGroup("SpellbladeMod:GoldTierBlade", group);


        }
        public static void AddThoriumItems(Mod mod, Mod thorium)
        {
            if (thorium == null)
                return;
            
            ModRecipe recipe;
        }
        public static void AddMasterBlades(Mod mod)
        {
            ModRecipe recipe;
            //forest blade
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<WoodenBlade>());
            recipe.AddIngredient(ModContent.ItemType<BorealDagger>());
            recipe.AddIngredient(ModContent.ItemType<MahoganyBlade>());
            recipe.AddIngredient(ModContent.ItemType<PalmwoodSpellstaff>());
            recipe.AddIngredient(ModContent.ItemType<ShadewoodDagger>());
            recipe.AddIngredient(ModContent.ItemType<ArcaneCore>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<ForestBlade>());

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<WoodenBlade>());
            recipe.AddIngredient(ModContent.ItemType<BorealDagger>());
            recipe.AddIngredient(ModContent.ItemType<MahoganyBlade>());
            recipe.AddIngredient(ModContent.ItemType<PalmwoodSpellstaff>());
            recipe.AddIngredient(ModContent.ItemType<EbonwoodDagger>());
            recipe.AddIngredient(ModContent.ItemType<ArcaneCore>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<ForestBlade>());

            //alloy blade
            recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("SpellbladeMod:CopperTierBlade");
            recipe.AddRecipeGroup("SpellbladeMod:IronTierBlade");
            recipe.AddRecipeGroup("SpellbladeMod:SilverTierBlade");
            recipe.AddRecipeGroup("SpellbladeMod:GoldTierBlade");
            recipe.AddIngredient(ModContent.ItemType<ArcaneCore>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<AlloyBlade>());

            //shadows brink
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Muramasa>());
            recipe.AddIngredient(ModContent.ItemType<HellstoneBlade>());
            recipe.AddIngredient(ModContent.ItemType<BeeBlade>());
            recipe.AddIngredient(ModContent.ItemType<DemoniteBlade>());
            recipe.AddIngredient(ModContent.ItemType<ArcaneCore>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<ShadowsBrink>());

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Muramasa>());
            recipe.AddIngredient(ModContent.ItemType<HellstoneBlade>());
            recipe.AddIngredient(ModContent.ItemType<BeeBlade>());
            recipe.AddIngredient(ModContent.ItemType<CrimtaneBlade>());
            recipe.AddIngredient(ModContent.ItemType<ArcaneCore>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ModContent.ItemType<ShadowsBrink>());
        }
        
        public static void AddQOLRecipies(Mod mod)
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
            recipe.AddIngredient(ItemID.HallowedBar,  12);
            recipe.AddIngredient(ItemID.SoulofLight,  12);
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
