﻿using Microsoft.Xna.Framework;
using ModDeTchass.Content.Items.Tiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ModDeTchass.Content.Tiles;

public class CoemsBox : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileObsidianKill[Type] = true;
        TileID.Sets.HasOutlines[Type] = false;
        TileID.Sets.DisableSmartCursor[Type] = true;
        
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
        TileObjectData.newTile.Origin = new Point16(0, 1);
        TileObjectData.newTile.LavaDeath = false;
        TileObjectData.newTile.DrawYOffset = 2;
        TileObjectData.newTile.StyleLineSkip = 2;
        TileObjectData.addTile(Type);

        LocalizedText name = CreateMapEntryName();
        AddMapEntry(new Color(62, 52, 153), name);
    }

    
    public override void MouseOver(int i, int j)
    {
        Player player = Main.LocalPlayer;
        player.noThrow = 2;
        player.cursorItemIconEnabled = true;
        player.cursorItemIconID = ModContent.ItemType<CoemsBoxItem>();
    }

    public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
    {
        return true;
    }

    public override void EmitParticles(int i, int j, Tile tileCache, short tileFrameX, short tileFrameY, Color tileLight, bool visible)
    {
        Tile tile = Main.tile[i, j];

        if (!visible || tile.TileFrameX != 36 || tile.TileFrameY % 36 != 0 || (int)Main.timeForVisualEffects % 7 != 0 || !Main.rand.NextBool(3)) {
            return;
        }

        int musicNote = Main.rand.Next(570, 573);
        Vector2 spawnPosition = new Vector2(i * 16 + 8, j * 16 - 8);
        Vector2 noteMovement = new Vector2(Main.WindForVisuals * 2f, -0.5f);
        noteMovement.X *= Main.rand.NextFloat(0.5f, 1.5f);
        noteMovement.Y *= Main.rand.NextFloat(0.5f, 1.5f);
        switch (musicNote) {
            case 572:
                spawnPosition.X -= 8f;
                break;
            case 571:
                spawnPosition.X -= 4f;
                break;
        }

        Gore.NewGore(new EntitySource_TileUpdate(i, j), spawnPosition, noteMovement, musicNote, 0.8f);
    }
}