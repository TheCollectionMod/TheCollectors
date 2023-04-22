using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Events;
using Terraria.GameContent.Personalities;
using Terraria.Utilities;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;
using TheCollectors.Items;
using System.Linq;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.NPCs.TownNPCs
{
    public class MeteormanProfile : ITownNPCProfile
    {
        public int RollVariation() => 0;
        public string GetNameForVariant(NPC npc) => npc.getNewNPCName();
        public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
        {
            if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)

                return ModContent.Request<Texture2D>("TheCollectors/NPCs/TownNPCs/Meteorman");

            if (npc.altTexture == 1)

                return ModContent.Request<Texture2D>("TheCollectors/NPCs/TownNPCs/Meteorman_Party");

            return ModContent.Request<Texture2D>("TheCollectors/NPCs/TownNPCs/Meteorman");
        }
        public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("TheCollectors/NPCs/TownNPCs/Meteorman_Head");
    }
    [AutoloadHead]
    public class Meteorman : ModNPC
    {
        public override ITownNPCProfile TownNPCProfile()
        {
            return new MeteormanProfile();
        }
        public override string Texture => "TheCollectors/NPCs/TownNPCs/Meteorman";
        public int NumberOfTimesTalkedTo = 0;
        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Roco",
                "Meteoro",
                "Rocky Taicho",
                "Stonesy",
                "Space Rock"
            };
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteorman");
            Main.npcFrameCount[NPC.type] = 26;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 5;
            NPCID.Sets.AttackFrameCount[NPC.type] = 5;
            NPCID.Sets.DangerDetectRange[NPC.type] = 100;
            NPCID.Sets.AttackType[NPC.type] = NPCID.Sets.AttackType[NPCID.Guide];
            NPCID.Sets.AttackTime[NPC.type] = 10;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = 8; // Posición del Party Hat

            NPCID.Sets.DebuffImmunitySets.Add(NPC.type, new Terraria.DataStructures.NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[]
                 {
                    BuffID.OnFire,
                    BuffID.OnFire3, // Hellfire?
                    BuffID.ShadowFlame,
                    BuffID.Burning
                 }
            });

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f,
                Direction = -1
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness
            //.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Love) // hacer que meteorito o cielo sean elegibles
            .SetBiomeAffection<DesertBiome>(AffectionLevel.Like)
            .SetBiomeAffection<OceanBiome>(AffectionLevel.Dislike)
            .SetBiomeAffection<SnowBiome>(AffectionLevel.Hate)
            .SetNPCAffection(NPCID.SantaClaus, AffectionLevel.Love)
            .SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Love)
            .SetNPCAffection(NPCID.Dryad, AffectionLevel.Like)
            .SetNPCAffection(NPCID.TaxCollector, AffectionLevel.Hate);
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 36;
            NPC.height = 48;
            NPC.aiStyle = 7; // Town NPC AI Style
            NPC.damage = 30;
            NPC.defense = 40;
            NPC.lifeMax = 500;
            NPC.knockBackResist = 0.5f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            AnimationType = NPCID.DyeTrader;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Meteor,
                new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.Meteorman")
            });
        }
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (TheCollectorsWorld.savedMeteorman && NPC.CountNPCS(ModContent.NPCType<Meteorman>()) < 1)
            {
                return true;
            }
            return false;
        }
        public override bool CanGoToStatue(bool toKingStatue)
        {
            return true;
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
        }
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true; // Esto lo convierte en tienda
            }
        }
        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tools.MeteorClentaminator>()); nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Ammo.MeteoriteSolution>()); nextSlot++;
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Ammo.MeteoriteHardenerSolution>()); nextSlot++;
            }
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.CopperSoil>()); nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.TinSoil>()); nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.IronSoil>()); nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.LeadSoil>()); nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.SilverSoil>()); nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.TungstenSoil>()); nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.GoldSoil>()); nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.PlatinumSoil>()); nextSlot++;
            //shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.MeteoriteSoil>()); nextSlot++;
            //shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.DemoniteSoil>()); nextSlot++;
            //shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.CrimtaneSoil>()); nextSlot++;

            if (NPC.downedBoss3) //Skeletron
            {
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.ObsidianSoil>()); nextSlot++;
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.HellstoneSoil>()); nextSlot++;
            }
            if (Main.hardMode)
            {
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.CobaltSoil>()); nextSlot++;
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.PalladiumSoil>()); nextSlot++;
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.MythrilSoil>()); nextSlot++;
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.OrichalcumSoil>()); nextSlot++;
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.TitaniumSoil>()); nextSlot++;
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.AdamantiteSoil>()); nextSlot++;
            }
            if (NPC.downedMechBossAny)
            {
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.HallowedSoil>()); nextSlot++;
            }
            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.ChlorophyteSoil>()); nextSlot++;
            }
            if (NPC.downedPlantBoss)
            {
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.ShroomiteSoil>()); nextSlot++;
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.SpectreSoil>()); nextSlot++;
            }
            if (NPC.downedMoonlord)
            {
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.Meteorman.LuminiteSoil>()); nextSlot++;

            }
            if (BirthdayParty.PartyIsUp) // fiesta activa
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Armor.Vanity.MeteormanMask>()); nextSlot++;
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Armor.Vanity.MeteormanBody>()); 
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Armor.Vanity.MeteormanLegs>());
            }
        }
        public override string GetChat()
        {
            NumberOfTimesTalkedTo++;
            switch (Main.rand.Next(5))
            {
                case 0:
                    {
                        switch (Main.rand.Next(5))
                        {
                            case 0:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.StandardDialogue1");
                            case 1:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.StandardDialogue2");
                            case 2:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.StandardDialogue3");
                            case 3:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.StandardDialogue4");
                            case 4:
                                if (NumberOfTimesTalkedTo >= 10)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.TalkALot");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.NotTalkALot");
                        }
                    }
                    return null;
                case 1:
                    {
                        int dryad = NPC.FindFirstNPC(NPCID.Dryad);
                        int demolitionist = NPC.FindFirstNPC(NPCID.Demolitionist);
                        int santaclaus = NPC.FindFirstNPC(NPCID.SantaClaus);

                        switch (Main.rand.Next(3))
                        {
                            case 0:
                                if (dryad >= 0 && Main.rand.NextBool(4))
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.Dryad", Main.npc[dryad].GivenName);
                                }
                                else return null;

                            case 1:
                                if (demolitionist >= 0 && Main.rand.NextBool(4))
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.Demolitionist", Main.npc[demolitionist].GivenName);
                                }
                                else return null;
                            case 2:
                                if (santaclaus >= 0 && Main.rand.NextBool(4))
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.SantaClaus", Main.npc[santaclaus].GivenName);
                                }
                                else return null;
                        }
                    }
                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.FaltanNPCs");
                case 2:
                    {
                        switch (Main.invasionType)  // (Main.invasionType == X)	GoblinArmy (1), FrostLegion (2), Pirates (3), MartianMadness (4), (Main.eclipse)
                        {
                            case 1:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.InvansionGenerica");
                            case 2:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.InvansionGenerica");
                            case 3:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.InvansionGenerica");
                            case 4:
                                if (!NPC.downedMartians) 
                                { 
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.MartianInvasion2");
                                }
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.MartianInvasion4"); 
                            default:
                                if (NPC.downedMartians)
                                {
                                    Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.MartianInvasion3");
                                }
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.MartianInvasion1");
                        }
                    }
                case 3:
                    {
                        switch (Main.rand.Next(2))
                        {
                            case 0:
                                if (Main.hardMode)
                                {
                                    Main.npcChatCornerItem = ModContent.ItemType<Items.Ammo.MeteoriteHardenerSolution>();
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.MeteoriteHardenerSolution2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.MeteoriteHardenerSolution1");
                            case 1:
                                if (Main.hardMode)
                                {
                                    Main.npcChatCornerItem = ItemID.MythrilPickaxe;
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.RefinedMeteoriteOre");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.MeteoriteOre");
                        }
                    }
                    return null;
                case 4:
                    {
                        switch (Main.rand.Next(4))
                        {
                            case 0:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.SoilsDialogue1");
                            case 1:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.SoilsDialogue2");
                            case 2:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.SoilsDialogue3");
                            case 3:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.SoilsDialogue4");
                        }
                    }
                    return null;
            }
            return null;
        }
        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }
        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 10;
            randExtraCooldown = 10;
        }
        public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). 
        {
            if (Main.hardMode)
            {
                scale = 1f;                 //Scale is a multiplier for the item's drawing size, 
                item = ItemID.MeteorStaff;  //item is the ID of the item to be drawn, 
                closeness = 20;
            }
            else
            {
                scale = 1f;                 //Scale is a multiplier for the item's drawing size, 
                item = ItemID.SpaceGun;     //item is the ID of the item to be drawn, 
                closeness = 20;             //and closeness is how close the item should be drawn to the NPC.
            }

        }
        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)//Allows you to determine the projectile type of this town NPC's attack, and how long it takes for the projectile to actually appear
        {
            if (Main.hardMode)
            {
                projType = ProjectileID.Meteor3;
                attackDelay = 1;
            }
            else
            {
                projType = ProjectileID.MeteorShot;
                attackDelay = 1;
            }
        }
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)//Allows you to determine the speed at which this town NPC throws a projectile when it attacks. Multiplier is the speed of the projectile, gravityCorrection is how much extra the projectile gets thrown upwards, and randomOffset allows you to randomize the projectile's velocity in a square centered around the original velocity
        {
            multiplier = 7f;
        }
        /*public override void OnKill()
        {
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<Items.Accessories.MeteormanHeart>(), 1, false, 0, false, false);
        }*/
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Armor.Vanity.MeteormanMask>(), 10)); // Drop a stack of 5 to 15 items with 1 in 2 chance (50% chance)
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 8; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Lava, 2.5f * hitDirection, -2.5f, Scale: 0.8f);
                }

                if (!Main.dedServ)
                {
                    Vector2 pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/MeteormanGore3").Type);

                    pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/MeteormanGore2").Type);

                    pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/MeteormanGore1").Type);
                }
            }
            else
            {
                for (int k = 0; k < damage / NPC.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Lava, hitDirection, -1f, Scale: 0.6f);
                }
            }
        }
    }
}