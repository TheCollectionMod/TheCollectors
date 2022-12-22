using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using TheCollectors.Projectiles.Magic;

namespace TheCollectors.Items.Weapons.Magic
{
	public class TopazStaffTier1 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Opulent Topaz Staff");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			//Common Properties
			Item.CloneDefaults(ItemID.TopazStaff);
			Item.width = 40;
			Item.height = 40;
			Item.value = Item.sellPrice(0, 0, 46, 0);
			Item.value = Item.buyPrice(0, 0, 0, 0);
			Item.rare = ItemRarityID.Green;

			//Use Properties
			Item.useTime = 35; //Total time that the item will take
			Item.useAnimation = 35; //Total time that the animation of the item will take
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item43 with { Pitch = -0.10f, PitchVariance = 0.80f };
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff

			//Weapon Properties
			Item.damage = 26; // Base Staff 16
			Item.mana = 8;
			Item.crit = 1; //le suma 1% al base
			Item.shootSpeed = 7.5f; //Velocity of projectile
			Item.shoot = ModContent.ProjectileType<TopazBoltTier1>();
		}
	}
}