using Terraria;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoriteChestLocked : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteChest>());
			Item.width = 32;
			Item.height = 30;
			Item.value = 500;
			Item.placeStyle = 1; // Use this to place the chest in its locked style

		}
	}
}