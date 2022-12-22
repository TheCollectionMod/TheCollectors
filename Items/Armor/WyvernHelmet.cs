using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class WyvernHelmet : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Wyvern Helmet");
			Tooltip.SetDefault("12% Increased minion damage."
								+ "\nIncreases your max number of minions by 1.");

			// Be sure to have "using Terraria.Localization".
			/*DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Casco de guiverno");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "+21% daño de súbditos."
													+ "\n+1 máximo de súbditos.");*/
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.defense = 8;
		}

		public override void UpdateEquip(Player player)
		{
			//player.minionDamage += 0.12f;
			player.GetDamage(DamageClass.Summon) += 0.12f;   /*12% increased damage*/
			player.maxMinions += 1;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<WyvernBreastplate>() && legs.type == ItemType<WyvernGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "10% Increased minion damage"
							+ "\nIncreases your max number of minions by 1.";

			//player.minionDamage += 0.10f;
			player.GetDamage(DamageClass.Summon) += 0.10f;   /*10% increased damage*/
			player.maxMinions += 1;
		}
	}
}