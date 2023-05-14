using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class SpectreTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/SpectreTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}