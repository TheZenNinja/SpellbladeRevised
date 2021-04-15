using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;

namespace SpellbladeRevised.Items.Weapons
{
    public abstract class SpellstaffBase : WeaponBase
    {
        public override int[] ManaRegen { get; } = new int[]
            {
                2,
                3,
                4,
                6,
                8,
                10,
                12,
                20,
            };
        public enum StaffAttackType
        {
            spear = 0,
            spinOnce = 1,
            spinHold = 2,
            rapidJab = 3,
            arcStab = 4,
        }
        
        protected virtual int staffID => mod.ProjectileType(GetStaffID());
        protected string GetStaffID() => GetType().Name.Replace("Spellstaff", "SpellstaffProj");
        protected string GetSpearID() => GetType().Name.Replace("Spellstaff", "SpellspearProj");
        protected virtual float primaryShootSpeed { get; } = 10;
        public virtual StaffAttackType primaryAttackType { get; } = StaffAttackType.spear;

        protected virtual int spearID => mod.ProjectileType(GetSpearID());
        protected virtual float altShootSpeed { get; } = 10;
        public virtual StaffAttackType altAttackType { get; } = StaffAttackType.spinOnce;

        public override void ModifyWeaponDamage(Player player, ref float add, ref float multi, ref float flat)
        {
            float magicDmg = MathHelper.Clamp(player.magicDamage * .75f, 0, float.MaxValue);
            float meleeDmg = MathHelper.Clamp(player.meleeDamage * .25f, 0, float.MaxValue);
            add = magicDmg + meleeDmg;
            float magicMulit = MathHelper.Clamp(player.magicDamageMult * .75f, 0, float.MaxValue);
            float meleeMulti = MathHelper.Clamp(player.meleeDamageMult * .25f, 0, float.MaxValue);
            multi = magicMulit + meleeMulti;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.ownedProjectileCounts[staffID] > 0 || player.ownedProjectileCounts[spearID] > 0)
                return false;
            return base.CanUseItem(player);
        }
        public override void OnLeftClick(Player player)
        {
            base.OnLeftClick(player);
            item.mana = manaCost;
        }
        public override void OnRightClick(Player player)
        {
            base.OnRightClick(player);
            item.mana = 0;
        }
        public override void SetDefaults()
        {
            SetBasicCustomDefaults();
            item.shoot = staffID;
            item.noUseGraphic = true; 
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.channel = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 dir = Vector2.Normalize(Main.MouseWorld - player.position);

            if (player.altFunctionUse == 2)
            {
                switch (altAttackType)
                {
                    default:
                    case StaffAttackType.spear:
                    case StaffAttackType.rapidJab:
                    case StaffAttackType.arcStab:
                        Projectile.NewProjectile(position, dir * altShootSpeed, spearID, altDmg, altKnockback, player.whoAmI, onHitManaRegen, 0);
                        break;
                    case StaffAttackType.spinOnce:
                    case StaffAttackType.spinHold:
                        Projectile.NewProjectile(position, dir * altShootSpeed, staffID, altDmg, altKnockback, player.whoAmI, onHitManaRegen, 0);
                        break;
                }
            }
            else
                switch (primaryAttackType)
                {
                    default:
                    case StaffAttackType.spear:
                    case StaffAttackType.rapidJab:
                    case StaffAttackType.arcStab:
                        Projectile.NewProjectile(position, dir * primaryShootSpeed, spearID, primaryDmg, primaryKnockback, player.whoAmI, onHitManaRegen);
                        break;
                    case StaffAttackType.spinOnce:
                        Projectile.NewProjectile(position, dir * primaryShootSpeed, staffID, primaryDmg, primaryKnockback, player.whoAmI, onHitManaRegen, 0);
                        break;
                    case StaffAttackType.spinHold:
                        Projectile.NewProjectile(position, dir * primaryShootSpeed, staffID, primaryDmg, primaryKnockback, player.whoAmI, onHitManaRegen, 1);
                        break;
                }

            return false;
        }
    }
}
