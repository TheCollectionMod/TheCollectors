/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Tools
{
	public class ExplosivePickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Geode Pickaxe");
			Tooltip.SetDefault("Right-click to cause a powerful explosion in a 5-chunk radius");
		}

		public override void SetDefaults()
		{
			//Common Properties
			Item.width = 32;
			Item.height = 32;
			Item.value = 22000;
			Item.rare = ItemRarityID.Green;

			//Use Properties
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item1;
			Item.useStyle = ItemUseStyleID.Swing;

			//Weapon Properties
			Item.DamageType = DamageClass.Melee;
			Item.damage = 20;
			Item.knockBack = 6;

			//Tool Propierties
			Item.pick = 100;
			Item.scale = 1.15f;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2) // Alt function (right-click)
			{
				Item.useTime = 60;
				Item.useAnimation = 60;
				Item.UseSound = SoundID.Item14; // Explosion sound
				Item.shoot = ProjectileID.None; // No projectile
				Item.pick = 0; // No pickaxe power
			}
			else // Normal function (left-click)
			{
				Item.useTime = 20;
				Item.useAnimation = 20;
				Item.UseSound = SoundID.Item1; // Normal swing sound
				Item.shoot = ProjectileID.None; // No projectile
				Item.pick = 100; // Normal pickaxe power
			}
			return base.CanUseItem(player);
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (player.altFunctionUse == 2) // Alt function (right-click)
			{
				// Apply temporary debuff
				player.AddBuff(BuffID.Confused, 60 * 60);
			}
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (player.altFunctionUse == 2) // Alt function (right-click)
			{
				// Trigger explosion
				int radius = 24; // cambio el radio a 3 chunks
				int x = (int)(hitbox.Center.X / 16f / 16f) - radius;
				int y = (int)(hitbox.Center.Y / 16f / 16f) - radius;
				for (int i = x; i < x + radius * 2 + 1; i++)
				{
					for (int j = y; j < y + radius * 2 + 1; j++)
					{
						if (Main.tile[i, j] != null && Main.tile[i, j].active && !Main.tile[i, j].inActive)
						{
							WorldGen.KillTile(i, j, false, false, true);
							if (Main.netMode == NetmodeID.Server)
							{
								NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
							}
						}
					}
				}

				// Apply temporary debuff
				player.AddBuff(BuffID.Confused, 60 * 60);
			}
		}
	}
}*/
