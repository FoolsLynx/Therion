using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Therion.Items.Weapons
{
    public class TherionDagger : TherionItem
    {
        public override void SetSafeDefaults()
        {
            item.value = Item.sellPrice(gold: 5, silver: 25);
            item.useStyle = ItemUseStyleID.Stabbing;
            item.useAnimation = 8;
            item.useTime = 10;
            item.useTurn = true;
            item.rare = ItemRarityID.LightPurple;
            item.Size = new Vector2(20, 20);
            item.UseSound = SoundID.Item1;
            item.damage = 54;
            item.knockBack = 1.5f;
            item.glowMask = TherionGlowmasks.TherionDagger;
            item.crit = 2;


            therionCost = 500;
            therionBuff = ModContent.BuffType<Buffs.TherionBurstBuff>();
            therionBuffTime = 60 * 15;
        }
    }
}
