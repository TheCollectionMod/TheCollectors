using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class TitaniumTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/TitaniumTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}