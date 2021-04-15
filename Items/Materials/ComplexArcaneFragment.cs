using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Items.Materials
{
	/// <summary>
	/// Mechanical Bosses
	/// </summary>
	public class ComplexArcaneFragment : TempItem
	{
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			base.ModifyTooltips(tooltips);

			TooltipLine manaRestore = new TooltipLine(mod, "Tooltip0", "Arcing with arcane energy");
			tooltips.Add(manaRestore);
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			item.value = Item.sellPrice(gold:5);
			item.rare = ItemRarityID.Pink;
		}
	}
}