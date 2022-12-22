﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace TheCollectors.Items.Weapons.Throwing
{
    public class HellstoneShuriken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellstone Shuriken");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            //Common Properties
            Item.width = 22; // Hitbox Width
            Item.height = 22; // Hitbox Height
            Item.value = Item.buyPrice(0, 0, 0, 45);
            Item.value = Item.sellPrice(0, 0, 0, 30);
            Item.rare = ItemRarityID.Orange;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.scale = 1.25f;

            //Use Properties
            Item.useTime = 15; //Total time that the item will take
            Item.useAnimation = 15; //Total time that the animation of the item will take
            Item.autoReuse = true;

            //Item.useTurn = true;
            Item.UseSound = SoundID.Item1;
            Item.useStyle = ItemUseStyleID.Swing;

            //Weapon Properties
            Item.noUseGraphic = true;
            Item.noMelee = true; //Weapon sprite does no damage
            Item.DamageType = DamageClass.Throwing;
            Item.damage = 40;
            Item.knockBack = 0;
            Item.crit = 4;
            Item.shootSpeed = 11f; //Velocity of projectile
            Item.shoot = ModContent.ProjectileType<Projectiles.Throwing.HellstoneShuriken>();
        }
    }
}
