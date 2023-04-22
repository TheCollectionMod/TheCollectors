﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace TheCollectors.Items.NPCStash.Meteorman
{
	public class NebulaSoil : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nebula Soil");
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
			Item.createTile = ModContent.TileType<Items.NPCStash.Meteorman.NebulaSoilTile>();

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
				ItemID.FragmentNebula,
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
	public class NebulaSoilTile : ModTile
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
			name.SetDefault("Nebula Soil");
			AddMapEntry(new Color(161, 172, 173), name); //revisar

			DustType = DustID.LunarOre;
			ItemDrop = ModContent.ItemType<Items.NPCStash.Meteorman.NebulaSoil>();
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
