using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.NPCs.GlobalNPCs;

public class Guide : GlobalNPC
{
    private static Profiles.StackedNPCProfile NPCProfile;
    private const string TexturePath = "ModDeTchass/Content/Textures/Guide_Default";
    
    public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
    {
        return entity.type == NPCID.Guide;
    }

    public override void SetStaticDefaults()
    {
        NPCProfile = new Profiles.StackedNPCProfile(
            new Profiles.DefaultNPCProfile(TexturePath, NPCHeadID.Guide, TexturePath)
        );
    }

    public override ITownNPCProfile ModifyTownNPCProfile(NPC npc)
    {
        return NPCProfile;
    }
}