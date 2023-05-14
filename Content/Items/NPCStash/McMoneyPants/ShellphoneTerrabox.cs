using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;

namespace TheCollectors.Content.Items.NPCStash.McMoneyPants
{
	public class ShellphoneTerrabox : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
		}

		public override void SetDefaults()
		{

			Item.width = 12; 
			Item.height = 12;
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
			var purrela = new IItemDropRule[5] 
			{
				ItemDropRule.NotScalingWithLuck(ItemID.PlatinumBar, 1, 5, 10),
				ItemDropRule.NotScalingWithLuck(ItemID.GoldBar, 1, 5, 10),
				ItemDropRule.NotScalingWithLuck(ItemID.Chain, 1, 5, 10),
				ItemDropRule.NotScalingWithLuck(ItemID.PlatinumWatch, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.GoldWatch, 1)
			};

			var comun = new IItemDropRule[14] 
			{
				ItemDropRule.NotScalingWithLuck(ItemID.DepthMeter, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Compass, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Radar, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.TallyCounter, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.LifeformAnalyzer, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.DPSMeter, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.MetalDetector, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.FishermansGuide, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.WeatherRadio, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Sextant, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.MagicMirror, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.IceMirror, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.DemonConch, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.MagicConch, 1)
			};

			var raro = new IItemDropRule[4] 
			{
				ItemDropRule.NotScalingWithLuck(ItemID.GPS, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.REK, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.GoblinTech, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.FishFinder, 1)
			};

			var muyraro = new IItemDropRule[1]
			{
				ItemDropRule.NotScalingWithLuck(ItemID.PDA, 1),
			};

			var sugorare = new IItemDropRule[1]
			{
				ItemDropRule.NotScalingWithLuck(ItemID.CellPhone, 1)
			};

			IItemDropRule[] bolsa = new IItemDropRule[1] 
			{
				ItemDropRule.SequentialRulesNotScalingWithLuck(1,
					new OneFromRulesRule(2, purrela),		// 50%
					new OneFromRulesRule(4, comun),			// 25%
					new OneFromRulesRule(8, raro),			// 12.5%
					new OneFromRulesRule(25, muyraro),		// 4%
					new OneFromRulesRule(50, sugorare)),	// 2%
			};
			itemLoot.Add(ItemDropRule.AlwaysAtleastOneSuccess(bolsa));
		}
	}
}