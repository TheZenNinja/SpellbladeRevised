using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpellbladeRevised.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Items.Weapons.Hardmode.Metal
{
    public class AdamantiteSpellblade : SpellbladeBase
    {
        protected override int additiveCritChance => 4;
        protected override int primaryDmg => 45;
        protected override float primaryKnockback => 6;
        protected override int primaryUseTime => 25;
        protected override int onHitManaRegen => ManaRegenT4;

        protected override int manaCost => 10;
        protected override int altUseTime => 6;
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2,39);
        protected override int projectileID => ProjectileID.AdamantiteGlaive;
        protected override int altDmg => 45;
        protected override float altKnockback => 2;
        protected override int projectileSpeed => 12;
        protected override int projectileSpread => 15;

        protected override int value => Item.sellPrice(gold: 3);
        protected override int rarity => ItemRarityID.LightRed;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adamantite Spellblade");
            Tooltip.SetDefault("Rapidly send out spears with <right>.");
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 48;
            item.height = 48;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            // Fix the speedX and Y to point them horizontally.
            speedX = new Vector2(speedX, speedY).Length() * (speedX > 0 ? 1 : -1);
            speedY = 0;

            // Add random Rotation
            Vector2 speed = new Vector2(speedX, speedY);
            speed = speed.RotatedBy(player.itemRotation);
            speed = speed.RotatedByRandom(MathHelper.ToRadians(projectileSpread));

            damage = altDmg;
            speedX = speed.X;
            speedY = speed.Y;

            int id = Projectile.NewProjectile(position, new Vector2(speedX, speedY), projectileID, damage, knockBack, player.whoAmI);
            Main.projectile[id].timeLeft = 15;
            return false;
        }
    }
}
