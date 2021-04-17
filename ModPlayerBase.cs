using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised
{
	public abstract class ModPlayerBase : ModPlayer
    {
		public abstract Color classTextColor { get; }
		public abstract string classTitleText { get; }
    }
}
