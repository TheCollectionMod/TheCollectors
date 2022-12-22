﻿using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoriteSofa : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Refined Meteorite Sofa");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			//Common Properties
			Item.width = 12;
			Item.height = 12;
			Item.value = Item.sellPrice(0, 0, 0, 60);
			Item.rare = ItemRarityID.White;
			Item.maxStack = 99;
			Item.consumable = true;
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteSofa>());

			//Use Properties
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 14;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
		}
	}
}
