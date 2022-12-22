using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Weapons.Melee
{
    public class MeteorBoomerang : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteor Boomerang");
            Tooltip.SetDefault("Has a chance of inflicting 'On Fire!' and 'Bleeding' to enemies");
            //DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Bumerán de meteorito");
            //Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Puede infligir ¡En llamas! y 'Hemorragia' a los enemigos");
        }
        public override void SetDefaults()
        {
            Item.value = 1000000; // in copper coins
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 20; //Total time that the animation of the item will take
            Item.useTime = 31; //Total time that the item will take
            Item.autoReuse = false;
            Item.rare = ItemRarityID.Orange;
            Item.width = 22; // Hitbox Width
            Item.height = 32; // Hitbox Height
            Item.scale = 1.25f;
            Item.UseSound = SoundID.Item1;
            Item.damage = 27;
            Item.knockBack = 8f;
            Item.shoot = ModContent.ProjectileType<Projectiles.MeteorBoomerang>();
            Item.shootSpeed = 11f; //Velocity of projectile
            Item.noMelee = true; //Weapon sprite does no damage
            Item.DamageType = DamageClass.Melee;
            Item.noUseGraphic = true;
        }

        public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
