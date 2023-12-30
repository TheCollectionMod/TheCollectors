using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class AdamantiteTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/AdamantiteTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}