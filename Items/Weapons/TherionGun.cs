using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Therion.Projectiles;

namespace Therion.Items.Weapons
{
    public class TherionGun : TherionItem
    {
        public override void SetSafeDefaults()
        {
            item.value = Item.sellPrice(gold: 5, silver: 25);
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 22;
            item.autoReuse = true;
            item.rare = ItemRarityID.LightPurple;
            item.Size = new Vector2(30, 30);
            item.UseSound = SoundID.Item1;
            item.damage = 65;
            item.knockBack = 3.5f;
            item.glowMask = TherionGlowmasks.TherionGun;
            item.crit = 4;

            item.noMelee = true;
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 8f;

            item.useAmmo = AmmoID.Bullet;

            therionCost = 500;
            therionBuff = ModContent.BuffType<Buffs.TherionBurstBuff>();
            therionBuffTime = 60 * 15;
        }

        public override Vector2? HoldoutOffset()
        {
            return Vector2.Zero;
        }
    }
}
