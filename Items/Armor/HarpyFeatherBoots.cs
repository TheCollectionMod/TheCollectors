using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class HarpyFeatherBoots : ModItem
	{
		public override void SetStaticDefaults() 
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Harpy Feather Boots");
			Tooltip.SetDefault("3% Increased minion damage");
		}
		public override void SetDefaults() 
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 1, 50, 0);
			Item.rare = ItemRarityID.Green;
			Item.defense = 3;
		}
		public override void UpdateEquip(Player player) 
		{
			//player.minionDamage += 0.03f;
			player.GetDamage(DamageClass.Summon) += 0.03f;   // 3 % increased minion damage/
		}
	}
}