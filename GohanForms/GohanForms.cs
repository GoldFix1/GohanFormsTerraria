using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;
using System;
using System.Reflection;
using MonoMod.RuntimeDetour;
using Terraria;
using System.Dynamic;
using GohanForms.Transformations;
using System.IO;
using DBZGoatLib;
using GohanForms.Model;
using Terraria.ModLoader.Config;
//using DBTBalance;
//using DBTBalance.Buffs;
//using DBTBalance.Helpers;
//using DBTBalance.Model;

namespace GohanForms
{
	public class GohanForms : Mod
	{
        public static GohanForms Instance;
        public static Mod DBZMOD;
        public static Mod DBCA;
        public static Mod GOATLIB;

        public const BindingFlags flagsAll = BindingFlags.Public | BindingFlags.NonPublic
        | BindingFlags.Instance | BindingFlags.Static | BindingFlags.GetField
        | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty;

        internal static List<Detour> Detours = new List<Detour>();
        internal static List<Hook> Hooks = new List<Hook>();

        public void Nothing() { }
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            GNetworkHandler.HandlePacket(reader, whoAmI);
        }


        //        public static SSBETES Instance;
        //        public static Mod DBTBalance;
    }
}