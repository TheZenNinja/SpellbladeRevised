using Terraria.ModLoader;

namespace SpellbladeRevised
{
    public abstract class ModPlayerBase : ModPlayer
    {

        public override void ResetEffects() => ResetVariables();
        public override void UpdateDead() => ResetVariables();

        public abstract void ResetVariables();
    }
}
