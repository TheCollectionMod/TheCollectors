using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Placeable
{
	public class ThrowingDummy : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Throwing Dummy Trainer");
			Tooltip.SetDefault("Increases throwing damage, speed and critical strike chance.");

			// Be sure to have "using Terraria.Localization".
			//DisplayName.AddTranslation(GameCulture.Spanish, "Monigote de entrenamiento arrojadizo");
			//Tooltip.AddTranslation(GameCulture.Spanish, "Aumento de daño, probabilidad de crítico y velocidad de lanzamiento a las armas arrojadizas.");
		}

		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 32;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 150;
			Item.rare = ItemRarityID.LightPurple;
			Item.createTile = TileType<Tiles.ThrowingDummy>();
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Mannequin);
			recipe.AddIngredient(ItemID.ThrowingKnife, 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}