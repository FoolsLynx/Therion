using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.ID;

namespace Therion
{
    public class TherionPlayer : ModPlayer
    {

        public const int DEFAULT_EXAMPLE_RESOURCE_MAX = 1000;

        public static TherionPlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<TherionPlayer>();
        }

        // Damage
        public float therionDamageAdd;
        public float therionDamageMult = 1f;
        public float therionKnockback;
        public int therionCrit;

        // Resource
        public int therionResourceCurrent;
        public int therionResourceMax;
        public int therionResourceMax2;
        public float therionResourceRegenRate;
        internal int therionResourceRegenTimer = 0;
        public static readonly Color HealTherionResource = Color.Purple;

        // Ailments
        public bool equilibriumEffect = false;

        public override void Initialize()
        {
            therionResourceMax = DEFAULT_EXAMPLE_RESOURCE_MAX;
        }

        public override void ResetEffects()
        {
            ResetVariables();
        }

        public override void UpdateDead()
        {
            ResetVariables();
        }

        private void ResetVariables()
        {
            therionDamageAdd = 0f;
            therionDamageMult = 1f;
            therionKnockback = 0f;
            therionCrit = 0;
            therionResourceRegenRate = 1f;
            therionResourceMax2 = therionResourceMax;
            equilibriumEffect = false;
        }

        public override void PostUpdateMiscEffects()
        {
            UpdateResource();
        }

        private void UpdateResource()
        {
            if (Main.hardMode)
            {
                therionResourceRegenTimer++;
                if (therionResourceRegenTimer > 60 / therionResourceRegenRate)
                {
                    therionResourceCurrent += 1;
                    therionResourceRegenTimer = 0;
                }
            }
            therionResourceCurrent = (int)MathHelper.Clamp(therionResourceCurrent, 0, therionResourceMax2);
        }

        public void TherionEffect(int healAmount, bool broadcast = true)
        {
            CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), Color.MediumPurple, healAmount);
            if(broadcast && Main.netMode == NetmodeID.MultiplayerClient && player.whoAmI == Main.myPlayer)
            {
                NetMessage.SendData(MessageID.HealEffect, -1, -1, null, player.whoAmI, healAmount);
            }
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"therionPoints", therionResourceCurrent }
            };
        }

        public override void Load(TagCompound tag)
        {
            therionResourceCurrent = tag.GetInt("therionPoints");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int _ = reader.ReadInt32();
            therionResourceCurrent = reader.ReadInt32();
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();
            packet.Write((byte)TherionMessageType.TherionPlayerSyncPlayer);
            packet.Write((byte)player.whoAmI);
            packet.Write(therionResourceCurrent);
            packet.Send(toWho, fromWho);
        }

        public override void UpdateLifeRegen()
        {
            if(equilibriumEffect)
            {
                if (player.lifeRegen > 0) player.lifeRegen = 0;
                player.lifeRegenTime = 0;
                player.lifeRegen -= 4;
                therionResourceRegenRate += 4;
            }
        }
    }
}
