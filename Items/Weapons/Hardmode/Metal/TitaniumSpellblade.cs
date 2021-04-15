using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpellbladeRevised.Projectiles;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Items.Weapons.Hardmode.Metal
{
    public class TitaniumSpellblade : SpellbladeBase
    {
        protected override int additiveCritChance => 4;
        protected override int primaryDmg => 45;
        protected override float primaryKnockback => 6;
        protected override int primaryUseTime => 25;
        protected override int onHitManaRegen => ManaRegenT4;

        protected override int manaCost => 8;
        protected override int altUseTime => 4;
        protected override int projectileID => ModContent.ProjectileType<CustomSkyFracture>();
        protected override int altDmg => 25;
        protected override float altKnockback => 2;
        protected override int projectileSpeed => 15;

        protected override int value => Item.sellPrice(gold: 3);
        protected override int rarity => ItemRarityID.LightRed;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Titanium Spellblade");
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
            int radius = 16 * 16;
            Vector2 mousePosition = Main.MouseWorld;

            double angle = Main.rand.NextDouble() * 360;
            Vector2 randPos = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            Vector2 pos = randPos * radius + mousePosition;

            Vector2 velDir = Vector2.Normalize(mousePosition - pos);

            int id = Projectile.NewProjectile(pos, velDir * projectileSpeed, projectileID, altDmg, altKnockback, Main.myPlayer, 1);
            Main.projectile[id].timeLeft = 30;
            return false;
        }
    }
}
