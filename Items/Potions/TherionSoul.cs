using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Therion.Items.Potions
{
    public class TherionSoul : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Heart);
        }

        public override bool CanPickup(Player player)
        {
            return true;
        }

        public override bool ItemSpace(Player player)
        {
            return true;
        }

        public override bool OnPickup(Player player)
        {
            Main.PlaySound(SoundID.Grab, (int)player.position.X, (int)player.position.Y, 1);

            TherionPlayer.ModPlayer(player).therionResourceCurrent += 50;
            if(Main.myPlayer == player.whoAmI)
            {
                TherionPlayer.ModPlayer(player).TherionEffect(50);
            }
            return false;
        }
    }
}
