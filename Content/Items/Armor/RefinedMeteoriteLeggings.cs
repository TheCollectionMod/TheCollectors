using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class RefinedMeteoriteLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
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
			player.GetDamage(DamageClass.Generic) += 0.07f;   // 7% Increased/
		}
	}
}