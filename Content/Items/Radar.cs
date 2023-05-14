/*using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Map;

namespace TuMod
{
    public class StatueDetector : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 1;
            item.consumable = false;
            item.value = Item.sellPrice(gold: 1);
            item.rare = 2;
        }

        public override bool UseItem(Player player)
        {
            //Definimos el radio de detección
            int detectionRadius = 50;

            //Obtenemos la posición actual del jugador
            Vector2 playerPosition = player.position;

            //Buscamos las estatuas en un área determinada alrededor del jugador
            for (int i = (int)playerPosition.X / 16 - detectionRadius; i < (int)playerPosition.X / 16 + detectionRadius; i++)
            {
                for (int j = (int)playerPosition.Y / 16 - detectionRadius; j < (int)playerPosition.Y / 16 + detectionRadius; j++)
                {
                    Tile tile = Main.tile[i, j];

                    if (tile.TileType == 411)
                    {
                        //Si encontramos una estatua, la marcamos en el mapa
                        Main.Map[MapHelper.GetMapCoords(i, j, 1)].IconType = 4;
                    }
                }
            }

            //Mostramos un mensaje de confirmación al jugador
            Main.NewText("Las estatuas cercanas han sido marcadas en tu mapa.", Color.LimeGreen);

            return true;
        }
    }
}*/
