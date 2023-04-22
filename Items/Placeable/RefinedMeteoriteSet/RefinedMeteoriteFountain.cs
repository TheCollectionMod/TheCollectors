using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoriteFountain : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Refined Meteorite Fountain");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            //Common Properties
            Item.width = 28; //revisar
            Item.height = 20; //revisar
            Item.value = Item.buyPrice(0, 4, 0, 0);
            Item.value = Item.sellPrice(0, 0, 80, 0);
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteFountain>();

            //Use Properties
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
        }
    }
}

