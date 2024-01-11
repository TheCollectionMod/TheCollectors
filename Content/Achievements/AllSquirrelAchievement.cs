using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TheCollectors.Content.Items.Consumables.Critters;

namespace TheCollectors.Content.Achievements
{
    public class AllSquirrelsAchievement : ModAchievement
    {
        public override string TextureName => "TheCollectors/Content/Achievements/AllSquirrelsAchievement";
        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);
            // Pre-Hardmode
            var c1 = AddItemPickupCondition([ModContent.ItemType<CopperSquirrelItem>()]);
            var c2 = AddItemPickupCondition([ModContent.ItemType<TinSquirrelItem>()]);
            var c3 = AddItemPickupCondition([ModContent.ItemType<IronSquirrelItem>()]);
            var c4 = AddItemPickupCondition([ModContent.ItemType<LeadSquirrelItem>()]);
            var c5 = AddItemPickupCondition([ModContent.ItemType<SilverSquirrelItem>()]);
            var c6 = AddItemPickupCondition([ModContent.ItemType<TungstenSquirrelItem>()]);
            var c7 = AddItemPickupCondition([ModContent.ItemType<GoldSquirrelItem>()]);
            var c8 = AddItemPickupCondition([ModContent.ItemType<PlatinumSquirrelItem>()]);
            var c9 = AddItemPickupCondition([ModContent.ItemType<SturdyFossilSquirrelItem>()]);
            var c10 = AddItemPickupCondition([ModContent.ItemType<DemoniteSquirrelItem>()]);
            var c11 = AddItemPickupCondition([ModContent.ItemType<CrimtaneSquirrelItem>()]);
            var c12 = AddItemPickupCondition([ModContent.ItemType<MeteoriteSquirrelItem>()]);
            var c13 = AddItemPickupCondition([ModContent.ItemType<ObsidianSquirrelItem>()]);
            var c14 = AddItemPickupCondition([ModContent.ItemType<HellstoneSquirrelItem>()]);
            // Hardmode
            var c15 = AddItemPickupCondition([ModContent.ItemType<CobaltSquirrelItem>()]);
            var c16 = AddItemPickupCondition([ModContent.ItemType<PalladiumSquirrelItem>()]);
            var c17 = AddItemPickupCondition([ModContent.ItemType<MythrilSquirrelItem>()]);
            var c18 = AddItemPickupCondition([ModContent.ItemType<OrichalcumSquirrelItem>()]);
            var c19 = AddItemPickupCondition([ModContent.ItemType<AdamantiteSquirrelItem>()]);
            var c20 = AddItemPickupCondition([ModContent.ItemType<TitaniumSquirrelItem>()]);
            var c21 = AddItemPickupCondition([ModContent.ItemType<HardenedMeteoriteSquirrelItem>()]);
            var c22 = AddItemPickupCondition([ModContent.ItemType<HallowedSquirrelItem>()]);
            var c23 = AddItemPickupCondition([ModContent.ItemType<ChlorophyteSquirrelItem>()]);
            var c24 = AddItemPickupCondition([ModContent.ItemType<ShroomiteSquirrelItem>()]);
            var c25 = AddItemPickupCondition([ModContent.ItemType<SpectreSquirrelItem>()]);
            var c26 = AddItemPickupCondition([ModContent.ItemType<StardustSquirrelItem>()]);
            var c27 = AddItemPickupCondition([ModContent.ItemType<SolarSquirrelItem>()]);
            var c28 = AddItemPickupCondition([ModContent.ItemType<VortexSquirrelItem>()]);
            var c29 = AddItemPickupCondition([ModContent.ItemType<NebulaSquirrelItem>()]);
            var c30 = AddItemPickupCondition([ModContent.ItemType<LuminiteSquirrelItem>()]);
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
