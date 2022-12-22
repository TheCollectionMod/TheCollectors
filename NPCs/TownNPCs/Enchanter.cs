using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;
using Terraria.Utilities;
using Terraria.Localization;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.IO;
using TheCollectors.Items;
using System;
using System.Linq;
using TheCollectors.Projectiles.Magic;
using TheCollectors.Items.Weapons.Magic;
using Terraria.GameContent.Events;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.NPCs.TownNPCs
{
    public class EnchanterProfile : ITownNPCProfile
    {
        public int RollVariation() => 0;
        public string GetNameForVariant(NPC npc) => npc.getNewNPCName();
        public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
        {
            if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)

                return ModContent.Request<Texture2D>("TheCollectors/NPCs/TownNPCs/Enchanter");

            if (npc.altTexture == 1)

                return ModContent.Request<Texture2D>("TheCollectors/NPCs/TownNPCs/Enchanter_Party");

            return ModContent.Request<Texture2D>("TheCollectors/NPCs/TownNPCs/Enchanter");
        }
        public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("TheCollectors/NPCs/TownNPCs/Enchanter_Head");
    }
    [AutoloadHead]

    public class Enchanter : ModNPC
    {
        public override ITownNPCProfile TownNPCProfile()
        {
            return new EnchanterProfile();
        }
        public override string Texture => "TheCollectors/NPCs/TownNPCs/Enchanter";
        public int NumberOfTimesTalkedTo = 0;
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
                "Tim",
                "Timmy",
                "Timonthy",
                "Timote",
                "Timothy",
                "Timot"
            };
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanter");
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 4;      // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs.
            NPCID.Sets.AttackFrameCount[NPC.type] = 3;
            NPCID.Sets.DangerDetectRange[NPC.type] = 100;   // The amount of pixels away from the center of the npc that it tries to attack enemies.
            NPCID.Sets.AttackType[NPC.type] = NPCID.Sets.AttackType[NPCID.Wizard];
            NPCID.Sets.AttackTime[NPC.type] = 10;           // The amount of time it takes for the NPC's attack animation to be over once it starts.
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = 10;           // For when a party is active, the party hat spawns at a Y offset.

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
             .SetBiomeAffection<HallowBiome>(AffectionLevel.Like)
             .SetBiomeAffection<OceanBiome>(AffectionLevel.Dislike)
             .SetBiomeAffection<UndergroundBiome>(AffectionLevel.Hate)
             //.SetBiomeAffection<ExampleSurfaceBiome>(AffectionLevel.Love) // Para los biomas del mod, cuando tenga
             //.SetNPCAffection(ModContent.NPCType<RuneWizard>(), AffectionLevel.Love) // Para los NPCs del mod
             .SetNPCAffection(NPCID.Dryad, AffectionLevel.Love)
             .SetNPCAffection(NPCID.Wizard, AffectionLevel.Like)
             .SetNPCAffection(NPCID.PartyGirl, AffectionLevel.Like)
             .SetNPCAffection(NPCID.Cyborg, AffectionLevel.Dislike)
             .SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Dislike);
            //Princess is automatically set
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;         // Sets NPC to be a Town NPC
            NPC.friendly = true;        // NPC Will not attack player
            NPC.width = 36;
            NPC.height = 56;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.knockBackResist = 0.5f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            AnimationType = NPCID.Wizard;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the preferred biomes of this town NPC listed in the bestiary.
				// With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow,

				// You can add multiple elements if you really wanted to
				// You can also use localization keys (see Localization/en-US.lang)
				new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.Enchanter")
            });
        }
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (TheCollectorsWorld.savedEnchanter && NPC.CountNPCS(ModContent.NPCType<Enchanter>()) < 1)
            {
                return true;
            }
            return false;
        }
        public override bool CanGoToStatue(bool toKingStatue)
        {
            return true;
        }
        public override void SetChatButtons(ref string button, ref string button2)  // What the chat buttons are when you open up the chat UI
        {
            button = Language.GetTextValue("LegacyInterface.28");

        }
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
        }
        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Magic.AmethystStaffTier1>());
            shop.item[nextSlot].shopCustomPrice = 50;
            shop.item[nextSlot].shopSpecialCurrency = TheCollectors.MagicSoulId;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Magic.TopazStaffTier1>());
            shop.item[nextSlot].shopCustomPrice = 50;
            shop.item[nextSlot].shopSpecialCurrency = TheCollectors.MagicSoulId;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Magic.SapphireStaffTier1>());
            shop.item[nextSlot].shopCustomPrice = 50;
            shop.item[nextSlot].shopSpecialCurrency = TheCollectors.MagicSoulId;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Magic.EmeraldStaffTier1>());
            shop.item[nextSlot].shopCustomPrice = 50;
            shop.item[nextSlot].shopSpecialCurrency = TheCollectors.MagicSoulId;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Magic.AmberStaffTier1>());
            shop.item[nextSlot].shopCustomPrice = 50;
            shop.item[nextSlot].shopSpecialCurrency = TheCollectors.MagicSoulId;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Magic.RubyStaffTier1>());
            shop.item[nextSlot].shopCustomPrice = 50;
            shop.item[nextSlot].shopSpecialCurrency = TheCollectors.MagicSoulId;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Magic.DiamondStaffTier1>());
            shop.item[nextSlot].shopCustomPrice = 50;
            shop.item[nextSlot].shopSpecialCurrency = TheCollectors.MagicSoulId;
            nextSlot++;

            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Magic.AmethystStaffTier2>());
                shop.item[nextSlot].shopCustomPrice = 200;
                shop.item[nextSlot].shopSpecialCurrency = TheCollectors.MagicSoulId;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Magic.TopazStaffTier2>());
                shop.item[nextSlot].shopCustomPrice = 200;
                shop.item[nextSlot].shopSpecialCurrency = TheCollectors.MagicSoulId;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Magic.SapphireStaffTier2>());
                shop.item[nextSlot].shopCustomPrice = 300;
                shop.item[nextSlot].shopSpecialCurrency = TheCollectors.MagicSoulId;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Magic.EmeraldStaffTier2>());
                shop.item[nextSlot].shopCustomPrice = 300;
                shop.item[nextSlot].shopSpecialCurrency = TheCollectors.MagicSoulId;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Magic.AmberStaffTier2>());
                shop.item[nextSlot].shopCustomPrice = 400;
                shop.item[nextSlot].shopSpecialCurrency = TheCollectors.MagicSoulId;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Magic.RubyStaffTier2>());
                shop.item[nextSlot].shopCustomPrice = 400;
                shop.item[nextSlot].shopSpecialCurrency = TheCollectors.MagicSoulId;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Magic.DiamondStaffTier2>());
                shop.item[nextSlot].shopCustomPrice = 500;
                shop.item[nextSlot].shopSpecialCurrency = TheCollectors.MagicSoulId;
                nextSlot++;
            }
        }
        public override string GetChat()
        {
            NumberOfTimesTalkedTo++;
            switch (Main.rand.Next(4))
            {
                case 0:
                    {
                        switch (Main.rand.Next(2))
                        {
                            case 0:
                                {
                                    switch (Main.rand.Next(5))
                                    {
                                        case 0:
                                            return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.StandardDialogue1");
                                        case 1:
                                            return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.StandardDialogue2");
                                        case 2:
                                            return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.StandardDialogue3");
                                        case 3:
                                            return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.InfoSoul");
                                        case 4:
                                            if (NumberOfTimesTalkedTo >= 20)
                                            {
                                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.TalkALot");
                                            }
                                            else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.NotTalkALot");
                                    }
                                    return null;
                                }
                            case 1:
                                if (BirthdayParty.PartyIsUp)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.PartyIsUp");
                                }
                                else return null;
                        }
                    }
                    return null;
                case 1:
                    {
                        int wizard = NPC.FindFirstNPC(NPCID.Wizard);
                        int partygirl = NPC.FindFirstNPC(NPCID.PartyGirl);
                        int dryad = NPC.FindFirstNPC(NPCID.Dryad);
                        //int runeWizard = NPC.FindFirstNPC(ModContent.NPCType < RuneWizard());

                        switch (Main.rand.Next(3))
                        {
                            case 0:
                                if (wizard >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.Wizard", Main.npc[wizard].GivenName);
                                }
                                else return null;

                            case 1:
                                if (partygirl >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.PartyGirl", Main.npc[partygirl].GivenName);
                                }
                                else return null;
                            case 2:
                                if (dryad >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.Dryad", Main.npc[partygirl].GivenName);
                                }
                                else return null;
                                /*case 2:
                                    if (runeWizard >= 0)
                                    {
                                        return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.RuneWizard1", Main.npc[runeWizard].GivenName);
                                    }
                                    else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.RuneWizard2", Main.npc[runeWizard].GivenName);*/
                        }
                    }
                    return null;
                case 2:
                    {
                        switch (Main.invasionType)  // (Main.invasionType == X)	GoblinArmy (1), FrostLegion (2), Pirates (3), MartianMadness (4)
                        {
                            case 1:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.InvansionGenerica");
                            case 2:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.FrostInvasion2");
                            case 3:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.InvansionGenerica");
                            case 4:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.InvansionGenerica");
                            default:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.FrostInvasion1");
                        }
                    }
                case 3:
                    {
                        switch (Main.rand.Next(1))
                        {
                            case 0:
                                if (NPC.downedAncientCultist)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.AncientCultist2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.AncientCultist1");
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
            if (Main.snowMoon)
            {
                scale = 1f;                 //Scale is a multiplier for the item's drawing size, 
                item = ModContent.ItemType<RubyStaffTier1>();    //item is the ID of the item to be drawn, 
                closeness = 20;
            }
            if (Main.hardMode)
            {
                scale = 1f;                 //Scale is a multiplier for the item's drawing size, 
                item = ModContent.ItemType<DiamondStaffTier2>();    //item is the ID of the item to be drawn, 
                closeness = 20;
            }
            else
            {
                scale = 1f;                 //Scale is a multiplier for the item's drawing size, 
                item = ModContent.ItemType<DiamondStaffTier1>();    //item is the ID of the item to be drawn, 
                closeness = 20;             //and closeness is how close the item should be drawn to the NPC.
            }
        }
        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            if (Main.snowMoon)
            {
                projType = ModContent.ProjectileType<RubyBoltTier1>();
                attackDelay = 1;
            }
            if (Main.hardMode)
            {
                projType = ModContent.ProjectileType<DiamondBoltTier2>();
                attackDelay = 1;
            }
            else
            {
                projType = ModContent.ProjectileType<DiamondBoltTier1>();
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
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.WizardHat, 10)); // Drop a stack of 5 to 15 items with 1 in 2 chance (50% chance)
        }
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
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/EnchanterGore3").Type);

                    pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/EnchanterGore2").Type);

                    pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/EnchanterGore1").Type);
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