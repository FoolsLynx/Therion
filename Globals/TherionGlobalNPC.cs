using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Therion.Items;
using Therion.Items.Placeables;
using Therion.Items.Potions;
using Therion.NPCs;

namespace Therion.Globals
{
    public class TherionGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.lifeMax >= 250 && Main.hardMode)
            {
                if (Main.rand.Next(6) == 0)
                {
                    int drops = 1;
                    if (Main.expertMode) drops += Main.rand.Next(0, 2);
                    if (npc.boss) drops *= Main.rand.Next(1, 4);

                    for (var i = 0; i < drops; i++)
                    {
                        Item.NewItem(npc.position, npc.width, npc.height, ModContent.ItemType<TherionSoul>());
                    }
                }
            }
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if(type == NPCID.Dryad && TherionTraveller.FindNPC(ModContent.NPCType<TherionTraveller>()) != null)
            {
                shop.item[nextSlot++].SetDefaults(ModContent.ItemType<TherionHerbSeeds>());

            }
        }
    }
}
