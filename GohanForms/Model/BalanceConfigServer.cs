using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace GohanForms.Model
{
    /*
    internal class BalanceConfigServer
    {
        //public static object Instance { get; internal set; }

        // public override ConfigScope Mode => ConfigScope.ServerSide;

        //public static BalanceConfigServer Instance;

        //public bool SSJTweaks;


        
        internal static bool GetValue()
        {
            throw new NotImplementedException();
        }
        
    }
    */
    internal class BalanceConfigServer : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        public static BalanceConfigServer Instance;

        [Label("Rebalanced Stats (Mod Reload Required)")]
        [Tooltip("Self explanatory")]
        [DefaultValue(false)]
        public bool SSJTweaks;
    }
}