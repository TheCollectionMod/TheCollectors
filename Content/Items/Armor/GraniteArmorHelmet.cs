using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class GraniteArmorHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            SetBonusText = this.GetLocalization("SetBonus");
        }
        public static LocalizedText SetBonusText { get; private set; }
        public override void SetDefaults() {
			Item.width = 24;
			Item.height = 22;
			Item.value = Item.sellPrice(0, 0, 60, 0);
			Item.rare = ItemRarityID.Orange;
			Item.defense = 6;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<GraniteArmorBreastplate>() && legs.type == ItemType<GraniteArmorGreaves>();
		}
        public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.AddBuff(BuffID.Endurance, 2);
			player.GetDamage(DamageClass.Melee) += 0.10f;   /*10 % increased melee damage*/
		}
	}
}