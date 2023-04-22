using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Tiles.Trees
{
    class NebulaTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Tiles/Trees/NebulaTreeLeaf";

		public override void SetStaticDefaults()
		{

			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}