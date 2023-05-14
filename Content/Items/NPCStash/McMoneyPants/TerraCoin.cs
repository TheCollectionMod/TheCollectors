using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TheCollectors.Content.Items.NPCStash.McMoneyPants
{
	public class TerraCoin : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100; // How many items are needed in order to research duplication of this item in Journey mode. See https://terraria.gamepedia.com/Journey_Mode/Research_list for a list of commonly used research amounts depending on item type.
		}

		public override void SetDefaults()
		{
			Item.width = 28; // The item texture's width
			Item.height = 28; // The item texture's height
			Item.maxStack = 999; // The item's max stack value
			Item.value = Item.buyPrice(0, 1, 0, 0);
			Item.value = Item.sellPrice(0, 0, 50, 0);
			Item.rare = ItemRarityID.Purple;
		}
	}
}
