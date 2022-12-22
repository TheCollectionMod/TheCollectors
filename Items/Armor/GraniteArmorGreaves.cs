using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class GraniteArmorGreaves : ModItem
	{
		public override void SetStaticDefaults() 
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Granite Greaves");

			// Be sure to have "using Terraria.Localization".
			//DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Perneras de granito");
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