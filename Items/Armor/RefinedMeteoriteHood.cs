using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RefinedMeteoriteHood : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Refined Meteorite Hood");
			Tooltip.SetDefault("Increases your max number of minions by 1."
				+ "\nIncreases minion damage by 15%.");
			// Be sure to have "using Terraria.Localization".
			/*DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Caperuza de meteorito refinado");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "+1 máximo de súbditos."
				+ "\n+15% daño de súbditos.");*/
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Pink;
			Item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
			//player.minionDamage += 0.15f;   /*15 % increased minion damage*/
			player.GetDamage(DamageClass.Summon) += 0.15f; // Increase by 10%
			player.maxMinions += 1;         /*Increases your max number of minions"*/
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<RefinedMeteoriteBreastplate>() && legs.type == ItemType<RefinedMeteoriteLeggings>();
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Immunity to 'On Fire','Burning' and lava"
							+ "\nEmits an aura of light"
							+ "\nReduced damage taken when under half health"
							+ "\nIncreases your max number of minions by 2.";

			player.AddBuff(BuffID.Shine, 2);
			player.buffImmune[BuffID.OnFire] = true;
			player.buffImmune[BuffID.Burning] = true;
			player.lavaImmune = true;
			player.maxMinions += 2;         /*Increases your max number of minions"*/
			/*if (player.statLife < 200)  //Ej condicion: Añade el buffo cuando la vida baja de 200
			{
				player.AddBuff(mod.BuffType("MeteorbodyBuff"), 2);
			}*/

			/*AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.FromCultureName(GameCulture.CultureName.Spanish)), "Inmunidad a '¡En llamas!','Ardiendo' y lava"
			+ "\nEmite un aura de luz"
			+ "\n+2 máximo de súbditos.");*/
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