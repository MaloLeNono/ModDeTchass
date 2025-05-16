using Terraria;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Buffs;

public class Unemployed : ModBuff
{
    public override void SetStaticDefaults()
    {
        Main.buffNoSave[Type] = false;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.GetModPlayer<Bum>().isUnemployed = true;
        player.moveSpeed -= 0.85f;
    }
}

class Bum : ModPlayer
{
    public bool isUnemployed;

    public override void ResetEffects()
    {
        isUnemployed = false;
    }
    
    public override void PostUpdateRunSpeeds()
    {
        if (isUnemployed)
        {
            Player.maxRunSpeed -= 2f;
            Player.accRunSpeed -= 2.5f;
        }
    }
}