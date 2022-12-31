using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class HarpyHairpin : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Harpy Hairpin");
			Tooltip.SetDefault("3% Increased minion damage");
			ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Draw hair as if a hat was covering the top. Used by Wizards Hat
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
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
			player.setBonus = "9% Increased minion damage"
							+ "\nIncreases your max number of minions by 2."
							+ "\nGrants 'Battle' buff.";

			player.AddBuff(BuffID.Battle, 2);
			player.GetDamage(DamageClass.Summon) += 0.09f;   // 9 % increased minion damage/
			player.maxMinions += 2;
		}
	}
}