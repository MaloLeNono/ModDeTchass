using ModDeTchass.Common.Systems;
using ModDeTchass.Content.Buffs;
using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace ModDeTchass.Content.NPCs.Hostile;

public class Neutre : ModNPC
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
        NPC.lifeMax = 150;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = Sounds.LudoEi;
        NPC.value = Item.buyPrice(silver: 10);
        NPC.knockBackResist = 0.5f;
        NPC.aiStyle = 3;
        AnimationType = NPCID.Zombie;
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Microplastics>(), 1, 2000, 2500));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RawTchass>(), 4, 10, 20));
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) => SpawnCondition.OverworldNightMonster.Chance * 0.005f;

    public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
    {
        if (target.HasBuff<Employed>())
        {
            target.ClearBuff(ModContent.BuffType<Employed>());;
            target.AddBuff(ModContent.BuffType<Unemployed>(), 72000);
        }
        
        if (Main.rand.NextBool(4)) 
            target.AddBuff(ModContent.BuffType<Baladie>(), 36000);
    }
}