using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Therion.Items.Weapons
{
    public class TherionClaw : TherionItem
    {
        public override void SetSafeDefaults()
        {
            item.value = Item.sellPrice(gold: 20);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 8;
            item.useTime = 12;
            item.autoReuse = true;
            item.useTurn = true;
            item.rare = ItemRarityID.LightPurple;
            item.Size = new Vector2(30, 30);
            item.UseSound = SoundID.Item1;
            item.damage = 125;
            item.knockBack = 1.5f;
            item.glowMask = TherionGlowmasks.TherionClaw;
            item.crit = 6;


            therionCost = 750;
            therionBuff = ModContent.BuffType<Buffs.LethalPainBuff>();
            therionBuffTime = 60 * 30;
        }
    }
}
