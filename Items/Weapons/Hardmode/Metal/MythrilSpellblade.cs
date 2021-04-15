using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpellbladeRevised.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Items.Weapons.Hardmode.Metal
{
    public class MythrilSpellblade : SpellbladeBase
    {
        protected override int additiveCritChance => 4;
        protected override int primaryDmg => 45;
        protected override float primaryKnockback => 4;
        protected override int primaryUseTime => 24;
        protected override int onHitManaRegen => ManaRegenT4;

        protected override int manaCost => 20;
        protected override int altUseTime => 25;
        protected override int projectileID => ModContent.ProjectileType<MythrilProjectile>();
        protected override int altDmg => 70;
        protected override float altKnockback => 5;
        protected override int projectileSpeed => 12;

        protected override int value => Item.sellPrice(gold:5);
        protected override int rarity => ItemRarityID.LightRed;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mythril Spellblade");
            Tooltip.SetDefault("Shoots a homing spirit");
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 48;
            item.height = 48;
        }
    }
}
