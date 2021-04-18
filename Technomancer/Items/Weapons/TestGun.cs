using Microsoft.Xna.Framework;
using SpellbladeRevised.Technomancer.Projectiles;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Technomancer.Items.Weapons
{
    public class TestGun : TechnomancerGunBase
    {
        public override string Texture => "Terraria/Item_" + ItemID.VortexBeater;
        public override Vector2? HoldoutOffset() => new Vector2(0, 0);
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.width = 20;
            item.height = 12;

            item.useTime = 10;
            item.useAnimation = 10;
            item.reuseDelay = 15;
            item.knockBack = 4f;

            item.shoot = ModContent.ProjectileType<TestProjectile>();
            item.shootSpeed = 20;
            item.damage = 50;
            item.mana = 10;

            item.UseSound = new LegacySoundStyle(2, 114);
        }
    }
}
