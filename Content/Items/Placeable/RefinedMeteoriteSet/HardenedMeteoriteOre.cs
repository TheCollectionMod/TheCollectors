using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Placeable.RefinedMeteoriteSet
{
	public class HardenedMeteoriteOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 100;
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 89;  // influences the inventory sort order. 89 is HallowedBar, higher is more valuable.
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.RefinedMeteoriteSet.HardenedMeteoriteOre>());
			Item.rare = ItemRarityID.Orange;
			Item.width = 12;
			Item.height = 12;
			Item.value = 3000;
		}
	}
}
