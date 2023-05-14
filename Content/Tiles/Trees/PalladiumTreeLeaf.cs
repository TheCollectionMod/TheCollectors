using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class PalladiumTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/PalladiumTreeLeaf";

		public override void SetStaticDefaults()
		{ 
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}