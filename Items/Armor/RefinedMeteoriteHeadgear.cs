using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RefinedMeteoriteHeadgear : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Refined Meteorite Headgear");
			Tooltip.SetDefault("+100 max mana"
			+ "\n+12% increased magic damage and critical strike chance");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 1, 50, 0);
			Item.rare = ItemRarityID.Pink;
			Item.defense = 5;
		}
		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 100;
			player.GetDamage(DamageClass.Magic) += 0.12f; // Increase by 12%
			player.GetCritChance(DamageClass.Magic) += 0.12f; // Increase by 12%
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<RefinedMeteoriteBreastplate>() && legs.type == ItemType<RefinedMeteoriteLeggings>();
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Immunity to 'On Fire','Burning' and lava"
							+ "\nEmits an aura of light"
							+ "\nReduced damage taken when under half health"
							+ "\n20% reduced mana usage"
							+ "\nRefined Meteor Staff don't consume mana"; //Revisar
			player.AddBuff(BuffID.Shine, 2);
			player.buffImmune[BuffID.OnFire] = true;
			player.buffImmune[BuffID.Burning] = true;
			player.lavaImmune = true;
			if (player.statLife < 0.5f * player.statLifeMax)
			{
				player.AddBuff(ModContent.BuffType<Buffs.MeteorbodyBuff>(), 3600, false);
			}
			player.manaCost -= 0.2f;    //20% decreased mana cost 
			/*if (Main.LocalPlayer.HasItem(ItemID.MeteorStaff))
			{
				player.spaceGun = true;
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