using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheCollectors.Items.Placeable.Paintings
{
	public class NinjaPaintings : ModTile
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
			//disableSmartCursor = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Painting");
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
					item = ItemType<NinjaPaintingVol1>();
					break;
				case 1:
					item = ItemType<NinjaPaintingVol2>();
					break;
				case 2:
					item = ItemType<NinjaPaintingVol3>();
					break;
				case 3:
					item = ItemType<NinjaPaintingVol4>();
					break;
				case 4:
					item = ItemType<NinjaPaintingVol5>();
					break;
				case 5:
					item = ItemType<NinjaPaintingVolEx>();
					break;
				default:
					return;
			}
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, item);
		}
		
		/*public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
		{
			if (i % 2 == 1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
		}*/
	}
	public abstract class ModPainting : ModItem
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
			Item.createTile = TileType<NinjaPaintings>();
			Item.placeStyle = 0;
		}
	}
	public class NinjaPaintingVol1 : ModPainting
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("NinjaPaintingVol1");
		}
		public override void SafeSetDefaults()
		{
			Item.createTile = TileType<NinjaPaintings>();
			Item.placeStyle = 0;
		}
	}
	public class NinjaPaintingVol2 : ModPainting
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("NinjaPaintingVol2");
		}
		public override void SafeSetDefaults()
		{
			Item.createTile = TileType<NinjaPaintings>();
			Item.placeStyle = 1;
		}
	}
	public class NinjaPaintingVol3 : ModPainting
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("NinjaPaintingVol3");
		}
		public override void SafeSetDefaults()
		{
			Item.createTile = TileType<NinjaPaintings>();
			Item.placeStyle = 2;
		}
	}
	public class NinjaPaintingVol4 : ModPainting
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("NinjaPaintingVol4");
		}
		public override void SafeSetDefaults()
		{
			Item.createTile = TileType<NinjaPaintings>();
			Item.placeStyle = 3;
		}
	}
	public class NinjaPaintingVol5 : ModPainting
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("NinjaPaintingVol5");
		}
		public override void SafeSetDefaults()
		{
			Item.createTile = TileType<NinjaPaintings>();
			Item.placeStyle = 4;
		}
	}
	public class NinjaPaintingVolEx : ModPainting
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("NinjaPaintingVolEx");
		}
		public override void SafeSetDefaults()
		{
			Item.createTile = TileType<NinjaPaintings>();
			Item.placeStyle = 5;
		}
	}
}	
