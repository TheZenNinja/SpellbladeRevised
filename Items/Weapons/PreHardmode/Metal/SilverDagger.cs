using Microsoft.Xna.Framework;
using SpellbladeRevised.Projectiles;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using SpellbladeRevised.Buffs;
using SpellbladeRevised.Minions;

namespace SpellbladeRevised.Items.Weapons.PreHardmode.Metal
{
    public class SilverBuff : DaggerBuffBase { }
    public class SilverMinion : SpelldaggerMinionBase 
    {
        protected override float minionCapacity => .25f;
    }
    public class SilverProjectile : SpelldaggerProjectileBase { }
    public class SilverDagger : SpelldaggerBase
    {
        protected override int width => 32;
        protected override int height => 32;
        protected override int value => Item.sellPrice(silver: 25);
        protected override int rarity => ItemRarityID.Blue;

        protected override int primaryDmg => 10;
        protected override float primaryKnockback => 4f;
        protected override int primaryUseTime => 22;
        public override float projPrimarySpeed => projectileSpeed[1];
        protected override int onHitManaRegen => ManaRegen[1];
        protected override int manaCost => 12;

        protected override int altUseTime => 20;
        protected override int altDmg => 20;
        protected override float altKnockback => 3;
        public override int minionCount => 4;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver Spellblade");
        }
    }
}
