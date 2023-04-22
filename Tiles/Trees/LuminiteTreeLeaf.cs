using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Tiles.Trees
{
    class LuminiteTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Tiles/Trees/LuminiteTreeLeaf";

		public override void SetStaticDefaults()
		{

			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}