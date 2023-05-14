using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class OrichalcumTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/OrichalcumTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}