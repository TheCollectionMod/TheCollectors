using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Tiles.Trees
{
    class MythrilTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Tiles/Trees/MythrilTreeLeaf";

		public override void SetStaticDefaults()
		{

			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}