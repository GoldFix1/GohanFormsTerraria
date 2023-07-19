using Microsoft.Xna.Framework;
using Terraria;
using DBZGoatLib.Model;
using Microsoft.Xna.Framework.Graphics;
using DBZGoatLib;
using Terraria.ModLoader;
using DBZGoatLib.Handlers;
/*
using DBTBalance.Helpers;
using DBTBalance.Model;
using DBTBalance.Buffs;
using DBTBalance;
*/
using GohanForms.Assets;
using System.Linq;
using System.Reflection;
using GohanForms.Model;

namespace GohanForms.Transformations
{
    public class MysticBuff : Transformation
    {
        public override AuraData AuraData() => new AuraData("DBZModPort/Effects/Animations/Aura/BaseAura", 4, BlendState.Additive, new Color(175, 175, 180));

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<GOHPlayer>();

            return !player.HasBuff<MysticBuff>() && modPlayer.MysticAchieved;

            //player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.PSSBBuff>()) >= 1 && 
        }


        public override string FormName() => "Potential Unleashed";

        public override string HairTexturePath() => "GohanForms/Assets/MysticHair";

        public override Gradient KiBarGradient() => new Gradient(new Color(152, 152, 152)).AddStop(1f, new Color(216, 216, 216));


        public override void OnTransform(Player player)
        {
            player.GetModPlayer<GOHPlayer>().MysticActive = true;
        }

        public override void PostTransform(Player player)
        {
            player.GetModPlayer<GOHPlayer>().MysticActive = false;
        }

        public override bool SaiyanSparks() => true;

        public override SoundData SoundData() => new SoundData("DBZMODPORT/Sounds/SSJAscension", "DBZMODPORT/Sounds/SSJ3", 260);

        public override bool Stackable() => false;

        public override Color TextColor() => Color.WhiteSmoke;

        /*
        public static bool IsDBTREnabled(BindingFlags bindingFlags) //BindingFlags bindingFlags
        {
            if (ModLoader.TryGetMod("DBTBalance", out Mod dbtr))
            {
                var BalanceConfig = dbtr.Code.DefinedTypes.First(x => x.Name.Equals("BalanceConfigServer"));
                dynamic Instance = BalanceConfig.GetField("Instance", BindingFlags.Public - 1).GetValue(null);
                return (bool)(Instance?.SSJTweaks ?? false);
            }
            else return false;
        }
        */
        public override void SetStaticDefaults()
        {
            kiDrainRate = 4f;
            kiDrainRateWithMastery = 2f;
            attackDrainMulti = 0.55f;
            
            if (!BalanceConfigServer.Instance.SSJTweaks)
                //(BalanceConfigServer.GetValue() == true)
                //(BalanceConfigServer.Instance.SSJTweaks)
            {
            
                baseDefenceBonus = 19;
                damageMulti = 3.5f; 
                speedMulti = 3.25f;
            
            }
            else 
            {
                baseDefenceBonus = 24;
                damageMulti = 1.55f;
                speedMulti = 1.12f;
            }
            
            base.SetStaticDefaults(); // ALWAYS call this somewhere in your SetStaticDefaults()!
        }
    }
}
