using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Placeable.RedCandyCaneSet
{
	public class RedCandyCaneChest : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.RedCandyCaneSet.RedCandyCaneChest>());
			Item.width = 32;
			Item.height = 30;
			Item.value = 500;
		}
	}

	public class RedCandyCaneChestKey : ModItem
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