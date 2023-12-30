using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class TinTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/TinTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}