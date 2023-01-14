using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class GraniteArmorHelmet : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Granite Helmet");
		}
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
			player.setBonus = "10% Increased melee damage"
							+ "\nGrants 'Endurance' buff.";

			player.AddBuff(BuffID.Endurance, 2);
			player.GetDamage(DamageClass.Melee) += 0.10f;   /*10 % increased melee damage*/
			TheCollectorsPlayer modPlayer = player.GetModPlayer<TheCollectorsPlayer>();
			modPlayer.fullGraniteSet = true;
		}
	}
}