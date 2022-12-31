using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class GraniteArmorBreastplate : ModItem
	{
		public override void SetStaticDefaults() 
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Granite Breastplate");
		}
		public override void SetDefaults() 
		{
			Item.width = 28;
			Item.height = 24;
			Item.value = Item.buyPrice(0, 2, 0, 0);
			Item.value = Item.sellPrice(0, 0, 70, 0);
			Item.rare = ItemRarityID.Orange;
			Item.defense = 7;
		}
	}
}