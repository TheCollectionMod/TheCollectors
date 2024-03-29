using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TheCollectors.Content.Items.Placeable.RefinedMeteoriteSet;
using TheCollectors.Content.Tiles.RefinedMeteoriteSet;


namespace TheCollectors
{
	// In this class we separate recipe related code from our main class
	public class TheCollectorsRecipes : ModSystem
	{
		// A place to store the recipe group so we can easily use it later
		public static RecipeGroup TheCollectorsRecipeGroup;

		public override void Unload()
		{
			TheCollectorsRecipeGroup = null;
		}
		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => $"{Language.GetTextValue("Copper or Tin Armor")}", ItemID.IceMirror, ItemID.MagicMirror);
			RecipeGroup.RegisterGroup(nameof(ItemID.MagicMirror), group);
		}
		public override void AddRecipes()
		{
			{
			// Vanilla Only Recipes

				Recipe.Create(ItemID.SlimeStaff, 1)
					.AddIngredient(ItemID.Gel, 15)
					.AddRecipeGroup("Wood", 10) //solo sirve madera normal, revisar
					.AddTile(TileID.WorkBenches)
					.Register();

			// ModRecipes

				Recipe.Create(ModContent.ItemType<Content.Items.Ammo.MeteorArrow>(), 100)
					.AddIngredient(ItemID.WoodenArrow, 100)
					.AddIngredient(ItemID.Meteorite, 1)
					.AddTile(TileID.WorkBenches)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Accessories.MeteormanHeart>(), 1)
					.AddIngredient(ItemID.LifeCrystal, 1)
					.AddIngredient(ItemID.Meteorite, 15)
					.AddTile(TileID.WorkBenches)
					.Register();

				//Armors

				Recipe.Create(ModContent.ItemType<Content.Items.Armor.GraniteArmorHelmet>(), 1)
					.AddIngredient(ItemID.Granite, 50)
					.AddTile(TileID.Furnaces)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Armor.GraniteArmorBreastplate>(), 1)
					.AddIngredient(ItemID.Granite, 50)
					.AddTile(TileID.Furnaces)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Armor.GraniteArmorGreaves>(), 1)
					.AddIngredient(ItemID.Granite, 50)
					.AddTile(TileID.Furnaces)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Armor.HarpyFeatherHat>(), 1)
					.AddIngredient(ItemID.Feather, 15)
					.AddTile(TileID.SkyMill)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Armor.HarpyFeatherChest>(), 1)
					.AddIngredient(ItemID.Feather, 25)
					.AddTile(TileID.SkyMill)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Armor.HarpyFeatherBoots>(), 1)
					.AddIngredient(ItemID.Feather, 20)
					.AddTile(TileID.SkyMill)
					.Register();
				
				Recipe.Create(ModContent.ItemType<Content.Items.Armor.HarpyHairpin>(), 1)
					.AddIngredient(ItemID.Feather, 15)
					.AddTile(TileID.SkyMill)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Armor.RefinedMeteoriteHat>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBar>(), 12)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Armor.RefinedMeteoriteHeadgear>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBar>(), 12)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Armor.RefinedMeteoriteHelmet>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBar>(), 12)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Armor.RefinedMeteoriteHood>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBar>(), 12)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Armor.RefinedMeteoriteMask>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBar>(), 12)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Armor.RefinedMeteoriteBreastplate>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBar>(), 24)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Armor.RefinedMeteoriteLeggings>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBar>(), 18)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Armor.SlimeCoat_Mask>(), 1)
					.AddIngredient(ItemID.Gel, 15)
					.AddTile(TileID.WorkBenches)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Armor.SlimeCoat_RoyalMask>(), 1)
					.AddIngredient(ItemType<Content.Items.Armor.SlimeCoat_Mask>(), 1)
					.AddIngredient(ItemID.RoyalGel, 1)
					.AddTile(TileID.WorkBenches)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Armor.SlimeCoat_Breastplate>(), 1)
					.AddIngredient(ItemID.Gel, 25)
					.AddTile(TileID.WorkBenches)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Armor.SlimeCoat_Leggings>(), 1)
					.AddIngredient(ItemID.Gel, 15)
					.AddTile(TileID.WorkBenches)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Armor.WyvernHelmet>(), 1)
					.AddIngredient(ItemType<Content.Items.WyvernScale>(), 12)
					.AddTile(TileID.MythrilAnvil)
					.Register();
				Recipe.Create(ModContent.ItemType<Content.Items.Armor.WyvernBreastplate>(), 1)
					.AddIngredient(ItemType<Content.Items.WyvernScale>(), 12)
					.AddTile(TileID.MythrilAnvil)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Armor.WyvernGreaves>(), 1)
					.AddIngredient(ItemType<Content.Items.WyvernScale>(), 12)
					.AddTile(TileID.MythrilAnvil)
					.Register();

				//Pets

				Recipe.Create(ModContent.ItemType<Content.Pets.LivingSpaceRock.LivingSpaceRockItem> (), 1)
					.AddIngredient(ItemID.Meteorite, 5)
					.AddIngredient(ItemID.LifeCrystal)
					.AddTile(TileID.Furnaces)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Pets.Monja.MonjaItem>(), 1)
					.AddIngredient(ItemID.Silk, 10)
					.AddTile(TileID.Loom)
					.Register();

				//Placeable
				Recipe.Create(ItemID.ShroomiteBar, 1)
					.AddIngredient(ItemType<Content.Items.NPCStash.Meteorman.ShroomiteOre>(), 4)
					.AddTile(TileID.MythrilAnvil)
					.Register();
				Recipe.Create(ItemID.HallowedBar, 1)
					.AddIngredient(ItemType<Content.Items.NPCStash.Meteorman.HallowedOre>(), 4)
					.AddTile(TileID.MythrilAnvil)
					.Register();

				Recipe.Create(ItemID.SpectreBar, 1)
					.AddIngredient(ItemType<Content.Items.NPCStash.Meteorman.SpectreOre>(), 4)
					.AddTile(TileID.MythrilAnvil)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteAnimatedLantern>(), 1)
					.AddIngredient(ItemType<Content.Items.Consumables.Critters.MeteoriteFairyItem>(), 1)
					.AddIngredient(ItemID.Bottle, 1)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBar>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.HardenedMeteoriteOre>(), 4)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBathtub>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 14)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBed>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 15)
					.AddIngredient(ItemID.Silk, 5)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBench>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 8)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 5)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.HardenedMeteoriteOre>(), 1)
					.AddIngredient(ItemID.StoneBlock, 5)
					.AddTile(TileID.Furnaces)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBookcase>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 20)
					.AddIngredient(ItemID.Book, 10)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteCampfire>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteTorch>(), 5)
					.AddRecipeGroup("Wood", 10) //solo sirve madera normal, revisar
					//.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteCandelabra>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 5)
					.AddIngredient(ItemID.Torch, 3)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteCandle>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 4)
					.AddIngredient(ItemID.Torch, 1)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteChandelier>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 4)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteTorch>(), 4)
					.AddIngredient(ItemID.Chain, 1)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteChair>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 4)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteChest>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 8)
					.AddRecipeGroup("IronBar", 2) //revisar
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteChimney>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 10)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteClock>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 10)
					.AddRecipeGroup("IronBar", 3) //revisar
					.AddIngredient(ItemID.Glass, 6)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteCommandSign>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBar>(), 4)
					.AddRecipeGroup("Wood", 6) //solo sirve madera normal, revisar
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteDoor>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 6)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteDresser>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 16)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteFireplace>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 10)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteTorch>(), 2)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBar>(), 2)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteFountain>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 10)
					.AddIngredient(ItemID.WaterBucket, 1)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteLamp>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 3)
					.AddIngredient(ItemID.Torch, 1)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteLantern>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 6)
					.AddIngredient(ItemID.Torch, 1)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoritePiano>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 15)
					.AddIngredient(ItemID.Bone, 4)
					.AddIngredient(ItemID.Book, 1)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoritePlate>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 1)
					.AddIngredient(ItemID.ClayBlock, 1)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoritePlatform>(), 2)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 1)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteShingles>(), 5)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 2)
					.AddRecipeGroup("Wood", 2) //solo sirve madera normal, revisar
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteSink>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 6)
					.AddIngredient(ItemID.WaterBucket, 1)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteSofa>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 5)
					.AddIngredient(ItemID.Silk, 2)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteTable>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 8)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteToilet>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 6)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteTorch>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 4)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteTrashCan>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBar>(), 6)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteVase>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 3)
					.AddIngredient(ItemID.ClayBlock, 1)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteWall>(), 4)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 1)
					.AddTile(TileID.WorkBenches)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteWallAdvanced>(), 4)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteWall>(), 4)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteTorch>(), 1)
					.AddTile(TileID.WorkBenches)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteWorkbench>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBlock>(), 10)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneBathtub>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 140)
					.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneBed>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 150)
					.AddIngredient(ItemID.Silk, 5)
					.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.Register();

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneBench>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 80)
					//.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.AddTile(TileID.WorkBenches)
					.Register();*/

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneBookcase>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 200)
					.AddIngredient(ItemID.Book, 10)
					//.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.AddTile(TileID.WorkBenches)
					.Register();*/

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneCampfire>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneTorch>(), 5)
					.AddRecipeGroup("Wood", 10) //solo sirve madera normal, revisar
												//.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();*/

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneCandelabra>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 50)
					.AddIngredient(ItemID.Torch, 3)
					//.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.AddTile(TileID.WorkBenches)
					.Register();*/

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneCandle>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 40)
					.AddIngredient(ItemID.Torch, 1)
					.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.Register();

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneChandelier>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 40)
					.AddIngredient(ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneTorch>(), 4)
					.AddIngredient(ItemID.Chain, 1)
					//.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.AddTile(TileID.WorkBenches)
					.Register();*/

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneChair>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 40)
					.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneChest>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 80)
					.AddRecipeGroup("IronBar", 2) //revisar
					.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.Register();

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneChimney>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 100)
					//.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.AddTile(TileID.WorkBenches)
					.Register();*/

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneClock>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 100)
					.AddRecipeGroup("IronBar", 3) //revisar
					.AddIngredient(ItemID.Glass, 6)
					//.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.AddTile(TileID.WorkBenches)
					.Register();*/

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneCommandSign>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 40)
					.AddRecipeGroup("Wood", 6) //solo sirve madera normal, revisar
					//.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.AddTile(TileID.WorkBenches)
					.Register();*/

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneDoor>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 60)
					.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneDresser>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 160)
					.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.AddTile(TileID.WorkBenches)
					.Register();

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneFireplace>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 100)
					.AddIngredient(ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneTorch>(), 2)
					.AddIngredient(ItemType<Content.Items.Placeable.RedCandyCaneSet.RefinedMeteoriteBar>(), 2)
					//.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.AddTile(TileID.WorkBenches)
					.Register();*/

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneFountain>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 100)
					.AddIngredient(ItemID.WaterBucket, 1)
					//.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.AddTile(TileID.WorkBenches)
					.Register();*/

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneLamp>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 30)
					.AddIngredient(ItemID.Torch, 1)
					.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneLantern>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 60)
					.AddIngredient(ItemID.Torch, 1)
					.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.Register();

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCanePiano>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 150)
					.AddIngredient(ItemID.Bone, 4)
					.AddIngredient(ItemID.Book, 1)
					//.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.AddTile(TileID.WorkBenches)
					.Register();*/

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCanePlate>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 10)
					.AddIngredient(ItemID.ClayBlock, 1)
					//.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.AddTile(TileID.WorkBenches)
					.Register();*/

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCanePlatform>(), 2)
					.AddIngredient(ItemID.CandyCaneBlock, 10)
					.Register();

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneShingles>(), 5)
					.AddIngredient(ItemID.CandyCaneBlock, 20)
					.AddRecipeGroup("Wood", 2) //solo sirve madera normal, revisar
					.Register();*/

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneSink>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 60)
					.AddIngredient(ItemID.WaterBucket, 1)
					//.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.AddTile(TileID.WorkBenches)
					.Register();*/

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneSofa>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 50)
					.AddIngredient(ItemID.Silk, 2)
					.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneTable>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 80)
					.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.Register();

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneToilet>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 60)
					//.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.AddTile(TileID.WorkBenches)
					.Register();*/

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneTorch>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 40)
					//.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.AddTile(TileID.WorkBenches)
					.Register();*/

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneTrashCan>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBar>(), 6)
					//.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.AddTile(TileID.WorkBenches)
					.Register();*/

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneVase>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 30)
					.AddIngredient(ItemID.ClayBlock, 1)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();*/

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneWallAdvanced>(), 4)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteWall>(), 4)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteTorch>(), 1)
					.AddTile(TileID.WorkBenches)
					.Register();*/

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneWorkbench>(), 1)
					.AddIngredient(ItemID.CandyCaneBlock, 100)
					//.AddTile(TileType<Content.Tiles.RedCandyCaneSet.RedCandyCaneCraftingStation>())
					.AddTile(TileID.WorkBenches)
					.Register();*/


				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.ThrowingDummy>(), 1)
					.AddRecipeGroup("Wood", 20) //solo sirve madera normal, revisar
					.AddIngredient(ItemID.Hay, 50)
					.AddIngredient(ItemID.ThrowingKnife, 3)
					.AddTile(TileID.Sawmill)
					.Register();

				//Placeable Paintings

				/*Recipe.Create(ModContent.ItemType<Content.Items.Placeable.Paintings.MeteormanPainting1>(), 1)
					.AddIngredient(ItemID.Silk, 10)
					.AddIngredient(ItemID.Meteorite, 10)
					.AddTile(TileID.WorkBenches)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Placeable.Paintings.NinjaPainting4>(), 1)
					.AddIngredient(ItemID.Silk, 10)
					.AddIngredient(ItemID.Gel, 10)
					.AddTile(TileID.WorkBenches)
					.Register();*/

				//Tools

				Recipe.Create(ModContent.ItemType<Content.Items.Tools.MeteorFishingPole>(), 1)
					.AddIngredient(ItemID.MeteoriteBar, 8)
					.AddIngredient(ItemID.WoodFishingPole, 1)
					.AddTile(TileID.WorkBenches)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Tools.MarbleFishingPole>(), 1)
					.AddIngredient(ItemID.Marble, 10)
					.AddIngredient(ItemID.WoodFishingPole, 1)
					.AddTile(TileID.WorkBenches)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Tools.MeteorPickaxe>(), 1)
					.AddIngredient(ItemID.MeteoriteBar, 12)
					.AddTile(TileID.Anvils)
					.Register();

			//Usables

				/*Recipe.Create(ModContent.ItemType<Content.Items.Usables.SkeletonBanner>(), 1)
					.AddIngredient(ItemID.Bone, 99)
					.AddIngredient(ItemID.Silk, 10)
					.AddTile(TileID.Anvils)
					.Register();*/

			//Weapons.Melee

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Melee.MeteorBoomerang > (), 1)
					.AddIngredient(ItemID.MeteoriteBar, 10)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Melee.MeteoriteSpear>(), 1)
					.AddIngredient(ItemID.MeteoriteBar, 10)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Melee.MeteoriteYoyo>(), 1)
					.AddIngredient(ItemID.MeteoriteBar, 10)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Melee.RefinedMeteorSword>(), 1)
					.AddIngredient(ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBar>(), 24)
					.AddTile(TileType<Content.Tiles.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>())
					.Register();

				//Weapons.Magic

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Magic.BookofMeteors>(), 1)
					.AddIngredient(ItemType<Content.Items.MagicSoul>(), 10)
					.AddIngredient(ItemID.Book, 1)
					.AddIngredient(ItemID.MeteoriteBar, 5)
					.AddTile(TileID.Bookcases)
					.Register();

				//Weapons.Summon

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Summon.MeteoriteWhip>(), 1)
					.AddIngredient(ItemID.Chain, 1)
					.AddIngredient(ItemID.MeteoriteBar, 5)
					.AddTile(TileID.Furnaces)
					.Register();

				//Weapons.Throwing

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.MeteorJavelin>(), 20)
					.AddIngredient(ItemID.MeteoriteBar, 10)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.CopperShuriken>(), 100)
					.AddIngredient(ItemID.CopperBar, 1)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.TinShuriken>(), 100)
					.AddIngredient(ItemID.TinBar, 1)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.IronShuriken>(), 100)
					.AddIngredient(ItemID.IronBar, 1)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.LeadShuriken>(), 100)
					.AddIngredient(ItemID.LeadBar, 1)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.SilverShuriken>(), 100)
					.AddIngredient(ItemID.SilverBar, 1)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.TungstenShuriken>(), 100)
					.AddIngredient(ItemID.TungstenBar, 1)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.GoldShuriken>(), 100)
					.AddIngredient(ItemID.GoldBar, 1)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.PlatinumShuriken>(), 100)
					.AddIngredient(ItemID.PlatinumBar, 1)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.CrimsonShuriken>(), 100)
					.AddIngredient(ItemID.CrimtaneBar, 1)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.DemoniteShuriken>(), 100)
					.AddIngredient(ItemID.DemoniteBar, 1)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.MeteoriteShuriken>(), 100)
					.AddIngredient(ItemID.MeteoriteBar, 1)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.ObsidianShuriken>(), 100)
					.AddIngredient(ItemID.ObsidianBrick, 1)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.HellstoneShuriken>(), 100)
					.AddIngredient(ItemID.HellstoneBar, 1)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.SlimeShuriken>(), 100)
					.AddIngredient(ItemID.Gel, 10)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.EyeShuriken>(), 100)
					.AddIngredient(ItemID.Lens, 10)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.BrainShuriken>(), 100)
					.AddIngredient(ItemID.Vertebrae, 10)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.WormShuriken>(), 100)
					.AddIngredient(ItemID.RottenChunk, 10)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.BeeShuriken>(), 100)
					.AddIngredient(ItemID.Stinger, 10)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.BoneShuriken>(), 100)
					.AddIngredient(ItemID.Bone, 50)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.DeerShuriken>(), 100)
					.AddIngredient(ItemID.FlinxFur, 10)
					.AddTile(TileID.Anvils)
					.Register();

				Recipe.Create(ModContent.ItemType<Content.Items.Weapons.Throwing.WallShuriken>(), 100)
					.AddIngredient(ItemID.PlatinumBar, 1)
					.AddTile(TileID.Anvils)
					.Register();

				//Mounts

				Recipe.Create(ModContent.ItemType<Content.Mounts.MeteorHoverboardKey>(), 1)
					.AddIngredient(ItemID.GoldenKey, 1)
					.AddIngredient(ItemID.Meteorite, 15)
					.AddTile(TileID.Anvils)
					.Register();
			}
		}
	}
}
