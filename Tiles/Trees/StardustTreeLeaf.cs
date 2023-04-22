using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Tiles.Trees
{
    class StardustTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Tiles/Trees/StardustTreeLeaf";

		public override void SetStaticDefaults()
		{

			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}