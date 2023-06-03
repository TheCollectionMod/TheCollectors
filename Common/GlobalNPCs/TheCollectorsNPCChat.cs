using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Personalities;
using TheCollectors.Content.NPCs.TownNPCs;
using static Terraria.ModLoader.ModContent;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Bestiary;
using Terraria.Utilities;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;
using TheCollectors.Content.Items;
using System.Linq;

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