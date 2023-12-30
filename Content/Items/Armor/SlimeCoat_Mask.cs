using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class SlimeCoat_Mask : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 1, 50, 0);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 2;
		}
		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Summon) += 0.01f;   /*1% increased damage*/
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<SlimeCoat_Breastplate>() && legs.type == ItemType<SlimeCoat_Leggings>();
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "3% Increased minion damage"
							+ "\nIncreases your max number of minions by 1."
							+ "\nAllows to walk on water and honey."
							+ "\nYou are slimy and sticky.";
			
			player.AddBuff(BuffID.Slimed, 2);
			player.GetDamage(DamageClass.Summon) += 0.03f;   /*3% increased damage*/
			player.maxMinions += 1;
			player.waterWalk2 = true;
		}
	}
}