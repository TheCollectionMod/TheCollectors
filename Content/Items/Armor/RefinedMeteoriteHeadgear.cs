using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RefinedMeteoriteHeadgear : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            SetBonusText = this.GetLocalization("SetBonus");
        }
        public static LocalizedText SetBonusText { get; private set; }
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
            player.setBonus = SetBonusText.Value;
			player.AddBuff(BuffID.Shine, 2);
			player.buffImmune[BuffID.OnFire] = true;
			player.buffImmune[BuffID.Burning] = true;
			player.lavaImmune = true;
			if (player.statLife < 0.5f * player.statLifeMax)
			{
				player.AddBuff(ModContent.BuffType<Buffs.MeteorbodyBuff>(), 3600, false);
			}
			player.manaCost -= 0.2f;    //20% decreased mana cost 
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