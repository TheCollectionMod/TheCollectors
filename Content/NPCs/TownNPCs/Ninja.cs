using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using System.Linq;
using Terraria.Audio;
using Terraria.Utilities;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.DataStructures;
using ReLogic.Content;
using Terraria.ModLoader.IO;
using TheCollectors.Content.Projectiles.Throwing;
using TheCollectors.Content.Dusts;

namespace TheCollectors.Content.NPCs.TownNPCs
{
    // [AutoloadHead] and NPC.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
    [AutoloadHead]

    public class Ninja : ModNPC
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
        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Saske",
                "Furamuros",
                "Smooth Figure",
                "Hattori",
                "Boninja"
            };
        }
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 25;

            NPCID.Sets.ExtraFramesCount[NPC.type] = 5;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 1000; // The amount of pixels away from the center of the NPC that it tries to attack enemies.
            NPCID.Sets.AttackType[NPC.type] = 0; // The type of attack the Town NPC performs. 0 = throwing, 1 = shooting, 2 = magic, 3 = melee
            NPCID.Sets.AttackTime[NPC.type] = 30; // The amount of time it takes for the NPC's attack animation to be over once it starts.
            NPCID.Sets.AttackAverageChance[Type] = 30; // The denominator for the chance for a Town NPC to attack. Lower numbers make the Town NPC appear more aggressive.
            NPCID.Sets.HatOffsetY[NPC.type] = 4; // For when a party is active, the party hat spawns at a Y offset.

            NPCID.Sets.ShimmerTownTransform[Type] = true; // Allows for this NPC to have a different texture after touching the Shimmer liquid.

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f,  // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
                Direction = -1  // -1 is left and 1 is right.
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness
            //.SetBiomeAffection<ForestBiome>(AffectionLevel.Love)
            .SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
            .SetBiomeAffection<OceanBiome>(AffectionLevel.Dislike)
            .SetBiomeAffection<HallowBiome>(AffectionLevel.Hate)
            .SetNPCAffection(NPCID.Guide, AffectionLevel.Love); // < Mind the semicolon!
            //.SetNPCAffection(ModContent.NPCType<MasterSan>(), AffectionLevel.Like) // Para los NPCs del mod
            // Dislike QueenSlimede BossesAsNpecs, call hecho en otro archivo
            // Hate KingSlime de BossesAsNpecs, call hecho en otro archivo

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
            NPC.height = 44;
            NPC.aiStyle = 7;
            NPC.damage = 20;
            NPC.defense = 20;
            NPC.lifeMax = 350;
            NPC.knockBackResist = 0.6f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.Item1;

            AnimationType = NPCID.Guide;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the preferred biomes of this town NPC listed in the bestiary.
				// With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,

				// You can add multiple elements if you really wanted to
				// You can also use localization keys (see Localization/en-US.lang)
				new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.Ninja")
            });
        }
        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            if (NPC.downedSlimeKing)
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

                Dust.NewDustPerfect(NPC.Center + position, ModContent.DustType<Sparkle>(), Vector2.Zero).noGravity = true;
            }
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "!Battle Changue!";
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        { 
            if (firstButton)
            {
                shop = ShopName; // Esto lo convierte en tienda
            }
            else
            {
                Main.npcChatText = Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.BattleChangue");
                Main.LocalPlayer.AddBuff(ModContent.BuffType<Buffs.StealthBuff>(),36000); /*600 = 10seg*/
            }
        }
        public override void ModifyActiveShop(string shopName, Item[] items)
        {
			foreach (Item item in items) {
				// Skip 'air' items and null items.
				if (item == null || item.type == ItemID.None) {
					continue;
				}

				// If NPC is shimmered then reduce all prices by 50%.
				if (NPC.IsShimmerVariant) {
					int value = item.shopCustomPrice ?? item.value;
					item.shopCustomPrice = value / 2;
				}
			}
		}
        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, ShopName)
                .Add(ItemID.Katana)
                .Add(ItemID.Shuriken)
                .Add(ItemID.NinjaHood)
                .Add(ItemID.NinjaPants)
                .Add(ItemID.NinjaShirt)
                .Add(ItemID.InvisibilityPotion)
                .Add(ItemID.SpikyBall, Condition.DownedGoblinArmy)
                .Add(ItemID.PoisonedKnife, Condition.Hardmode)
                .Add(ItemID.Muramasa, Condition.Hardmode)
                .Add<Items.Placeable.ThrowingDummy>()
                .Add<Items.Weapons.Throwing.SlimeShuriken>()
                .Add<Items.Weapons.Throwing.EyeShuriken>(Condition.DownedEyeOfCthulhu)
                .Add<Items.Weapons.Throwing.WormShuriken>(Condition.DownedEaterOfWorlds)
                .Add<Items.Weapons.Throwing.BrainShuriken>(Condition.DownedBrainOfCthulhu)
                .Add<Items.Weapons.Throwing.BeeShuriken>(Condition.DownedQueenBee)
                .Add<Items.Weapons.Throwing.BoneShuriken>(Condition.DownedEyeOfCthulhu)
                .Add<Items.Weapons.Throwing.DeerShuriken>(Condition.DownedDeerclops)
                .Add<Items.Weapons.Throwing.WallShuriken>(Condition.Hardmode)
                .Add<Items.Weapons.Throwing.PartyShuriken>(Condition.BirthdayParty);

            npcShop.Register(); // Name of this shop tab
        }
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
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.StandardDialogue1");
                            case 1:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.StandardDialogue2");
                            case 2:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.StandardDialogue3");
                            case 3:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.StandardDialogue4");
                            case 4:
                                if (NumberOfTimesTalkedTo >= 20)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.TalkALot");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.NotTalkALot");
                        }
                    }
                    return null;
                case 1:
                    {
                        int guide = NPC.FindFirstNPC(NPCID.Guide);
                        int partygirl = NPC.FindFirstNPC(NPCID.PartyGirl);
                        //int mastersan = NPC.FindFirstNPC(ModContent.NPCType<MasterSan>());

                            switch (Main.rand.Next(2))
                        {
                            case 0:
                                if (guide >= 0)
                                    switch (Main.rand.Next(2))
                                    {
                                        case 1:

                                            return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.Guide1", Main.npc[guide].GivenName);

                                        default:

                                            return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.Guide2", Main.npc[guide].GivenName);
                                    }
                                else return null;

                            case 1:
                                if (partygirl >= 0)
                                    switch (Main.rand.Next(2))
                                    {
                                        case 1:

                                            return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.PartyGirl1", Main.npc[guide].GivenName);

                                        default:

                                            return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.PartyGirl2", Main.npc[guide].GivenName);
                                    }
                                else return null;
                        }
                    }
                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.OtrosNPCs");
                case 2:
                    {
                        switch (Main.invasionType)  // (Main.invasionType == X)	GoblinArmy (1), FrostLegion (2), Pirates (3), MartianMadness (4), (Main.eclipse)
                        {
                            case 1:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.InvasionGenerica");
                            case 2:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.InvasionGenerica");
                            case 3:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.InvasionGenerica");
                            case 4:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.InvasionGenerica");
                            default:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.NotInvansionGenerica");
                        }
                    }
                case 3:
                    {
                        switch (Main.rand.Next(2))
                        {
                            case 0:
                                if (NPC.downedQueenSlime)
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
        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }
        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }
        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            if (Main.hardMode)
            {
                projType = ModContent.ProjectileType<WallShuriken>();
                attackDelay = 1;
            }
            else
            {
                projType = ModContent.ProjectileType<GoldShuriken>();
                attackDelay = 1;
            }

            if (Main.snowMoon)
            {
                projType = ModContent.ProjectileType<HellstoneShuriken>();
                attackDelay = 1;
            }
        }
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 30f;
            gravityCorrection = 0f;
            randomOffset = 2f;
        }
       /* public override void HitEffect(NPC.HitInfo hit)
        {
            int num = NPC.life > 0 ? 1 : 5;

            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Smoke);
            }

            if (Main.netMode != NetmodeID.Server && NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, ModContent.Find<ModGore>(Mod.Name + "/" + Name + "Gore").Type, 1f);
            }
        }*/
        public override void HitEffect(NPC.HitInfo hit)
        {
            int num = NPC.life > 0 ? 1 : 5;

            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Smoke);
            }

            if (Main.netMode != NetmodeID.Server && NPC.life <= 0)
            {
                // Retrieve the gore types. This NPC has shimmer and party variants for head, arm, and leg gore. (12 total gores)
                string variant = "";
                if (NPC.IsShimmerVariant) variant += "_Shimmer";
                if (NPC.altTexture == 1) variant += "_Party";
                int hatGore = NPC.GetPartyHatGore();
                int headGore = Mod.Find<ModGore>($"{Name}_Gore{variant}").Type;

                // Spawn the gores. The positions of the arms and legs are lowered for a more natural look.
                if (hatGore > 0)
                {
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, hatGore);
                }
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, headGore, 1f);
            }
        }
        /*public override void ModifyNPCLoot(NPCLoot npcLoot)
         {
             npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.Armor.Vanity.MeteormanMask>(), 10)); 
         }*///poner revista erotica, con chat especial si la tienes en el inventario, la pierdes
        public override void LoadData(TagCompound tag)
        {
            NumberOfTimesTalkedTo = tag.GetInt("numberOfTimesTalkedTo");
        }
        public override void SaveData(TagCompound tag)
        {
            tag["numberOfTimesTalkedTo"] = NumberOfTimesTalkedTo;
        }
    }
}