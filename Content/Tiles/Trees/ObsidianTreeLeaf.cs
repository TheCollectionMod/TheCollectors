using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class ObsidianTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/ObsidianTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}