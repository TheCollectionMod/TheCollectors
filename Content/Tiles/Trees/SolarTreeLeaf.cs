using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class SolarTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/SolarTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}