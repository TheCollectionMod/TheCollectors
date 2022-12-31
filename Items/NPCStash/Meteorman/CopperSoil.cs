using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;
using Terraria.IO;
using Terraria.WorldBuilding;


namespace TheCollectors.Items.NPCStash.Meteorman
{
	public class CopperSoil : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Copper Soil");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
			ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;
		}
		public override void SetDefaults()
		{
			//Common Properties
			Item.width = 12;
			Item.height = 12;
			Item.value = Item.sellPrice(0, 0, 0, 0);
			Item.rare = ItemRarityID.White;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Items.NPCStash.Meteorman.CopperSoilTile>();

			//Use Properties
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 14;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
		}
		public override void ExtractinatorUse(ref int resultType, ref int resultStack)
		{
			int[] gems = new int[]
			{
				ItemID.Topaz,
				ItemID.Amethyst,
				ItemID.Sapphire,
				ItemID.Emerald,
				ItemID.Diamond,
				ItemID.Ruby
			};
			resultStack = Main.rand.Next(7, 15);
			resultType = Main.rand.Next(gems);
		}
		/*public override void ExtractinatorUse(ref int resultType, ref int resultStack)
		{ // Calls upon use of an extractinator. Below is the chance you will get ExampleOre from the extractinator.
			if (Main.rand.NextBool(3))
			{
				resultType = ItemID.CopperOre;  // Get this from the extractinator with a 1 in 3 chance.
				if (Main.rand.NextBool(5))
				{
					resultStack += Main.rand.Next(2); // Add a chance to get more than one of ExampleOre from the extractinator.
				}
				/*resultType = ModContent.ItemType<HardenedMeteoriteOre>();  // Get this from the extractinator with a 1 in 3 chance.
				if (Main.rand.NextBool(5))
				{
					resultStack += Main.rand.Next(2); // Add a chance to get more than one of ExampleOre from the extractinator.
				}
			}
		}*/
	}
	public class CopperSoilTile : ModTile
	{
		public override void SetStaticDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
											 //Main.tileOreFinderPriority[Type] = 720; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			Main.tileShine2[Type] = false; // Modifies the draw color slightly.
			Main.tileShine[Type] = 875; // How often tiny dust appear off this tile. Larger is less frequently
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = false;
			Main.tileFlame[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileLavaDeath[Type] = false;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Copper Soil");
			AddMapEntry(new Color(207, 170, 216), name);
			//name.AddTranslation(GameCulture.Spanish, "Meteorito endurecido");

			DustType = DustID.FlameBurst;
			ItemDrop = ModContent.ItemType<Items.NPCStash.Meteorman.CopperSoil>();
			HitSound = SoundID.Tink;
			//soundStyle = 1;
			MineResist = 4f;
			MinPick = 20;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			base.ModifyLight(i, j, ref r, ref g, ref b);
			r = 0.5f;
			g = 0.75f;
			b = 1f;
		}
	}
}
