using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;

namespace TheCollectors.Items.NPCStash.McMoneyPants
{
	public class ZenithTerrabox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zenith mysterious terrabox");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}" // References a language key that says "Right Click To Open" in the language of the game
								+ "\nPuede tocar cualquiera de los materiales para construir la Zenith.");
			
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

			var purrela = new IItemDropRule[9] 
			{
				ItemDropRule.NotScalingWithLuck(ItemID.CopperOre, 1, 10, 15),
				ItemDropRule.NotScalingWithLuck(ItemID.Vine, 1, 10, 15),
				ItemDropRule.NotScalingWithLuck(ItemID.JungleSpores, 1, 10, 15),
				ItemDropRule.NotScalingWithLuck(ItemID.Stinger, 1, 10, 15),
				ItemDropRule.NotScalingWithLuck(ItemID.ChlorophyteOre, 1, 10, 15),
				ItemDropRule.NotScalingWithLuck(ItemID.Obsidian, 1, 10, 15),
				ItemDropRule.NotScalingWithLuck(ItemID.Hellstone, 1, 10, 15),
				ItemDropRule.NotScalingWithLuck(ItemID.DemoniteOre, 1, 10, 15),
				ItemDropRule.NotScalingWithLuck(ItemID.CrimtaneOre, 1, 10, 15),
			};

			var comun = new IItemDropRule[10] 
			{
				ItemDropRule.NotScalingWithLuck(ItemID.CopperBar, 1, 5, 10),
				ItemDropRule.NotScalingWithLuck(ItemID.CopperShortsword, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.ChlorophyteBar, 1, 5, 10),
				ItemDropRule.NotScalingWithLuck(ItemID.HallowedBar, 1, 5, 10),
				ItemDropRule.NotScalingWithLuck(ItemID.SoulofMight, 1, 5, 10),
				ItemDropRule.NotScalingWithLuck(ItemID.SoulofSight, 1, 5, 10),
				ItemDropRule.NotScalingWithLuck(ItemID.SoulofFright, 1, 5, 10),
				ItemDropRule.NotScalingWithLuck(ItemID.CrimtaneBar, 1, 5, 10),
				ItemDropRule.NotScalingWithLuck(ItemID.DemoniteBar, 1, 5, 10),
				ItemDropRule.NotScalingWithLuck(ItemID.HellstoneBar, 1, 5, 10),
			};

			var raro = new IItemDropRule[15] 
			{
				ItemDropRule.NotScalingWithLuck(ItemID.Excalibur, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BladeofGrass, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Muramasa, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.FieryGreatsword, 1), //Volcano
				ItemDropRule.NotScalingWithLuck(ItemID.LightsBane, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BloodButcherer, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BrokenHeroSword, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Starfury, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.EnchantedSword, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BeeKeeper, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Seedler, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.TheHorsemansBlade, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.InfluxWaver, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.StarWrath, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Meowmere, 1),
			};

			var muyraro = new IItemDropRule[3]
			{
				ItemDropRule.NotScalingWithLuck(ItemID.NightsEdge, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.TrueExcalibur, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.TrueNightsEdge, 1),
			};

			var sugorare = new IItemDropRule[1]
			{
				ItemDropRule.NotScalingWithLuck(ItemID.TerraBlade, 1)
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