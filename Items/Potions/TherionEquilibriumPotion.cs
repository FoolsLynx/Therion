using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Therion.Items.Placeables;

namespace Therion.Items.Potions
{
    public class TherionEquilibriumPotion : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.LightPurple;
            item.value = Item.buyPrice(gold: 10);
            item.buffType = ModContent.BuffType<Buffs.TherionEquilibriumBuff>(); 
            item.buffTime = 60 * 5; 
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TherionPotion>());
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.AddIngredient(ItemID.VileMushroom);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}