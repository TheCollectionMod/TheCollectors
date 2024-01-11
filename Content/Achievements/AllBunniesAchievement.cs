using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TheCollectors.Content.Items.Consumables.Critters;

namespace TheCollectors.Content.Achievements
{
    public class AllBunniesAchievement : ModAchievement
    {
        public override string TextureName => "TheCollectors/Content/Achievements/AllBunniesAchievement";
        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);
            // Pre-Hardmode
            var c1 = AddItemPickupCondition([ModContent.ItemType<CopperBunnyItem>()]);
            var c2 = AddItemPickupCondition([ModContent.ItemType<TinBunnyItem>()]);
            var c3 = AddItemPickupCondition([ModContent.ItemType<IronBunnyItem>()]);
            var c4 = AddItemPickupCondition([ModContent.ItemType<LeadBunnyItem>()]);
            var c5 = AddItemPickupCondition([ModContent.ItemType<SilverBunnyItem>()]);
            var c6 = AddItemPickupCondition([ModContent.ItemType<TungstenBunnyItem>()]);
            var c7 = AddItemPickupCondition([ModContent.ItemType<GoldBunnyItem>()]);
            var c8 = AddItemPickupCondition([ModContent.ItemType<PlatinumBunnyItem>()]);
            var c9 = AddItemPickupCondition([ModContent.ItemType<SturdyFossilBunnyItem>()]);
            var c10 = AddItemPickupCondition([ModContent.ItemType<DemoniteBunnyItem>()]);
            var c11 = AddItemPickupCondition([ModContent.ItemType<CrimtaneBunnyItem>()]);
            var c12 = AddItemPickupCondition([ModContent.ItemType<MeteoriteBunnyItem>()]);
            var c13 = AddItemPickupCondition([ModContent.ItemType<ObsidianBunnyItem>()]);
            var c14 = AddItemPickupCondition([ModContent.ItemType<HellstoneBunnyItem>()]);
            // Hardmode
            var c15 = AddItemPickupCondition([ModContent.ItemType<CobaltBunnyItem>()]);
            var c16 = AddItemPickupCondition([ModContent.ItemType<PalladiumBunnyItem>()]);
            var c17 = AddItemPickupCondition([ModContent.ItemType<MythrilBunnyItem>()]);
            var c18 = AddItemPickupCondition([ModContent.ItemType<OrichalcumBunnyItem>()]);
            var c19 = AddItemPickupCondition([ModContent.ItemType<AdamantiteBunnyItem>()]);
            var c20 = AddItemPickupCondition([ModContent.ItemType<TitaniumBunnyItem>()]);
            var c21 = AddItemPickupCondition([ModContent.ItemType<HardenedMeteoriteBunnyItem>()]);
            var c22 = AddItemPickupCondition([ModContent.ItemType<HallowedBunnyItem>()]);
            var c23 = AddItemPickupCondition([ModContent.ItemType<ChlorophyteBunnyItem>()]);
            var c24 = AddItemPickupCondition([ModContent.ItemType<ShroomiteBunnyItem>()]);
            var c25 = AddItemPickupCondition([ModContent.ItemType<SpectreBunnyItem>()]);
            var c26 = AddItemPickupCondition([ModContent.ItemType<StardustBunnyItem>()]);
            var c27 = AddItemPickupCondition([ModContent.ItemType<SolarBunnyItem>()]);
            var c28 = AddItemPickupCondition([ModContent.ItemType<VortexBunnyItem>()]);
            var c29 = AddItemPickupCondition([ModContent.ItemType<NebulaBunnyItem>()]);
            var c30 = AddItemPickupCondition([ModContent.ItemType<LuminiteBunnyItem>()]);
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
