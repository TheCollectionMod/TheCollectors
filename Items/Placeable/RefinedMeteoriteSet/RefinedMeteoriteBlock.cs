using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoriteBlock : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Refined Meteorite Block");
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
			Item.createTile = ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteBlock>();

			//Use Properties
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 14;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
		}

		public override void ExtractinatorUse(ref int resultType, ref int resultStack)
		{ // Calls upon use of an extractinator. Below is the chance you will get ExampleOre from the extractinator.
			if (Main.rand.NextBool(3))
			{
				resultType = ModContent.ItemType<HardenedMeteoriteOre>();  // Get this from the extractinator with a 1 in 3 chance.
				if (Main.rand.NextBool(5))
				{
					resultStack += Main.rand.Next(2); // Add a chance to get more than one of ExampleOre from the extractinator.
				}
			}
		}
	}
}
