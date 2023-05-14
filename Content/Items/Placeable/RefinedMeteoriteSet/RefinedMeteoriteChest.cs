using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoriteChest : ModItem
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
		}
	}

	public class RefinedMeteoriteChestKey : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 3;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.GoldenKey);
		}
	}
}