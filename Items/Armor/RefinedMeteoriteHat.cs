using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RefinedMeteoriteHat : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Refined Meteorite Hat");
			Tooltip.SetDefault("20% increased throwing damage" 
				+ "\n10% increased throwing critical strike chance");

			// Be sure to have "using Terraria.Localization".
			/*DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Gorro de meteorito refinado");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "+20% daño arrojadizo"
				+ "\n+10% probabilidad de ataque arrojadizo crítico");*/
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Pink;
			Item.defense = 9;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Throwing) += 0.20f; // Increase by 20%
			player.GetCritChance(DamageClass.Throwing) += 0.10f; // Increase by 10%
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<RefinedMeteoriteBreastplate>() && legs.type == ItemType<RefinedMeteoriteLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Immunity to 'On Fire','Burning' and lava"
							+ "\nEmits an aura of light"
							+ "\nReduced damage taken when under 200 health"
							+ "\nReduced the aggro from enemies";

			player.AddBuff(BuffID.Shine, 2);
			player.buffImmune[BuffID.OnFire] = true;
			player.buffImmune[BuffID.Burning] = true;
			player.lavaImmune = true;
			player.aggro -= 400;
			/*if (player.statLife < 200)  //Ej condicion: Añade buff cuando la vida baja de 200
			{
				player.AddBuff(mod.BuffType("MeteorbodyBuff"), 2);
			}*/
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