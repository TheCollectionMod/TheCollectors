﻿using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class HellstoneTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/HellstoneTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}