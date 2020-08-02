using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Therion.Projectiles
{
    public class TherionYoyoProjectile : ModProjectile 
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 320f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 14.5f;
        }

        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.scale = 1f;
            projectile.glowMask = TherionGlowmasks.TherionYoyo;
        }

        public override void PostAI()
        {
            if(Main.rand.Next(8) == 0)
            {

            }
        }
    }
}
