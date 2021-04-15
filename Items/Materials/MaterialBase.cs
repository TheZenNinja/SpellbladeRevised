using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Items.Materials
{
    public abstract class MaterialBase : ModItem
    {
        public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine line = new TooltipLine(mod, "Face", SpellbladeRevised.classTitleText)
			{
				overrideColor = SpellbladeRevised.classTextColor
			};
			tooltips.Insert(1, line);
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = Item.sellPrice(silver: 10);
			item.rare = ItemRarityID.Green;
		}
	}
}
