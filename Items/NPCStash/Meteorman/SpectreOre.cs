﻿using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Terraria;

namespace TheCollectors.Items.NPCStash.Meteorman
{
	public class SpectreOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spectre Ore");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 95; // influences the inventory sort order. 89 is HallowedBar, higher is more valuable.
		}
		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.createTile = TileType<Items.NPCStash.Meteorman.SpectreOreTile>();
			Item.rare = ItemRarityID.Lime;
			Item.width = 12;
			Item.height = 12;
			Item.value = 3000;
		}
	}
	public class SpectreOreTile : ModTile
	{
		public override void SetStaticDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			Main.tileOreFinderPriority[Type] = 720; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			Main.tileShine2[Type] = false; // Modifies the draw color slightly.
			Main.tileShine[Type] = 875; // How often tiny dust appear off this tile. Larger is less frequently
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = false;
			Main.tileFlame[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileLavaDeath[Type] = false;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Spectre Ore");
			AddMapEntry(new Color(207, 170, 216), name);

			DustType = DustID.SpectreStaff; //revisar
			ItemDrop = ModContent.ItemType<Items.NPCStash.Meteorman.SpectreOre>();
			HitSound = SoundID.Tink;
			MineResist = 4f;
			MinPick = 200;
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

