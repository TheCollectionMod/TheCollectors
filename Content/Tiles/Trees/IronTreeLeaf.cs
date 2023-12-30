using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class IronTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/IronTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}