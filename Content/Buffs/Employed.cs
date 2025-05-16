using Terraria;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Buffs;

public class Employed : ModBuff
{
    public override void SetStaticDefaults()
    {
        Main.debuff[Type] = false;
        Main.buffNoSave[Type] = false;
        Main.buffNoTimeDisplay[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.GetModPlayer<EmployedPlayer>().isEmployed = true;
        player.moveSpeed += 0.85f;
    }
}

class EmployedPlayer : ModPlayer
{
    public bool isEmployed;

    public override void ResetEffects()
    {
        isEmployed = false;
    }

    public override void PostUpdateRunSpeeds()
    {
        if (isEmployed)
        {
            Player.maxRunSpeed += 2f;
            Player.accRunSpeed += 2.5f;
        }
    }
}