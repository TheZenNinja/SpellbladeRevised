using Microsoft.Xna.Framework;
using System;

namespace SpellbladeRevised.Assassin
{
    public class AssassinPlayer : ModPlayerBase
    {
        public override Color classTextColor => new Color(87, 3, 3);
        public override string classTitleText => "-Assassin Class-";

        public override void ResetVariables()
        {
        }
    }
}
