using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoritePlate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Refined Meteorite Plate");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 200;
		}

		public override void SetDefaults()
		{
			//Common Properties
			Item.width = 16;
			Item.height = 16;
			Item.value = Item.sellPrice(0, 0, 0, 0);
			Item.rare = ItemRarityID.White;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoritePlate>();

			//Use Properties
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 14;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
		}

	}
}
