using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class RefinedMeteoriteLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Refined Meteorite Leggings");
			Tooltip.SetDefault("+7% increased damage"
				+ "\n+8% increased movement speed");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 1, 50, 0);
			Item.rare = ItemRarityID.Pink;
			Item.defense = 11;
		}
		public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.08f;
			player.GetDamage(DamageClass.Generic) += 7;   // 7% Increased/
		}
	}
}