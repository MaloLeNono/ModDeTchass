using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Buffs;

class Cancer : ModBuff
{
    public override void SetStaticDefaults()
    {
        Main.debuff[Type] = true;
        Main.buffNoSave[Type] = false;
        Main.buffNoTimeDisplay[Type] = true;
        BuffID.Sets.LongerExpertDebuff[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.GetModPlayer<CancerPatient>().hasCancer = true;
        player.moveSpeed -= 0.05f;
    }
}

class CancerPatient : ModPlayer
{
    public bool hasCancer;
    
    public override void ResetEffects()
    {
        hasCancer = false;
    }

    public override void UpdateBadLifeRegen()
    {
        if (hasCancer)
        {
            if (Player.lifeRegen > 0)
                Player.lifeRegen = 0;
            
            Player.lifeRegenTime = 0;
            Player.lifeRegen -= 1;
        }
    }

    public override void PostUpdate()
    {
        Player.statDefense -= 20;
    }

    public override void PostUpdateRunSpeeds()
    {
        Player.maxRunSpeed -= 0.5f;
        Player.accRunSpeed -= 0.10f;
    }
}