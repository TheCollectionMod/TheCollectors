using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheCollectors.Buffs;

namespace TheCollectors.Items.Accessories
{
	public class MeteormanHeart : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Meteorman Heart");
			Tooltip.SetDefault("Grants Meteor Body");
		}
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

			/*if (player.HasBuff(BuffID.OnFire))
			{
				player.AddBuff(ModContent.BuffType<HealingFire>(), 0);

			} */
		}
	}
}