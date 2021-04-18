using Terraria.ID;
using Terraria.ModLoader;


namespace SpellbladeRevised.Technomancer.Minions
{
    public class TechnoMinionBase : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.UFOMinion;
        public int lifetime
        {
            get => (int)projectile.ai[0];
            set => projectile.ai[0] = value;
        }

        public int maxLifetime = 60 * 15;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Techno Minion");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.UFOMinion);
            aiType = ProjectileID.UFOMinion;
            lifetime = 0;
        }
        public override void AI()
        {
            base.AI();
            lifetime++;
            if (lifetime > maxLifetime)
                Kill(0);
        }

    }
}
