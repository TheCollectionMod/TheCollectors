using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Tiles.Trees
{
    class VortexTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Tiles/Trees/VortexTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}