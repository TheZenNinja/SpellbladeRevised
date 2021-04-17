using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpellbladeRevised
{
	public abstract class ModPlayerBase : ModPlayer
    {
		public abstract Color classTextColor { get; }
		public abstract string classTitleText { get; }
    }
}
