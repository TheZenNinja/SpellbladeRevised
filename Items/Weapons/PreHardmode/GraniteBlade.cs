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
using Terraria.ModLoader;
using SpellbladeRevised.Projectiles;

namespace SpellbladeRevised.Items.Weapons.PreHardmode
{
    public class GraniteBlade : SpellbladeBase
    {
        protected override int value => Item.sellPrice(gold: 2);
        protected override int rarity => ItemRarityID.Orange;
        protected override int primaryDmg => 25;
        protected override float primaryKnockback => 4;
        protected override int primaryUseTime => 20;
        protected override int onHitManaRegen => SpellbladeBase.ManaRegenT3;

        protected override int manaCost => 24;
        protected override int altUseTime => 4;
        protected override int castUseAnimationTime => 45;
        protected override int projectileID => 0;
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2, 92);
        protected override int altDmg => 40;
        protected override float altKnockback => 3;
        protected override int projectileSpeed => 35;

        public static short customGlowMask = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Spellblade");
            Tooltip.SetDefault("Shoots a demonic scythe with <right>.");
            customGlowMask = SpellbladeRevised.SetStaticDefaultsGlowMask(this);
        }

        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.width = 48;
            item.height = 48;
            item.glowMask = customGlowMask;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Items/Weapons/PreHardmode/GraniteGlow");
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width * 0.5f,
					item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale,
				SpriteEffects.None,
				0f
			);
		}

        public override void OnLeftClick(Player player)
        {
            base.OnLeftClick(player);

            Vector2 dir = Vector2.Normalize(Main.MouseWorld - player.position);
            Vector2 pos = SpellbladeRevised.RaycastToPosition(player.position, player.Size, player.position + dir * 16 * 64, player.Size);
            Main.PlaySound(primarySound, player.position);

            player.direction = dir.X > 0 ? 1 : -1;
            player.position = pos;
            if (player.whoAmI == Main.myPlayer)
                Main.SetCameraLerp(0.1f, 30);

            int id = Projectile.NewProjectile(player.position, dir * -projectileSpeed, ProjectileID.DD2SquireSonicBoom, altDmg, altKnockback, Main.myPlayer);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return false;
        }
    }
}
