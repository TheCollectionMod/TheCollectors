using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TheCollectors.Content.Items.Placeable.Paintings;

namespace TheCollectors.Content.Achievements
{
    public class MeteormanHistoryAchievement : ModAchievement
    {
        public override string TextureName => "TheCollectors/Content/Achievements/MeteormanHistoryAchievement";

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);
            var c1 = AddItemPickupCondition([ModContent.ItemType<MeteormanPaintingVol1>()]);
            var c2 = AddItemPickupCondition([ModContent.ItemType<MeteormanPaintingVol2>()]);
            var c3 = AddItemPickupCondition([ModContent.ItemType<MeteormanPaintingVol3>()]);
            var c4 = AddItemPickupCondition([ModContent.ItemType<MeteormanPaintingVol4>()]);
            var c5 = AddItemPickupCondition([ModContent.ItemType<MeteormanPaintingVol5>()]);
            var c6 = AddItemPickupCondition([ModContent.ItemType<MeteormanPaintingVolEx>()]);
        }

        public override void OnCompleted(Achievement achievement)
        {
            int firework = ProjectileID.RocketFireworksBoxBlue;
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                Projectile.NewProjectile(Main.LocalPlayer.GetSource_FromThis(), Main.LocalPlayer.Top, new Vector2(Main.rand.NextFloat(-2f, 2f), -3f), firework, 0, 0, Main.myPlayer);
            }
        }
    }
}
