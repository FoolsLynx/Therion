using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using Therion.Items;
using Therion.NPCs;

namespace Therion
{
    public class TherionWorld : ModWorld
    {
        public override void Initialize()
        {
            TherionTraveller.spawnTime = double.MaxValue;
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"traveller", TherionTraveller.Save() }
            };
        }

        public override void Load(TagCompound tag)
        {
            TherionTraveller.Load(tag.GetCompound("traveller"));
        }

        public override void PostWorldGen()
        {
            int numPlaced = 0;
            int maxToPlace = WorldGen.genRand.Next(100, 500);
            for(int i = 0; i < 1000; i++)
            {
                Chest chest = Main.chest[i];
                if(chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers)
                {
                    for(int j = 0; j < 40; j++)
                    {
                        if(chest.item[j].type == ItemID.None)
                        {
                            chest.item[j].SetDefaults(ModContent.ItemType<TherionCrystal>());
                            chest.item[j].stack = WorldGen.genRand.Next(1, 20);
                            numPlaced += chest.item[j].stack;
                            break;
                        }
                    }
                }
                if (numPlaced >= maxToPlace) break;
            }
        }

        public override void PreUpdate()
        {
            TherionTraveller.UpdateTraveller();
        }
    }
}
