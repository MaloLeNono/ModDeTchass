using System.IO;
using ModDeTchass.Content.NPCs.Town;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ModDeTchass.Common.Systems;

public class TownNPCRespawnSystem : ModSystem
{
    public static bool UnlockedGurt;
    public static bool UnlockedPetite;
    
    public override void ClearWorld()
    {
        UnlockedGurt = false;
        UnlockedPetite = false;
    }

    public override void SaveWorldData(TagCompound tag)
    {
        tag[nameof(UnlockedGurt)] = UnlockedGurt;
        tag[nameof(UnlockedPetite)] = UnlockedPetite;
    }

    public override void LoadWorldData(TagCompound tag)
    {
        UnlockedGurt = tag.GetBool(nameof(UnlockedGurt));
        UnlockedGurt |= NPC.AnyNPCs(ModContent.NPCType<Gurt>());
        UnlockedPetite = tag.GetBool(nameof(UnlockedPetite));
        UnlockedPetite |= NPC.AnyNPCs(ModContent.NPCType<Petite>());
    }

    public override void NetSend(BinaryWriter writer)
    {
        writer.WriteFlags(UnlockedGurt);
        writer.WriteFlags(UnlockedPetite);
    }

    public override void NetReceive(BinaryReader reader)
    {
        reader.ReadFlags(out UnlockedGurt);
        reader.ReadFlags(out UnlockedPetite);
    }
}