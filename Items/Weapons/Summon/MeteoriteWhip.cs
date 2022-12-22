﻿using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Weapons.Summon
{
	public class MeteoriteWhip : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			Item.DefaultToWhip(ModContent.ProjectileType<Projectiles.Summon.MeteoriteWhipProjectile>(), 20, 2, 4);

			Item.shootSpeed = 4;
			Item.rare = ItemRarityID.Green;

			Item.channel = true;
		}

		// Makes the whip receive melee prefixes
		public override bool MeleePrefix()
		{
			return true;
		}
	}
}
