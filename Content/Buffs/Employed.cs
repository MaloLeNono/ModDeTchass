using Terraria;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Buffs;

public class Employed : ModBuff
{
    public override void SetStaticDefaults()
    {
        Main.buffNoSave[Type] = false;
        Main.buffNoTimeDisplay[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.GetModPlayer<Employee>().isEmployed = true;
        player.moveSpeed += 0.85f;
    }
}

class Employee : ModPlayer
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