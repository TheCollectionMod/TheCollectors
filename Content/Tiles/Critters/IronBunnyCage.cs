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

namespace TheCollectors.Content.Tiles.Critters
{
	public class IronBunnyCage : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Iron Bunny Cage");
		}
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.AmberBunnyCage);
			Item.createTile = ModContent.TileType<IronBunnyCageTile>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Content.Items.Consumables.Critters.IronBunnyItem>(), 1);
			recipe.AddIngredient(ItemID.Terrarium, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
	public class IronBunnyCageTile : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileLavaDeath[Type] = true;
			//TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);  //The StyleSmallCage es la del rat�n
			TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
			AnimationFrameHeight = 54;

			TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(122, 217, 232), name);
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 64, 48, ModContent.ItemType<IronBunnyCage>());
		}

		public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
		{
			Tile tile = Main.tile[i, j];
			Main.critterCage = true;
			int left = i - tile.TileFrameX / 18;
			int top = j - tile.TileFrameY / 18;
			int offset = left / 3 * (top / 3);
			offset %= Main.cageFrames;
			frameYOffset = Main.bunnyCageFrame[offset] * AnimationFrameHeight;
		}
	}
}
