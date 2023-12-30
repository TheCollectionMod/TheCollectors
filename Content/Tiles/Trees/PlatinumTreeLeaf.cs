using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class PlatinumTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/PlatinumTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}