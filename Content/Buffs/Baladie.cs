using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Buffs;

public class Baladie : ModBuff
{
    public override void SetStaticDefaults()
    {
        Main.debuff[Type] = true;
        Main.buffNoSave[Type] = true;
        BuffID.Sets.LongerExpertDebuff[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.GetModPlayer<BaladiePlayer>().isSick = true;
    }
}

class BaladiePlayer : ModPlayer
{
    public bool isSick;

    public override void ResetEffects()
    {
        isSick = false;
    }

    public override void PostUpdate()
    {
        if (isSick)
            Player.statDefense -= 15;
    }
}