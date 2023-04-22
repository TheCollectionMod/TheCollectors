using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoriteTeja : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Refined Meteorite Crafting Station");
			Tooltip.SetDefault("Used for special crafting");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 14;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = Item.buyPrice(0, 10, 0, 0);
			Item.value = Item.sellPrice(0, 2, 0, 0);
			Item.rare = ItemRarityID.White;
			Item.createTile = TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteTeja>();
		}
	}
}