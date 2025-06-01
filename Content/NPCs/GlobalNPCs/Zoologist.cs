using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.NPCs.GlobalNPCs;

public class Zoologist : GlobalNPC
{
    private static Profiles.StackedNPCProfile NPCProfile;
    private const string TexturePath = "ModDeTchass/Content/Textures/Zoologist_Default";
    
    public override bool AppliesToEntity(NPC entity, bool lateInstantiation) => entity.type == NPCID.BestiaryGirl;

    public override void SetStaticDefaults()
    {
        NPCProfile = new Profiles.StackedNPCProfile(
            new Profiles.DefaultNPCProfile(TexturePath, NPCHeadID.BestiaryGirl, TexturePath)
        );
    }
    
    public override ITownNPCProfile ModifyTownNPCProfile(NPC npc) => NPCProfile;

    public override void GetChat(NPC npc, ref string chat) => chat = " ";

    public override void ModifyNPCNameList(NPC npc, List<string> nameList)
    {
        nameList.RemoveRange(0, nameList.Count);
        nameList.Add(" ");
    }

    public override void ModifyTypeName(NPC npc, ref string typeName) => typeName = " ";
}