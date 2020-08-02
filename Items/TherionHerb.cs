using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Therion.Items
{
    public class TherionHerb : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Moonglow);
            item.value = Item.sellPrice(silver: 5);
        }
    }
}
