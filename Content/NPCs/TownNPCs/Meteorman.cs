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
using TheCollectors.Content.Items;
using System.Linq;
using static Terraria.ModLoader.ModContent;
using TheCollectors.Content.Dusts;
using TheCollectors.Content.Items.Weapons.Magic;
using TheCollectors.Content.Projectiles.Magic;

namespace TheCollectors.Content.NPCs.TownNPCs
{
    // [AutoloadHead] and NPC.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
    [AutoloadHead]
    public class Meteorman : ModNPC
    {
        public const string ShopName = "Shop";
        public int NumberOfTimesTalkedTo = 0;
        private static int ShimmerHeadIndex;
        private static Profiles.StackedNPCProfile NPCProfile;
        public override void Load()
        {
            // Adds our Shimmer Head to the NPCHeadLoader.
            ShimmerHeadIndex = Mod.AddNPCHeadTexture(Type, Texture + "_Shimmer_Head");
        }
        public override ITownNPCProfile TownNPCProfile()
        {
            return NPCProfile;
        }
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
                "Roco",
                "Meteoro",
                "Rocky Taicho",
                "Stonesy",
                "Space Rock"
            };
        }
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 26;

            NPCID.Sets.ExtraFramesCount[NPC.type] = 5;
            NPCID.Sets.AttackFrameCount[NPC.type] = 5;
            NPCID.Sets.DangerDetectRange[NPC.type] = 100;
            NPCID.Sets.AttackType[NPC.type] = NPCID.Sets.AttackType[NPCID.Guide];
            NPCID.Sets.AttackTime[NPC.type] = 10;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = 8; // Posición del Party Hat

            /*NPCID.Sets.DebuffImmunitySets.Add(NPC.type, new Terraria.DataStructures.NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[]
                 {
                    BuffID.OnFire,
                    BuffID.OnFire3, // Hellfire?
                    BuffID.ShadowFlame,
                    BuffID.Burning
                 }
            });*/

            NPCID.Sets.ShimmerTownTransform[Type] = true; // Allows for this NPC to have a different texture after touching the Shimmer liquid.

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
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

            // This creates a "profile" for Ninja, which allows for different textures during a party and/or while the NPC is shimmered.
            NPCProfile = new Profiles.StackedNPCProfile(
                new Profiles.DefaultNPCProfile(Texture, NPCHeadLoader.GetHeadSlot(HeadTexture), Texture + "_Party"),
                new Profiles.DefaultNPCProfile(Texture + "_Shimmer", ShimmerHeadIndex, Texture + "_Shimmer_Party")
            );
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
        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            if (TheCollectorsWorld.savedMeteorman && NPC.CountNPCS(ModContent.NPCType<Meteorman>()) < 1)
            {
                return true;
            }
            return false;
        }
        // Make this Town NPC teleport to the King and/or Queen statue when triggered. Return toKingStatue for only King Statues. Return !toKingStatue for only Queen Statues. Return true for both.
        public override bool CanGoToStatue(bool toKingStatue)
        {
            return true;
        }
        // Create a square of pixels around the NPC on teleport.
        public void StatueTeleport()
        {
            for (int i = 0; i < 30; i++)
            {
                Vector2 position = Main.rand.NextVector2Square(-20, 21);
                if (Math.Abs(position.X) > Math.Abs(position.Y))
                {
                    position.X = Math.Sign(position.X) * 20;
                }
                else
                {
                    position.Y = Math.Sign(position.Y) * 20;
                }

                Dust.NewDustPerfect(NPC.Center + position, ModContent.DustType<MeteoriteSolution>(), Vector2.Zero).noGravity = true;
            }
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = ShopName;
            }
        }
        public override void ModifyActiveShop(string shopName, Item[] items)
        {
            foreach (Item item in items)
            {
                // Skip 'air' items and null items.
                if (item == null || item.type == ItemID.None)
                {
                    continue;
                }

                // If NPC is shimmered then reduce all prices by 50%.
                if (NPC.IsShimmerVariant)
                {
                    int value = item.shopCustomPrice ?? item.value;
                    item.shopCustomPrice = value / 2;
                }
            }
        }
        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, ShopName)
                .Add<Items.Tools.MeteorClentaminator>()
                .Add<Items.Ammo.MeteoriteSolution>()
                .Add<Items.Ammo.MeteoriteHardenerSolution>(Condition.Hardmode)
                .Add<Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteCraftingStation>(Condition.Hardmode)
                .Add<Items.NPCStash.Meteorman.SturdyFossilSoil>()
                .Add<Items.NPCStash.Meteorman.CopperSoil>()
                .Add<Items.NPCStash.Meteorman.TinSoil>()
                .Add<Items.NPCStash.Meteorman.IronSoil>()
                .Add<Items.NPCStash.Meteorman.LeadSoil>()
                .Add<Items.NPCStash.Meteorman.SilverSoil>()
                .Add<Items.NPCStash.Meteorman.TungstenSoil>()
                .Add<Items.NPCStash.Meteorman.GoldSoil>()
                .Add<Items.NPCStash.Meteorman.PlatinumSoil>()
                .Add<Items.NPCStash.Meteorman.MeteoriteSoil>()
                .Add<Items.NPCStash.Meteorman.DemoniteSoil>()
                .Add<Items.NPCStash.Meteorman.CrimtaneSoil>()
                .Add<Items.NPCStash.Meteorman.ObsidianSoil>(Condition.DownedSkeletron)
                .Add<Items.NPCStash.Meteorman.HellstoneSoil>(Condition.DownedSkeletron)
                .Add<Items.NPCStash.Meteorman.CobaltSoil>(Condition.Hardmode)
                .Add<Items.NPCStash.Meteorman.PalladiumSoil>(Condition.Hardmode)
                .Add<Items.NPCStash.Meteorman.MythrilSoil>(Condition.Hardmode)
                .Add<Items.NPCStash.Meteorman.OrichalcumSoil>(Condition.Hardmode)
                .Add<Items.NPCStash.Meteorman.TitaniumSoil>(Condition.Hardmode)
                .Add<Items.NPCStash.Meteorman.AdamantiteSoil>(Condition.Hardmode)
                .Add<Items.NPCStash.Meteorman.HallowedSoil>(Condition.DownedMechBossAny)
                .Add<Items.NPCStash.Meteorman.HardenedMeteoriteSoil>(Condition.DownedMechBossAny)
                .Add<Items.NPCStash.Meteorman.ChlorophyteSoil>(Condition.DownedMechBossAll)
                .Add<Items.NPCStash.Meteorman.ShroomiteSoil>(Condition.DownedPlantera)
                .Add<Items.NPCStash.Meteorman.SpectreSoil>(Condition.DownedPlantera)
                .Add<Items.NPCStash.Meteorman.SolarSoil>(Condition.DownedSolarPillar)
                .Add<Items.NPCStash.Meteorman.VortexSoil>(Condition.DownedVortexPillar)
                .Add<Items.NPCStash.Meteorman.NebulaSoil>(Condition.DownedNebulaPillar)
                .Add<Items.NPCStash.Meteorman.StardustSoil>(Condition.DownedStardustPillar)
                .Add<Items.NPCStash.Meteorman.LuminiteSoil>(Condition.DownedMoonLord)
                .Add<Items.Armor.Vanity.MeteormanMask>(Condition.BirthdayParty)
                /*.Add<Items.Armor.Vanity.MeteormanBody>(Condition.MeteormanBody)
                .Add<Items.Armor.Vanity.MeteormanLegs>(Condition.MeteormanLegs)*/;

            npcShop.Register(); // Name of this shop tab
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
                                    Main.npcChatCornerItem = ModContent.ItemType<Content.Items.Ammo.MeteoriteHardenerSolution>();
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.MeteoriteHardenerSolution2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Meteorman.MeteoriteHardenerSolution1");
                            case 1:
                                if (Main.hardMode)
                                {
                                    Main.npcChatCornerItem = ItemID.AdamantitePickaxe;
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
        public override void DrawTownAttackGun(ref Texture2D item, ref Rectangle itemFrame, ref float scale, ref int horizontalHoldoutOffset)/* tModPorter Note: closeness is now horizontalHoldoutOffset, use 'horizontalHoldoutOffset = Main.DrawPlayerItemPos(1f, itemtype) - originalClosenessValue' to adjust to the change. See docs for how to use hook with an item type. */ //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). 
        {
            if (Main.hardMode)
            {
                int itemType = ItemID.MeteorStaff;
                Main.GetItemDrawFrame(itemType, out item, out itemFrame);
                horizontalHoldoutOffset = (int)Main.DrawPlayerItemPos(1f, itemType).X - 20;
            }
            else
            {
                // If using an existing item, use this approach
                int itemType = ModContent.ItemType<BookofMeteors>();
                Main.GetItemDrawFrame(itemType, out item, out itemFrame);
                horizontalHoldoutOffset = (int)Main.DrawPlayerItemPos(1f, itemType).X - 20;
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
                projType = ModContent.ProjectileType<MeteorHead>();
                attackDelay = 1;
            }
        }
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)//Allows you to determine the speed at which this town NPC throws a projectile when it attacks. Multiplier is the speed of the projectile, gravityCorrection is how much extra the projectile gets thrown upwards, and randomOffset allows you to randomize the projectile's velocity in a square centered around the original velocity
        {
            multiplier = 7f;
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            int num = NPC.life > 0 ? 1 : 5;

            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Lava);
            }

            if (Main.netMode != NetmodeID.Server && NPC.life <= 0)
            {
                // Retrieve the gore types. This NPC has shimmer and party variants for head, arm, and leg gore. (12 total gores)
                string variant = "";
                if (NPC.IsShimmerVariant) variant += "_Shimmer";
                if (NPC.altTexture == 1) variant += "_Party";
                int hatGore = NPC.GetPartyHatGore();
                int headGore = Mod.Find<ModGore>($"{Name}_Gore{variant}_Head").Type;
                int armGore = Mod.Find<ModGore>($"{Name}_Gore{variant}_Arm").Type;
                int legGore = Mod.Find<ModGore>($"{Name}_Gore{variant}_Leg").Type;

                // Spawn the gores. The positions of the arms and legs are lowered for a more natural look.
                if (hatGore > 0)
                {
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, hatGore);
                }
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, headGore, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 20), NPC.velocity, armGore);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 20), NPC.velocity, armGore);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 34), NPC.velocity, legGore);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 34), NPC.velocity, legGore);
            }
        }
    }
}