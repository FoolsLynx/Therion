using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria.Localization;
using Therion.Items;
using Therion.Items.Potions;

namespace Therion.NPCs
{
    [AutoloadHead]
    public class TherionTraveller : ModNPC
    {
        public const double DESPAWN_TIME = 48600.0;

        public static double spawnTime = double.MaxValue;

        public static List<Item> shopItems = new List<Item>();

        public override string Texture => "Therion/NPCs/TherionTraveller";

        public static NPC FindNPC(int npcType) => Main.npc.FirstOrDefault(npc => npc.type == npcType && npc.active);

        public static void UpdateTraveller()
        {
            NPC traveller = FindNPC(ModContent.NPCType<TherionTraveller>());
            if(traveller != null && (!Main.dayTime || Main.time >= DESPAWN_TIME) && !IsNpcOnScreen(traveller.Center))
            {
                if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText(traveller.FullName + " has departed!", 50, 125, 255);
                else NetMessage.BroadcastChatMessage(NetworkText.FromLiteral(traveller.FullName + " has departed"), new Color(50, 125, 255));

                traveller.active = false;
                traveller.netSkip = -1;
                traveller.life = 0;
                traveller = null;
            }

            if(Main.dayTime && Main.time == 0)
            {
                if (traveller == null && Main.rand.NextBool(4))
                {
                    spawnTime = GetRandomSpawnTime(5400, 8100);
                }
                else
                {
                    spawnTime = double.MaxValue;
                }
            }

            if(traveller == null && CanSpawnNow())
            {
                int newTraveller = NPC.NewNPC(Main.spawnTileX * 16, Main.spawnTileY * 16, ModContent.NPCType<TherionTraveller>(), 1);
                traveller = Main.npc[newTraveller];
                traveller.homeless = true;
                traveller.direction = Main.spawnTileX >= WorldGen.bestX ? -1 : 1;
                traveller.netUpdate = true;

                shopItems = CreateNewShop();
                
                spawnTime = double.MaxValue;
                
                if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText(Language.GetTextValue("Announcement.HasArrived", traveller.FullName), 50, 125, 255);
                else NetMessage.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasArrived", traveller.GetFullNetName()), new Color(50, 125, 255));
            }
        }

        private static bool CanSpawnNow()
        {
            if (Main.eclipse || Main.invasionType > 0 && Main.invasionDelay == 0 && Main.invasionSize > 0) return false;

            if (Main.fastForwardTime) return false;

            return Main.dayTime && Main.time >= spawnTime && Main.time < DESPAWN_TIME && Main.hardMode;
        }

        private static bool IsNpcOnScreen(Vector2 center)
        {
            int w = NPC.sWidth + NPC.safeRangeX * 2;
            int h = NPC.sHeight + NPC.safeRangeY * 2;
            Rectangle npcScreenRect = new Rectangle((int)center.X - w / 2, (int)center.Y - h / 2, w, h);
            foreach(Player player in Main.player)
            {
                if (player.active && player.getRect().Intersects(npcScreenRect)) return true;
            }
            return false;
        }

        public static double GetRandomSpawnTime(double minTime, double maxTime)
        {
            return (maxTime - minTime) * Main.rand.NextDouble() + minTime;
        }

        public static List<Item> CreateNewShop()
        {
            var itemIds = new List<int>();

            itemIds.Add(ModContent.ItemType<TherionCrystal>());
            itemIds.Add(ModContent.ItemType<TherionPotion>());
            if (Main.rand.NextBool(4)) itemIds.Add(ModContent.ItemType<Items.Accessories.TherionBand>());
            if (Main.rand.NextBool(4)) itemIds.Add(ModContent.ItemType<Items.Accessories.TherionBelt>());


            NPC traveller = FindNPC(ModContent.NPCType<TherionTraveller>());
            Main.NewText(traveller.GivenName);
            if (traveller.GivenName.Equals("Velvet"))
            {
                itemIds.Add(ModContent.ItemType<Items.Weapons.TherionClaw>());
            }


            var items = new List<Item>();
            foreach(int itemId in itemIds)
            {
                Item item = new Item();
                item.SetDefaults(itemId);
                items.Add(item);
            }
            return items;
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.TravellingMerchant];
            NPCID.Sets.ExtraFramesCount[npc.type] = NPCID.Sets.ExtraFramesCount[NPCID.TravellingMerchant];
            NPCID.Sets.AttackFrameCount[npc.type] = NPCID.Sets.AttackFrameCount[NPCID.TravellingMerchant];
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true; 
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }

        public static TagCompound Save()
        {
            return new TagCompound
            {
                ["spawnTime"] = spawnTime,
                ["shopItems"] = shopItems
            };
        }

        public static void Load(TagCompound tag)
        {
            spawnTime = tag.GetDouble("spawnTime");
            shopItems = tag.Get<List<Item>>("shopItems");
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return false;
        }

        public override string TownNPCName()
        {
            switch(Main.rand.Next(8))
            {
                case 0:
                    return "Stagros";
                case 1:
                    return "Kamoana";
                case 2:
                    return "Griff";
                case 3:
                    return "Medissa";
                case 4:
                    return "Orthie";
                case 5:
                    return "Russ";
                case 6:
                    return "Dis";
                default:
                    return "Velvet";
            }
        }

        public override string GetChat()
        {
            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if(partyGirl >= 0 && Main.rand.NextBool(8))
            {
                return $"Oh... that {Main.npc[partyGirl].GivenName} is here... I've never seen someone so cheerful. It is annoying.";
            }

            switch(Main.rand.Next(4))
            {
                case 0:
                    return "I've been hunting down monsters and gathing Therion Crystals. Be sure to have a look at what I have.";
                case 1:
                    return "My little brother was murdered because of this worlds monsters. I will avenge his death and bring justice to the monster that murdered him.";
                case 2:
                    return $"Some people call me the Lord of Calamity. But you can just call me {npc.GivenName}.";
                default:
                    return "Are you the warrior of this place? If so, I have some goods that you might be interested in.";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton) shop = true;
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            foreach(Item item in shopItems)
            {
                if (item == null || item.type == ItemID.None) continue;
                shop.item[nextSlot++].SetDefaults(item.type);
            }
        }

        public override void AI()
        {
            npc.homeless = true;
        }

        public override void NPCLoot()
        {
            
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 40;
            knockback = 3f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 25;
            randExtraCooldown = 30;
        }


    }
}
