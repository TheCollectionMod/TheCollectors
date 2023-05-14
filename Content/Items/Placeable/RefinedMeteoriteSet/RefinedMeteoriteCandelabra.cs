using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoriteCandelabra : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Refined Meteorite Candelabra");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			//Common Properties
			Item.CloneDefaults(ItemID.Candelabra);
			Item.width = 12;
			Item.height = 12;
			Item.createTile = ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteCandelabra>();
		}
	}
}
