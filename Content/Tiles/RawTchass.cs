using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace ModDeTchass.Content.Tiles
{
    public class RawTchass : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.Ore[Type] = true;
            TileID.Sets.FriendlyFairyCanLureTo[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileOreFinderPriority[Type] = 525;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 1000;
            Main.tileMergeDirt[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;

            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(255, 148, 33), name);

            DustType = 84;
            HitSound = SoundID.Tink;
            MineResist = 4f;
            MinPick = 40;
        }
    }

    public class RawTchassSystem : ModSystem
    {
        public static LocalizedText RawTchassPassMessage { get; private set; }

        public override void SetStaticDefaults()
        {
            RawTchassPassMessage = Mod.GetLocalization($"WorldGen.{nameof(RawTchassPassMessage)}");
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));

            if (ShiniesIndex != -1)
            {
                tasks.Insert(ShiniesIndex + 1, new RawTchassPass("Tchass Mod Ores", 237.4298f));
            }
        }
    }

    public class RawTchassPass : GenPass
    {
        public RawTchassPass(string name, float loadWeight) : base(name, loadWeight)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = RawTchassSystem.RawTchassPassMessage.Value;

            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 1.2E-04); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, Main.maxTilesY);

                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(7, 12), WorldGen.genRand.Next(2, 6), ModContent.TileType<RawTchass>());
            }
        }
    }
}
