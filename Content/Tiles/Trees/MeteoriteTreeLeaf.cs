using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class MeteoriteTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/MeteoriteTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}