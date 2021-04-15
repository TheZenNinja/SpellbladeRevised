using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using SpellbladeRevised.Projectiles;
using SpellbladeRevised.Minions;
using SpellbladeRevised.Buffs;

namespace SpellbladeRevised.Items.Weapons.PreHardmode.Wooden
{
    public class BorealBuff : DaggerBuffBase { }
    public class BorealMinion : SpelldaggerMinionBase { }
    public class BorealProjectile : SpelldaggerProjectileBase { }
    public class BorealDagger : SpelldaggerBase
    {
        protected override int value => Item.sellPrice(copper: 50);
		protected override int rarity => ItemRarityID.White;

        protected override int primaryDmg => 8;
        protected override float primaryKnockback => 4;
        protected override int primaryUseTime => 26;
        public override float projPrimarySpeed => projectileSpeed[0];
        protected override int onHitManaRegen => ManaRegen[0];

        protected override int manaCost => 5;
        protected override int altUseTime => 26;
        protected override int altDmg => 4;
        protected override float altKnockback => 4;
        
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Chilled, Main.rand.Next(30, 60));
            base.OnHitNPC(player, target, damage, knockBack, crit);
        }
    }
}
