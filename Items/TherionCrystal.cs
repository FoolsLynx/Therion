using Terraria;
using Terraria.ModLoader;

namespace Therion.Items
{
    public class TherionCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            
        }

        public override void SetDefaults()
        {
            item.Size = new Microsoft.Xna.Framework.Vector2(10, 12);
            item.value = Item.sellPrice(silver: 15);
            item.maxStack = 999;
        }
    }
}
