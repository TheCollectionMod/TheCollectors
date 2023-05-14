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
using TheCollectors.Content.Items.NPCStash.Carver;

namespace TheCollectors.Content.NPCs.TownNPCs
{
    // [AutoloadHead] and NPC.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
    [AutoloadHead]

    public class Carver : ModNPC
    {
        /*private int currentQuest = -1;
        private int lastQuestCompletionTime = -1;

        private static readonly int[] woodTypes = { ItemID.Wood, ItemID.BorealWood, ItemID.PalmWood, ItemID.RichMahogany, ItemID.Ebonwood, ItemID.Shadewood, ItemID.Pearlwood };

        private static readonly int[][] woodTypeRewardPools =
        {
            new int[] { ItemID.WoodenSword, ItemID.WoodenHammer, ItemID.WoodenBow },
            new int[] { ItemID.BorealWoodSword, ItemID.BorealWoodHammer, ItemID.BorealWoodBow },
            new int[] { ItemID.PalmWoodSword, ItemID.PalmWoodHammer, ItemID.PalmWoodBow },
            new int[] { ItemID.RichMahoganySword, ItemID.RichMahoganyHammer, ItemID.RichMahoganyBow },
            new int[] { ItemID.EbonwoodSword, ItemID.EbonwoodHammer, ItemID.EbonwoodBow },
            new int[] { ItemID.ShadewoodSword, ItemID.ShadewoodHammer, ItemID.ShadewoodBow },
            new int[] { ItemID.PearlwoodSword, ItemID.PearlwoodHammer, ItemID.PearlwoodBow }
        };*/
        private List<int> missionItems = new List<int> { ItemID.CopperBar, ItemID.SilverBar, ItemID.GoldBar };
        private List<int> missionRewards = new List<int> { ItemID.Wood, ItemID.StoneBlock, ItemID.IronOre };
        private List<int> missionItemsSet2 = new List<int> { ItemID.Ruby, ItemID.Emerald, ItemID.Diamond };
        private List<int> missionRewardsSet2 = new List<int> { ItemID.Shuriken, ItemID.CrystalBullet, ItemID.ArrowSign };
        private int requiredItem = 0;
        private string requiredItemName = "";
        private bool hasMission = false;

