using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace SpellbladeRevised.Items.Weapons.PreHardmode
{
    class AmberBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(silver: 30);
        protected override int rarity => ItemRarityID.Green;

        protected override int primaryDmg => 12;
        protected override float primaryKnockback => 4.5f;
        protected override int primaryUseTime => 20;
        protected override int onHitManaRegen => ManaRegenT2;

        protected override int manaCost => 12;
        protected override int altUseTime => 45;
        protected override int castUseStyle => ItemUseStyleID.HoldingUp;
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2, 9);
        protected override int projectileID => ProjectileID.SandnadoFriendly;
        protected override int altDmg => 6;
        protected override float altKnockback => 3;
        protected override int projectileSpeed => 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amber Spellblade");
            Tooltip.SetDefault("Summon a sandstorm with <right>.");
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 48;
            item.height = 48;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 mousePosition = Main.MouseWorld;

            int id = Projectile.NewProjectile(mousePosition, Vector2.Zero, projectileID, altDmg, altKnockback, Main.myPlayer);
            Main.projectile[id].timeLeft = 60;
            return false;
        }
    }
}
