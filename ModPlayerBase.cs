using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpellbladeRevised
{
	public abstract class ModPlayerBase : ModPlayer
    {
		public abstract Color classTextColor { get; }
		public abstract string classTitleText { get; }

        public override void ResetEffects() => ResetVariables();
        public override void UpdateDead() => ResetVariables();

        public abstract void ResetVariables();
    }
}
