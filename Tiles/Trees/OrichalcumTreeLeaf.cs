using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Tiles.Trees
{
    class OrichalcumTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Tiles/Trees/OrichalcumTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}