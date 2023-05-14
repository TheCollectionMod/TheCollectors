using TheCollectors.Content.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Audio;

namespace TheCollectors.Content.Tiles.RefinedMeteoriteSet
{
	public class RefinedMeteoritePlate : ModTile
	{
		private int foodItem;
		public int FoodItem
		{
			get { return foodItem; }
			set { foodItem = value; }
		}
		public override void SetStaticDefaults()
		{
			// Properties
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileID.Sets.DisableSmartCursor[Type] = true;

			AdjTiles = new int[] { TileID.FoodPlatter };

			// Names
			AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Plate"));

			// Placement
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.CoordinateHeights = new[] { 16 };
			TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);
			TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
			// The following 3 lines are needed if you decide to add more styles and stack them vertically
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.newTile.StyleMultiplier = 2;
			TileObjectData.newTile.StyleHorizontal = true;

			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
			TileObjectData.addAlternate(1); // Facing right will use the second texture style
			TileObjectData.addTile(Type);
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoritePlate>());
		}
		public override void PlaceInWorld(int i, int j, Item item)
		{
			// Si el ítem colocado en el mundo es un ítem de comida, almacenamos su tipo en la propiedad "foodItem"
			if (item.type == ItemID.Apple || item.type == ItemID.Bacon || item.type == ItemID.CookedFish || item.type == ItemID.CookedShrimp)
			{
				FoodItem = item.type;
				SoundEngine.PlaySound(SoundID.Item1);
			}
			else
			{
				FoodItem = 0;
			}
		}
		/*public override bool RightClick(int i, int j)
		{
			int rand = Main.rand.Next(2);
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Item94);
			SoundEngine.PlaySound(SoundID.Item78);
			//SoundEngine.PlaySound(new SoundStyle(rand == 0 ? "Sounds/Arpiano" : "Sounds/SoftMelodyPiano") with { PitchVariance = 0.05f }, new Vector2(i, j) * 16);
			return true;
		}*/
		public override bool RightClick(int i, int j)
		{
			// Si hay una comida en el plato, la eliminamos y reproducimos un sonido de comer
			if (FoodItem != 0)
			{
				FoodItem = 0;
				SoundEngine.PlaySound(SoundID.Item);
				return true;
			}
			return base.RightClick(i, j);
		}
	}
}