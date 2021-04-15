using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using SpellbladeRevised.Tiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Items.Materials
{
    public class ArcaneCore : TempItem
    {
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			base.ModifyTooltips(tooltips);

			TooltipLine manaRestore = new TooltipLine(mod, "Tooltip0", "Faintly glows with arcane energy");
			tooltips.Add(manaRestore);
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.Green;
		}
    }
}
