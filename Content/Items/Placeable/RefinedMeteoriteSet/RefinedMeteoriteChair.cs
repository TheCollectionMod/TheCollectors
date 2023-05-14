using Terraria;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoriteChair : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteChair>());
			Item.width = 12;
			Item.height = 30;
			Item.value = 150;
		}
	}
}
