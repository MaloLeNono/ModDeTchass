using System.IO;
using ModDeTchass.Content.NPCs.Town;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ModDeTchass.Common.Systems;

public class TownNPCRespawnSystem : ModSystem
{
    public static bool unlockedGurt = false;

    public override void ClearWorld()
    {
        unlockedGurt = false;
    }

    public override void SaveWorldData(TagCompound tag)
    {
        tag[nameof(unlockedGurt)] = unlockedGurt;
    }

    public override void LoadWorldData(TagCompound tag)
    {
        unlockedGurt = tag.GetBool(nameof(unlockedGurt));
        unlockedGurt |= NPC.AnyNPCs(ModContent.NPCType<Gurt>());
    }

    public override void NetSend(BinaryWriter writer)
    {
        writer.WriteFlags(unlockedGurt);
    }

    public override void NetReceive(BinaryReader reader)
    {
        reader.ReadFlags(out unlockedGurt);
    }
}