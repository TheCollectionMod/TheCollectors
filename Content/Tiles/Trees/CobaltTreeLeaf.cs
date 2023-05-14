using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class CobaltTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/CobaltTreeLeaf";

		public override void SetStaticDefaults()
		{

			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}