using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using Therion.Items;
using Therion.Items.Weapons;
using Therion.UI;

namespace Therion
{
	public class Therion : Mod
	{
		private UserInterface _therionResourceBarUI;
		internal TherionResourceBar TherionResourceBar;

		public override void Load()
		{
			if(!Main.dedServ)
			{
				TherionGlowmasks.Load();
				TherionResourceBar = new TherionResourceBar();
				_therionResourceBarUI = new UserInterface();
				_therionResourceBarUI.SetState(TherionResourceBar);
			}
		}

		public override void Unload()
		{
			TherionGlowmasks.Unload();
		}

		public override void UpdateUI(GameTime gameTime)
		{
			_therionResourceBarUI?.Update(gameTime);
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
			if(resourceBarIndex != -1)
			{
				layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer("Therion: Therion Resource Bar", delegate { _therionResourceBarUI.Draw(Main.spriteBatch, new GameTime()); return true; }, InterfaceScaleType.UI));
			}
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<TherionCrystal>(), 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<TherionDagger>());
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<TherionCrystal>(), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<TherionBlade>());
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<TherionCrystal>(), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<TherionBow>());
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<TherionCrystal>(), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<TherionSpear>());
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<TherionCrystal>(), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<TherionGun>());
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<TherionCrystal>(), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<TherionFlail>());
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<TherionCrystal>(), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<TherionScythe>());
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<TherionCrystal>(), 10);
			recipe.AddIngredient(ItemID.Cobweb, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ModContent.ItemType<TherionYoyo>());
			recipe.AddRecipe();
		}
	}

	internal enum TherionMessageType : byte
	{
		TherionPlayerSyncPlayer
	}
}