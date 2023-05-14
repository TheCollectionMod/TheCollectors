using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheCollectors.Content.Buffs;
using TheCollectors.Content.Projectiles.Throwing;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Common.GlobalNPCs
{
    public class TheCollectorsDamageOverTimeNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool MeteorJavelinDebuff;

        public override void ResetEffects(NPC npc)
        {
            MeteorJavelinDebuff = false;
        }

        public override void SetDefaults(NPC npc)
        {
            // We want our MeteoriteJavelin buff to follow the same immunities as BoneJavelin
            npc.buffImmune[BuffType<MeteorJavelinDebuff>()] = npc.buffImmune[BuffID.BoneJavelin];
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (MeteorJavelinDebuff)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                // Count how many MeteorJavelinProjectile are attached to this npc.
                int MeteorJavelinCount = 0;
                for (int i = 0; i < 1000; i++)
                {
                    Projectile p = Main.projectile[i];
                    if (p.active && p.type == ProjectileType<MeteorJavelinProjectile>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI)
                    {
                        MeteorJavelinCount++;
                    }
                }
                // Remember, lifeRegen affects the actual life loss, damage is just the text.
                // The logic shown here matches how vanilla debuffs stack in terms of damage numbers shown and actual life loss.
                npc.lifeRegen -= MeteorJavelinCount * 2 * 3;
                if (damage < MeteorJavelinCount * 3)
                {
                    damage = MeteorJavelinCount * 3;
                }
            }
        }
    }
}