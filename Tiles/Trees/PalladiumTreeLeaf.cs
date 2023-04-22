using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Tiles.Trees
{
    class PalladiumTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Tiles/Trees/PalladiumTreeLeaf";

		public override void SetStaticDefaults()
		{ 
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}