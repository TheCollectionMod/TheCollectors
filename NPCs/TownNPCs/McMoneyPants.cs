using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Terraria.Utilities;
using System;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;
using TheCollectors.Items;
using System.Linq;

namespace TheCollectors.NPCs.TownNPCs
{
    public class McMoneyPantsProfile : ITownNPCProfile
    {
        public int RollVariation() => 0;
        public string GetNameForVariant(NPC npc) => npc.getNewNPCName();
        public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
        {
            if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)

                return ModContent.Request<Texture2D>("TheCollectors/NPCs/TownNPCs/McMoneyPants");

            if (npc.altTexture == 1)

                return ModContent.Request<Texture2D>("TheCollectors/NPCs/TownNPCs/McMoneyPants_Party");

            return ModContent.Request<Texture2D>("TheCollectors/NPCs/TownNPCs/McMoneyPants");
        }
        public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("TheCollectors/NPCs/TownNPCs/McMoneyPants_Head");
    }
    [AutoloadHead]
    public class McMoneyPants : ModNPC
    {
        public override ITownNPCProfile TownNPCProfile()
        {
            return new McMoneyPantsProfile();
        }
        public override string Texture => "TheCollectors/NPCs/TownNPCs/McMoneyPants";
        public int NumberOfTimesTalkedTo = 0;
        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Nusk",
                "Vesos",
                "Suquenvergo",
                "Güilito",
                "Duopoly",
                "Jaleculani"
            };
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mc. Money Pants");
            Main.npcFrameCount[NPC.type] = 26;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 5;
            NPCID.Sets.AttackFrameCount[NPC.type] = 6;
            NPCID.Sets.DangerDetectRange[NPC.type] = 300;
            NPCID.Sets.AttackType[NPC.type] = NPCID.Sets.AttackType[NPCID.Guide];
            //NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 10;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = -7;           // For when a party is active, the party hat spawns at a Y offset.

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f,
                Direction = -1
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness
            .SetBiomeAffection<ForestBiome>(AffectionLevel.Love)
            /*.SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
            .SetBiomeAffection<HallowBiome>(AffectionLevel.Dislike)
            .SetBiomeAffection<SnowBiome>(AffectionLevel.Hate)*/
            .SetNPCAffection(NPCID.TaxCollector, AffectionLevel.Love)
            .SetNPCAffection(NPCID.Nurse, AffectionLevel.Like);
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 36;
            NPC.height = 48;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.knockBackResist = 0.5f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            AnimationType = NPCID.DyeTrader;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.McMoneyPants")
            });
        }
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (var i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                foreach (Item item in player.inventory)
                {
                    if (item.type == ModContent.ItemType<Items.NPCStash.McMoneyPants.TerraCoin>())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public override bool CanGoToStatue(bool toKingStatue)
        {
            return true;
        }     
        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
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
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.McMoneyPants.ShellphoneTerrabox>());
            shop.item[nextSlot].shopCustomPrice = 1;
            shop.item[nextSlot].shopSpecialCurrency = TheCollectors.TerraCoinId;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.McMoneyPants.AnkhShieldTerrabox>());
            shop.item[nextSlot].shopCustomPrice = 1;
            shop.item[nextSlot].shopSpecialCurrency = TheCollectors.TerraCoinId;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.McMoneyPants.ZenithTerrabox>());
            shop.item[nextSlot].shopCustomPrice = 1;
            shop.item[nextSlot].shopSpecialCurrency = TheCollectors.TerraCoinId;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NPCStash.McMoneyPants.TerrasparkBootsTerrabox>());
            shop.item[nextSlot].shopCustomPrice = 1;
            shop.item[nextSlot].shopSpecialCurrency = TheCollectors.TerraCoinId;
            nextSlot++;
        }
        /*rule => rule is ItemDropWithConditionRule drop // If the rule is an ItemDropWithConditionRule instance
						&& drop.itemId == ItemID.GreenCap // And that instance drops a green cap
						&& drop.condition is Conditions.NamedNPC npcNameCondition // ..And if its condition is that an npc name must match some string
						&& npcNameCondition.neededName == "Andrew" // And the condition's string is "Andrew".*/
        public override string GetChat()
        {
            NumberOfTimesTalkedTo++;
            switch (Main.rand.Next(4))
            {
                case 0:
                    {
                        switch (Main.rand.Next(5))
                        {
                            case 0:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.StandardDialogue1");
                            case 1:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.StandardDialogue2");
                            case 2:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.StandardDialogue3");
                            case 3:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.StandardDialogue4");
                            case 4:
                                if (NumberOfTimesTalkedTo >= 20)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.TalkALot");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.NotTalkALot");
                        }
                    }
                    return null;
                case 1:
                    {
                        int nurse = NPC.FindFirstNPC(NPCID.Nurse);
                        int taxcollector = NPC.FindFirstNPC(NPCID.TaxCollector);
                        int goblintinkerer = NPC.FindFirstNPC(NPCID.GoblinTinkerer);

                        switch (Main.rand.Next(3))
                        {
                            case 0:
                                if (nurse >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.Nurse", Main.npc[nurse].GivenName);
                                }
                                else return null;

                            case 1:
                                if (taxcollector >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.TaxCollector", Main.npc[taxcollector].GivenName);
                                }
                                else return null;
                            case 2:
                                if (goblintinkerer >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.GoblinTinkerer", Main.npc[goblintinkerer].GivenName);
                                }
                                else return null;
                        }
                    }
                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.FaltanNPCs");
                case 2:
                    {
                        switch (Main.invasionType)  // (Main.invasionType == X)	GoblinArmy (1), FrostLegion (2), Pirates (3), MartianMadness (4), (Main.eclipse)
                        {
                            case 1:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.InvansionGenerica");
                            case 2:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.InvansionGenerica");
                            case 3:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.InvansionGenerica");
                            case 4:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.InvansionGenerica");
                            default:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.NotInvansionGenerica");
                        }
                    }
                case 3:
                    {
                        switch (Main.rand.Next(2))
                        {
                            case 0:
                                if (Main.slimeRain)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.QueenSlime2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.QueenSlime1");
                            case 1:
                                if (Main.slimeRain)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.SlimeRain2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.SlimeRain1");
                        }
                    }
                    return null;
            }
            return null;
        }
       /* public override string GetChat()
        {
            NumberOfTimesTalkedTo++;
            switch (Main.rand.Next(2))
            {
                case 0:
                    {
                        switch (Main.rand.Next(1))
                        {
                            case 0:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.StandardDialogue1");
                        }
                    }
                    return null;
                case 1:
                    {
                        int dryad = NPC.FindFirstNPC(NPCID.Dryad);
                        int witchdoctor = NPC.FindFirstNPC(NPCID.WitchDoctor);
                        //int runeWizard = NPC.FindFirstNPC(ModContent.NPCType < RuneWizard());

                        switch (Main.rand.Next(2))
                        {
                            case 0:
                                if (dryad >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.Dryad1", Main.npc[dryad].GivenName);
                                }
                                return null;

                            case 1:
                                if (witchdoctor >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.WitchDoctor1", Main.npc[witchdoctor].GivenName);
                                }
                                else return null;
                        }
                    }
                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.FaltanNPCs");

            }
            return null;
        }*/
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
        public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
        {
            scale = 1f;
            item = ItemID.CoinGun;
            closeness = 20;
        }
        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
                projType = ProjectileID.GoldenBullet;
                attackDelay = 1;
        }
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 7f;
            gravityCorrection = 0f;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Armor.Vanity.McMoneyHat>(), 10)); // Drop a stack of 5 to 15 items with 1 in 2 chance (50% chance)
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 8; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.GoldCoin, 2.5f * hitDirection, -2.5f, Scale: 0.8f);
                }

                if (!Main.dedServ)
                {
                    Vector2 pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/McMoneyPantsGore3").Type);

                    pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/McMoneyPantsGore2").Type);

                    pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/McMoneyPantsGore1").Type);
                }
            }
            else
            {
                for (int k = 0; k < damage / NPC.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, hitDirection, -1f, Scale: 0.6f);
                }
            }
        }
    }
}
