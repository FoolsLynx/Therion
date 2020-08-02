using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Therion.Projectiles;

namespace Therion.Items.Weapons
{
    public class TherionSpear : TherionItem
    {
        public override void SetSafeDefaults()
        {
            item.value = Item.sellPrice(gold: 20);
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 16;
            item.useTime = 20;
            item.autoReuse = true;
            item.useTurn = false;
            item.rare = ItemRarityID.LightPurple;
            item.Size = new Vector2(12, 30);
            item.UseSound = SoundID.Item1;
            item.damage = 65;
            item.knockBack = 6.5f;
            item.crit = 3;
            item.shootSpeed = 3.9f;
            item.shoot = ModContent.ProjectileType<TherionSpearProjectile>();
            item.noMelee = true;
            item.noUseGraphic = true;

            therionCost = 500;
            therionBuff = ModContent.BuffType<Buffs.TherionBurstBuff>();
            therionBuffTime = 60 * 15;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1 && base.CanUseItem(player);
        }
    }
}
