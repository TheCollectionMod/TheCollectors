using System;
using TheCollectors.Content.Tiles.RefinedMeteoriteSet;
using Terraria.ModLoader;

namespace TheCollectors.Common.Systems
{
	public class ExampleBiomeTileCount : ModSystem
	{
		public int exampleBlockCount;

		public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
		{
			exampleBlockCount = tileCounts[ModContent.TileType<RefinedMeteoriteBlock>()];
		}
	}
}