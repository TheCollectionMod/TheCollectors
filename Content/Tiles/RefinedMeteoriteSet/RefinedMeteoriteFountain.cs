using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using TheCollectors.Content.Dusts;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;
using Terraria.Audio;

namespace TheCollectors.Content.Tiles.RefinedMeteoriteSet
{
    public class RefinedMeteoriteFountain : ModTile
    {
        const int animationFrameWidth = 36;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Origin = new Point16(1, 2);
            //TileObjectData.newTile.Width = width;
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 16 };
            TileObjectData.addTile(Type);

            LocalizedText name = CreateMapEntryName();
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            // name.SetDefault("Water Fountain");
            AddMapEntry(new Color(179, 146, 107), name);
            AnimationFrameHeight = 72;
            AdjTiles = new int[] { TileID.WaterFountain };
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Terraria.Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteFountain>());
        }
        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteFountain>();
        }
        public override bool RightClick(int i, int j)
        {
            int rand = Main.rand.Next(2);
            SoundEngine.PlaySound(SoundID.Splash);
            HitWire(i, j);
            return true;
        }
        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];

            Vector2 zero = Main.drawToScreen ?
                Vector2.Zero : new Vector2(Main.offScreenRange, Main.offScreenRange);

            Texture2D texture = TextureAssets.Tile[Type].Value;

            int animate = tile.TileFrameY >= AnimationFrameHeight ?
                Main.tileFrame[Type] * AnimationFrameHeight : 0;

            Main.spriteBatch.Draw(texture, new Vector2(i * 16, j * 16) - Main.screenPosition + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY + animate, 16, 16), Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);
            return false;
        }
        //Don't animate if deactivated
        public override void AnimateIndividualTile(int type, int i, int j, ref int TileFrameXOffset, ref int TileFrameYOffset)
        {
            if (Main.tile[i, j].TileFrameX >= animationFrameWidth)
            {
                TileFrameYOffset = 0;
            }
        }
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frame = Main.tileFrame[TileID.WaterFountain];
            frameCounter = Main.tileFrameCounter[TileID.WaterFountain];
        }
        public override void HitWire(int i, int j)
        {
            int x = i - Main.tile[i, j].TileFrameX / 18 % 2;
            int y = j - Main.tile[i, j].TileFrameY / 18 % 4;

            Wiring.SkipWire(x, y);
            Wiring.SkipWire(x, y + 1);
            Wiring.SkipWire(x + 1, y);
            Wiring.SkipWire(x + 1, y + 1);
            Wiring.SkipWire(x + 2, y);
            Wiring.SkipWire(x + 2, y + 1);

            for (int l = x; l < x + 2; l++)
            {
                for (int m = y; m < y + 4; m++)
                {
                    if (Main.tile[l, m].HasTile && Main.tile[l, m].TileType == Type)
                    {
                        if (Main.tile[l, m].TileFrameY < (short)AnimationFrameHeight)
                            Main.tile[l, m].TileFrameY += (short)AnimationFrameHeight;
                        else
                            Main.tile[l, m].TileFrameY -= (short)AnimationFrameHeight;
                    }
                }
            }

            if (Wiring.running)
            {
                for (int g = 0; g < 1; g++)
                {
                    for (int h = 0; h < 1; h++)
                    {
                        Wiring.SkipWire(x + g, y + h);
                    }
                }
            }

            NetMessage.SendTileSquare(-1, x, y + 1, 6);
        }
        /*public override void HitWire(int i, int j)
        {
            //Top left tile
            int x = i - Main.tile[i, j].TileFrameX % animationFrameWidth / 18;
            int y = j - Main.tile[i, j].TileFrameY % AnimationFrameHeight / 18;

            Wiring.SkipWire(x, y);
            Wiring.SkipWire(x, y + 1);
            Wiring.SkipWire(x + 1, y);
            Wiring.SkipWire(x + 1, y + 1);
            Wiring.SkipWire(x + 2, y);
            Wiring.SkipWire(x + 2, y + 1);

            bool activate = Main.tile[x, y].TileFrameX != 0;
            for (int l = x; l < x + 3; l++)
            {
                for (int m = y; m < y + 2; m++)
                {
                    if (Main.tile[l, m].HasTile && Main.tile[l, m].TileType == Type)
                    {
                        if (activate)
                        {
                            Main.tile[l, m].TileFrameX -= animationFrameWidth;
                        }
                        else
                        {
                            Main.tile[l, m].TileFrameX += animationFrameWidth;
                        }
                    }
                }
            }
            NetMessage.SendTileSquare(-1, x + 1, y + 1, 3);
        }*/

        /*public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (frameCounter > 6)
            {
                frameCounter = 0;
                frame++;
                if (frame > 7)
                {
                    frame = 0;
                }
            }
        }*/
        /*public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
{
    Tile tile = Main.tile[i, j];
    Texture2D texture;
    if (Main.canDrawColorTile(i, j))
    {
        texture = Main.tileAltTexture[Type, tile.color()];
    }
    else
    {
        texture = Main.tileTexture[Type];
    }
    Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
    if (Main.drawToScreen)
    {
        zero = Vector2.Zero;
    }
    int animate = 0;
    if (tile.TileFrameY >= 72)
    {
        animate = Main.tileFrame[Type] * AnimationFrameHeight;
    }
    Main.spriteBatch.Draw(texture, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY + animate, 16, 16), Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);
    return false;
}*/
        /*public override void HitWire(int i, int j)
          {
              //Top left tile
              int x = i - Main.tile[i, j].TileFrameX % animationFrameWidth / 18;
              int y = j - Main.tile[i, j].TileFrameY % AnimationFrameHeight / 18;

              Wiring.SkipWire(x, y);
              Wiring.SkipWire(x, y + 1);
              Wiring.SkipWire(x + 1, y);
              Wiring.SkipWire(x + 1, y + 1);
              Wiring.SkipWire(x + 2, y);
              Wiring.SkipWire(x + 2, y + 1);

              bool activate = Main.tile[x, y].TileFrameX != 0;
              for (int l = x; l < x + 3; l++)
              {
                  for (int m = y; m < y + 2; m++)
                  {
                      if (Main.tile[l, m].HasTile && Main.tile[l, m].TileType == Type)
                      {
                          if (activate)
                          {
                              Main.tile[l, m].TileFrameX -= animationFrameWidth;
                          }
                          else
                          {
                              Main.tile[l, m].TileFrameX += animationFrameWidth;
                          }
                      }
                  }
              }
              NetMessage.SendTileSquare(-1, x + 1, y + 1, 3);
          }*/

        /*public override void HitWire(int i, int j)
        {
            int x = i - (Main.tile[i, j].TileFrameX / 18) % 2;
            int y = j - (Main.tile[i, j].TileFrameY / 18) % 4;
            for (int l = x; l < x + 2; l++)
            {
                for (int m = y; m < y + 4; m++)
                {
                    if (Main.tile[l, m] == null)
                    {
                        Main.tile[l, m] = new Tile();
                    }
                    if (Main.tile[l, m].HasTile && Main.tile[l, m].TileType == Type)
                    {
                        if (Main.tile[l, m].TileFrameY < 72)
                        {
                            Main.tile[l, m].TileFrameY += 72;
                        }
                        else
                        {
                            Main.tile[l, m].TileFrameY -= 72;
                        }
                    }
                }
            }
            if (Wiring.running)
            {
                Wiring.SkipWire(x, y);
                Wiring.SkipWire(x, y + 1);
                Wiring.SkipWire(x, y + 2);
                Wiring.SkipWire(x, y + 3);
                Wiring.SkipWire(x + 1, y);
                Wiring.SkipWire(x + 1, y + 1);
                Wiring.SkipWire(x + 1, y + 2);
                Wiring.SkipWire(x + 1, y + 3);
            }
            NetMessage.SendTileSquare(-1, x, y + 1, 3);
        }*/


    }
}