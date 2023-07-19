using Terraria;
using Terraria.ModLoader;
using DBZGoatLib;
using System;
using DBZGoatLib.Model;
using Microsoft.Xna.Framework;
using Steamworks;
using GohanForms.Transformations;
using GohanForms.Items;
using System.Security.Policy;
using Terraria.ModLoader.IO;
using DBZMODPORT.Buffs;
using DBZMODPORT;
//using DBTBalance;
using System.Linq;
using System.Reflection;
using Terraria.ID;

namespace GohanForms.Assets
{
    internal class GOHPlayer : ModPlayer
    {
        public const int LifePerFruit = 50;
        public const int MaxExampleLifeFruits = 1;

        public bool MysticActive;
        public bool MysticUnlockMsg;
        public bool MysticAchieved;

        public bool BeastActive;
        public bool BeastUnlockMsg;
        public bool BeastAchieved;
        public bool MPB_Unlock;

        public bool POTUNLActive;
        public bool POTUNLUnlockMsg;
        public bool POTUNLAchieved;

        public DateTime? Offset = null;
        public DateTime? PoweringUpTime = null;
        public DateTime? LastPowerUpTick = null;

        private TransformationInfo? Form = null;

        public override void PostUpdate()
        {
            if (MysticAchieved && !MysticUnlockMsg)
            {
                MysticUnlockMsg = true;
                Main.NewText("Your potential has been unleashed!");
            }

            if (MPB_Unlock && Main.netMode == NetmodeID.MultiplayerClient)
            {
                //dynamic modPlayer = GohanForms.DBZMOD.Code.DefinedTypes.First(x => x.Name.Equals("MyPlayer")).GetMethod("ModPlayer").Invoke(null, new object[] { Player });

                Player player = Main.player[Main.myPlayer];
                if (player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.MysticBuff>()) >= 1)
                {
                    BeastAchieved = true;
                    MPB_Unlock = false;
                }
            }
            if (BeastAchieved && !BeastUnlockMsg)
            {
                BeastUnlockMsg = true;
                if (Main.netMode != NetmodeID.Server)
                {
                    Player player = Main.player[Main.myPlayer];
                    player.AddBuff(ModContent.BuffType<BeastBuff>(), 14400);
                    Main.NewText("You have come even further beyond.", Color.SlateBlue);
                    player.AddBuff(ModContent.BuffType<BeastBuff>(), 14400);
                }
            }

            if (POTUNLAchieved && !POTUNLUnlockMsg)
            {
                POTUNLUnlockMsg = true;
                Main.NewText("You have unlocked your true potential.");

                Player player = Main.player[Main.myPlayer];
                player.GetDamage(DamageClass.Generic).Base += 2f;
                player.moveSpeed += 0.25f;
                player.statDefense += 5;
                player.statLifeMax2 += LifePerFruit;
                player.statLife += LifePerFruit;
            }
        }


        public override void SaveData(TagCompound tag)
        {
            tag.Add("GohanForms_MysticAchieved", MysticAchieved);
            tag.Add("GohanForms_MysticUnlockMsg", MysticUnlockMsg);

            tag.Add("GohanForms_BeastAchieved", BeastAchieved);
            tag.Add("GohanForms_BeastUnlockMsg", BeastUnlockMsg);

            tag.Add("GohanForms_POTUNLAchieved", POTUNLAchieved);
            tag.Add("GohanForms_POTUNLUnlockMsg", POTUNLUnlockMsg);
        }

