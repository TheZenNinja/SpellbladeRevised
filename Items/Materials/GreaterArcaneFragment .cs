using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Items.Materials
{
	/// <summary>
	/// Early hardmode
	/// </summary>
	public class GreaterArcaneFragment : TempItem
	{
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			base.ModifyTooltips(tooltips);

			TooltipLine manaRestore = new TooltipLine(mod, "Tooltip0", "Radiates arcane energy");
			tooltips.Add(manaRestore);
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			item.value = Item.sellPrice(gold:1);
			item.rare = ItemRarityID.LightRed;
		}
	}
}