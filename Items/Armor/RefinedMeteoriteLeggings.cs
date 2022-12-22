using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class RefinedMeteoriteLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Refined Meteorite Leggings");
			Tooltip.SetDefault("+7% increased damage"
				+ "\n+8% increased movement speed");

			// Be sure to have "using Terraria.Localization".
			/*DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Grebas de meteorito refinado");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "+7% daño"
				+ "\n+8% velocidad de movimiento");*/
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Pink;
			Item.defense = 11;
		}

		public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.08f;
			//player.allDamage += 0.07f;
			player.GetDamage(DamageClass.Generic) += 7;   // 7% Increased/
		}
	}
}