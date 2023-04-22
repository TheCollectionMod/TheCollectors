using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TheCollectors.NPCs.TownGuardians
{
    public class CopperGuard : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Copper Guard");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Guide]; // Use the same number of frames as the Guide
        }

        public override void SetDefaults()
        {
            NPC.width = 18;
            NPC.height = 40;
            NPC.damage = 15;
            NPC.defense = 8;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 3; // Same AI style as the Fighter AI
            AnimationType = NPCID.Guide; // Use the same animation as the Guide
            NPC.npcSlots = 0; // Does not take up an NPC slot
            NPC.friendly = true; // Friendly NPC
            NPC.chaseable = true; // Can chase enemies
            NPC.dontTakeDamageFromHostiles = true; // Doesn't take damage from enemies
            NPC.Hitbox = new Rectangle((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height);
        }

        public override void AI()
        {
            NPC.Hitbox = new Rectangle((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height);

            // Search for enemies within range
            float range = 400f; // Set the range of the guard
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && !npc.friendly && npc.type != NPCID.TargetDummy && npc.DistanceSQ(NPC.Center) < range * range)
                {
                    // Set the guard's target to the closest enemy within range
                    NPC.target = i;
                    NPC.netUpdate = true;
                    break;
                }
            }

            if (NPC.HasValidTarget)
            {
                NPC.ai[0] = 1f; // Attack mode
            }
            else
            {
                NPC.ai[0] = 0f; // Idle mode
            }
        }
    }
}