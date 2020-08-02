using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Therion.Items.Accessories
{
    public class TherionBelt : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.BandofRegeneration;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases Damage for Therion items by 20%");
        }

        public override void SetDefaults()
        {
            item.Size = new Microsoft.Xna.Framework.Vector2(34);
            item.rare = ItemRarityID.LightPurple;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 5);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var therionPlayer = TherionPlayer.ModPlayer(player);
            therionPlayer.therionDamageMult *= 1.2f;
        }
    }
}
