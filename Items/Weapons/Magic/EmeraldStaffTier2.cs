using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using TheCollectors.Projectiles.Magic;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Weapons.Magic
{
	public class EmeraldStaffTier2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spiky Nature Emerald Staff");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			//Common Properties
			Item.CloneDefaults(ItemID.EmeraldStaff);
			Item.width = 44;
			Item.height = 44;
			Item.value = Item.sellPrice(0, 1, 30, 0);
			Item.value = Item.buyPrice(0, 0, 0, 0);
			Item.rare = ItemRarityID.Pink;

			//Use Properties
			Item.useTime = 31; //Total time that the item will take
			Item.useAnimation = 31; //Total time that the animation of the item will take
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item43 with { Pitch = -0.40f, PitchVariance = 0.80f };
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff

			//Weapon Properties
			Item.damage = 39; // Base Staff 19
			Item.mana = 12;
			Item.crit = 2; //le suma 1% al base
			Item.shootSpeed = 10f; //Velocity of projectile
			Item.shoot = ModContent.ProjectileType<EmeraldBoltTier2>();
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return head.type == ItemID.ChlorophyteHeadgear || head.type == ItemID.ChlorophyteHelmet && body.type == ItemID.ChlorophytePlateMail && legs.type == ItemID.ChlorophyteGreaves;
		}

		public override void UpdateArmorSet(Player player)
		{
			//player.setBonus = "10% Increased melee damage"
			//				+ "\nGrants 'Endurance' buff.";

			player.AddBuff(BuffID.LeafCrystal, 18000);
			//player.GetDamage(DamageClass.Melee) += 0.10f;   /*10 % increased melee damage*/
			TheCollectorsPlayer modPlayer = player.GetModPlayer<TheCollectorsPlayer>();
			modPlayer.FakeCrystalLeafSet = true;
		}
	}
}