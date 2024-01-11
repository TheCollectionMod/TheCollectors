using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using TheCollectors.Content.Items.Placeable.Paintings;

namespace TheCollectors.Content.Achievements
{
    public class NinjaHistoryAchievement : ModAchievement
    {
        public override string TextureName => "TheCollectors/Content/Achievements/NinjaHistoryAchievement";
        public override void SetStaticDefaults()
        {
            Achievement.SetCategory(AchievementCategory.Collector);

            // SISTEMA CHECKLIST INTERNA: Cada línea registra de forma permanente que tuviste el cuadro.
            // Aunque el jugador lo venda o lo done, la checklist se queda marcada en verde.
            var c1 = AddItemPickupCondition([ModContent.ItemType<NinjaPaintingVol1>()]);
            var c2 = AddItemPickupCondition([ModContent.ItemType<NinjaPaintingVol2>()]);
            var c3 = AddItemPickupCondition([ModContent.ItemType<NinjaPaintingVol3>()]);
            var c4 = AddItemPickupCondition([ModContent.ItemType<NinjaPaintingVol4>()]);
            var c5 = AddItemPickupCondition([ModContent.ItemType<NinjaPaintingVol5>()]);
            var c6 = AddItemPickupCondition([ModContent.ItemType<NinjaPaintingVolEx>()]);

            // El rastreador nativo ConditionsCompletedTracker se encarga de ir sumando 
            // los tics (1/6, 2/6, 3/6...) de forma automática en el menú de Terraria.
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
