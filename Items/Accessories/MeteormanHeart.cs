using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TheCollectors.Buffs;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Accessories
{
	public class MeteormanHeart : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Meteorman Heart");
			Tooltip.SetDefault("Hacer que burn cure");
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

			if (player.HasBuff(BuffID.OnFire))
			{
				player.AddBuff(ModContent.BuffType<HealingFire>(), 0);

			} 
		}
	}
}