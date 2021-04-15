using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Items.Materials
{
	/// <summary>
	/// Lunar Fragments
	/// </summary>
	public class CelestialArcaneFragment : TempItem
	{
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			base.ModifyTooltips(tooltips);

			TooltipLine manaRestore = new TooltipLine(mod, "Tooltip0", "Vibrates in tune with reality");
			tooltips.Add(manaRestore);
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			item.value = Item.sellPrice(gold:5);
			item.rare = ItemRarityID.Red;
		}
	}
}