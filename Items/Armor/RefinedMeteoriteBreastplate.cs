using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class RefinedMeteoriteBreastplate : ModItem
	{
		public override void SetStaticDefaults() 
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Refined Meteorite Breastplate");
			Tooltip.SetDefault("7% Increased critical strike chance");
		}
		public override void SetDefaults() 
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 1, 50, 0);
			Item.rare = ItemRarityID.Pink;
			Item.defense = 15;
		}
		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Generic) += 7;   // 7% Increased critical strike chance/
		}
	}
}