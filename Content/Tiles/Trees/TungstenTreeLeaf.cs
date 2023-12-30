using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class TungstenTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/TungstenTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}