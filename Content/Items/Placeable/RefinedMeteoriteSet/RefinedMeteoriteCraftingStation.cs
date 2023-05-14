using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoriteCraftingStation : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Refined Meteorite Crafting Station");
			// Tooltip.SetDefault("Used for special crafting");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			//Common Properties
			Item.CloneDefaults(ItemID.SkyMill);
			Item.width = 28;
			Item.height = 14;
			/*Item.value = Item.buyPrice(0, 10, 0, 0);
			Item.value = Item.sellPrice(0, 2, 0, 0);
			Item.rare = ItemRarityID.White;
			Item.maxStack = 99;
			Item.consumable = true;*/
			Item.createTile = ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>();

			/*//Use Properties
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;*/
		}
	}
}