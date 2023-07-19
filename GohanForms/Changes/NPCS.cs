using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria;
using GohanForms.Model;
using GohanForms.Assets;
using Microsoft.Xna.Framework;
using System.Linq;
using DBZGoatLib;
using DBZGoatLib.Model;
//using GohanForms.Items;

namespace GohanForms.Changes
{
    internal class NPCS : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public override void OnKill(NPC npc)
        {
            //if (ModLoader.HasMod("DBZMODPORT"))
            //{
            Player player = Main.player[Main.myPlayer];
            var GOHPlayer = player.GetModPlayer<GOHPlayer>();
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    //GOHPlayer Player = Main.CurrentPlayer.GetModPlayer<GOHPlayer>();
                    //var ModPlayerClass = GohanForms.DBZMOD.Code.DefinedTypes.First(x => x.Name.Equals("MyPlayer"));
                    //var getModPlayer = ModPlayerClass.GetMethod("ModPlayer");

                    //var dbzPlayer = getModPlayer.Invoke(null, new object[] { Player.Player });

                    if (GOHPlayer.BeastAchieved != true && player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.MysticBuff>()) >= 1)
                    {
                        if (npc.type == NPCID.MoonLordCore)
                        {
                            GOHPlayer.BeastAchieved = true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Main.maxPlayers; i++)
                    {
                        //Player player = Main.player[i];
                        if (player != null)
                        {
                            if (player.active)
                            {

                                if (GOHPlayer.BeastAchieved != true && player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.MysticBuff>()) >= 1)
                                {
                                    if (npc.type == NPCID.MoonLordCore)
                                    {
                                        GOHPlayer.MPB_Unlock = true;
                                        GOHPlayer.BeastAchieved = true;
                                        GNetworkHandler.SendUnlockStatus(i, true);
                                    }
                                }
                            }
                        }
                    }
                }
            //}
        }
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {

            if (npc.type == NPCID.MoonLordCore)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.BeastItem>(), 1, 1, 1));
            }

            if (npc.type == NPCID.Golem)
            {
                //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.MysticItem>(), 1, 0, 1));
            }

            if (npc.type == NPCID.EyeofCthulhu)
            {
                //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.POTUNLItem>(), 1, 1, 1));
            }
        }
    }
}
