using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class ChlorophyteTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/ChlorophyteTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}