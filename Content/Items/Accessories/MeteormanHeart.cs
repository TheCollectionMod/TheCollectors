using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheCollectors.Content.Buffs;

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
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(ModContent.BuffType<MeteorbodyBuff>(), 0);
		}
	}
}