using ModDeTchass.Content.Buffs;
using Terraria;
using Terraria.ModLoader;

namespace ModDeTchass.Common.Commands;

public class GetUnemployed : ModCommand
{
    public override CommandType Type => CommandType.Chat;
    public override string Command => "getunemployed";
    public override string Description => "Grants the 'Unemployed' debuff";

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        caller.Player.AddBuff(ModContent.BuffType<Unemployed>(), 72000);
    }
}