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
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.IO;
using System;
using TheCollectors.Projectiles.Magic;
using TheCollectors.Items.Weapons.Magic;
using static Terraria.ModLoader.ModContent;


namespace TheCollectors.NPCs.TownNPCs
{
    public class ArcheologistProfile : ITownNPCProfile
    {
        public int RollVariation() => 0;
        public string GetNameForVariant(NPC npc) => npc.getNewNPCName();
        public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
        {
            if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)

                return ModContent.Request<Texture2D>("TheCollectors/NPCs/TownNPCs/Archeologist");

            if (npc.altTexture == 1)

                return ModContent.Request<Texture2D>("TheCollectors/NPCs/TownNPCs/Archeologist_Party");

            return ModContent.Request<Texture2D>("TheCollectors/NPCs/TownNPCs/Archeologist");
        }
        public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("TheCollectors/NPCs/TownNPCs/Archeologist_Head");
    }
    [AutoloadHead]

    public class Archeologist : ModNPC
    {
        public override ITownNPCProfile TownNPCProfile()
        {
            return new ArcheologistProfile();
        }
        public override string Texture => "TheCollectors/NPCs/TownNPCs/Archeologist";
        public int NumberOfTimesTalkedTo = 0;
        private static bool LoreNPCs;
        private static bool LoreBosses;
        private static int tiendaNum = 1;
        public override void LoadData(TagCompound tag)
        {
            NumberOfTimesTalkedTo = tag.GetInt("numberOfTimesTalkedTo");
        }
        public override void SaveData(TagCompound tag)
        {
            tag["numberOfTimesTalkedTo"] = NumberOfTimesTalkedTo;
        }
        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Dr. Jones",
                "Indy",
                "Capitán Dinamita",
                "Jonesy",
                "Mungo Kidogo"
            };
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Archeologist");
            Main.npcFrameCount[NPC.type] = 26;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 5;
            NPCID.Sets.AttackFrameCount[NPC.type] = 6;
            NPCID.Sets.DangerDetectRange[NPC.type] = 100;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 10;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = -7;           // For when a party is active, the party hat spawns at a Y offset.

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f,  // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
                Direction = -1  // -1 is left and 1 is right. NPCs are drawn facing the left by default.
                                // Rotation = MathHelper.ToRadians(180) // You can also change the rotation of an NPC. Rotation is measured in radians
                                // If you want to see an example of manually modifying these when the NPC is drawn, see PreDraw
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness
            .SetBiomeAffection<JungleBiome>(AffectionLevel.Love)
            .SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
            .SetBiomeAffection<HallowBiome>(AffectionLevel.Dislike)
            .SetBiomeAffection<SnowBiome>(AffectionLevel.Hate)
            .SetNPCAffection(NPCID.Dryad, AffectionLevel.Love)
            .SetNPCAffection(NPCID.BestiaryGirl, AffectionLevel.Like)
            .SetNPCAffection(NPCID.Guide, AffectionLevel.Dislike)
            .SetNPCAffection(ModContent.NPCType<Ninja>(), AffectionLevel.Dislike) // Para los NPCs del mod
            .SetNPCAffection(NPCID.WitchDoctor, AffectionLevel.Hate);
            //Princess is automatically set
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
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,
				new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.Archeologist")
            });
        }
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (var i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                foreach (Item item in player.inventory)
                {
                    if (item.type == ItemID.RopeCoil)
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
        public override void SetChatButtons(ref string button, ref string button2)  // What the chat buttons are when you open up the chat UI
        {
            switch (tiendaNum)
            {
                case 1:
                    button = Language.GetTextValue("LegacyInterface.28");
                    break;

                case 2:
                    button = "Lore - Ciudadanos";
                    break;

                default:
                    button = "Lore - Jefes";
                    break;
            }

            button2 = "Cambiar botón";
                 
           if (tiendaNum >= 4)
           {
               tiendaNum = 1;
           }

        }
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
                switch (tiendaNum)
                {
                    case 1:
                        LoreNPCs = true;
                        LoreBosses = false;
                        break;
                    case 2:
                        LoreNPCs = false;
                        LoreBosses = true;
                        break;
                    case 3:
                        LoreNPCs = false;
                        LoreBosses = false;
                        break;
                }
            }
            else if (!firstButton)
            {
                tiendaNum++;
            }
        }
        public override void SetupShop(Chest shop, ref int nextSlot)
        {

            if (LoreNPCs)
            {
                Main.npcChatText = Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.LoreNPCs");
            }
            else if (LoreBosses)
            {
                Main.npcChatText = Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.LoreBosses");
            }
            else if (!LoreBosses && !LoreNPCs)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Torch); nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Rope); nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.RopeCoil); nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Bomb); nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.GrapplingHook); nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Boomstick); nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.MusketBall); nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.ChainKnife); nextSlot++;

                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.DyeTradersScimitar); nextSlot++;
                }

                if (Main.bloodMoon)
                    shop.item[nextSlot].SetDefaults(ItemID.SilverBullet);
            }
        }
        public override string GetChat()
        {
            NumberOfTimesTalkedTo++;
            switch (Main.rand.Next(5))
            {
                case 0:
                    {
                        switch (Main.rand.Next(7))
                        {
                            case 0:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.StandardDialogue1");
                            case 1:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.StandardDialogue2");
                            case 2:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.StandardDialogue3");
                            case 3:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.StandardDialogue4");
                            case 4:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.StandardDialogue5");
                            case 5:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.InfoLore");
                            case 6:
                                if (NumberOfTimesTalkedTo >= 20)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.TalkALot");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.NotTalkALot");
                        }
                    }
                    return null;
                case 1:
                    {
                        int dryad = NPC.FindFirstNPC(NPCID.Dryad);
                        int bestiarygirl = NPC.FindFirstNPC(NPCID.BestiaryGirl);
                        int guide = NPC.FindFirstNPC(NPCID.Guide);
                        int witchdoctor = NPC.FindFirstNPC(NPCID.WitchDoctor);
                        int ninja = NPC.FindFirstNPC(ModContent.NPCType <Ninja>());

                        switch (Main.rand.Next(2))
                        {
                            case 0:
                                if (dryad >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Dryad", Main.npc[dryad].GivenName);
                                }
                                else return null;
                            case 1:
                                if (bestiarygirl >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.BestiaryGirl", Main.npc[bestiarygirl].GivenName);
                                }
                                else return null;
                            case 2:
                                if (guide >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Guide", Main.npc[guide].GivenName);
                                }
                                else return null;
                            case 3:
                                if (witchdoctor >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.WitchDoctor", Main.npc[witchdoctor].GivenName);
                                }
                                else return null;
                            case 4:
                                if (ninja >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Ninja", Main.npc[ninja].GivenName);
                                }
                                else return null;
                        }
                    }
                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.FaltanNPCs");
                case 2:
                    {
                        switch (Main.invasionType)  // (Main.invasionType == X)	GoblinArmy (1), FrostLegion (2), Pirates (3), MartianMadness (4)
                        {
                            case 1:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.GoblinInvasion");
                            case 2:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.FrostLegionInvasion");
                            case 3:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.PiratesInvansion");
                            case 4:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.MartianInvansion");
                            default:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.NotInvasion");
                        }
                    }
                case 3:
                    {
                        switch (Main.rand.Next(7))
                        {
                            case 0:
                                if (NPC.downedSlimeKing)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.SlimeKing2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.SlimeKing1");
                            case 1:
                                if (NPC.downedBoss1)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.EyeofCthulhu2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.EyeofCthulhu1");
                            case 2:
                                if (NPC.downedBoss2)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.BrainWorm2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.BrainWorm1");
                            case 3:
                                if (NPC.downedQueenBee)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.QueenBee2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.QueenBee1");
                            case 4:
                                if (NPC.downedBoss3)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Skeletron2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Skeletron1");
                            case 5:
                                if (NPC.downedDeerclops)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Deerclops2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Deerclops1");
                            case 6:
                                if (Main.hardMode)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Wall2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Wall1");
                            default:
                                if (Main.hardMode)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Hardmode");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.NotHardmode");
                        }
                    }

                case 4:
                    {
                        if (Main.hardMode) 
                        {
                            switch (Main.rand.Next(8))
                            {
                                case 0:
                                    if (NPC.downedMechBoss2)
                                    {
                                        return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Twins2");
                                    }
                                    else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Twins1");
                                case 1:
                                    if (NPC.downedMechBoss1)
                                    {
                                        return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Destroyer2");
                                    }
                                    else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Destroyer1");
                                case 2:
                                    if (NPC.downedMechBoss3)
                                    {
                                        return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.SkeletronPrime2");
                                    }
                                    else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.SkeletronPrime1");
                                case 3:
                                    if (NPC.downedPlantBoss)
                                    {
                                        return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Plantera2");
                                    }
                                    else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Plantera1");
                                case 4:
                                    if (NPC.downedGolemBoss)
                                    {
                                        return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Golem2");
                                    }
                                    else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Golem1");
                                case 5:
                                    if (NPC.downedFishron)
                                    {
                                        return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Fishron2");
                                    }
                                    else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Fishron1");
                                case 6:
                                    if (NPC.downedEmpressOfLight)
                                    {
                                        return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.EmpressOfLight2");
                                    }
                                    else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.EmpressOfLight1");
                                case 7:
                                    if (NPC.downedAncientCultist)
                                    {
                                        switch (Main.rand.Next(2))
                                        {
                                            case 0:
                                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.AncientCultist2");
                                            case 1:
                                                if (NPC.downedTowers)
                                                    switch (Main.rand.Next(2))
                                                    {
                                                        case 0:
                                                            return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Towers2");
                                                        case 1:
                                                            if (NPC.downedMoonlord)
                                                            {
                                                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Moonlord2");
                                                            }
                                                            else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Moonlord1");
                                                    }
                                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Towers1");
                                        }
                                       return null;
                                    }
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.AncientCultist1");
                            }
                        }
                        else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.NotHardmode");
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

            if (Main.snowMoon)
            {
                scale = 1f;
                item =  ItemID.FireWhip;
                closeness = 20;
            }
            if (Main.hardMode)
            {
                scale = 1f;
                item = ItemID.SwordWhip;
                closeness = 20;
            }
            else
            {
                scale = 1f;
                item = ItemID.BlandWhip;
                closeness = 20;
            }
        }
        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            if (Main.hardMode)
            {
                projType = ProjectileID.PoisonedKnife;
                attackDelay = 1;
            }
            else
            {
                projType = ProjectileID.Shuriken;
                attackDelay = 1;
            }

            if (Main.snowMoon)
            {
                projType = ProjectileID.StarAnise;
                attackDelay = 1;
            }

            if (Main.bloodMoon)
            {
                projType = ProjectileID.BoneDagger;
                attackDelay = 1;
            }

            if (Main.pumpkinMoon)
            {
                projType = ProjectileID.MolotovCocktail;
                attackDelay = 1;
            }
        }
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 7f;
            gravityCorrection = 0f;
            randomOffset = 2f;
        }
        /*public override void OnKill()
        {
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.WizardHat, 1, false, 0, false, false);
        }*/
        /* public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.WizardHat, 10)); // Drop a stack of 5 to 15 items with 1 in 2 chance (50% chance)
        }*/
        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 8; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, 2.5f * hitDirection, -2.5f, Scale: 0.8f);
                }

                if (!Main.dedServ)
                {
                    Vector2 pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/ArqueologistGore3").Type);

                    pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/ArqueologistGore2").Type);

                    pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/ArqueologistGore1").Type);
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
          /*  // Chat Normal
            switch (Main.rand.Next(5))
            {
                case 0:
                    return "They had to be snakes ...";
                case 1:
                    if (NPC.downedPlantBoss)
                    {
                        return "That key has to be the one that opens the jungle temple.";
                    }
                    else
                    {
                        return "It is said that there is a hidden temple in the jungle.";
                    }

                case 2:
                    return "I wanted to use a whip, but it's not implemented yet ";
                case 3:
                    {
                        // Main.npcChatCornerItem shows a single item in the corner, like the Angler Quest chat.
                        Main.npcChatCornerItem = ItemID.EndlessMusketPouch;
                        return $"Hey, if you find a [i:{ItemID.EndlessMusketPouch}], I can upgrade it for you. 'Not yet implemented'";
                    }
                default: // Default is the default if no other case is true. In this case if random nu
                    return "Hello, I am an experienced archaeologist, I can provide very useful basic equipment.";*/