using Terraria;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoritePlatform : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 200;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoritePlatform>());
			Item.width = 8;
			Item.height = 10;
		}
	}
}