        public const string ShopName = "Shop";
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
                "NPC Temporal"
            };
        }
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 5;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 1000;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 30;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 4; // Posición del Party Hat

            NPCID.Sets.ShimmerTownTransform[Type] = true; // Allows for this NPC to have a different texture after touching the Shimmer liquid.

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f,
                Direction = -1
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness
            //.SetBiomeAffection<ForestBiome>(AffectionLevel.Love)
            .SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
            .SetBiomeAffection<OceanBiome>(AffectionLevel.Dislike)
            .SetBiomeAffection<HallowBiome>(AffectionLevel.Hate)
            .SetNPCAffection(NPCID.Guide, AffectionLevel.Love);

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
            NPC.height = 52;
            NPC.aiStyle = 7;
            NPC.damage = 20;
            NPC.defense = 20;
            NPC.lifeMax = 350;
            NPC.knockBackResist = 0.6f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.Item1;

            AnimationType = NPCID.Angler;
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
				new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.Carver")
            });
        }
        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            if (TheCollectorsWorld.savedCarver && NPC.CountNPCS(ModContent.NPCType<Carver>()) < 1)
            {
                return true;
            }
            return false;
        }
        public override bool CanGoToStatue(bool toQueenStatue)
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
            button = Language.GetTextValue("LegacyInterface.28"); // Botón de tienda
            button2 = "Misión"; // Botón de misión
        }
        //private int Questactual = -1;

        //private static readonly int[] objetodemision = { ItemID.Wood, ItemID.BorealWood, ItemID.PalmWood };

        //private static readonly int[] objetodemision = { ModContent.ItemType<QuestWood>() };

        //private static readonly int[] recompensasmision = { ItemID.Sunflower, ItemID.Sunfury, ItemID.SunMask };
        /*public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                // Botón de tienda
                shop = ShopName;
                Main.npcChatText = "¡Bienvenido a mi tienda! Echa un vistazo a lo que tengo a la venta.";
            }
            else
            {
                // Botón de misión
                var missionItems = new List<int> { ItemID.IronBar, ItemID.SilverBar, ItemID.GoldBar };
                var missionRewards = new List<int> { ItemID.Wood, ItemID.StoneBlock, ItemID.IronOre };

                if (!hasMission)
                {
                    var requiredItem = missionItems[Main.rand.Next(missionItems.Count)];
                    var requiredItemName = Lang.GetItemNameValue(requiredItem);
                    Main.npcChatCornerItem = requiredItem;
                    Main.npcChatText = $"Necesito un {requiredItemName} para completar una tarea. ¿Podrías traérmelo? Te recompensaré generosamente.";
                    hasMission = true;
                }

                var currentItem = Main.npcChatCornerItem;
                if (currentItem != null)
                {
                    var requiredItemName = Lang.GetItemNameValue(currentItem);
                    for (int i = 0; i < Main.LocalPlayer.inventory.Length; i++)
                    {
                        var item = Main.LocalPlayer.inventory[i];
                        if (item.type == currentItem)
                        {
                            Main.npcChatText = $"¡Gracias por traerme el {requiredItemName}! Aquí tienes tu recompensa.";
                            Main.LocalPlayer.inventory[i].TurnToAir();
                            var rewardItem = missionRewards[Main.rand.Next(missionRewards.Count)];
                            var reward = new Item();
                            var entitySource = NPC.GetSource_GiftOrReward();
                            reward.SetDefaults(rewardItem);
                            reward.stack = 1;
                            Main.LocalPlayer.QuickSpawnItem(entitySource, reward);
                            //Main.LocalPlayer.QuickSpawnClonedItem(NPC.GetSource_GiftOrReward(), reward);
                            hasMission = false;
                            Main.npcChatCornerItem = 0;
                            return;
                        }
                    }
                    Main.npcChatText = $"Lo siento, todavía necesito un {requiredItemName} para completar mi tarea.";
                }
                else
                {
                    Main.npcChatText = "No tengo ninguna tarea para ti en este momento.";
                }
            }
        }*/
        //private DateTime lastMissionCompletedTime = DateTime.MinValue;
        //private readonly TimeSpan missionCooldown = TimeSpan.FromDays(1);
        //private int lastMissionDay = -1;
        // private readonly int missionCooldownDays = 1;
        private bool dayOver;
        private bool nightOver;
        public override void AI()
        {
            if (!Main.dayTime)
            {
                nightOver = true;
            }

            if (Main.dayTime)
            {
                dayOver = true;
            }
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                // Botón de tienda
                shop = ShopName;
                Main.npcChatText = "¡Bienvenido a mi tienda! Echa un vistazo a lo que tengo a la venta.";
            }

            if (dayOver && nightOver)
            {
                // Botón de misión
                if (!hasMission)
                    {
                        missionItems = new List<int> { /*ModContent.ItemType<QuestWood>()*/ItemID.CopperBar, ItemID.SilverBar, ItemID.GoldBar };
                        missionRewards = new List<int> { ItemID.Wood, ItemID.StoneBlock, ItemID.IronOre };
                        requiredItem = missionItems[Main.rand.Next(missionItems.Count)];
                        requiredItemName = Lang.GetItemNameValue(requiredItem);
                        hasMission = true;
                        Main.npcChatCornerItem = requiredItem;

                        switch (requiredItem)
                        {
                            case ItemID.CopperBar:
                                Main.npcChatText = "¡Necesito quest wood! ¿Podrías conseguírmela? Te recompensaré con un bloque de madera de ébano.";
                                break;
                            case ItemID.SilverBar:
                                Main.npcChatText = $"Necesito una barra de plata para crear un objeto especial. ¿Podrías traérmela? Te daré a cambio una bolsa de monedas.";
                                break;
                            case ItemID.GoldBar:
                                Main.npcChatText = $"Necesito una barra de oro para mi investigación. ¿Podrías conseguirme una? Te recompensaré con un cofre lleno de objetos valiosos.";
                                break;
                        }
                        return;
                    }

                    // Comprobar si se ha completado la misión
                    for (int i = 0; i < Main.LocalPlayer.inventory.Length; i++)
                    {
                        var item = Main.LocalPlayer.inventory[i];
                        if (item.type == requiredItem)
                        {
                            Main.npcChatText = $"¡Gracias por traerme el {requiredItemName}! Aquí tienes tu recompensa.";
                            Main.LocalPlayer.inventory[i].TurnToAir();
                            var rewardItem = missionRewards[Main.rand.Next(missionRewards.Count)];
                            var entitySource = NPC.GetSource_GiftOrReward();
                            var reward = new Item();
                            reward.SetDefaults(rewardItem);
                            reward.stack = 1;
                            Main.LocalPlayer.QuickSpawnItem(entitySource, reward);
                            dayOver = false;
                            nightOver = false;
                            hasMission = false;
                            Main.npcChatCornerItem = 0;
                            return;
                        }
                    }
                    Main.npcChatText = Language.GetTextValue("Mods.TheCollectors.Dialogue.Carver.QuestNotFinished1") + requiredItemName + Language.GetTextValue("Mods.TheCollectors.Dialogue.Carver.QuestNotFinished2");
                    //Main.npcChatText = $"Lo siento, todavía necesito un {requiredItemName} para completar mi tarea.";
            }
            else
            { 
                Main.npcChatText = $"Lo siento, ya has completado una misión hoy. Vuelve mañana para recibir una nueva misión.";
                return;
            }
        }
        /*public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            List<int> misionesdisponibles = new List<int> { 3544, 3545, 3546, 3547, 3548 };

            if (firstButton)
            {
                shop = ShopName;
                Main.npcChatText = "¡Bienvenido a mi tienda! Echa un vistazo a lo que tengo a la venta.";
            }
            else
            {
                // Si el jugador no ha iniciado una misión, mostrar una lista de misiones disponibles
                if (Questactual == -1)
                {
                    Main.npcChatCornerItem = 0;
                    Main.npcChatText = "";
                    foreach (var quest in misionesdisponibles)
                    {
                        if (Main.LocalPlayer.HasItem(quest.objetodemision) && !quest.isCompleted)
                        {
                            Main.npcChatText += $"{quest.nombre} - {quest.descripcion}\n";
                        }
                    }
                    if (Main.npcChatText == "")
                    {
                        Main.npcChatText = "No tienes misiones disponibles en este momento.";
                    }
                }
                else
                {
                    // Comprobar si se ha completado la misión actual
                    var quest = misionesdisponibles[Questactual];
                    var itemType = quest.recompensasmision; // Obtener el tipo de objeto a crear
                    var stackSize = 1; // Cantidad de objetos a crear
                    var reward = new Item(); // Crear un nuevo objeto de tipo Item
                    reward.SetDefaults(itemType); // Establecer el tipo de objeto
                    reward.stack = stackSize; // Establecer la cantidad de objetos a crear
                    var objeto = quest.objetodemision;
                    var playerItem = Main.LocalPlayer.FindItem(objeto);
                    if (playerItem >= 0 && Main.LocalPlayer.inventory[playerItem].stack == 1)
                    {
                        // Se ha completado la misión
                        Main.LocalPlayer.inventory[playerItem].TurnToAir(); // Destruir objeto de misión
                        Main.LocalPlayer.QuickSpawnClonedItem(NPC.GetSource_GiftOrReward(), reward); // Dar recompensa
                        Main.npcChatText = $"¡Gracias por traerme los bloques de {Lang.GetItemNameValue(objeto)}! Aquí tienes tu recompensa.";
                        quest.isCompleted = true; // Marcar misión como completada
                        Questactual = -1;
                    }
                    else
                    {
                        // El jugador no tiene el objeto requerido para completar la misión
                        Main.npcChatText = $"No tienes suficientes {Lang.GetItemNameValue(objeto)} para completar esta misión.";
                    }
                }
            }
        

        /*public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = ShopName; // Esto lo convierte en tienda
                Main.npcChatText = "¡Bienvenido a mi tienda! Echa un vistazo a lo que tengo a la venta.";
            }
            else
            {
                if (Questactual == -1) //"Questactual" es igual a -1, significa que no hay misión en curso, por lo que se puede iniciar una nueva misión
                {
                    // Se puede empezar una nueva misión
                    Questactual = Main.rand.Next(objetodemision.Length);
                    int cantidadrequerida = Main.rand.Next(10, 20);
                    Main.npcChatText = "Necesito " + cantidadrequerida + " bloques de " + Lang.GetItemNameValue(objetodemision[Questactual]) + ". ¿Podrías conseguirlos para mí? Si lo consigues, tu esfuerzo se verá recompensado.";
                }
                else
                {
                    // Comprobar si se ha completado la misión actual
                    int objeto = objetodemision[Questactual];
                    int cantidadrequerida = Main.rand.Next(10, 20);
                    int destruirobjetomision = Main.LocalPlayer.FindItem(objeto);
                    if (destruirobjetomision != -1 && Main.LocalPlayer.inventory[destruirobjetomision].stack >= cantidadrequerida)
                    {
                        // Se ha completado la misión
                        Main.LocalPlayer.inventory[destruirobjetomision].stack -= cantidadrequerida;
                        Main.LocalPlayer.QuickSpawnClonedItem(NPC.GetSource_GiftOrReward(), recompensasmision[Questactual]);
                        Main.npcChatText = "¡Gracias por traerme los bloques de " + Lang.GetItemNameValue(objeto) + "! Aquí tienes tu recompensa.";
                        Questactual = -1;
                    }
                    else
                    {
                        // No se ha completado la misión
                        Main.npcChatText = "Aún necesito " + cantidadrequerida + " bloques de " + Lang.GetItemNameValue(objeto) + ". ¡Vuelve cuando los tengas!";
                    }
                }
            }
        
        /*{
            if (Questactual == -1) //"Questactual" es igual a -1, significa que no hay misión en curso, por lo que se puede iniciar una nueva misión
            {
                // Se puede empezar una nueva misión
                Questactual = Main.rand.Next(objetodemision.Length);
                //int cantidadrequerida = Main.rand.Next(10, 20);
                Main.npcChatText = "Necesito " + Lang.GetItemNameValue(objetodemision[Questactual]) + ". ¿Podrías conseguirla para mí? Si lo consigues, tu esfuerzo se verá recompensado.";
            }
            else
            {
                // Comprobar si se ha completado la misión actual
                //int itemType = recompensasmision[Questactual]; // Obtener el tipo de objeto a crear
               // int stackSize = 1; // Cantidad de objetos a crear
                //Item reward = new Item(); // Crear un nuevo objeto de tipo Item
                //reward.SetDefaults(itemType); // Establecer el tipo de objeto
                //reward.stack = stackSize; // Establecer la cantidad de objetos a crear
                int objeto = objetodemision[Questactual];
                int cantidadrequerida = Main.rand.Next(1);
                int destruirobjetomision = Main.LocalPlayer.FindItem(objeto);
                //int reward = recompensasmision[Questactual];
                if (Main.LocalPlayer.CountItem(objeto, cantidadrequerida) >= cantidadrequerida)
                {
                    // Se ha completado la misión

                    var entitySource = NPC.GetSource_GiftOrReward();
                    Main.LocalPlayer.HasItem(objeto);
                    Main.LocalPlayer.ConsumeItem(objeto);

                    // Crear objeto de recompensa
                    int itemType = recompensasmision[Questactual];
                    int stackSize = 1;
                    Item reward = new Item();
                    reward.SetDefaults(itemType);
                    reward.stack = stackSize;

                    // Entregar recompensa
                    Main.LocalPlayer.QuickSpawnClonedItem(entitySource, reward);
                    Main.npcChatText = "¡Gracias por traerme " + Lang.GetItemNameValue(objeto) + "! Aquí tienes tu recompensa.";
                    Questactual = -1;
                }
                /*if (Main.LocalPlayer.CountItem(objeto, cantidadrequerida) >= cantidadrequerida)
                {
                    // Se ha completado la misión

                    //Main.LocalPlayer.GiveItem(reward);
                    var entitySource = NPC.GetSource_GiftOrReward();
                    Main.LocalPlayer.HasItem(objeto);
                    Main.LocalPlayer.ConsumeItem(objeto);
                    Main.LocalPlayer.QuickSpawnClonedItem(NPC.GetSource_GiftOrReward(), reward);
                    //Main.LocalPlayer.QuickSpawnClonedItem(entitySource, reward, 1);
                    //Main.LocalPlayer.inventory[destruirobjetomision].TurnToAir();
                    //Main.LocalPlayer.QuickSpawnItem(entitySource, reward);
                    Main.npcChatText = "¡Gracias por traerme los bloques de " + Lang.GetItemNameValue(objeto) + "! Aquí tienes tu recompensa.";
                    Questactual = -1;

                }
                else
                {
                    // No se ha completado la misión
                    Main.npcChatText = "Aún necesito " + (cantidadrequerida - Main.LocalPlayer.CountItem(objeto)) + " bloques de " + Lang.GetItemNameValue(objeto) + ". ¡Vuelve cuando los tengas!";
                }
            }
        }*/
        /*public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = ShopName; // Esto lo convierte en tienda
                Main.npcChatText = "¡Bienvenido a mi tienda! Echa un vistazo a lo que tengo a la venta.";
            }
            else
            {
                if (Questactual == -1)
                {
                    // Se puede empezar una nueva misión
                    Questactual = Main.rand.Next(objetodemision.Length);
                    int cantidadrequerida = Main.rand.Next(10, 20);
                    Main.npcChatText = "Necesito " + cantidadrequerida + " bloques de " + Lang.GetItemNameValue(objetodemision[Questactual]) + ". ¿Podrías conseguirlos para mí? Si lo consigues, tu esfuerzo se verá recompensado.";
                }
                else
                {
                    // Comprobar si se ha completado la misión actual
                    int objeto = objetodemision[Questactual];
                    int cantidadrequerida = Main.rand.Next(10, 20);
                    int destruirobjetomision = Main.LocalPlayer.FindItem(objeto);
                    int reward = recompensasmision[Questactual];
                    if (Main.LocalPlayer.CountItem(objeto, cantidadrequerida) >= cantidadrequerida)
                    {
                        // Se ha completado la misión
                        /*Main.LocalPlayer.ConsumeItem(itemID, requiredWoodAmount);
                        Main.LocalPlayer.GiveItem(reward);
                        Main.LocalPlayer.inventory[destruirobjetomision].TurnToAir();
                        Main.npcChatText = "¡Gracias por traerme los bloques de " + Lang.GetItemNameValue(objeto) + "! Aquí tienes tu recompensa.";
                        Questactual = -1;

                    }
                    else
                    {
                        // No se ha completado la misión
                        Main.npcChatText = "Aún necesito " + (cantidadrequerida - Main.LocalPlayer.CountItem(objeto)) + " bloques de " + Lang.GetItemNameValue(objeto) + ". ¡Vuelve cuando los tengas!";
                    }
                }
            }
        }*/
        /*public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = ShopName; // Esto lo convierte en tienda
                Main.npcChatText = "¡Bienvenido a mi tienda! Echa un vistazo a lo que tengo a la venta.";
            }
            else
            {
                // Lógica para el botón de misión
                int currentDay = Main.dayTime ? Main.dayTime : Main.dayTime + 86400;
                int daysSinceLastCompletion = currentDay - lastQuestCompletionTime;
                if (daysSinceLastCompletion < 1)
                {
                    Main.npcChatText = "No tengo misiones disponibles por ahora. Vuelve mañana.";
                }
                else
                {
                    if (currentQuest == -1 && (lastQuestCompletionTime == -1 || lastQuestCompletionTime < Main.dayCount))
                    {
                        // Se puede empezar una nueva misión
                        currentQuest = Main.rand.Next(woodTypes.Length);
                        int requiredWoodAmount = Main.rand.Next(10, 20);
                        int reward = woodTypeRewardPools[currentQuest][Main.rand.Next(woodTypeRewardPools[currentQuest].Length)];
                        Main.npcChatText = "Necesito " + requiredWoodAmount + " bloques de " + Lang.GetItemNameValue(woodTypes[currentQuest]) + ". ¿Podrías conseguirlos para mí? Como recompensa te daré " + Lang.GetItemNameValue(reward) + ".";
                    }
                    else if (currentQuest == -1 && lastQuestCompletionTime >= Main.dayCount)
                    {
                        // Todavía no se puede empezar una nueva misión
                        Main.npcChatText = "Lo siento, no tengo ninguna misión para ti hoy. Vuelve mañana.";
                    }
                    else
                    {
                        // Comprobar si se ha completado la misión actual
                        int itemID = woodTypes[currentQuest];
                        int requiredWoodAmount = Main.rand.Next(10, 20);
                        int reward = woodTypeRewardPools[currentQuest][Main.rand.Next(woodTypeRewardPools[currentQuest].Length)];
                        if (Main.LocalPlayer.CountItem(itemID) >= requiredWoodAmount)
                        {
                            // Se ha completado la misión actual
                            Main.npcChatText = "¡Has completado la misión! Aquí tienes tu recompensa.";
                            Main.LocalPlayer.GetItem(reward);
                            lastQuestCompletionTime = Main.dayCount;
                            currentQuest = -1;
                        }
                        else
                        {
                            // Muestra el progreso de la misión actual
                            int currentWoodAmount = Main.LocalPlayer.CountItem(itemID);
                            Main.npcChatText = "Todavía necesitas traer " + (requiredWoodAmount - currentWoodAmount) + " bloques de madera de este tipo.";
                        }
                    }
                }
            }
        }*/
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
                .Add(ItemID.Sunflower);

            npcShop.Register(); // Name of this shop tab
        }
        public override string GetChat()
        {
            return Language.GetTextValue("Mods.TheCollectors.Dialogue.Carver.TemporalDialogue");
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
            projType = ModContent.ProjectileType<MeteorJavelinProjectile>();
            attackDelay = 1;
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