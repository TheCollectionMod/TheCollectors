using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class HarpyFeatherChest : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Harpy Feather Chest");
			Tooltip.SetDefault("3% Increased minion damage");
		}
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 20;
			Item.value = Item.sellPrice(0, 1, 50, 0);
			Item.rare = ItemRarityID.Green;
			Item.defense = 4;
		}
		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Summon) += 0.03f;   // 3 % increased minion damage/
		}
		public override void AddRecipes()
		{
			Recipe.Create(ModContent.ItemType<Items.Armor.HarpyFeatherChest>(), 1)
				.AddIngredient(ItemID.Feather, 25)
				.AddTile(TileID.Furnaces)
				.Register();
		}
	}
}