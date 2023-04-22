using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Tiles.Trees
{
    class TitaniumTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Tiles/Trees/TitaniumTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}