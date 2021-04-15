using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Items.Materials
{
	/// <summary>
	/// Starter Material
	/// </summary>
	public class LesserArcaneFragment : TempItem
	{
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			base.ModifyTooltips(tooltips);

			TooltipLine manaRestore = new TooltipLine(mod, "Tooltip0", "Faintly hums with arcane energy");
			tooltips.Add(manaRestore);
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			item.value = Item.sellPrice(silver:10);
			item.rare = ItemRarityID.White;
		}
	}
}