using ModDeTchass.Common.Systems;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace ModDeTchass.Content.NPCs.Town;

[AutoloadHead]
public class Petite : ModNPC
{
    private const string ShopName = "Petite";

    private static int shimmerHeadIndex;
    private static Profiles.StackedNPCProfile NPCProfile;
    
    public override void Load()
    {
        shimmerHeadIndex = Mod.AddNPCHeadTexture(Type, Texture + "_Shimmer_Head");
    }
    
    public override void SetStaticDefaults()
    {
        NPCID.Sets.DangerDetectRange[Type] = 2;
        NPCID.Sets.AttackType[Type] = -1;
        NPCID.Sets.AttackTime[Type] = -1;
        NPCID.Sets.AttackAverageChance[Type] = 999;
        NPCID.Sets.HatOffsetY[Type] = 1;
        NPCID.Sets.ShimmerTownTransform[NPC.type] = true;
        NPCID.Sets.ShimmerTownTransform[Type] = true;

        NPC.Happiness
            .SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
            .SetBiomeAffection<JungleBiome>(AffectionLevel.Hate)
            .SetBiomeAffection<MushroomBiome>(AffectionLevel.Love)
            .SetNPCAffection<Gurt>(AffectionLevel.Hate)
            .SetNPCAffection(NPCID.Angler, AffectionLevel.Love)
            .SetNPCAffection(NPCID.DD2Bartender, AffectionLevel.Like)
            .SetNPCAffection(NPCID.BestiaryGirl, AffectionLevel.Dislike);

        NPCProfile = new Profiles.StackedNPCProfile(
            new Profiles.DefaultNPCProfile(Texture, NPCHeadLoader.GetHeadSlot(HeadTexture), Texture + "_Party"),
            new Profiles.DefaultNPCProfile(Texture + "_Shimmer", shimmerHeadIndex, Texture + "_Shimmer_Party")
        );
    }
    
    public override void SetDefaults()
    {
        NPC.townNPC = true;
        NPC.friendly = true;
        NPC.width = 2;
        NPC.height = 2;
        NPC.aiStyle = 7;
        NPC.damage = 1;
        NPC.defense = 1;
        NPC.lifeMax = 5;
        NPC.HitSound = Sounds.OursinEi;
        NPC.DeathSound = Sounds.LudoEi;
        NPC.knockBackResist = 0f;
    }
    
    public override void HitEffect(NPC.HitInfo hit)
    {
        int num = NPC.life > 0 ? 1 : 5;

        for (int i = 0; i < num; i++)
        {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood);
        }
    }
    
    public override void OnSpawn(IEntitySource source)
    {
        if (source is EntitySource_SpawnNPC)
            TownNPCRespawnSystem.UnlockedPetite = true;
    }
    
    public override bool CanTownNPCSpawn(int numTownNPCs) => TownNPCRespawnSystem.UnlockedPetite || Condition.DownedQueenBee.IsMet();
    
    public override ITownNPCProfile TownNPCProfile() => NPCProfile;
    
    public override string GetChat()
    {
        WeightedRandom<string> chat = new WeightedRandom<string>();

        chat.Add("JE SUIS TELLEMENT PETIIIITE");
        chat.Add("UN POUR TOUS ET TOUS POUR UN!");
        chat.Add("JE N'AI PAS ASSEZ MANGÉ DE BOUFFE DE TCHASS ALORS JE SUIS TRÈS PETITE!");
        chat.Add("J'AI DES OS DE VERRE!!!!!!!");
        chat.Add("MÈRE NATURE, VA NIQUER TES GRANDS MORTS!!!!!!!!");
        chat.Add("JE SUIS LITÉRALLEMENT UN COLIS NE PAS TOUCHER FRAGILE!!!!");
        chat.Add("JE SUIS UN WIKIPÉDIA SUR PATTES!!!");

        string chosenChat = chat;
        return chosenChat;
    }
    
    public override void SetChatButtons(ref string button, ref string button2) => button = "Petite";
    
    public override void OnChatButtonClicked(bool firstButton, ref string shopName)
    {
        if (!firstButton) return;
        
        shopName = ShopName;
    }
    
    public override void AddShops()
    {
        NPCShop npcShop = new NPCShop(Type, ShopName)
            .Add(new Item(ItemID.Bone) { shopCustomPrice = Item.buyPrice(gold: 1) });
        npcShop.Register();
    }
    
    public override void ModifyNPCLoot(NPCLoot npcLoot) => npcLoot.Add(ItemDropRule.Common(ItemID.Bone));

    public override bool CanGoToStatue(bool toKingStatue) => true;

    public override void OnGoToStatue(bool toKingStatue)
    {
        if (Main.netMode != NetmodeID.Server) return;
        
        ModPacket packet = Mod.GetPacket();
        packet.Write((byte)NPC.whoAmI);
        packet.Send();
    }
}