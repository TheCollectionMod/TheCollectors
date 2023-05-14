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
    public class TheCollectorsNPCShop : GlobalNPC
    {
        //C�digo para a�adir items a las tiendas de los NPC Vanilla
        /*public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            // This example does not use the AppliesToEntity hook, as such, we can handle multiple npcs here by using if statements.
            if (type == NPCID.Dryad)
            {
                // Adding an item to a vanilla NPC is easy:
                // This item sells for the normal price.
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleMountItem>());
                nextSlot++; // Don't forget this line, it is essential.

                // We can use shopCustomPrice and shopSpecialCurrency to support custom prices and currency. Usually a shop sells an item for item.value.
                // Editing item.value in SetupShop is an incorrect approach.

                // This shop entry sells for 2 Defenders Medals.
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleMountItem>());
                shop.item[nextSlot].shopCustomPrice = 2;
                shop.item[nextSlot].shopSpecialCurrency = CustomCurrencyID.DefenderMedals; // omit this line if shopCustomPrice should be in regular coins.
                nextSlot++;

                // This shop entry sells for 3 of a custom currency added in our mod.
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleMountItem>());
                shop.item[nextSlot].shopCustomPrice = 3;
                shop.item[nextSlot].shopSpecialCurrency = ExampleMod.ExampleCustomCurrencyId;
                nextSlot++;
            }
            else if (type == NPCID.Wizard)
            {
                // You can use conditions to dynamically change items offered for sale in a shop
                if (Main.expertMode)
                {
                    //TODO:
                    // shop.item[nextSlot].SetDefaults(ItemType<Infinity>());
                    // nextSlot++;
                }
            }
            else if (type == NPCID.Stylist)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleHairDye>());
                nextSlot++;
                if (Main.dayTime == false)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Content.Items.ExampleItem>());
                    nextSlot++;
                }
            }
        }*/
    }
}