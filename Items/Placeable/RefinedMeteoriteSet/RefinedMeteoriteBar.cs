using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoriteBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Refined Meteorite Bar");

			// Be sure to have "using Terraria.Localization".
			//DisplayName.AddTranslation(GameCulture.Spanish, "Lingote de meteorito refinado");

			ItemID.Sets.SortingPriorityMaterials[Item.type] = 89; // influences the inventory sort order. 89 is HallowedBar, higher is more valuable.
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 999;
			Item.value = 750;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteBar>();
			Item.placeStyle = 0;
			Item.rare = ItemRarityID.Orange;
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<HardenedMeteoriteOre>(), 4);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}
