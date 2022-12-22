using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TheCollectors.Dusts;

namespace TheCollectors.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoriteTorch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Refined Meteorite Torch");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
		}

		public override void SetDefaults()
		{
			//Common Properties
			Item.width = 10;
			Item.height = 12;
			Item.value = Item.sellPrice(0, 0, 0, 9);
			Item.rare = ItemRarityID.White;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteTorch>();
			Item.flame = true;
			Item.noWet = true;
			Item.holdStyle = ItemHoldStyleID.HoldFront;

			//Use Properties
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 14;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
		}

		public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
		{ // Overrides the default sorting method of this Item.
			itemGroup = ContentSamples.CreativeHelper.ItemGroup.Torches; // Vanilla usually matches sorting methods with the right type of item, but sometimes, like with torches, it doesn't. Make sure to set whichever items manually if need be.
		}

		public override void HoldItem(Player player)
		{
			// Randomly spawn sparkles when the torch is held. Twice bigger chance to spawn them when swinging the torch.
			if (Main.rand.NextBool(player.itemAnimation > 0 ? 40 : 80))
			{
				Dust.NewDust(new Vector2(player.itemLocation.X + 16f * player.direction, player.itemLocation.Y - 14f * player.gravDir), 4, 4, ModContent.DustType<Sparkle>());
			}

			// Create a white (1.0, 1.0, 1.0) light at the torch's approximate position, when the item is held.
			Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);

			Lighting.AddLight(position, 1f, 1f, 1f);
		}

		public override void PostUpdate()
		{
			// Create a white (1.0, 1.0, 1.0) light when the item is in world, and isn't underwater.
			if (!Item.wet)
			{
				Lighting.AddLight(Item.Center, 1f, 1f, 1f);
			}
		}

		public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick)
		{
			dryTorch = true; // This makes our item eligible for being selected with smart select at a short distance when not underwater.
		}
	}
}

