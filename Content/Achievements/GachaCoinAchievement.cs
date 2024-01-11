using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Achievements;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Achievements
{
    public class GachaCoinAchievement : ModAchievement
    {
        public override string TextureName => "TheCollectors/Content/Achievements/GachaCoinAchievement";

        public static CustomIntCondition TerraCoinPickupCondition;

        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);
            TerraCoinPickupCondition = AddIntCondition("TerraCoinPickupCount", 1000);
        }

        public override void OnCompleted(Achievement achievement)
        {
            int firework = ProjectileID.RocketFireworksBoxYellow;

            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                Projectile.NewProjectile(
                    Main.LocalPlayer.GetSource_FromThis(),
                    Main.LocalPlayer.Top,
                    new Vector2(Main.rand.NextFloat(-2f, 2f), -3f),
                    firework, 0, 0, Main.myPlayer
                );
            }
        }
    }
}

