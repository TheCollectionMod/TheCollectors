using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Consumables.Critters
{
	public class MeteoriteSquirrelItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;
		}

		public override void SetDefaults()
		{
			Item.width = Item.height = 20;
			Item.rare = ItemRarityID.Blue;
			Item.maxStack = 99;
			Item.noUseGraphic = true;
			Item.value = Item.sellPrice(0, 0, 2, 0);
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = Item.useAnimation = 20;
			Item.noMelee = true;
			Item.consumable = true;
			Item.autoReuse = true;
		}

		public override bool? UseItem(Player player)
		{
			NPC.NewNPC(player.GetSource_ItemUse(Item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<NPCs.Critters.MeteoriteSquirrel>());
			return true;
		}
	}
}