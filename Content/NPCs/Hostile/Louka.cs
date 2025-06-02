using ModDeTchass.Common.Systems;
using ModDeTchass.Content.Items.Consumables;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace ModDeTchass.Content.NPCs.Hostile;

public class Louka : ModNPC
{
    public override void SetDefaults()
    {
        NPC.netAlways = true;
        NPC.width = 260;
        NPC.height = 130;
        NPC.damage = 20;
        NPC.defense = 9;
        NPC.lifeMax = 200;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = Sounds.LudoEi;
        NPC.value = Item.buyPrice(gold: 5);
        NPC.knockBackResist = 99f;
        NPC.aiStyle = 3;
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) => SpawnCondition.OverworldNightMonster.Chance * 0.1f;

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RepasDeTchass>(), 2));
        npcLoot.Add(ItemDropRule.Common(ItemID.MartianConduitPlating, 10, 5, 10));
    }
}