using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Therion
{
    public static class TherionGlowmasks
    {
        public static short TherionBlade;
        public static short TherionBow;
        public static short TherionDagger;
        public static short TherionYoyo;
        public static short TherionGun;
        public static short TherionScythe;
        public static short TherionSpear;
        public static short TherionFlail;




        public static short TherionClaw;
        public static short TherionUltimateWeapon;


        private const short COUNT = 20;
        private static short _end;

        public static bool Loaded;

        public static void Load()
        {
            Array.Resize(ref Main.glowMaskTexture, Main.glowMaskTexture.Length + COUNT);

            short i = (short)(Main.glowMaskTexture.Length - COUNT);

            TherionBlade = i++;
            Main.glowMaskTexture[TherionBlade] = ModContent.GetTexture("Therion/Items/Weapons/TherionBlade_Glow");
            TherionBow = i++;
            Main.glowMaskTexture[TherionBow] = ModContent.GetTexture("Therion/Items/Weapons/TherionBow_Glow");
            TherionDagger = i++;
            Main.glowMaskTexture[TherionDagger] = ModContent.GetTexture("Therion/Items/Weapons/TherionDagger_Glow");
            TherionYoyo = i++;
            Main.glowMaskTexture[TherionYoyo] = ModContent.GetTexture("Therion/Projectiles/TherionYoyoProjectile_Glow");
            TherionSpear = i++;
            Main.glowMaskTexture[TherionSpear] = ModContent.GetTexture("Therion/Projectiles/TherionSpearProjectile_Glow");
            TherionFlail = i++;
            Main.glowMaskTexture[TherionFlail] = ModContent.GetTexture("Therion/Projectiles/TherionFlailProjectile_Glow");
            TherionScythe = i++;
            Main.glowMaskTexture[TherionScythe] = ModContent.GetTexture("Therion/Items/Weapons/TherionScythe_Glow");
            TherionGun = i++;
            Main.glowMaskTexture[TherionGun] = ModContent.GetTexture("Therion/Items/Weapons/TherionGun_Glow");

            TherionClaw = i++;
            Main.glowMaskTexture[TherionClaw] = ModContent.GetTexture("Therion/Items/Weapons/TherionClaw_Glow");
            TherionUltimateWeapon = i++;
            Main.glowMaskTexture[TherionUltimateWeapon] = ModContent.GetTexture("Therion/Items/Weapons/TherionUltimateWeapon_Glow");


            _end = i;
            Loaded = true;
        }

        public static void Unload()
        {
            if(Loaded)
            {
                Main.glowMaskTexture[TherionBlade] = null;

                if(Main.glowMaskTexture.Length == _end)
                {
                    Array.Resize(ref Main.glowMaskTexture, Main.glowMaskTexture.Length - COUNT);
                }
                Loaded = false;

                TherionBlade = 0;
                TherionBow = 0;
                TherionDagger = 0;
                TherionYoyo = 0;
                TherionSpear = 0;
                TherionFlail = 0;
                TherionScythe = 0;
                TherionGun = 0;

                TherionClaw = 0;
                TherionUltimateWeapon = 0;

                _end = 0;
            }
        }
    }
}
