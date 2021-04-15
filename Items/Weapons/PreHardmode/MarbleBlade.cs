using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;

namespace SpellbladeRevised.Items.Weapons.PreHardmode
{
    public class MarbleBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(gold: 2);
        protected override int rarity => ItemRarityID.Orange;
        protected override int primaryDmg => 25;
        protected override float primaryKnockback => 4;
        protected override int primaryUseTime => 20;
        protected override int onHitManaRegen => SpellbladeBase.ManaRegenT3;

        protected override int manaCost => 30;
        protected override int altUseTime => 18;
        protected override int projectileID => ProjectileID.JavelinFriendly;
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2, 8);
        protected override int altDmg => 30;
        protected override float altKnockback => 3;
        protected override int projectileSpeed => 12;

        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Marble Spellblade");
            Tooltip.SetDefault("Launches a volley of javelins with <right>.");
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 48;
            item.height = 48;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int i = 0; i < 8; i++)
            {
                Vector2 randPos = new Vector2(Main.rand.Next(-32, 32), Main.rand.Next(-16, 16));
                Vector2 rotation = Vector2.Normalize(Main.MouseWorld - player.position);
                //rotation *= player.direction;
                float speed = projectileSpeed * MathHelper.Clamp((float)Main.rand.NextDouble() + 0.5f, 0.8f, 1.2f);

                Projectile.NewProjectile(player.position + new Vector2(-player.direction * 16, 0) + randPos, rotation * speed, projectileID, altDmg, altKnockback, Main.myPlayer);
            }

            return false;
        }
    }
}
