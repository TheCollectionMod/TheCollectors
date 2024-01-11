using Terraria;
using Terraria.ModLoader;
using TheCollectors.Content.Projectiles.Throwing;

namespace TheCollectors.Common.GlobalNPCs
{
    internal class DamageOverTimeGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool MeteorJavelinDebuff;

        public override void ResetEffects(NPC npc)
        {
            MeteorJavelinDebuff = false;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (MeteorJavelinDebuff)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                // Count how many ExampleJavelinProjectile are attached to this npc.
                int exampleJavelinCount = 0;
                foreach (var p in Main.ActiveProjectiles)
                {
                    if (p.type == ModContent.ProjectileType<MeteorJavelinProjectile>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI)
                    {
                        exampleJavelinCount++;
                    }
                }
                // Remember, lifeRegen affects the actual life loss, damage is just the text.
                // The logic shown here matches how vanilla debuffs stack in terms of damage numbers shown and actual life loss.
                npc.lifeRegen -= exampleJavelinCount * 2 * 3;
                if (damage < exampleJavelinCount * 3)
                {
                    damage = exampleJavelinCount * 3;
                }
            }
        }

    }
}