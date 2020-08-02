using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Therion.Projectiles;

namespace Therion.Items.Weapons
{
    public class TherionYoyo : TherionItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
        }

        public override void SetSafeDefaults()
        {
            item.value = Item.sellPrice(gold: 5, silver: 25);
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 20;
            item.useTime = 20;
            item.rare = ItemRarityID.LightPurple;
            item.Size = new Vector2(24);
            item.UseSound = SoundID.Item1;
            item.damage = 65;
            item.knockBack = 1.5f;
            item.crit = 3;

            item.channel = true;
            item.noMelee = true;
            item.noUseGraphic = true;

            item.shootSpeed = 18f;
            item.shoot = ModContent.ProjectileType<TherionYoyoProjectile>();

            therionCost = 500;
            therionBuff = ModContent.BuffType<Buffs.TherionFocusBuff>();
            therionBuffTime = 60 * 15;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1 && base.CanUseItem(player);
        }
    }
}
