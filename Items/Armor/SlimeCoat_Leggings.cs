using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class SlimeCoat_Leggings : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Slime Coat - Leggings");
			Tooltip.SetDefault("1% Increased minion damage");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 1, 50, 0);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 1;
		}
		public override void UpdateEquip(Player player) 
		{
			player.GetDamage(DamageClass.Summon) += 0.01f;   /*1% increased damage*/
		}
	}
}