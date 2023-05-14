using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class StardustTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/StardustTreeLeaf";

		public override void SetStaticDefaults()
		{

			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}