using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Placeable.RedCandyCaneSet
{
	public class RedCandyCaneCandle : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			//Common Properties
			Item.CloneDefaults(ItemID.Candle);
			Item.width = 12;
			Item.height = 12;
			Item.createTile = ModContent.TileType<Tiles.RedCandyCaneSet.RedCandyCaneCandle>();
		}
	}
}

