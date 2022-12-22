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

namespace TheCollectors.Items.Placeable.Banners
{
	public class TheCollectorsBanners : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.StyleWrapLimit = 111;
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Banner");
			AddMapEntry(new Color(13, 88, 130), name);
		}
		public override bool CreateDust(int i, int j, ref int type)
		{
			return false;
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			int style = frameX / 18;
			int item;
			switch (style)
			{
				case 0:
					item = ItemType<EyelingBanner>();
					break;
				case 1:
					item = ItemType<ClawclopsBanner>();
					break;
				case 2:
					item = ItemType<SkitteringHuskBanner>();
					break;
				case 3:
					item = ItemType<CorruptedFlameElementalBanner>();
					break;
				default:
					return;
			}
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 48, item);
		}
		public override void NearbyEffects(int i, int j, bool closer)
		{
			if (closer)
			{
				Player player = Main.LocalPlayer;
				int style = Main.tile[i, j].TileFrameX / 18;
				int type;
				switch (style)
				{
					case 0:
						type = ModContent.NPCType<NPCs.Enemies.Corruption.Eyeling>();
						break;
					case 1:
						type = ModContent.NPCType<NPCs.Enemies.Corruption.Clawclops>();
						break;
					case 2:
						type = ModContent.NPCType<NPCs.Enemies.Corruption.SkitteringHusk>();
						break;
					case 3:
						type = ModContent.NPCType<NPCs.Enemies.Corruption.CorruptedFlameElemental>();
						break;
					default:
						return;
				}
				Main.SceneMetrics.hasBanner = true;
				Main.SceneMetrics.NPCBannerBuff[type] = true;
			}
		}
		public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
		{
			if (i % 2 == 1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
		}
	}
	public abstract class ModBanner : ModItem
	{
		/*public override void SetStaticDefaults()
		{
			SetResearchCost(modItem.Type, amt);
		}*/
		public override void SetDefaults()
		{
			Item.width = 10;
			Item.height = 24;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.buyPrice(0, 0, 10, 0);
			SafeSetDefaults();
		}
		public virtual void SafeSetDefaults()
		{
			Item.createTile = TileType<TheCollectorsBanners>();
			Item.placeStyle = 0;
		}
	}
	public class EyelingBanner : ModBanner
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eyeling Banner");
		}
		public override void SafeSetDefaults()
		{
			Item.createTile = TileType<TheCollectorsBanners>();
			Item.placeStyle = 0;
		}
	}
	public class ClawclopsBanner : ModBanner
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Clawclops Banner");
		}
		public override void SafeSetDefaults()
		{
			Item.createTile = TileType<TheCollectorsBanners>();
			Item.placeStyle = 1;
		}
	}
	public class SkitteringHuskBanner : ModBanner
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skittering Husk Banner");
		}
		public override void SafeSetDefaults()
		{
			Item.createTile = TileType<TheCollectorsBanners>();
			Item.placeStyle = 2;
		}
	}
	public class CorruptedFlameElementalBanner : ModBanner
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corrupted Flame Elemental Banner");
		}
		public override void SafeSetDefaults()
		{
			Item.createTile = TileType<TheCollectorsBanners>();
			Item.placeStyle = 3;
		}
	}
}	
