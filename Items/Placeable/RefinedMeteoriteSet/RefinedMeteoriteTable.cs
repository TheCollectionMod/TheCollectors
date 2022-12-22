using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoriteTable : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Refined Meteorite Table");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			//Common Properties
			Item.width = 30;
			Item.height = 22;
			Item.value = Item.sellPrice(0, 0, 0, 60);
			Item.rare = ItemRarityID.White;
			Item.maxStack = 99;
			Item.consumable = true;
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteTable>());

			//Use Properties
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 14;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
		}
	}
}
