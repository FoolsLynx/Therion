using Terraria.ModLoader;
using Terraria.ID;

namespace Therion.Items.Placeables
{
    public class TherionHerbSeeds : ModItem
    {
		public override void SetDefaults()
		{
			item.autoReuse = true;
			item.useTurn = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 15;
			item.useTime = 10;
			item.maxStack = 99;
			item.consumable = true;
			item.placeStyle = 0;
			item.width = 12;
			item.height = 14;
			item.value = 80;
			item.createTile = ModContent.TileType<Tiles.TherionHerb>();
		}
	}
}
