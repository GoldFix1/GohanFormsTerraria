using Microsoft.Xna.Framework;
using Terraria;
using DBZGoatLib.Model;
using Microsoft.Xna.Framework.Graphics;
using DBZGoatLib;
using Terraria.ModLoader;
using DBZGoatLib.Handlers;
using GohanForms.Assets;

namespace GohanForms.Transformations
{
    public class POTUNLBuff : Transformation
    {
        public override AuraData AuraData() => new AuraData("DBZModPort/Effects/Animations/Aura/BaseAura", 4, BlendState.Additive, new Color(175, 175, 180));

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<GOHPlayer>();

            return !player.HasBuff<POTUNLBuff>() && modPlayer.POTUNLAchieved;

            //player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.PSSBBuff>()) >= 1 && 
        }


        public override string FormName() => "Potential Unlocked";

        public override string HairTexturePath() => "GohanForms/Assets/MystiHair";

        public override Gradient KiBarGradient() => new Gradient(new Color(152, 152, 152)).AddStop(1f, new Color(216, 216, 216));


        public override void OnTransform(Player player)
        {
            player.GetModPlayer<GOHPlayer>().POTUNLActive = true;
        }

        public override void PostTransform(Player player)
        {
            player.GetModPlayer<GOHPlayer>().POTUNLActive = true;
        }

        public override bool SaiyanSparks() => false;

        public override SoundData SoundData() => new SoundData("DBZMODPORT/Sounds/SSJAscension", "DBZMODPORT/Sounds/SSJAura", 260);

        public override bool Stackable() => true;

        public override Color TextColor() => Color.WhiteSmoke;

        public override void SetStaticDefaults()
        {
            damageMulti = 1.15f; 
            //speedMulti = 1f; 

            //kiDrainRate = 1f;
            //kiDrainRateWithMastery = 1f;

            //attackDrainMulti = 1f; 
            //baseDefenceBonus = 21;

            base.SetStaticDefaults(); // ALWAYS call this somewhere in your SetStaticDefaults()!
        }
    }
}
