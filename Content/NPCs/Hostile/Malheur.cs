using ModDeTchass.Common.Systems;
using ModDeTchass.Content.Buffs;
using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace ModDeTchass.Content.NPCs.Hostile;

public class Malheur : ModNPC
{
    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[Type] = 3;
    }

    public override void SetDefaults()
    {
        NPC.netAlways = true;
        NPC.width = 18;
        NPC.height = 40;
        NPC.damage = 10;
        NPC.defense = 6;
        NPC.lifeMax = 200;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = Sounds.LudoEi;
        NPC.value = Item.buyPrice(silver: 2);
        NPC.knockBackResist = 0.5f;
        NPC.aiStyle = 3;
        AnimationType = NPCID.Zombie;
    }
    
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Microplastics>(), 1, 10, 15));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RawTchass>(), 4, 2, 10));
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (!Condition.Hardmode.IsMet())
            return SpawnCondition.OverworldNightMonster.Chance * 0.8f;
        return 0;
    }
    
    public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
    {
        if (Main.rand.NextBool(4)) 
            target.AddBuff(ModContent.BuffType<Baladie>(), 36000);
    }
}