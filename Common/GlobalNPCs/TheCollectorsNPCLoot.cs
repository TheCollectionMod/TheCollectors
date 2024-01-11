using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TheCollectors.Content.Items;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Common.GlobalNPCs
{
    public class TheCollectorsNPCLoot : GlobalNPC
    {
        public override void ModifyGlobalLoot(GlobalLoot globalLoot)
        {
                // This is where we add global rules for all NPC. Here is a simple example:
                //globalLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.NPCStash.McMoneyPants.TerraCoin>(), 10));
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            // Terramonedas
            if (!NPCID.Sets.CountsAsCritter[npc.type]) // Checks if NPCID Counts as a critter, if false runs the statment
            {
                // This is where we add global rules for all NPC. Here is a simple example:
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.NPCStash.McMoneyPants.TerraCoin>(), 20)); //5%
            }
            // NPC Vanilla
            if (npc.type == NPCID.WyvernHead)
            {
                //npcLoot.Add(ItemDropRule.Common(ItemID.GreenCap, Main.rand.Next(3, 15)));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.WyvernScale>(), 2, 5, 15)); // Drop a stack of 5 to 15 items with 100 in 2 chance (50% chance)
            }

            if (npc.type == NPCID.MeteorHead)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.Weapons.Magic.BookofMeteors>(), 20)); // Drop with 100 in 20 chance (5% chance)
            }

            if (npc.type == NPCID.Tim)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.MagicSoul>(), 2, 15, 20)); 
            }

            if (npc.type == NPCID.RuneWizard)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.MagicSoul>(), 2, 25, 30)); 
            }

            if (npc.type == NPCID.IceSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneChestKey>(), 10));
            }

            int[] magicSoulPreHardmode = { NPCID.GoblinSorcerer, NPCID.FireImp, NPCID.DarkCaster };
            foreach (int npcId in magicSoulPreHardmode)
            {
                if (npc.type == npcId)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.MagicSoul>(), 5, 5, 10)); // 20% de probabilidad, de 5 a 10 almas
                    break; 
                }
            }

            int[] magicSoulHardmode = {
                NPCID.DiabolistRed, NPCID.DiabolistWhite, NPCID.Necromancer,NPCID.NecromancerArmored, NPCID.RaggedCaster, NPCID.RaggedCasterOpenCoat, NPCID.DesertDjinn
            };
            foreach (int npcId in magicSoulHardmode)
            {
                if (npc.type == npcId)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.MagicSoul>(), 5, 15, 20)); // 20% de probabilidad, de 15 a 20 almas
                    break;
                }
            }
        }
    }
}