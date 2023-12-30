using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class LeadTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/LeadTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}