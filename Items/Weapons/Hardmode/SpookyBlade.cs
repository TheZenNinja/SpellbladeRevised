using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Items.Weapons.Hardmode
{
    public class SpookyBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(gold: 1);
        protected override int rarity => ItemRarityID.Yellow;

        protected override int primaryDmg => 60;
        protected override float primaryKnockback => 6;
        protected override int primaryUseTime => 24;
        protected override int onHitManaRegen => ManaRegenT2;

        protected override int manaCost => 16;
        protected override int altUseTime => 16;
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2, 5);
        protected override int projectileID => ProjectileID.FlamingWood;
        protected override int altDmg => 75;
        protected override float altKnockback => 4;
        protected override int projectileSpeed => 18;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spookywood Spellblade");
            Tooltip.SetDefault("Holy wood overrun by crystals");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 dir = Vector2.Normalize(Main.MouseWorld - player.itemLocation);
            int id = Projectile.NewProjectile(player.itemLocation, dir * projectileSpeed, projectileID, altDmg, altKnockback, player.whoAmI);
            Main.projectile[id].friendly = true;
            Main.projectile[id].hostile = false;
            return false;
        }
    }
}
