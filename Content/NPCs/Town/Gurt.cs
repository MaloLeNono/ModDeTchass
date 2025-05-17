using ModDeTchass.Common.Systems;
using ModDeTchass.Content.Items.Consumables;
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
public class Gurt : ModNPC
{
    public const string ShopName = "Gurt";

    private static int ShimmerHeadIndex;
    private static Profiles.StackedNPCProfile NPCProfile;

    public override void Load()
    {
        ShimmerHeadIndex = Mod.AddNPCHeadTexture(Type, Texture + "_Shimmer_Head");
    }

    public override void SetStaticDefaults()
    {
        NPCID.Sets.DangerDetectRange[Type] = 500;
        NPCID.Sets.AttackType[Type] = 0;
        NPCID.Sets.AttackTime[Type] = 90;
        NPCID.Sets.AttackAverageChance[Type] = 50;
        NPCID.Sets.HatOffsetY[Type] = 4;
        NPCID.Sets.ShimmerTownTransform[NPC.type] = true;
        NPCID.Sets.ShimmerTownTransform[Type] = true;

        NPC.Happiness
            .SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike)
            .SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
            .SetBiomeAffection<CorruptionBiome>(AffectionLevel.Like)
            .SetNPCAffection(NPCID.Dryad, AffectionLevel.Like)
            .SetNPCAffection(NPCID.BestiaryGirl, AffectionLevel.Love)
            .SetNPCAffection(NPCID.Angler, AffectionLevel.Dislike)
            .SetNPCAffection(NPCID.Guide, AffectionLevel.Hate);

        NPCProfile = new Profiles.StackedNPCProfile(
            new Profiles.DefaultNPCProfile(Texture, NPCHeadLoader.GetHeadSlot(HeadTexture), Texture + "_Party"),
            new Profiles.DefaultNPCProfile(Texture + "_Shimmer", ShimmerHeadIndex, Texture + "_Shimmer_Party")
        );
    }

    public override void SetDefaults()
    {
        NPC.townNPC = true;
        NPC.friendly = true;
        NPC.width = 18;
        NPC.height = 46;
        NPC.aiStyle = 7;
        NPC.damage = 1;
        NPC.defense = 1;
        NPC.lifeMax = 50;
        NPC.HitSound = ModDeTchass.OursinEi;
        NPC.DeathSound = ModDeTchass.LudoEi;
        NPC.knockBackResist = 0.5f;
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
            TownNPCRespawnSystem.unlockedGurt = true;
    }

    public override bool CanTownNPCSpawn(int numTownNPCs)
    {
        return TownNPCRespawnSystem.unlockedGurt || DownedBossSystem.downedBossDeTchass;
    }

    public override ITownNPCProfile TownNPCProfile()
    {
        return NPCProfile;
    }

    public override string GetChat()
    {
        WeightedRandom<string> chat = new WeightedRandom<string>();
        
        chat.Add("Yo");
        chat.Add("sybau");
        chat.Add("this does not mama the mia");
        chat.Add("Gurt: yo");
        chat.Add("Strait up jorkin it... and by \"it\" i mean... my peanits...");
        chat.Add("i goon to the zoologist");
        chat.Add("Top 10 nintendo memes that will make you the coolest friend in the group chat");
        chat.Add("bfdtchs");

        string chosenChat = chat;
        return chosenChat;
    }

    public override void SetChatButtons(ref string button, ref string button2)
    {
        button = "Gurt";
        button2 = "Yo";
    }

    public override void OnChatButtonClicked(bool firstButton, ref string shopName)
    {
        if (firstButton)
        {
            shopName = ShopName;
        }
        else
            Main.npcChatText = GetChat();
    }

    public override void AddShops()
    {
        var npcShop = new NPCShop(Type, ShopName)
            .Add<CanOfInsects>()
            .Add<GlennQuagmire>()
            .Add(new Item(ItemID.DirtBlock) { shopCustomPrice = Item.buyPrice(platinum: 25) });
        
        npcShop.Register();
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Prime>()));
    }

    public override bool CanGoToStatue(bool toKingStatue) => true;

    public override void OnGoToStatue(bool toKingStatue)
    {
        if (Main.netMode == NetmodeID.Server)
        {
            ModPacket packet = Mod.GetPacket();
            packet.Write((byte)NPC.whoAmI);
            packet.Send();
        }
    }

    public override void TownNPCAttackStrength(ref int damage, ref float knockback)
    {
        damage = 1;
        knockback = 1f;
    }

    public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
    {
        cooldown = 30;
        randExtraCooldown = 50;
    }

    public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
    {
        projType = ProjectileID.BallOHurt;
        attackDelay = 1;
    }

    public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
    {
        multiplier = 1f;
        randomOffset = 1f;
    }
}