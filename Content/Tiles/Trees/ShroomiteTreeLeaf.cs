using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class ShroomiteTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/ShroomiteTreeLeaf";

		public override void SetStaticDefaults()
		{

			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}