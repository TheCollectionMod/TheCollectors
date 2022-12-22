using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class SlimeCoat_RoyalMask : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Slime Coat - Royal Mask");
			Tooltip.SetDefault("1% Increased minion damage");

			// Be sure to have "using Terraria.Localization".
			/*DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Recubrimiento de Slime - Máscara Real");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "+1% daño de súbditos.");*/
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 1;
		}
		public override void UpdateEquip(Player player)
		{
			//player.minionDamage += 0.01f;
			player.GetDamage(DamageClass.Summon) += 1;   /*1% increased damage*/
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<SlimeCoat_Breastplate>() && legs.type == ItemType<SlimeCoat_Leggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "3% Increased minion damage"
							+ "\nIncreases your max number of minions by 1."
							+ "\nAllows to walk on water and honey."
							+ "\nYou are slimy and sticky."
							+ "\nSlimes become friendly.";
			
			player.AddBuff(BuffID.Slimed, 2);
			//player.minionDamage += 0.03f;
			player.GetDamage(DamageClass.Summon) += 0.03f;   /*3% increased damage*/
			player.maxMinions += 1;
			player.waterWalk2 = true;
			player.npcTypeNoAggro[1] = true;
			player.npcTypeNoAggro[16] = true;
			player.npcTypeNoAggro[59] = true;
			player.npcTypeNoAggro[71] = true;
			player.npcTypeNoAggro[81] = true;
			player.npcTypeNoAggro[138] = true;
			player.npcTypeNoAggro[121] = true;
			player.npcTypeNoAggro[122] = true;
			player.npcTypeNoAggro[141] = true;
			player.npcTypeNoAggro[147] = true;
			player.npcTypeNoAggro[183] = true;
			player.npcTypeNoAggro[184] = true;
			player.npcTypeNoAggro[204] = true;
			player.npcTypeNoAggro[225] = true;
			player.npcTypeNoAggro[244] = true;
			player.npcTypeNoAggro[302] = true;
			player.npcTypeNoAggro[333] = true;
			player.npcTypeNoAggro[335] = true;
			player.npcTypeNoAggro[334] = true;
			player.npcTypeNoAggro[336] = true;
			player.npcTypeNoAggro[537] = true;
		}
	}
}