using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TheCollectors.Content.NPCs.TownNPCs;

namespace TheCollectors.Common.GlobalNPCs
{
    public class TheCollectorsNPCChat : GlobalNPC
    {
        public override void GetChat(NPC npc, ref string chat)
        {
            int ninja = NPC.FindFirstNPC(ModContent.NPCType<Ninja>());
            int mcmoneypants = NPC.FindFirstNPC(ModContent.NPCType<McMoneyPants>());

            switch (npc.type)
            {
                case NPCID.Guide:
                    if (ninja >= 0 && Main.rand.Next(0, 6) == 0)
                    {
                        chat = Language.GetTextValue("Mods.TheCollectors.Dialogue.Guide.Ninja", Main.npc[ninja].GivenName);
                    }
                    break;

                case NPCID.BestiaryGirl: // Zoologist
                    if (ninja >= 0 && Main.rand.Next(0, 6) == 0)
                    {
                        if (Main.bloodMoon || Main.moonPhase == 0)
                        {
                            chat = Language.GetTextValue("Mods.TheCollectors.Dialogue.Zoologist.Ninja2", Main.npc[ninja].GivenName);
                        }
                        else
                        {
                            chat = Language.GetTextValue("Mods.TheCollectors.Dialogue.Zoologist.Ninja1", Main.npc[ninja].GivenName);
                        }
                    }
                    break;

                case NPCID.GoblinTinkerer:
                    if (mcmoneypants >= 0 && Main.rand.Next(0, 6) == 0)
                    {
                        chat = Language.GetTextValue("Mods.TheCollectors.Dialogue.GoblinTinkerer.McMoneyPants", Main.npc[mcmoneypants].GivenName);
                    }
                    break;
            }
        }
    }
}