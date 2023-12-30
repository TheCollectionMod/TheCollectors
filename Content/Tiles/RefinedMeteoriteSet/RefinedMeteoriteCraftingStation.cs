using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.Audio;
using Terraria.GameContent.Creative;

namespace TheCollectors.Content.Tiles.RefinedMeteoriteSet
{
	public class RefinedMeteoriteCraftingStation : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			AnimationFrameHeight = 54;

			TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Refined Meteorite Crafting Station");
			AddMapEntry(new Color(191, 142, 111), name);
		}

		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			frameCounter++;
			if (frameCounter >= 8) //replace 10 with duration of frame in ticks
			{
				frameCounter = 0;
				frame++;
				frame %= 12;
			}
		}
	}
}
