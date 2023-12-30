using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class NebulaTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/NebulaTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}