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

namespace TheCollectors.Content.Tiles.RedCandyCaneSet
{
	internal class RedCandyCaneLamp : ModTile
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
			// Main.tileFlame[Type] = true; // This breaks it.

			// Placement
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1xX);
			TileObjectData.newTile.StyleLineSkip = 2;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.WaterDeath = true;
			TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.addTile(Type);

			// Etc
			AddMapEntry(new Color(255, 102, 102), Language.GetText("MapObject.FloorLamp"));
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);

			// Assets
			if (!Main.dedServ)
			{
				flameTexture = ModContent.Request<Texture2D>("TheCollectors/Content/Tiles/RedCandyCaneSet/RedCandyCaneLamp_Flame"); // We could also reuse Main.FlameTexture[] textures, but using our own texture is nice.
			}
		}

		public override void HitWire(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			int topY = j - tile.TileFrameY / 18 % 3;
			short frameAdjustment = (short)(tile.TileFrameX > 0 ? -18 : 18);

			Main.tile[i, topY].TileFrameX += frameAdjustment;
			Main.tile[i, topY + 1].TileFrameX += frameAdjustment;
			Main.tile[i, topY + 2].TileFrameX += frameAdjustment;

			Wiring.SkipWire(i, topY);
			Wiring.SkipWire(i, topY + 1);
			Wiring.SkipWire(i, topY + 2);

			// Avoid trying to send packets in singleplayer.
			if (Main.netMode != NetmodeID.SinglePlayer)
			{
				NetMessage.SendTileSquare(-1, i, topY + 1, 3, TileChangeType.None);
			}
		}

		public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
		{
			if (i % 2 == 1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
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

			if (i % 2 == 1)
			{
				effects = SpriteEffects.FlipHorizontally;
			}

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

			ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)(uint)i); // Don't remove any casts
		}
	}
}