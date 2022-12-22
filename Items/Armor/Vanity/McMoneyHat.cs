using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Armor.Vanity
{
	// This tells tModLoader to look for a texture called MinionBossMask_Head, which is the texture on the player
	// and then registers this item to be accepted in head equip slots
	[AutoloadEquip(EquipType.Head)]
	public class McMoneyHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("McMoney Hat");
			ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Draw hair as if a hat was covering the top. Used by Wizards Hat

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;

			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 75);
			Item.vanity = true;
			Item.maxStack = 1;
		}
	}
}