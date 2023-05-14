using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class WyvernHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
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

			player.GetDamage(DamageClass.Summon) += 0.10f;   /*10% increased damage*/
			player.maxMinions += 1;
		}
	}
}