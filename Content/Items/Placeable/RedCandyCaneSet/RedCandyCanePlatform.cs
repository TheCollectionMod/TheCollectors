using Terraria;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Placeable.RedCandyCaneSet
{
	public class RedCandyCanePlatform : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 200;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.RedCandyCaneSet.RedCandyCanePlatform>());
			Item.width = 8;
			Item.height = 10;
		}
	}
}