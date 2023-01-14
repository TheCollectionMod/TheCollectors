using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RefinedMeteoriteHelmet : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Refined Meteorite Helmet");
			Tooltip.SetDefault("+10% increased melee damage."
				+ "\n+10% increased melee critical strike chance."
				+ "\n+10% increased melee speed.");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 1, 50, 0);
			Item.rare = ItemRarityID.Pink;
			Item.defense = 24;
		}
		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Melee) += 0.10f; // Increase by 10%
			player.GetCritChance(DamageClass.Melee) += 0.10f; // Increase by 10%
			player.GetAttackSpeed(DamageClass.Melee) += 0.10f; // Increase by 10%
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<RefinedMeteoriteBreastplate>() && legs.type == ItemType<RefinedMeteoriteLeggings>();
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Immunity to 'On Fire','Burning' and lava"
							+ "\nEmits an aura of light"
							+ "\nReduced damage taken when under half health"
							+ "\n19% Increased melee speed"
							+ "\n19% Increases movement speed"
							+ "\nIncreases maximum life by 25";
			
			player.AddBuff(BuffID.Shine, 2);
			player.buffImmune[BuffID.OnFire] = true;
			player.buffImmune[BuffID.Burning] = true;
			player.lavaImmune = true;
			player.GetAttackSpeed(DamageClass.Melee) += 0.19f; // Increase by 19%
			player.moveSpeed += 0.19f;       /*19% Increases movement speed*/
			player.statLifeMax2 += 25;     /*Increases maximum life by 25*/
			if (player.statLife < 0.5f * player.statLifeMax)
			{
				player.AddBuff(ModContent.BuffType<Buffs.MeteorbodyBuff>(), 3600, false);
			}
		}
		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
			player.armorEffectDrawOutlines = false;
			player.armorEffectDrawShadowLokis = true;
			player.armorEffectDrawShadowSubtle = true;
		}
	}
}