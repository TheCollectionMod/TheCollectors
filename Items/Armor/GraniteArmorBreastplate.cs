using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class GraniteArmorBreastplate : ModItem
	{
		public override void SetStaticDefaults() 
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Granite Breastplate");

			// Be sure to have "using Terraria.Localization".
			//DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Armadura de granito");
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