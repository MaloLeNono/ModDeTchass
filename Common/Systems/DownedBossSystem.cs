using System.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ModDeTchass.Common.Systems
{
    class DownedBossSystem : ModSystem
    {
        public static bool downedBossDeTchass = false;

        public override void ClearWorld()
        {
            downedBossDeTchass = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            if (downedBossDeTchass)
            {
                tag["downedBossDeTchass"] = true;
            }
        }

        public override void LoadWorldData(TagCompound tag)
        {
            downedBossDeTchass = tag.ContainsKey("downedBossDeTchass");
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.WriteFlags(downedBossDeTchass);
        }

        public override void NetReceive(BinaryReader reader)
        {
            reader.ReadFlags(out downedBossDeTchass);
        }
    }
}
