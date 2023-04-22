using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Consumables.Food
{
	public class IronFruit : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Iromelo");
			Tooltip.SetDefault("{$CommonItemTooltip.MediumStats}\n'Mysteriously good'");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;
			Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
			ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
				new Color(249, 230, 136),
				new Color(152, 93, 95),
				new Color(174, 192, 192)
			};
			ItemID.Sets.IsFood[Type] = true;
		}
		public override void SetDefaults()
		{
			Item.DefaultToFood(22, 22, BuffID.WellFed, 54000); // 15 minutos
			Item.maxStack = 999;
			Item.value = Item.buyPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Blue;
		}
		/*public override void OnConsumeItem(Player player)
		{
			player.AddBuff(BuffID.WellFed, 3600);
		}*/
	}
}