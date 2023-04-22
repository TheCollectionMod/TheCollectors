using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoriteCraftingStation : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Refined Meteorite Crafting Station");
			Tooltip.SetDefault("Used for special crafting");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			//Common Properties
			Item.width = 28;
			Item.height = 14;
			Item.value = Item.buyPrice(0, 10, 0, 0);
			Item.value = Item.sellPrice(0, 2, 0, 0);
			Item.rare = ItemRarityID.White;
			Item.maxStack = 99;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>();

			//Use Properties
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronAnvil);
			recipe.AddIngredient(ItemType<RefinedMeteoriteBar>(), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LeadAnvil);
			recipe.AddIngredient(ItemType<RefinedMeteoriteBar>(), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}