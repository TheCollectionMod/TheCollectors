using Terraria;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoriteSofa : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteSofa>());
			Item.width = 28;
			Item.height = 20;
			Item.value = 2000;
		}
	}
}