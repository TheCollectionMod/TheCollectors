using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Tiles.Trees
{
    class HallowTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Tiles/Trees/HallowTreeLeaf";

		public override void SetStaticDefaults()
		{

			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}