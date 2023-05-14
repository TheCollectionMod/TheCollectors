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
using TheCollectors.Content.Projectiles.Magic;
using TheCollectors.Content.Items.Weapons.Magic;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;
using System.Linq;
using Terraria.ModLoader.Config;
using TheCollectors.Content.Projectiles.Throwing;

namespace TheCollectors.Content.NPCs.TownGuardians
{
    [AutoloadHead]

    public class CopperGuard : ModNPC
    {
        /*public override ITownNPCProfile TownNPCProfile()
        {
            return new CopperGuardProfile();
        }*/
        public override string Texture => "TheCollectors/Content/NPCs/TownGuardians/CopperGuard";
        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Cobreman",
                "Cobrefensor",
                "Coperito",
                "Aesirguard",
                "Kuparivartija",
                "Aescopadael",
                "Chalkobates"
            };
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Copper Guard");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.PossessedArmor]; // Use the same number of frames as the Possessed Armor
            NPCID.Sets.CannotSitOnFurniture[Type] = true;

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f,
                Direction = -1
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
        }
        public override void SetDefaults()
        {
            NPC.width = 40;
            NPC.height = 56;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath6;
            NPC.knockBackResist = 0.6f;
            //NPC.aiStyle = 3; // Same AI style as the Fighter AI
            NPC.aiStyle = -1; // No usar AI predefinida
            AnimationType = NPCID.PossessedArmor; // Use the same animation as the Possessed Armor

            NPC.friendly = true; // Friendly NPC
            NPC.townNPC = true;
            NPC.housingCategory = HousingCategoryID.PetNPCs;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.CopperGuard")
            });
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Polish";
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                var mplayer = Main.LocalPlayer.GetModPlayer<TheCollectorsPlayer>();
                mplayer.PetAnimal(NPC.whoAmI);

                return;
            }
        }
        public override string GetChat()
        {
            switch (Main.rand.Next(3))
            {
                case 0:
                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.CopperGuard.StandardDialogue1");
                case 1:
                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.CopperGuard.StandardDialogue2");
                case 2:
                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.CopperGuard.StandardDialogue3");
            }
            return null;
        }
        /* public override bool CanTownNPCSpawn(int numTownNPCs, int money)
         {
             // Check if there is already a CopperGuardian
             if (TheCollectorsWorld.spawnedCopperGuardian && NPC.CountNPCS(ModContent.NPCType<CopperGuard>()) < 1)
             {
                 return true;
             }

             // Check for the required mannequin equipped with Copper armor and Watch accessory
             for (int i = 0; i < Main.maxTilesX; i++)
             {
                 for (int j = 0; j < Main.maxTilesY; j++)
                 {
                     Tile tile = Main.tile[i, j];
                     if (tile.TileType == TileID.Mannequin && tile.TileFrameX == 0 && tile.TileFrameY == 0)
                     {
                         Item helmet = new Item();
                         helmet.SetDefaults(ItemID.CopperHelmet);
                         bool hasHelmet = tile.item[0].IsTheSameAs(helmet);

                         Item chainmail = new Item();
                         chainmail.SetDefaults(ItemID.CopperChainmail);
                         bool hasChainmail = tile.item[1].IsTheSameAs(chainmail);

                         Item greaves = new Item();
                         greaves.SetDefaults(ItemID.CopperGreaves);
                         bool hasGreaves = tile.item[2].IsTheSameAs(greaves);

                         Item watch = new Item();
                         watch.SetDefaults(ItemID.CopperWatch);
                         bool hasWatch = tile.item[3].IsTheSameAs(watch);

                         if (hasHelmet && hasChainmail && hasGreaves && hasWatch)
                         {
                             // Maniquí tiene equipado el conjunto de armadura de cobre
                         }
                     }
                 }
             }

             return false;
         }*/
        /* public override bool CanTownNPCSpawn(int numTownNPCs, int money)
         {
             // Check if there is already a CopperGuardian
             if (TheCollectorsWorld.spawnedCopperGuardian && NPC.CountNPCS(ModContent.NPCType<CopperGuard>()) < 1)
             {
                 return true;
             }
             return false;

             // Check if the world has the required mannequin equipped with Copper armor and Watch accessory
             bool hasRequiredMannequin = false;
             for (int i = 0; i < Main.maxTilesX; i++)
             {
                 for (int j = 0; j < Main.maxTilesY; j++)
                 {
                     Tile tile = Main.tile[i, j];
                     if (tile.TileType == TileID.Mannequin && tile.TileFrameX == 0 && tile.TileFrameY == 0)
                     {
                         Item helmetItem = new Item();
                         helmetItem.SetDefaults(ItemID.CopperHelmet);
                         bool hasHelmet = tile.item.stack > 0 && tile.item.IsTheSameAs(helmetItem);

                         Item chainmailItem = new Item();
                         chainmailItem.SetDefaults(ItemID.CopperChainmail);
                         bool hasChainmail = tile.item.stack > 1 && tile.item.IsTheSameAs(chainmailItem);

                         Item greavesItem = new Item();
                         greavesItem.SetDefaults(ItemID.CopperGreaves);
                         bool hasGreaves = tile.item.stack > 2 && tile.item.IsTheSameAs(greavesItem);

                         Item watchItem = new Item();
                         watchItem.SetDefaults(ItemID.CopperWatch);
                         bool hasWatch = false;
                         for (int k = 3; k < tile.item.stack; k++)
                         {
                             if (tile.item[k].IsTheSameAs(watchItem))
                             {
                                 hasWatch = true;
                                 break;
                             }
                         }

                         hasRequiredMannequin = hasHelmet && hasChainmail && hasGreaves && hasWatch;
                         if (hasRequiredMannequin)
                         {
                             break;
                         }
                     }
                 }

                 if (hasRequiredMannequin)
                 {
                     break;
                 }
             }

             return hasRequiredMannequin;
         }*/
        /* public override bool CanTownNPCSpawn(int numTownNPCs, int money)
         {
             // Check if there is already a CopperGuard in the world
             foreach (NPC npc in Main.npc)
             {
                 if (npc.type == NPCType<CopperGuard>())
                 {
                     return false;
                 }
             }
             bool hasSuitableHouse = false;
             for (int i = 0; i < Main.maxTilesX; i++)
             {
                 for (int j = 0; j < Main.maxTilesY; j++)
                 {
                     Tile tile = Main.tile[i, j];
                     if (tile != null && tile.active() && tile.type == TileID.WorkBenches)
                     {
                         int mannequinX = i + 1;
                         int mannequinY = j;
                         Tile mannequinTile = Main.tile[mannequinX, mannequinY];
                         if (mannequinTile != null && mannequinTile.frameX % 36 == 0 && mannequinTile.frameY % 36 == 0)
                         {
                             Item headItem = new Item();
                             headItem.SetDefaults(ItemID.CopperHelmet);
                             Item bodyItem = new Item();
                             bodyItem.SetDefaults(ItemID.CopperChainmail);
                             Item legsItem = new Item();
                             legsItem.SetDefaults(ItemID.CopperGreaves);
                             Item accItem = new Item();
                             accItem.SetDefaults(ItemID.CopperWatch);
                             bool hasHeadItem = false;
                             bool hasBodyItem = false;
                             bool hasLegsItem = false;
                             bool hasAccItem = false;
                             for (int k = 0; k < 2; k++)
                             {
                                 int itemX = mannequinX + k;
                                 int itemY = mannequinY;
                                 Tile itemTile = Main.tile[itemX, itemY];
                                 if (itemTile != null && itemTile.active() && itemTile.type == TileID.Displays && itemTile.frameX % 36 == 0 && itemTile.frameY % 36 == 0)
                                 {
                                     int displayItemIndex = itemTile.frameY / 36;
                                     if (displayItemIndex == 0)
                                     {
                                         Item currentItem = new Item();
                                         currentItem.netDefaults(itemTile.frameX / 36 == 1 ? ItemID.MaleMannequin : ItemID.FemaleMannequin);
                                         if (currentItem.type == headItem.type && currentItem.color == headItem.color)
                                         {
                                             hasHeadItem = true;
                                         }
                                         else if (currentItem.type == bodyItem.type && currentItem.color == bodyItem.color)
                                         {
                                             hasBodyItem = true;
                                         }
                                         else if (currentItem.type == legsItem.type && currentItem.color == legsItem.color)
                                         {
                                             hasLegsItem = true;
                                         }
                                         else if (currentItem.type == accItem.type && currentItem.color == accItem.color)
                                         {
                                             hasAccItem = true;
                                         }
                                     }
                                 }
                             }
                             if (hasHeadItem && hasBodyItem && hasLegsItem && hasAccItem)
                             {
                                 hasSuitableHouse = true;
                                 break;
                             }
                         }
                     }
                 }
                 // Check if there is a habitable house with a mannequin containing the required items
                 foreach (House house in Main.housing)
             {
                 if (house?.Type == HouseType.Town && house.IsOccupied && house.NumNPCs < house.MaxNPCsAllowed)
                 {
                     foreach (Tile tile in house.Tiles)
                     {
                         if (tile.type == TileID.Mannequin && tile.frameX == 0 && tile.frameY == 0)
                         {
                             // Check if the mannequin is wearing the required items
                             Item head = new Item();
                             Item body = new Item();
                             Item legs = new Item();
                             Item accessory = new Item();
                             head.SetDefaults(ItemID.CopperHelmet);
                             body.SetDefaults(ItemID.CopperChainmail);
                             legs.SetDefaults(ItemID.CopperGreaves);
                             accessory.SetDefaults(ItemID.CopperWatch);
                             if (tile.item?.IsTheSameAs(head) == true &&
                                 tile.itemFrameX == 0 && tile.itemFrameY == 0 &&
                                 tile.item2?.IsTheSameAs(body) == true &&
                                 tile.itemFrame2X == 0 && tile.itemFrame2Y == 18 &&
                                 tile.item3?.IsTheSameAs(legs) == true &&
                                 tile.itemFrame3X == 0 && tile.itemFrame3Y == 36 &&
                                 tile.item4?.IsTheSameAs(accessory) == true &&
                                 tile.itemFrame4X == 54 && tile.itemFrame4Y == 0)
                             {
                                 return true;
                             }
                         }
                     }
                 }
             }

             return false;
         }
         /*public override bool CanTownNPCSpawn(int numTownNPCs, int money)
         {
             // Only spawn if there is a house with a mannequin equipped with Copper Armor and Magic Essence
             bool copperArmorEquipped = false;
             bool magicEssenceEquipped = false;
             for (int i = 0; i < Main.player.Length; i++)
             {
                 Player player = Main.player[i];
                 if (player.active && player.HeldItem.type == ItemID.CopperHelmet && player.armor[1].type == ItemID.CopperChainmail &&
                     player.armor[2].type == ItemID.CopperGreaves && player.armor[4].type == ItemID.CopperWatch)
                 {
                     for (int j = 0; j < player.armor.Length; j++)
                     {
                         if (player.armor[j].type == Mod.ItemType("MagicEssence"))
                         {
                             copperArmorEquipped = true;
                             break;
                         }
                     }
                 }

                 if (copperArmorEquipped)
                 {
                     for (int j = 0; j < player.inventory.Length; j++)
                     {
                         if (player.inventory[j].type == Mod.ItemType("MagicEssence"))
                         {
                             magicEssenceEquipped = true;
                             break;
                         }
                     }
                 }
             }

             if (copperArmorEquipped && magicEssenceEquipped && numTownNPCs < 1)
             {
                 return true;
             }
             return false;
         }*/
        /*public override void AI()
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
        }*/
        private NPC FindClosestNPC(Vector2 position, float maxDistance, Func<NPC, bool> predicate)
        {
            NPC closestNPC = null;
            float closestDistance = float.MaxValue;
            foreach (NPC npc in Main.npc)
            {
                if (npc.active && npc.Distance(position) < maxDistance && predicate(npc))
                {
                    float distance = Vector2.DistanceSquared(position, npc.Center);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestNPC = npc;
                    }
                }
            }
            return closestNPC;
        }
        public override void AI()
        {
            Player player = Main.LocalPlayer; // Obtener al jugador local

            // Si el jugador está cerca, atacar a los enemigos cercanos
            if (Vector2.Distance(NPC.Center, player.Center) < 100)
            {
                NPC enemy = FindClosestNPC(NPC.Center, 300,
                    npc => npc.active && !npc.friendly && !npc.dontTakeDamage);
                if (enemy != null)
                {
                    Vector2 direction = enemy.Center - NPC.Center;
                    direction.Normalize();
                    NPC.velocity = direction * 3f; // Mover hacia el enemigo
                }
            }
            else
            {
                // Si el jugador no está cerca, mover hacia él
                Vector2 direction = player.Center - NPC.Center;
                direction.Normalize();
                NPC.velocity = direction * 1.5f;
            }

            base.AI();
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
        public override void HitEffect(NPC.HitInfo hit)
        {
            int num = NPC.life > 0 ? 1 : 5;

            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood);
            }

            if (Main.netMode != NetmodeID.Server && NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, ModContent.Find<ModGore>(Mod.Name + "/" + Name + "_Head").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, ModContent.Find<ModGore>(Mod.Name + "/" + Name + "_Arm").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, ModContent.Find<ModGore>(Mod.Name + "/" + Name + "_Leg").Type, 1f);
            }
        }
    }
}