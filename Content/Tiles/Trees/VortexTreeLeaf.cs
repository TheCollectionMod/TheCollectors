﻿using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Tiles.Trees
{
    class VortexTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Content/Tiles/Trees/VortexTreeLeaf";

		public override void SetStaticDefaults()
		{
			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}