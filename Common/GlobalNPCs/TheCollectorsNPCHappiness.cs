using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameContent.Personalities;
using TheCollectors.Content.NPCs.TownNPCs;

namespace TheCollectors.Common.GlobalNPCs
{
    public class TheCollectorsNPCHappiness : GlobalNPC
    {
        //Código para modificar la felicidad de los NPCs Vanilla y otros mods
        public override void SetStaticDefaults()
        {
            int ninjaType = ModContent.NPCType<Ninja>(); // Get Ninja's type
            var ninjaHappiness = NPCHappiness.Get(ninjaType);
            int enchanterType = ModContent.NPCType<Enchanter>(); // Get Enchanter's type
            var enchanterHappiness = NPCHappiness.Get(enchanterType);
            var guideHappiness = NPCHappiness.Get(NPCID.Guide); // Get the key into The Guide's happiness
            var partygirlHappiness = NPCHappiness.Get(NPCID.PartyGirl); // Get the key into The PartyGirl's happiness

            guideHappiness.SetNPCAffection(ninjaType, AffectionLevel.Love); // Make the Guide love Ninja!
            partygirlHappiness.SetNPCAffection(ninjaType, AffectionLevel.Like); // Make the PartyGirl like Ninja!
            partygirlHappiness.SetNPCAffection(enchanterType, AffectionLevel.Like); // Make the PartyGirl like Ninja!
                                                                                    
            if (ModLoader.TryGetMod("BossesAsNPCs", out Mod bossesAsNPCs))
            {
                // We call to see if the "Town NPCs Cross Mod Support" config is enabled in Bosses As NPCs.
                if ((bool)bossesAsNPCs.Call("TownNPCsCrossModSupport"))
                {
                    // We get the Type and Happiness of our chosen NPC, in this case Moon Lord.
                    // You MUST use TryFind. If you use Find, your mod will not load if the given NPC is unloaded.
                    if (bossesAsNPCs.TryFind<ModNPC>("KingSlime", out ModNPC kingSlime))
                    {
                        var kingSlimeHappiness = NPCHappiness.Get(kingSlime.Type);
                        // Then we make both NPCs love each other.
                        // Make sure to follow HappinessVar.SetNPCAffection(TypeVar, ...)
                        ninjaHappiness.SetNPCAffection(kingSlime.Type, AffectionLevel.Hate);
                        kingSlimeHappiness.SetNPCAffection(ninjaType, AffectionLevel.Hate);
                    }
                    if (bossesAsNPCs.TryFind<ModNPC>("QueenSlime", out ModNPC queenSlime))
                    {
                        var queenSlimeHappiness = NPCHappiness.Get(queenSlime.Type);
                        // Then we make both NPCs love each other.
                        // Make sure to follow HappinessVar.SetNPCAffection(TypeVar, ...)
                        ninjaHappiness.SetNPCAffection(queenSlime.Type, AffectionLevel.Dislike);
                        queenSlimeHappiness.SetNPCAffection(ninjaType, AffectionLevel.Dislike);
                    }
                }
            }
        }
        /* What are the internal NPC names for these Town NPCs?
         * Most are pretty obvious, but remember to capitalize each word. Even words like "of".
         * 
         * English Name           Class Name
         * 
         * King Slime        =    KingSlime
         * Eye of Cthulhu    =    EyeOfCthulhu
         * Eater of Worlds   =    EaterOfWorlds
         * Brain of Cthulhu  =    BrainOfCthulhu
         * Queen Bee         =    QueenBee
         * Skeletron         =    Skeletron
         * Deerclops         =    Deerclops
         * Wall of Flesh     =    WallOfFlesh
         * Queen Slime       =    QueenSlime
         * The Destroyer     =    TheDestroyer
         * Retinazer         =    Retinazer
         * Spazmatism        =    Spazmatism
         * Plantera          =    Plantera
         * Golem             =    Golem
         * Empress of Light  =    EmpressOfLight
         * Duke Fishron      =    DukeFishron
         * Betsy             =    Betsy
         * Lunatic Cultist   =    LunaticCultist
         * Moon Lord         =    MoonLord
         * Dreadnaultilus    =    Dreadnaultilus
         * Mothron           =    Mothron
         * Pumpking          =    Pumpking
         * Ice Queen         =    IceQueen
         * Martian Saucer    =    MartianSaucer
         * The Torch God     =    TorchGod
         */
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
    }
}