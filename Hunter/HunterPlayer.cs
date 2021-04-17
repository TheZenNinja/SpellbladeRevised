using Microsoft.Xna.Framework;
using System;

namespace SpellbladeRevised.Hunter
{
    public class HunterPlayer : ModPlayerBase
    {
        public override Color classTextColor => new Color(18, 107, 0);
        public override string classTitleText => "-Hunter Class-";

        public override void ResetVariables()
        {
        }
    }
}
