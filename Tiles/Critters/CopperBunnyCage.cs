using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;

namespace TheCollectors.Tiles.Critters
{
	public class CopperBunnyCage : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Copper Bunny Cage");
		}
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 22;
			Item.value = Item.buyPrice(0, 0, 30, 0);

			Item.maxStack = 999;

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 15;
			Item.useAnimation = 15;

			Item.useTurn = true;
			Item.autoReuse = true;
			Item.consumable = true;

			Item.createTile = ModContent.TileType<CopperBunnyCageTile>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.Consumables.CopperBunnyItem>(), 1);
			recipe.AddIngredient(ItemID.Terrarium, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
	public class CopperBunnyCageTile : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.Width = 3;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table | AnchorType.SolidTile | AnchorType.SolidWithTop, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.addTile(Type);
			DustType = DustID.Glass;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Critter Cage");
			AddMapEntry(new Color(200, 200, 200), name);
		}
		//private readonly int AnimationFrameHeight = 36;
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = .33f;
			g = .025f;
			b = 1.15f;
		}
		/*public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
		{
			// Tweak the frame drawn by x position so tiles next to each other are off-sync and look much more interesting
			int uniqueAnimationFrame = Main.tileFrame[Type] + i;
			if (i % 2 == 0)
				uniqueAnimationFrame += 3;
			if (i % 3 == 0)
				uniqueAnimationFrame += 3;
			if (i % 4 == 0)
				uniqueAnimationFrame += 3;
			uniqueAnimationFrame %= 6;

			// frameYOffset = modTile.animationFrameHeight * Main.tileFrame [type] will already be set before this hook is called
			// But we have a horizontal animated texture, so we use frameXOffset instead of frameYOffset
			frameYOffset = uniqueAnimationFrame * AnimationFrameHeight;
		}*/
		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			if (++Main.tileFrameCounter[TileID.AmberBunnyCage] >= 16)
			{
				Main.tileFrameCounter[TileID.AmberBunnyCage] = 0;
				if (++Main.tileFrame[TileID.AmberBunnyCage] >= 4)
				{
					Main.tileFrame[TileID.AmberBunnyCage] = 0;
				}
			}
		}
		/*public override void AnimateTile(ref int frame, ref int frameCounter)
		{

			frameCounter++;
			if (frameCounter >= 10) //replace 10 with duration of frame in ticks
			{
				frameCounter = 0;
				frame++;
				frame %= 5;
			}
		}*/
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 64, 48, ModContent.ItemType<CopperBunnyCage>());
		}
    }
}