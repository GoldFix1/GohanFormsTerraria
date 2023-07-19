using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using GohanForms.Transformations;
using GohanForms.Assets;

namespace GohanForms.Transformations
{
	public class EDBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Potential Release");
            Description.SetDefault("Your power is starting to increase");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetDamage(DamageClass.Generic) += 0.25f;
			player.GetDamage(DamageClass.Generic) *= 1.12f;
			player.GetDamage(DamageClass.Generic).Base += 4f;
			player.GetDamage(DamageClass.Generic).Flat += 5f;
            player.moveSpeed -= 0.4f;
            player.statDefense += 5;

            int buffInde = player.FindBuffIndex(ModContent.BuffType<EDBuff>());
            if (buffInde < 10)
            {
                int buffTime = player.buffTime[buffInde];
                // ...
                if (buffTime <= 5)
                {

                    var GOHPlayer = player.GetModPlayer<GOHPlayer>();

                    player.AddBuff(ModContent.BuffType<MysticBuff>(), 600);

                    GOHPlayer.MysticAchieved = true;

                }

            }

        }
	}
}
