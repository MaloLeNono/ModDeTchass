using Steamworks;
using System.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ModDeTchass.Common.Systems
{
    class DownedBossSystem : ModSystem
    {
        public static bool downedBossDeTchass = false;
        public static bool downedBfdtchs = false;

        public override void ClearWorld()
        {
            downedBossDeTchass = false;
            downedBfdtchs = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            if (downedBossDeTchass)
            {
                tag["downedBossDeTchass"] = true;
            }
            if (downedBfdtchs)
            {
                tag["downedBfdtchs"] = true;
            }
        }

        public override void LoadWorldData(TagCompound tag)
        {
            downedBossDeTchass = tag.ContainsKey("downedBossDeTchass");
            downedBfdtchs = tag.ContainsKey("downedBfdtchs");
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.WriteFlags(downedBossDeTchass);
            writer.WriteFlags(downedBfdtchs);
        }

        public override void NetReceive(BinaryReader reader)
        {
            reader.ReadFlags(out downedBossDeTchass);
            reader.ReadFlags(out downedBfdtchs);
        }
    }
}
