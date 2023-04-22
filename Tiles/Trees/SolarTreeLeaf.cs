using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Tiles.Trees
{
    class SolarTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Tiles/Trees/SolarTreeLeaf";

		public override void SetStaticDefaults()
		{

			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}