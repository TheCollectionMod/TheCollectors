using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TheCollectors.Content.Tiles.RefinedMeteoriteSet
{
	// This class shows off many things common to Lamp tiles in Terraria. The process for creating this example is detailed in: https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#examplelamp-tile
	// If you can't figure out how to recreate a vanilla tile, see that guide for instructions on how to figure it out yourself.
	internal class RefinedMeteoriteChandelier : ModTile
	{
		private Asset<Texture2D> flameTexture;

		public override void SetStaticDefaults()
		{
			// Properties
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileWaterDeath[Type] = true;
			Main.tileLavaDeath[Type] = true;

			// Placement
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Width = 3;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
			TileObjectData.newTile.DrawYOffset = 0;
			TileObjectData.newTile.WaterDeath = true;
			TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.addTile(Type);

			// Etc
			AddMapEntry(new Color(253, 221, 3), Language.GetText("MapObject.FloorLamp"));

			// Assets
			if (!Main.dedServ)
			{
				flameTexture = ModContent.Request<Texture2D>("TheCollectors/Content/Tiles/RefinedMeteoriteSet/RefinedMeteoriteChandelier_Flame"); // We could also reuse Main.FlameTexture[] textures, but using our own texture is nice.
			}
		}

		public override void HitWire(int i, int j) //ExxoAvalonOrigins Mod

		{
			int x = i - Main.tile[i, j].TileFrameX / 18 % 3;
			int y = j - Main.tile[i, j].TileFrameY / 18 % 3;
			for (int l = x; l < x + 3; l++)
			{
				for (int m = y; m < y + 3; m++)
				{
					if (Main.tile[l, m].HasTile && Main.tile[l, m].TileType == Type)
					{
						if (Main.tile[l, m].TileFrameX < 54)
						{
							Main.tile[l, m].TileFrameX += 54;
						}
						else
						{
							Main.tile[l, m].TileFrameX -= 54;
						}
					}
				}
			}
			if (Wiring.running)
			{
				Wiring.SkipWire(x, y);
				Wiring.SkipWire(x, y + 1);
				Wiring.SkipWire(x, y + 2);
				Wiring.SkipWire(x + 1, y);
				Wiring.SkipWire(x + 1, y + 1);
				Wiring.SkipWire(x + 1, y + 2);
				Wiring.SkipWire(x + 2, y);
				Wiring.SkipWire(x + 2, y + 1);
				Wiring.SkipWire(x + 2, y + 2);
			}
			NetMessage.SendTileSquare(-1, x, y + 1, 3);
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			Tile tile = Main.tile[i, j];
			if (tile.TileFrameX == 0)
			{
				// We can support different light colors for different styles here: switch (tile.frameY / 54)
				r = 1f;
				g = 0.75f;
				b = 1f;
			}
		}

		public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData)
		{
			if (Main.gamePaused || !Main.instance.IsActive || Lighting.UpdateEveryFrame && !Main.rand.NextBool(4))
			{
				return;
			}

			Tile tile = Main.tile[i, j];

			short frameX = tile.TileFrameX;
			short frameY = tile.TileFrameY;

			// Return if the lamp is off (when frameX is 0), or if a random check failed.
			if (frameX != 0 || !Main.rand.NextBool(40))
			{
				return;
			}

			int style = frameY / 54;

			if (frameY / 18 % 3 == 0)
			{
				int dustChoice = -1;

				if (style == 0)
				{
					dustChoice = 21; // A purple dust.
				}

				// We can support different dust for different styles here
				if (dustChoice != -1)
				{
					var dust = Dust.NewDustDirect(new Vector2(i * 16 + 4, j * 16 + 2), 4, 4, dustChoice, 0f, 0f, 100, default, 1f);

					if (!Main.rand.NextBool(3))
					{
						dust.noGravity = true;
					}

					dust.velocity *= 0.3f;
					dust.velocity.Y = dust.velocity.Y - 1.5f;
				}
			}
		}

		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			SpriteEffects effects = SpriteEffects.None;

			Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);

			if (Main.drawToScreen)
			{
				zero = Vector2.Zero;
			}

			Tile tile = Main.tile[i, j];
			int width = 16;
			int offsetY = 0;
			int height = 16;
			short frameX = tile.TileFrameX;
			short frameY = tile.TileFrameY;

			TileLoader.SetDrawPositions(i, j, ref width, ref offsetY, ref height, ref frameX, ref frameY);

			ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 48 | (long)(uint)i); // Don't remove any casts.

			// We can support different flames for different styles here: int style = Main.tile[j, i].frameY / 54;
			for (int c = 0; c < 7; c++)
			{
				float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
				float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;

				spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(167, 53, 175, 0), 0f, default, 1f, effects, 0f);
			}
		}
	}
}
