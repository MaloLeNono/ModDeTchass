using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.GlobalItems;

public class CopperShortsword : GlobalItem
{
    public override bool AppliesToEntity(Item entity, bool lateInstantiation)
    {
        return entity.type == ItemID.CopperShortsword;
    }
    
    public override void SetDefaults(Item entity)
    {
        entity.damage = 1;
        entity.knockBack = 20;
        entity.axe = 3;
        entity.pick = 15;
        entity.hammer = 15;
    }

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        tooltips.Add(new TooltipLine(Mod, "CopperShortsword", "What"));
    }
}