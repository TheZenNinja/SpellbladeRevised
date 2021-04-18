using Terraria;
using Terraria.ModLoader;


namespace SpellbladeRevised.Technomancer.Projectiles
{
    public abstract class BaseProjectile : ModProjectile
    {
        public Player getPlayer()
        {
            Player p = Main.player[projectile.owner];
            return p;
        }
        public override void SetDefaults()
        {
            projectile.ranged = false;
            projectile.melee = false;
            projectile.magic = false;
            projectile.minion = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            getPlayer().GetModPlayer<TechnomancerPlayer>().TryToGainStacks();
        }
    }
}
