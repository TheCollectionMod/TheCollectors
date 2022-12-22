using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.Linq;
using TheCollectors.Projectiles.Magic;

namespace TheCollectors.Items.Weapons.Magic
{
	public class TopazStaffTier2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Greedy Opulent Topaz Staff");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			//Common Properties
			Item.CloneDefaults(ItemID.TopazStaff);
			Item.width = 44;
			Item.height = 44;
			Item.value = Item.sellPrice(0, 1, 6, 0);
			Item.value = Item.buyPrice(0, 0, 0, 0);
			Item.rare = ItemRarityID.LightRed;

			//Use Properties
			Item.useTime = 34; //Total time that the item will take
			Item.useAnimation = 34; //Total time that the animation of the item will take
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item43 with { Pitch = -0.40f, PitchVariance = 0.80f };
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff

			//Weapon Properties
			Item.damage = 46; // Base Staff 16
			Item.mana = 10;
			Item.crit = 2; //le suma 1% al base
			Item.shootSpeed = 8.5f; //Velocity of projectile
			Item.shoot = ModContent.ProjectileType<TopazBoltTier2>();
		}
	}
}