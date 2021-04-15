using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using SpellbladeRevised.Projectiles;

namespace SpellbladeRevised.Items.Weapons.PreHardmode
{
    //public class ObsidianProjectile : SpelldaggerProjectileBase
    //{
    //}
    public class ObsidianBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(gold: 2);
        protected override int rarity => ItemRarityID.Orange;
        protected override int primaryDmg => 25;
        protected override float primaryKnockback => 4;
        protected override int primaryUseTime => 20;
        protected override int onHitManaRegen => SpellbladeBase.ManaRegenT3;

        protected override int manaCost => 24;
        protected override int altUseTime => 18;
        protected override int projectileID => ProjectileID.DemonScythe;
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2,8);
        protected override int altDmg => 30;
        protected override float altKnockback => 3;
        protected override int projectileSpeed => 20;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Obsidian Spellblade");
            Tooltip.SetDefault("Shoots a demonic scythe");
        }
        public override void OnRightClick(Player player)
        {
            base.OnRightClick(player);
            //item.shoot = swingProjectileID;
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 48;
            item.height = 48;
        }
    }
}
