using Terraria.ID;


namespace SpellbladeRevised.Technomancer.Projectiles
{
    public class TestProjectile : BaseProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.Bullet;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Technomancer Bullet");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Bullet);
            aiType = ProjectileID.Bullet;
        }
    }
}