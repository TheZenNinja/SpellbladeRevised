using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Minions
{
    public abstract class MinionBase : ModProjectile
	{
		public override void AI()
		{
			CheckActive();
			Behavior();
		}
		public abstract void CheckActive();
		public abstract void Behavior();
		public virtual void IdleBehavior() { }
		public virtual void AttackBehavior() { }
	}
}