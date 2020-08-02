using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Therion.Projectiles;

namespace Therion.Items.Weapons
{
    public class TherionScythe : TherionItem
    {
        public override void SetSafeDefaults()
        {
            item.value = Item.sellPrice(gold: 5, silver: 25);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.useTime = 22;
            item.autoReuse = true;
            item.useTurn = true;
            item.rare = ItemRarityID.LightPurple;
            item.Size = new Vector2(30, 30);
            item.UseSound = SoundID.Item1;
            item.damage = 65;
            item.knockBack = 3.5f;
            item.crit = 4;
            item.glowMask = TherionGlowmasks.TherionScythe;

            item.shoot = ModContent.ProjectileType<TherionScytheProjectile>();
            item.shootSpeed = 8f;

            therionCost = 500;
            therionBuff = ModContent.BuffType<Buffs.TherionBurstBuff>();
            therionBuffTime = 60 * 15;
        }
    }
}
