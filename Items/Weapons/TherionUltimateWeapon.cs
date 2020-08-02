using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Therion.Items.Weapons
{
    public class TherionUltimateWeapon : TherionItem
    {
        public override void SetSafeDefaults()
        {
            item.value = Item.sellPrice(platinum: 1);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.useTime = 22;
            item.autoReuse = true;
            item.useTurn = true;
            item.rare = ItemRarityID.LightPurple;
            item.Size = new Vector2(30, 30);
            item.UseSound = SoundID.Item1;
            item.damage = 195;
            item.knockBack = 4.5f;
            item.glowMask = TherionGlowmasks.TherionUltimateWeapon;
            item.crit = 5;


            therionCost = 2000;
            therionBuff = ModContent.BuffType<Buffs.TherionUltimateBuff>();
            therionBuffTime = 60 * 15;
        }
    }
}
