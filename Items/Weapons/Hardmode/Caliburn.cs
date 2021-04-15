using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using SpellbladeRevised.Items.Weapons;
using SpellbladeRevised.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Items.Weapons.Hardmode
{
    public class Caliburn : SpellbladeBase
    {
        protected override int value => Item.sellPrice(gold: 2);
        protected override int rarity => ItemRarityID.Orange;

        protected override int primaryDmg => 35;
        protected override float primaryKnockback => 4;
        protected override int primaryUseTime => 20;
        protected override int onHitManaRegen => SpellbladeBase.ManaRegenT4;

        protected override int manaCost => 5;
        protected override int altUseTime => 10;
        protected override int projectileID => ModContent.ProjectileType<CaliburnLaser>();
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2, 60);
        protected override int altDmg => 18;
        protected override float altKnockback => 3;
        protected override int projectileSpeed => 14;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Caliburn");
            Tooltip.SetDefault("Switch between a beam of holy light and normal sword with <right>.");
        }
        public override void OnLeftClick(Player player)
        {
            base.OnLeftClick(player);
            item.channel = true;
        }
        public override void OnRightClick(Player player)
        {
            base.OnRightClick(player);
            item.channel = false;
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 64;
            item.height = 64;
        }
    }
}
