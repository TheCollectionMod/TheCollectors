using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Personalities;
using TheCollectors.NPCs.TownNPCs;
using static Terraria.ModLoader.ModContent;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Bestiary;
using Terraria.Utilities;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;
using TheCollectors.Items;
using System.Linq;

namespace TheCollectors.NPCs
{
    public class TheCollectorsGlobalNPC : GlobalNPC
    {
        public override void ModifyGlobalLoot(GlobalLoot globalLoot)
        {
                // This is where we add global rules for all NPC. Here is a simple example:
                //globalLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.NPCStash.McMoneyPants.TerraCoin>(), 10));
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (!NPCID.Sets.CountsAsCritter[npc.type]) // Checks if NPCID Counts as a critter, if false runs the statment
            {
                // This is where we add global rules for all NPC. Here is a simple example:
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.NPCStash.McMoneyPants.TerraCoin>(), 20));
            }

            if (npc.type == NPCID.WyvernHead)
            {
                //npcLoot.Add(ItemDropRule.Common(ItemID.GreenCap, Main.rand.Next(3, 15)));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.WyvernScale>(), 2, 5, 15)); // Drop a stack of 5 to 15 items with 100 in 2 chance (50% chance)
            }

            if (npc.type == NPCID.MeteorHead)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.Magic.BookofMeteors>(), 20)); // Drop with 100 in 20 chance (5% chance)
            }

            if (npc.type == NPCID.Tim)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.MagicSoul>(), 2, 15, 20)); 
            }

            if (npc.type == NPCID.RuneWizard)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.MagicSoul>(), 2, 25, 30)); 
            }

            int[] MagicSoulPreHardmode = new int[3] {NPCID.GoblinSorcerer, NPCID.FireImp, NPCID.DarkCaster};
            int MagicSoulPreHardmodeLoot = 0;
            foreach (int drop in MagicSoulPreHardmode)
            {
                if (npc.type == MagicSoulPreHardmode[MagicSoulPreHardmodeLoot])
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.MagicSoul>(), 10, 5, 10)); 
                }
                MagicSoulPreHardmodeLoot += 1;
            }

            int[] MagicSoulHardmode = new int[7] { NPCID.DiabolistRed, NPCID.DiabolistWhite, NPCID.Necromancer, NPCID.NecromancerArmored, NPCID.RaggedCaster, NPCID.RaggedCasterOpenCoat, NPCID.DesertDjinn};
            int MagicSoulHardmodeLoot = 0;
            foreach (int drop in MagicSoulHardmode)
            {
                if (npc.type == MagicSoulHardmode[MagicSoulHardmodeLoot])
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.MagicSoul>(), 5, 15, 20)); // Drop a stack of 15 to 20 items with 1 in 5 chance (20% chance)
                }
                MagicSoulHardmodeLoot += 1;
            }
        }

        //Código para modificar la felicidad de los NPCs Vanilla
        public override void SetStaticDefaults()
        {
            int ninjaType = ModContent.NPCType<Ninja>(); // Get Ninja's type
            int enchanterType = ModContent.NPCType<Enchanter>(); // Get Ninja's type
            var guideHappiness = NPCHappiness.Get(NPCID.Guide); // Get the key into The Guide's happiness
            var partygirlHappiness = NPCHappiness.Get(NPCID.PartyGirl); // Get the key into The PartyGirl's happiness

            guideHappiness.SetNPCAffection(ninjaType, AffectionLevel.Love); // Make the Guide love Ninja!
            partygirlHappiness.SetNPCAffection(ninjaType, AffectionLevel.Like); // Make the PartyGirl like Ninja!
            partygirlHappiness.SetNPCAffection(enchanterType, AffectionLevel.Like); // Make the PartyGirl like Ninja!
        }

        public override void GetChat(NPC npc, ref string chat)
        {
            int ninja = NPC.FindFirstNPC(ModContent.NPCType<Ninja>());
            switch (npc.type)
            {
                case NPCID.Guide:
                    if (Main.rand.Next(0, 6) == 0 && NPC.CountNPCS(ModContent.NPCType<Ninja>()) > 0)
                    {
                        Language.GetTextValue("Mods.TheCollectors.Dialogue.Guide.Ninja" + Main.npc[ninja].GivenName);
                    }
                    break;
                case NPCID.BestiaryGirl: //Zoologist
                    if (Main.rand.Next(0, 6) == 0 && NPC.CountNPCS(ModContent.NPCType<Ninja>()) > 0)
                    {
                        if (Main.bloodMoon || Main.moonPhase == 0)
                        {
                            Language.GetTextValue("Mods.TheCollectors.Dialogue.Zoologist.Ninja2" + Main.npc[ninja].GivenName);
                        }
                        else
                        {
                            Language.GetTextValue("Mods.TheCollectors.Dialogue.Zoologist.Ninja1" + Main.npc[ninja].GivenName);
                        }
                    }
                    break;
            }
            int mcmoneypants = NPC.FindFirstNPC(ModContent.NPCType<McMoneyPants>());
            switch (npc.type)
            {
                case NPCID.GoblinTinkerer:
                    if (Main.rand.Next(0, 6) == 0 && NPC.CountNPCS(ModContent.NPCType<McMoneyPants>()) > 0)
                    {
                        Language.GetTextValue("Mods.TheCollectors.Dialogue.GoblinTinkerer.McMoneyPants" + Main.npc[mcmoneypants].GivenName);
                    }
                    break;
            }
        }
        //Código para añadir items a las tiendas de los NPC Vanilla
        /*public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            // This example does not use the AppliesToEntity hook, as such, we can handle multiple npcs here by using if statements.
            if (type == NPCID.Dryad)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleMountItem>());
                nextSlot++; // Don't forget this line, it is essential.

                // We can use shopCustomPrice and shopSpecialCurrency to support custom prices and currency. Usually a shop sells an item for item.value.
                // Editing item.value in SetupShop is an incorrect approach.

                // This shop entry sells for 2 Defenders Medals.
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleMountItem>());
                shop.item[nextSlot].shopCustomPrice = 2;
                shop.item[nextSlot].shopSpecialCurrency = CustomCurrencyID.DefenderMedals; // omit this line if shopCustomPrice should be in regular coins.
                nextSlot++;

                // This shop entry sells for 3 of a custom currency added in our mod.
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleMountItem>());
                shop.item[nextSlot].shopCustomPrice = 3;
                shop.item[nextSlot].shopSpecialCurrency = ExampleMod.ExampleCustomCurrencyId;
                nextSlot++;
            }
            else if (type == NPCID.Wizard)
            {
                // You can use conditions to dynamically change items offered for sale in a shop
                if (Main.expertMode)
                {
                    //TODO:
                    // shop.item[nextSlot].SetDefaults(ItemType<Infinity>());
                    // nextSlot++;
                }
            }
            else if (type == NPCID.Stylist)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleHairDye>());
                nextSlot++;
                if (Main.dayTime == false)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.ExampleItem>());
                    nextSlot++;
                }
            }
        }*/
        public override bool InstancePerEntity => true;

        public bool MeteorJavelin;

        public override void ResetEffects(NPC npc)
        {
            MeteorJavelin = false;
        }

        public override void SetDefaults(NPC npc)
        {
            // We want our MeteoriteJavelin buff to follow the same immunities as BoneJavelin
            npc.buffImmune[BuffType<Buffs.MeteorJavelinBuff>()] = npc.buffImmune[BuffID.BoneJavelin];
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
                    if (p.active && p.type == ProjectileType<Projectiles.Throwing.MeteorJavelinProjectile>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI)
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