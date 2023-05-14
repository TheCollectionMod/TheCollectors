using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheCollectors.Content.Items.Placeable.Paintings
{
	public class MeteormanPaintings : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.Width = 6;
			TileObjectData.newTile.Height = 4;
			TileObjectData.newTile.Origin = new Point16(1, 2);
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.addTile(Type);
			DustType = 0;
			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(200, 200, 200), name);
		}

		public override bool CreateDust(int i, int j, ref int type)
		{
			return false;
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			int style = frameY / 72;
			int item;
			switch (style)
			{
				case 0:
					item = ItemType<MeteormanPaintingVol1>();
					break;
				case 1:
					item = ItemType<MeteormanPaintingVol2>();
					break;
				case 2:
					item = ItemType<MeteormanPaintingVol3>();
					break;
				case 3:
					item = ItemType<MeteormanPaintingVol4>();
					break;
				case 4:
					item = ItemType<MeteormanPaintingVol5>();
					break;
				case 5:
					item = ItemType<MeteormanPaintingVolEx>();
					break;
				default:
					return;
			}
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, item);
		}
	}

	public abstract class ModPainting2 : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 8;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 50000;
			Item.rare = ItemRarityID.White;
			SafeSetDefaults();
		}

		public virtual void SafeSetDefaults()
		{
			Item.createTile = TileType<MeteormanPaintings>();
			Item.placeStyle = 0;
		}
	}
	public class MeteormanPaintingVol1 : ModPainting2
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Moon rift");
			/* Tooltip.SetDefault("Meteorman Collection Vol.1"
							+ "\nWhat are those strange bright cracks in the moon?."
							+ "\nBy thyflyingraccons"); */
		}
		public override void SafeSetDefaults()
		{
			Item.createTile = TileType<MeteormanPaintings>();
			Item.placeStyle = 0;
		}
	}
	public class MeteormanPaintingVol2 : ModPainting2
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Space collision");
			/* Tooltip.SetDefault("Meteorman Collection Vol.2"
							+ "\nThe moonburst reaches the home of the Meteorite Man."
							+ "\nBy thyflyingraccons"); */
		}
		public override void SafeSetDefaults()
		{
			Item.createTile = TileType<MeteormanPaintings>();
			Item.placeStyle = 1;
		}
	}
	public class MeteormanPaintingVol3 : ModPainting2
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Descent to Earth");
			/* Tooltip.SetDefault("Meteorman Collection Vol.3"
							+ "\nPart of the meteorite is coming to Earth."
							+ "\nBy thyflyingraccons"); */
		}
		public override void SafeSetDefaults()
		{
			Item.createTile = TileType<MeteormanPaintings>();
			Item.placeStyle = 2;
		}
	}
	public class MeteormanPaintingVol4 : ModPainting2
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Deadly arrival");
			/* Tooltip.SetDefault("Meteorman Collection Vol.4"
							+ "\nMeteor Man is shown in an unusual pose."
							+ "\nBy thyflyingraccons"); */
		}
		public override void SafeSetDefaults()
		{
			Item.createTile = TileType<MeteormanPaintings>();
			Item.placeStyle = 3;
		}
	}
	public class MeteormanPaintingVol5 : ModPainting2
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("On the third day he rose");
			/* Tooltip.SetDefault("Meteorman Collection Vol.5"
							+ "\nThe Dryad heals the Meteorite Man."
							+ "\nBy thyflyingraccons"); */
		}
		public override void SafeSetDefaults()
		{
			Item.createTile = TileType<MeteormanPaintings>();
			Item.placeStyle = 4;
		}
	}
	public class MeteormanPaintingVolEx : ModPainting2
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("A new life");
			/* Tooltip.SetDefault("Meteorman Collection Vol.Ex"
							+ "\nMeteorite Man is shown planting some strange trees."
							+ "\nBy thyflyingraccons"); */
		}
		public override void SafeSetDefaults()
		{
			Item.createTile = TileType<MeteormanPaintings>();
			Item.placeStyle = 5;
		}
	}
}	
