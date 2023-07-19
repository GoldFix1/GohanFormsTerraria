using Microsoft.Xna.Framework;
using Terraria;
using DBZGoatLib.Model;
using Microsoft.Xna.Framework.Graphics;
using DBZGoatLib;
//using DBTBalance.Buffs;
//using DBTBalance;
//using DBTBalance.Helpers;
//using DBTBalance.Model;
using Terraria.ModLoader;
using DBZGoatLib.Handlers;
using GohanForms.Assets;
using GohanForms.Model;

namespace GohanForms.Transformations
{
    internal class BeastBuff : Transformation
    {
        public override AuraData AuraData() => new AuraData("GohanForms/Assets/BeastAura", 4, BlendState.AlphaBlend, new Color(171, 229, 255)); //44, 149, 197

        public override bool CanTransform(Player player)
        {
            var modPlayer = player.GetModPlayer<GOHPlayer>();

            return player.GetModPlayer<GPlayer>().GetMastery(ModContent.BuffType<Transformations.MysticBuff>()) >= 1 && !player.HasBuff<BeastBuff>() && modPlayer.BeastAchieved;

            //return !player.HasBuff<SSBEBuff>() && modPlayer.SSBEAchieved;
        }

        public override string FormName() => "Beast";

        public override string HairTexturePath() => "GohanForms/Assets/BeastHair";

        public override Gradient KiBarGradient() => new Gradient(new Color(75, 0, 130)).AddStop(1f, new Color(138, 43, 226));

        public override void OnTransform(Player player)
        {
            player.GetModPlayer<GOHPlayer>().BeastActive = true;
        }

        public override void PostTransform(Player player)
        {
            player.GetModPlayer<GOHPlayer>().BeastActive = false;
        }

        public override bool SaiyanSparks() => false;

        public override SoundData SoundData() => new SoundData("DBZMODPORT/Sounds/Awakening", "DBZMODPORT/Sounds/SSG", 260);

        public override bool Stackable() => false;

        public override Color TextColor() => Color.Indigo;

        public override void SetStaticDefaults()
        {
                kiDrainRate = 5f;
                kiDrainRateWithMastery = 2.7f;
                attackDrainMulti = 1f;
            if (!BalanceConfigServer.Instance.SSJTweaks)
            {
                baseDefenceBonus = 62;
                damageMulti = 5.25f;
                speedMulti = 5.40f;
            } 
            else
            {
                baseDefenceBonus = 45;
                damageMulti = 1.8f;
                speedMulti = 1.4f;
            }

            base.SetStaticDefaults(); 
        }
    }
}
