using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Placeable.RefinedMeteoriteSet
{
	internal class RefinedMeteoriteAnimatedLantern : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteAnimatedLantern>());
			Item.value = 10000;
		}
	}
}