using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Consumables.Critters
{
	public class MythrilBunnyItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mythril Bunny");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;
		}
		public override void SetDefaults()
		{
			//Common Properties
			Item.width = 28;
			Item.height = 28;
			Item.value = Item.sellPrice(0, 0, 15, 0);
			Item.rare = ItemRarityID.Blue;
			Item.maxStack = 99;
			Item.noMelee = true;
			Item.consumable = true;

			//Use Properties
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 15;		    
			Item.useAnimation = 15; 	
			Item.autoReuse = true;
			Item.noUseGraphic = true;
		}
		public override bool? UseItem(Player player)
		{
			NPC.NewNPC(player.GetSource_ItemUse(Item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<NPCs.Critters.MythrilBunny>());
			return true;
		}
	}
}