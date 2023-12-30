using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Accessories
{
	public class MeteormanHeart : ModItem
	{
		public override void SetDefaults()
		{
			Item.value = Item.buyPrice(0, 10, 0, 0);
			Item.value = Item.sellPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Orange;
			Item.maxStack = 1;
			Item.accessory = true;
			Item.defense = 10;
		}
	}
}