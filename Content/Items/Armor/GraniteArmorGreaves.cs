using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TheCollectors.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class GraniteArmorGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 65, 0);
			Item.rare = ItemRarityID.Orange;
			Item.defense = 6;
		}
	}
}