using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace TheCollectors.Items.Weapons.Throwing
{
    public class SlimeShuriken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Danseiken");
            Tooltip.SetDefault("A special shuriken that bounces!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            //Common Properties
            Item.width = 22; // Hitbox Width
            Item.height = 22; // Hitbox Height
            Item.value = Item.buyPrice(0, 0, 0, 38);
            Item.value = Item.sellPrice(0, 0, 0, 25);
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.scale = 1.25f;

            //Use Properties
            Item.useTime = 15; //Total time that the item will take
            Item.useAnimation = 15; //Total time that the animation of the item will take
            Item.autoReuse = false;

            //Item.useTurn = true;
            Item.UseSound = SoundID.Item1;
            Item.useStyle = ItemUseStyleID.Swing;

            //Weapon Properties
            Item.noUseGraphic = true;
            Item.noMelee = true; //Weapon sprite does no damage
            Item.DamageType = DamageClass.Throwing;
            Item.damage = 25;
            Item.knockBack = 0;
            Item.crit = 4;
            Item.shootSpeed = 10f; //Velocity of projectile
            Item.shoot = ModContent.ProjectileType<Projectiles.Throwing.SlimeShuriken>();
        }
    }
}
