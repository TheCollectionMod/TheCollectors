using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class HarpyFeatherHat : ModItem
	{
		public override void SetStaticDefaults() 
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Draw hair as if a hat was covering the top. Used by Wizards Hat
            SetBonusText = this.GetLocalization("SetBonus");
        }
        public static LocalizedText SetBonusText { get; private set; }
        public override void SetDefaults() {
			Item.width = 24;
			Item.height = 22;
			Item.value = Item.sellPrice(0, 1, 50, 0);
			Item.rare = ItemRarityID.Green;
			Item.defense = 3;
		}
		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Summon) += 0.03f;   // 3 % increased minion damage/
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<HarpyFeatherChest>() && legs.type == ItemType<HarpyFeatherBoots>();
		}
		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
			player.AddBuff(BuffID.Featherfall, 2);
			player.GetDamage(DamageClass.Summon) += 0.09f;   // 9 % increased minion damage/
			player.maxMinions += 2;
		}
	}
}