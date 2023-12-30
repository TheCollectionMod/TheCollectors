using Terraria;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Placeable.RedCandyCaneSet
{
	public class RedCandyCaneBathtub : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.RedCandyCaneSet.RedCandyCaneBathtub>());
			Item.width = 28;
			Item.height = 20;
			Item.value = 2000;
		}
	}
}

