using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Therion.Projectiles
{
    public class TherionScytheProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Size = new Vector2(46, 54);
            projectile.friendly = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 240;
            projectile.penetrate = 10;
            projectile.glowMask = TherionGlowmasks.TherionScythe;
        }

        public override void AI()
        {
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 30f)
            {
                if (projectile.ai[0] < 100f)
                {
                    projectile.velocity *= 1.09f;
                }
                else
                {
                    projectile.ai[0] = 200f;
                }
            }
            for (var k = 0; k < 2; k++)
            {
                var dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1f);
                Main.dust[dust].noGravity = true;
            }
            projectile.rotation += (float)projectile.direction * 0.3f;
            projectile.velocity *= 0.95f;
        }
    }
}
