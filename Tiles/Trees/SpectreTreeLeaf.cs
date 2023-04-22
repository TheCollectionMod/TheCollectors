using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Tiles.Trees
{
    class SpectreTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Tiles/Trees/SpectreTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}