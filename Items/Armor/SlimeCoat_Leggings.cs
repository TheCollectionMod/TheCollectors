using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class SlimeCoat_Leggings : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Slime Coat - Leggings");
			Tooltip.SetDefault("1% Increased minion damage");

			// Be sure to have "using Terraria.Localization".
		/*	DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Recubrimiento de Slime - Pantalones");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "+1% daño de súbditos.");*/
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 1;
		}

		public override void UpdateEquip(Player player) 
		{
			//player.minionDamage += 0.01f;
			player.GetDamage(DamageClass.Summon) += 0.01f;   /*1% increased damage*/
		}
	}
}