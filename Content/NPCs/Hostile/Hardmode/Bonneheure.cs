using ModDeTchass.Content.Buffs;
using ModDeTchass.Content.Items.Materials;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace ModDeTchass.Content.NPCs.Hostile.Hardmode;

public class Bonneheure : ModNPC
{
    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[Type] = 3;
    }

    public override void SetDefaults()
    {
        NPC.netAlways = true;
        NPC.width = 36;
        NPC.height = 80;
        NPC.damage = 50;
        NPC.defense = 9;
        NPC.lifeMax = 190;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = ModDeTchass.LudoEi;
        NPC.value = Item.buyPrice(silver: 20);
        NPC.knockBackResist = 1.2f;
        NPC.aiStyle = 3;
        AnimationType = NPCID.Zombie;
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Microplastics>(), 1, 20, 32));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BouffeDeTchass>(), 5, 1, 12));
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (Condition.Hardmode.IsMet())
            return SpawnCondition.OverworldNightMonster.Chance * 0.3f;
        return 0;
    }

    public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
    {
        if (Main.rand.NextBool(2))
            target.AddBuff(ModContent.BuffType<Baladie>(), 72000);
    }
}