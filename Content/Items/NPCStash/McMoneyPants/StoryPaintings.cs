using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;
using TheCollectors.Content.Items.Placeable.Paintings;

namespace TheCollectors.Content.Items.NPCStash.McMoneyPants
{
	public class StoryPaintings : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
		}

		public override void SetDefaults()
		{

			Item.width = 40; 
			Item.height = 44;
			Item.maxStack = 99;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(0, 2);
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void ModifyItemLoot(ItemLoot itemLoot) //from Origins Mod
		{
			//itemLoot.Add(ItemDropRule.Common(ItemID.Terrarium, 1));
			var purrela = new IItemDropRule[4] 
			{
				ItemDropRule.NotScalingWithLuck(ModContent.ItemType<MeteormanPaintingVol1>(), 1),
				ItemDropRule.NotScalingWithLuck(ModContent.ItemType<NinjaPaintingVol1>(), 1),               
				ItemDropRule.NotScalingWithLuck(ModContent.ItemType<MeteormanPaintingVol2>(), 1),
				ItemDropRule.NotScalingWithLuck(ModContent.ItemType<NinjaPaintingVol2>(), 1),
			};

			var comun = new IItemDropRule[2] 
			{
				ItemDropRule.NotScalingWithLuck(ModContent.ItemType<MeteormanPaintingVol3>(), 1),
				ItemDropRule.NotScalingWithLuck(ModContent.ItemType<NinjaPaintingVol3>(), 1),
			};

			var raro = new IItemDropRule[2] 
			{
				ItemDropRule.NotScalingWithLuck(ModContent.ItemType<MeteormanPaintingVol4>(), 1),
				ItemDropRule.NotScalingWithLuck(ModContent.ItemType<NinjaPaintingVol4>(), 1),
			};

			var muyraro = new IItemDropRule[2]
			{
				ItemDropRule.NotScalingWithLuck(ModContent.ItemType<MeteormanPaintingVol5>(), 1),
				ItemDropRule.NotScalingWithLuck(ModContent.ItemType<NinjaPaintingVol5>(), 1),
			};

			var sugorare = new IItemDropRule[2]
			{
				ItemDropRule.NotScalingWithLuck(ModContent.ItemType<MeteormanPaintingVolEx>(), 1),
				ItemDropRule.NotScalingWithLuck(ModContent.ItemType<NinjaPaintingVolEx>(), 1),
			};

			IItemDropRule[] bolsa = new IItemDropRule[1] 
			{
				ItemDropRule.SequentialRulesNotScalingWithLuck(1,
					new OneFromRulesRule(2, purrela),
					new OneFromRulesRule(4, comun),
					new OneFromRulesRule(8, raro),
					new OneFromRulesRule(25, muyraro),
					new OneFromRulesRule(50, sugorare)),
			};
			itemLoot.Add(ItemDropRule.AlwaysAtleastOneSuccess(bolsa));
		}
	}
}