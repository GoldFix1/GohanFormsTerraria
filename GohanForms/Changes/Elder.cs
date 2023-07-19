using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DBZGoatLib;
using DBZGoatLib.Model;
using DBZGoatLib.Handlers;
using GohanForms.Assets;
using GohanForms.Transformations;
using GohanForms.Items;

namespace GohanForms.Changes
{
    [AutoloadHead]
    public class Elder : ModNPC
    {
        public bool MysticActive;
        public bool MysticUnlockMsg;
        public bool MysticAchieved;

        public DateTime? Offset = null;
        public DateTime? PoweringUpTime = null;
        public DateTime? LastPowerUpTick = null;

        //private TransformationInfo? Form = null;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elder");
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 20;
            NPC.height = 20;
            NPC.aiStyle = 7;
            NPC.defense = 35;
            NPC.lifeMax = 300;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 0;
            NPCID.Sets.AttackFrameCount[NPC.type] = 1;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 30;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;
            AnimationType = 22;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {

            return NPC.AnyNPCs(ModContent.NPCType<Elder>());
            
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Kai"
            };
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Potential Unleash";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool buff)
        {
            if (firstButton)
            {
                Player player = Main.player[Main.myPlayer];

                Mod GF = ModLoader.GetMod("GohanForms");
                //Item.buffType = ModContent.BuffType<SlimeMinionBuff>();
                //player.AddBuff(BuffID.WaterCandle, 600);
                
                var GOHPlayer = player.GetModPlayer<GOHPlayer>();
                if (!GOHPlayer.MysticAchieved)
                {
                    Main.NewText("You have ritual buff, after 4 minutes your potential will be unleashed");
                    //Main.NewText("Your potential has been unleashed!");
                    player.AddBuff(ModContent.BuffType<EDBuff>(), 14400); //86400
                }
                else
                {
                    Main.NewText("You have already reached your maximum");
                }
            }
        }

        public override string GetChat()
        {
            NPC.FindFirstNPC(ModContent.NPCType<Elder>());
            switch (Main.rand.Next(2))
            {
                case 0:
                    return "Don't ask me how I ended up in this sword";
                case 1:
                    return "Don't you have any magazines with you?";
                default:
                    return "Do you want me to unleash your potential?";
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 15;
            knockback = 2f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 5;
            randExtraCooldown = 10;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.CursedFlameFriendly;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 7f;
        }
    }
}