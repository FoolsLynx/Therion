using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Therion.Buffs
{
    public class TherionPotionBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Swiftsoul");
            Description.SetDefault("Regenerates Therion Points");
            Main.debuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            TherionPlayer.ModPlayer(player).therionResourceRegenRate *= 10f;
        }
    }
}
