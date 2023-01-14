using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Armor.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class MeteormanMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteorman Mask");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(0, 0, 2, 0);
			Item.value = Item.buyPrice(0, 10, 0, 0);
			Item.vanity = true;
			Item.maxStack = 1;
		}
	}
}
