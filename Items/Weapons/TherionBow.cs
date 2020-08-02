using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Therion.Items.Weapons
{
    public class TherionBow : TherionItem
    {
        public override void SetSafeDefaults()
        {
            item.value = Item.sellPrice(gold: 20);
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 13;
            item.useTime = 16;
            item.autoReuse = true;
            item.useTurn = false;
            item.rare = ItemRarityID.LightPurple;
            item.Size = new Vector2(12, 30);
            item.UseSound = SoundID.Item5;
            item.damage = 65;
            item.knockBack = 1.5f;
            item.glowMask = TherionGlowmasks.TherionBow;
            item.crit = 3;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 18f;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.noMelee = true;


            therionCost = 500;
            therionBuff = ModContent.BuffType<Buffs.TherionFocusBuff>();
            therionBuffTime = 60 * 15;
        }
    }
}
