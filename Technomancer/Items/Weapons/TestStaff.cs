using SpellbladeRevised.Technomancer.Minions;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpellbladeRevised.Technomancer.Items.Weapons
{
    public class TestStaff : TechnomancerStaffBase
    {
        public override int MinionProjectileID => ModContent.ProjectileType<TechnoMinionBase>();

        public override string Texture => "Terraria/Item_" + ItemID.DeadlySphereStaff;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Test Staff");
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.damage = 10;
            item.knockBack = 3f;
            item.width = 32;
            item.height = 32;
            item.useTime = 45;
            item.useAnimation = 45;
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item44;
        }
    }
}
