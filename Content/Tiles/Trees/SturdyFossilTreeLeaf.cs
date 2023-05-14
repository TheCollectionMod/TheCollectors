using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class SturdyFossilTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/SturdyFossilTreeLeaf";

		public override void SetStaticDefaults()
		{

			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}