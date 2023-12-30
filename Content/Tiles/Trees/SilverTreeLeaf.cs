using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class SilverTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/SilverTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}