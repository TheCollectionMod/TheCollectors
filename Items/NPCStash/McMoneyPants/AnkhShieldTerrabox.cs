using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;

namespace TheCollectors.Items.NPCStash.McMoneyPants
{
	public class AnkhShieldTerrabox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("AnkhShield mysterious terrabox");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}" // References a language key that says "Right Click To Open" in the language of the game
								+ "\nPuede tocar cualquiera de los materiales para construir el Ankh Shield.");
			
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
			itemLoot.Add(ItemDropRule.Common(ItemID.Terrarium, 1));

			var purrela = new IItemDropRule[1] 
			{
				ItemDropRule.NotScalingWithLuck(ItemID.Obsidian, 1, 5, 10),
			};

			var comun = new IItemDropRule[2] 
			{
				ItemDropRule.NotScalingWithLuck(ItemID.ObsidianSkull, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.CobaltShield, 1),
			};

			var raro = new IItemDropRule[11] 
			{
				ItemDropRule.NotScalingWithLuck(ItemID.ObsidianShield, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Blindfold, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.PocketMirror, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Vitamins, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.ArmorPolish, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.AdhesiveBandage, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Bezoar, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Nazar, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Megaphone, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.TrifoldMap, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.FastClock, 1),
			};

			var muyraro = new IItemDropRule[4]
			{
				//ItemDropRule.NotScalingWithLuck(ItemID.ReflectiveShades, 1), // 1.4.4: Added into the game.
				ItemDropRule.NotScalingWithLuck(ItemID.ArmorBracing, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.MedicatedBandage, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.CountercurseMantra, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.ThePlan, 1),
			};

			var sugorare = new IItemDropRule[1]
			{
				ItemDropRule.NotScalingWithLuck(ItemID.AnkhCharm, 1)
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