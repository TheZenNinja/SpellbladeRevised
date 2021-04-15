using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using SpellbladeRevised.Buffs;
using Microsoft.Xna.Framework.Graphics;

namespace SpellbladeRevised.Items.Weapons
{
    public abstract class SpelldaggerBase : WeaponBase
    {
        protected static int[] projectileSpeed = new int[]
        {
            12,
            16,
            20,
            24,
        };

        protected override string GetName() => GetType().Name.Replace("Dagger", " Dagger");
        public virtual int minionCount { get; } = 1;
        public virtual bool useGrav { get; } = true;
        public virtual float projPrimarySpeed { get; } = projectileSpeed[0];
        public virtual float primarySpread { get; } = 5;
        protected override int height => 32;
        protected override int width => 32;

        protected virtual int throwID => mod.ProjectileType(GetProjectileID());
        protected string GetProjectileID() => GetType().Name.Replace("Dagger", "Projectile");
        protected virtual int minionID => mod.ProjectileType(GetSummonID());
        protected string GetSummonID() => GetType().Name.Replace("Dagger", "Minion");
        protected virtual int buffID => mod.BuffType(GetBuffID());
        protected string GetBuffID() => GetType().Name.Replace("Dagger", "Buff");

        public override void ModifyWeaponDamage(Player player, ref float add, ref float multi, ref float flat)
        {
            float magicDmg = MathHelper.Clamp(player.magicDamage * .75f, 0, float.MaxValue);
            float minionDmg = MathHelper.Clamp(player.minionDamage * .25f, 0, float.MaxValue);
            add = magicDmg + minionDmg;
            float magicMulit = MathHelper.Clamp(player.magicDamageMult * .75f, 0, float.MaxValue);
            float minionMulti = MathHelper.Clamp(player.minionDamageMult * .25f, 0, float.MaxValue);
            multi = magicMulit + minionMulti;
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.shoot = minionID;
            item.shootSpeed = projPrimarySpeed;
            item.shoot = throwID;
            item.noUseGraphic = true;
            item.mana = manaCost;
            item.width = width;
            item.height = height;
        }
		public override bool AltFunctionUse(Player player) => true;
        public override bool CanUseItem(Player player)
        {
            var sp = player.GetModPlayer<SpellbladePlayer>();
            //Main.NewText($"{sp.daggerCount}/{sp.daggerCountMax}");
            if (player.altFunctionUse == 2)
            {
                OnRightClick(player);
                return TryToSummon(player);
            }
            else
            {
                OnLeftClick(player);
                return true;
            }
        }
        public override void OnLeftClick(Player player)
        {
            base.OnLeftClick(player);
            item.shoot = throwID;
            item.mana = 0;
        }
        //public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        //{
        //    if (player.altFunctionUse == 1)
        //    {
        //        int mana = (int)Math.Round((float)damage / primaryDmg * onHitManaRegen);
        //        player.statMana += mana;
        //        if (player.whoAmI == Main.myPlayer && mana > 0)
        //            player.ManaEffect(mana);
        //    }
        //    base.OnHitNPC(player, target, damage, knockBack, crit);
        //}
        public bool TryToSummon(Player player)
        {
            player.AddBuff(buffID, 60);
            for (int i = 0; i < minionCount; i++)
            {
                //Main.NewText($"Summon Minion {i + 1}");
                var p = Projectile.NewProjectileDirect(player.position - new Vector2(0, 32), Vector2.Zero, minionID, GetAltDamage(player), altKnockback, player.whoAmI);
                Main.NewText($"OnSpawn: {p.whoAmI}");
            }
            return true;
        }
        public override void OnRightClick(Player player)
        {
            base.OnRightClick(player);
            item.shoot = ProjectileID.None;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 dir = Vector2.Normalize(Main.MouseWorld - player.position);
            dir.RotatedByRandom(MathHelper.ToRadians(primarySpread));
            Projectile.NewProjectile(player.itemLocation, dir * projPrimarySpeed, throwID, GetPrimaryDamage(player), primaryKnockback, player.whoAmI, onHitManaRegen);
            return false;
        }
    }
}
