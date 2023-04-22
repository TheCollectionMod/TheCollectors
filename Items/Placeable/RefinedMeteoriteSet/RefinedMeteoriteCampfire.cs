using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoriteCampfire : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Refined Meteorite Campfire");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
		}

		public override void SetDefaults()
		{
			//Common Properties
			Item.width = 12;
			Item.height = 12;
			Item.value = Item.sellPrice(0, 0, 3, 0);
			Item.rare = ItemRarityID.White;
			Item.maxStack = 99;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteCampfire>();

			//Use Properties
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 14;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
		}
	}
}
