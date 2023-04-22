using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Tiles.Trees
{
    class HardenedMeteoriteTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Tiles/Trees/HardenedMeteoriteTreeLeaf";

		public override void SetStaticDefaults()
		{

			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}