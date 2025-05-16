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
<<<<<<< HEAD
        if (hasCancer)
            Player.statDefense -= 20;
=======
        Player.statDefense -= 20;
>>>>>>> c45d5d5139c783b1a24dfa2135dd9941d898a68c
    }

    public override void PostUpdateRunSpeeds()
    {
<<<<<<< HEAD
        if (hasCancer)
        {
            Player.maxRunSpeed -= 0.5f;
            Player.accRunSpeed -= 0.10f;
        }
=======
        Player.maxRunSpeed -= 0.5f;
        Player.accRunSpeed -= 0.10f;
>>>>>>> c45d5d5139c783b1a24dfa2135dd9941d898a68c
    }
}