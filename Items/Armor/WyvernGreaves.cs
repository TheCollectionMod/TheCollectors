using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class WyvernGreaves : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Wyvern Greaves");
			Tooltip.SetDefault("12% Increased minion damage."
								+ "\nIncreases your max number of minions by 1.");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.defense = 12;
		}
		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Summon) += 0.12f;   /*12% increased damage*/
			player.maxMinions += 1;
		}
	}
}