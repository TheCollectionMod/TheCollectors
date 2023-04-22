using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Tiles.Trees
{
    class SturdyFossilTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Tiles/Trees/SturdyFossilTreeLeaf";

		public override void SetStaticDefaults()
		{

			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}