        public override void LoadData(TagCompound tag)
        {
            if (tag.ContainsKey("GohanForms_MysticAchieved"))
                MysticAchieved = tag.GetBool("GohanForms_MysticAchieved");
            if (tag.ContainsKey("GohanForms_MysticUnlockMsg"))
                MysticUnlockMsg = tag.GetBool("GohanForms_MysticUnlockMsg");

            if (tag.ContainsKey("GohanForms_BeastAchieved"))
                BeastAchieved = tag.GetBool("GohanForms_BeastAchieved");
            if (tag.ContainsKey("GohanForms_BeastUnlockMsg"))
                BeastUnlockMsg = tag.GetBool("GohanForms_BeastUnlockMsg");

            if (tag.ContainsKey("GohanForms_POTUNLAchieved"))
                POTUNLAchieved = tag.GetBool("GohanForms_POTUNLAchieved");
            if (tag.ContainsKey("GohanForms_POTUNLUnlockMsg"))
                POTUNLUnlockMsg = tag.GetBool("GohanForms_POTUNLUnlockMsg");
        }


        public class ExampleLifeFruitPlayer : ModPlayer
        {
            public int exampleLifeFruits;

            public override void ResetEffects()
            {
                // Increasing health in the ResetEffects hook in particular is important so it shows up properly in the player select menu
                // and so that life regeneration properly scales with the bonus health
                Player.statLifeMax2 += exampleLifeFruits * DivineWater.LifePerFruit;
            }

            public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
            {
                ModPacket packet = Mod.GetPacket();
                //packet.Write((byte)GohanForms.MessageType.ExamplePlayerSyncPlayer);
                packet.Write((byte)Player.whoAmI);
                packet.Write(exampleLifeFruits);
                packet.Send(toWho, fromWho);
            }

            // NOTE: The tag instance provided here is always empty by default.
            // Read https://github.com/tModLoader/tModLoader/wiki/Saving-and-loading-using-TagCompound to better understand Saving and Loading data.
            public override void SaveData(TagCompound tag)
            {
                tag["exampleLifeFruits"] = exampleLifeFruits;
            }

            public override void LoadData(TagCompound tag)
            {
                exampleLifeFruits = (int)tag["exampleLifeFruits"];
            }
        }


        public class BSSFPanel : TransformationTree
        {
            public override bool Complete() => false;
            public override bool Condition(Player player) => true;

            public override Connection[] Connections() => new Connection[]
            {
            //new Connection(5,0,1,false,new Gradient(Color.AliceBlue).AddStop(0.60f, new Color(176,196,222))),
            //Color.RoyalBlue
            new Connection(6,0,1,false,new Gradient(Color.AliceBlue).AddStop(0.60f, new Color(0,206,209))),
            };

            public override string Name() => "Bonus Forms";

            public override Node[] Nodes() => new Node[]
            {
            new Node(6, 0, "MysticBuff", "GohanForms/Transformations/MysticBuff", "Golem",UnlockConditionMystic,DiscoverConditionMystic), //Only gifted warriors can achieve such strength through training.
            new Node(7, 0, "BeastBuff", "GohanForms/Transformations/BeastBuff", "MoonLord",UnlockConditionBeast,DiscoverConditionBeast), //Train harder in your god form.
            //new Node(5, 0, "POTUNLBuff", "GohanForms/Transformations/POTUNLBuff", "EyeOfCthulhu",UnlockConditionPOTUNL,DiscoverConditionPOTUNL),
            };
            public bool UnlockConditionMystic(Player player)
            {
                var GOHPlayer = player.GetModPlayer<GOHPlayer>();

                return GOHPlayer.MysticAchieved;

            }

            public bool DiscoverConditionMystic(Player player)
            {
                return true;
            }

            public bool UnlockConditionBeast(Player player)
            {
                var GOHPlayer = player.GetModPlayer<GOHPlayer>();

                return player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.MysticBuff>()) >= 1 && GOHPlayer.BeastAchieved;

            }
            public bool DiscoverConditionBeast(Player player)
            {
                return player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.MysticBuff>()) >= 1;
            }
            public bool UnlockConditionPOTUNL(Player player)
            {
                var GOHPlayer = player.GetModPlayer<GOHPlayer>();

                return GOHPlayer.POTUNLAchieved;
            }

            public bool DiscoverConditionPOTUNL(Player player)
            {
                return true;
            }
        }
    }
}


