using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using SpellbladeRevised.Projectiles;
using SpellbladeRevised.Minions;
using SpellbladeRevised.Buffs;
using Microsoft.Xna.Framework.Graphics;

namespace SpellbladeRevised.Items.Weapons.PreHardmode.Wooden
{
    public class DynastyBuff : DaggerBuffBase { }
    public class DynastyMinion : SpelldaggerMinionBase
    {
        public override float scale => 1;
        protected override float minionCapacity => .5f;
        public override string Texture => "Terraria/Item_" + ItemID.Shuriken;
        public override void SetAttackRotation()
        {
            projectile.rotation -= 0.5f;
        }
        public override void SetIdleRotation()
        {
            projectile.rotation -= .1f;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (projectile.spriteDirection == -1)
                spriteEffects = SpriteEffects.FlipHorizontally;

            Texture2D texture = Main.projectileTexture[projectile.type];
            Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            Vector2 origin = sourceRectangle.Size() / 2;
            origin.X = projectile.spriteDirection == 1 ? (float)sourceRectangle.Width / 2 : 0;

            Main.spriteBatch.Draw
            (
                texture,
                projectile.Center - Main.screenPosition,
                sourceRectangle,
                lightColor,
                projectile.rotation,
                origin,
                projectile.scale,
                spriteEffects,
                0
            );

            return false;
        }
    }
    public class DynastyProjectile : SpelldaggerProjectileBase { }
    public class DynastyDagger : SpelldaggerBase
    {
        protected override int width => 32;
        protected override int height => 32;
        protected override int value => Item.sellPrice(gold: 1);
        protected override int rarity => ItemRarityID.Green;

        protected override int additiveCritChance => 16;
        protected override int primaryDmg => 16;
        protected override float primaryKnockback => 4;
        protected override int primaryUseTime => 16;
        public override float projPrimarySpeed => projectileSpeed[1];
        protected override int onHitManaRegen => ManaRegen[0];

        protected override int manaCost => 10;
        protected override int altUseTime => 20;
        protected override LegacySoundStyle primarySound => new LegacySoundStyle(2, 19);
        protected override int altDmg => 12;
        protected override float altKnockback => 4;
        public override int minionCount => 2;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dynasty Kunai");
            Tooltip.SetDefault("Many shinobi trained with this sword");
        }
    }
}
