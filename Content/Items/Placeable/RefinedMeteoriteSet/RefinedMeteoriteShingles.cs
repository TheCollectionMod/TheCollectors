using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Content.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoriteShingles : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Refined Meteorite Shingles");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
		}
		public override void SetDefaults() 
		{
			Item.CloneDefaults(ItemID.BlueDynastyShingles);
			Item.width = 28;
			Item.height = 14;
			Item.createTile = TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteShingles>();
		}
	}
}