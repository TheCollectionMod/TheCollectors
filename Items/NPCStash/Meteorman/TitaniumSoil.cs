﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace TheCollectors.Items.NPCStash.Meteorman
{
	public class TitaniumSoil : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titanium Soil");
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
			Item.createTile = ModContent.TileType<Items.NPCStash.Meteorman.TitaniumSoilTile>();

			//Use Properties
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 14;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
		}
		public override void ExtractinatorUse(ref int resultType, ref int resultStack)
		{
			int[] soil = new int[]
			{
				ItemID.TitaniumOre,
				ItemID.MudBlock,
				ItemID.SlushBlock,
				ItemID.DirtBlock,
				ItemID.SiltBlock,
				ItemID.ClayBlock
			};
			resultStack = Main.rand.Next(1, 1);
			resultType = Main.rand.Next(soil);
		}
	}
	public class TitaniumSoilTile : ModTile
	{
		public override void SetStaticDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			Main.tileShine2[Type] = false; // Modifies the draw color slightly.
			Main.tileShine[Type] = 875; // How often tiny dust appear off this tile. Larger is less frequently
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = false;
			Main.tileFlame[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileLavaDeath[Type] = false;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Titanium Soil");
			AddMapEntry(new Color(91, 90, 119), name);

			DustType = DustID.Titanium;
			ItemDrop = ModContent.ItemType<Items.NPCStash.Meteorman.TitaniumSoil>();
			HitSound = SoundID.Tink;

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
