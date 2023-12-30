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
            if (!NPCID.Sets.CountsAsCritter[npc.type]) // Checks if NPCID Counts as a critter, if false runs the statment
            {
                // This is where we add global rules for all NPC. Here is a simple example:
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.NPCStash.McMoneyPants.TerraCoin>(), 20)); //5%
            }

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

            int[] MagicSoulPreHardmode = new int[3] {NPCID.GoblinSorcerer, NPCID.FireImp, NPCID.DarkCaster};
            int MagicSoulPreHardmodeLoot = 0;
            foreach (int drop in MagicSoulPreHardmode)
            {
                if (npc.type == MagicSoulPreHardmode[MagicSoulPreHardmodeLoot])
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.MagicSoul>(), 5, 5, 10)); 
                }
                MagicSoulPreHardmodeLoot += 1;
            }

            int[] MagicSoulHardmode = new int[7] { NPCID.DiabolistRed, NPCID.DiabolistWhite, NPCID.Necromancer, NPCID.NecromancerArmored, NPCID.RaggedCaster, NPCID.RaggedCasterOpenCoat, NPCID.DesertDjinn};
            int MagicSoulHardmodeLoot = 0;
            foreach (int drop in MagicSoulHardmode)
            {
                if (npc.type == MagicSoulHardmode[MagicSoulHardmodeLoot])
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.MagicSoul>(), 5, 15, 20)); // Drop a stack of 15 to 20 items with 1 in 5 chance (20% chance)
                }
                MagicSoulHardmodeLoot += 1;
            }
        }

        public override bool InstancePerEntity => true;

        public bool MeteorJavelin;

        public override void ResetEffects(NPC npc)
        {
            MeteorJavelin = false;
        }

        public override void SetDefaults(NPC npc)
        {
            // We want our MeteoriteJavelin buff to follow the same immunities as BoneJavelin
            npc.buffImmune[BuffType<Content.Buffs.MeteorJavelinDebuff>()] = npc.buffImmune[BuffID.BoneJavelin];
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (MeteorJavelin)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                int MeteorJavelinCount = 0;
                for (int i = 0; i < 1000; i++)
                {
                    Projectile p = Main.projectile[i];
                    if (p.active && p.type == ProjectileType<Content.Projectiles.Throwing.MeteorJavelinProjectile>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI)
                    {
                        MeteorJavelinCount++;
                    }
                }
                npc.lifeRegen -= MeteorJavelinCount * 2 * 3;
                if (damage < MeteorJavelinCount * 3)
                {
                    damage = MeteorJavelinCount * 3;
                }
            }
        }
    }
}