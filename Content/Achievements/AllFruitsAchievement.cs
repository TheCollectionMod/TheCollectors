using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TheCollectors.Content.Items.Consumables.Food;

namespace TheCollectors.Content.Achievements
{
    public class AllFruitsAchievement : ModAchievement
    {
        public override string TextureName => "TheCollectors/Content/Achievements/AllFruitsAchievement";
        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);
            // Pre-Hardmode
            var c1 = AddItemPickupCondition([ModContent.ItemType<CopperFruit>()]);
            var c2 = AddItemPickupCondition([ModContent.ItemType<TinFruit>()]);
            var c3 = AddItemPickupCondition([ModContent.ItemType<IronFruit>()]);
            var c4 = AddItemPickupCondition([ModContent.ItemType<LeadFruit>()]);
            var c5 = AddItemPickupCondition([ModContent.ItemType<SilverFruit>()]);
            var c6 = AddItemPickupCondition([ModContent.ItemType<TungstenFruit>()]);
            var c7 = AddItemPickupCondition([ModContent.ItemType<GoldFruit>()]);
            var c8 = AddItemPickupCondition([ModContent.ItemType<PlatinumFruit>()]);
            var c9 = AddItemPickupCondition([ModContent.ItemType<FossilFruit>()]);
            var c10 = AddItemPickupCondition([ModContent.ItemType<DemoniteFruit>()]);
            var c11 = AddItemPickupCondition([ModContent.ItemType<CrimtaneFruit>()]);
            var c12 = AddItemPickupCondition([ModContent.ItemType<MeteoriteFruit>()]);
            var c13 = AddItemPickupCondition([ModContent.ItemType<ObsidianFruit>()]);
            var c14 = AddItemPickupCondition([ModContent.ItemType<HellstoneFruit>()]);
            // Hardmode
            var c15 = AddItemPickupCondition([ModContent.ItemType<CobaltFruit>()]);
            var c16 = AddItemPickupCondition([ModContent.ItemType<PalladiumFruit>()]);
            var c17 = AddItemPickupCondition([ModContent.ItemType<MythrilFruit>()]);
            var c18 = AddItemPickupCondition([ModContent.ItemType<OrichalcumFruit>()]);
            var c19 = AddItemPickupCondition([ModContent.ItemType<AdamantiteFruit>()]);
            var c20 = AddItemPickupCondition([ModContent.ItemType<TitaniumFruit>()]);
            var c21 = AddItemPickupCondition([ModContent.ItemType<HardenedMeteoriteFruit>()]);
            var c22 = AddItemPickupCondition([ModContent.ItemType<HallowedFruit>()]);
            var c23 = AddItemPickupCondition([ModContent.ItemType<ChlorophyteFruit>()]);
            var c24 = AddItemPickupCondition([ModContent.ItemType<ShroomiteFruit>()]);
            var c25 = AddItemPickupCondition([ModContent.ItemType<SpectreFruit>()]);
            var c26 = AddItemPickupCondition([ModContent.ItemType<StardustFruit>()]);
            var c27 = AddItemPickupCondition([ModContent.ItemType<SolarFruit>()]);
            var c28 = AddItemPickupCondition([ModContent.ItemType<VortexFruit>()]);
            var c29 = AddItemPickupCondition([ModContent.ItemType<NebulaFruit>()]);
            var c30 = AddItemPickupCondition([ModContent.ItemType<LuminiteFruit>()]);

        }
        public override void OnCompleted(Achievement achievement)
        {
            int firework = ProjectileID.RocketFireworksBoxRed;
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                Projectile.NewProjectile(Main.LocalPlayer.GetSource_FromThis(), Main.LocalPlayer.Top, new Vector2(Main.rand.NextFloat(-2f, 2f), -3f), firework, 0, 0, Main.myPlayer);
            }
        }
    }
}
