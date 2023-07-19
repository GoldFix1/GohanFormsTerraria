using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using GohanForms.Transformations;
using GohanForms.Assets;
using GohanForms.Items;
using Terraria.ModLoader.IO;

namespace GohanForms.Transformations
{
	// This class serves as an example of a debuff that causes constant loss of life
	// See ExampleLifeRegenDebuffPlayer.UpdateBadLifeRegen at the end of the file for more information
	public class CKBuff : ModBuff
	{
        public const int LifePerFruit = 50;
        public const int MaxExampleLifeFruits = 1;
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Power Boost"); // Buff display name
			Description.SetDefault("You can become stronger"); // Buff description
			Main.debuff[Type] = true;  // Is it a debuff?
			Main.pvpBuff[Type] = false; // Players can give other players buffs, which are listed as pvpBuff
			Main.buffNoSave[Type] = true; // Causes this buff not to persist when exiting and rejoining the world
			BuffID.Sets.LongerExpertDebuff[Type] = false; // If this buff is a debuff, setting this to true will make this buff last twice as long on players in expert mode
		}

		// Allows you to make this buff give certain effects to the given player
		public override void Update(Player player, ref int buffIndex) {

            var GOHPlayer = player.GetModPlayer<GOHPlayer>();
            if (player.statLifeMax == 400 && !GOHPlayer.POTUNLAchieved)
			{

                int buffInde = player.FindBuffIndex(ModContent.BuffType<CKBuff>());
				if (buffInde < 10)
				{
					int buffTime = player.buffTime[buffInde];
					if (buffTime <= 5)
					{

						player.AddBuff(ModContent.BuffType<POTUNLBuff>(), 600);

						GOHPlayer.POTUNLAchieved = true;
                        /*
                        player.statLifeMax2 += LifePerFruit;
                        player.statLife += LifePerFruit;
                        player.GetModPlayer<ExampleLifeFruitPlayer>().exampleLifeFruits++;
                        */
                    }
				}

                /*
                player.GetDamage(DamageClass.Generic) += 0.25f;
                player.GetDamage(DamageClass.Generic).Base += 2f;
                player.moveSpeed += 0.25f;
                player.statDefense += 5;
                player.statLifeMax2 += LifePerFruit;
                player.statLife += LifePerFruit;
                */

            }

        }
	}

    /*
	public class ExampleLifeRegenDebuffPlayer : ModPlayer
	{
		// Flag checking when life regen debuff should be activated
		public bool lifeRegenDebuff;

		public override void ResetEffects() {
			lifeRegenDebuff = false;
		}

		// Allows you to give the player a negative life regeneration based on its state (for example, the "On Fire!" debuff makes the player take damage-over-time)
		// This is typically done by setting player.lifeRegen to 0 if it is positive, setting player.lifeRegenTime to 0, and subtracting a number from player.lifeRegen
		// The player will take damage at a rate of half the number you subtract per second
		public override void UpdateBadLifeRegen() {
			if (lifeRegenDebuff) {
				// These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects
				if (Player.lifeRegen > 0)
					Player.lifeRegen = 0;
				// Player.lifeRegenTime uses to increase the speed at which the player reaches its maximum natural life regeneration
				// So we set it to 0, and while this debuff is active, it never reaches it
				Player.lifeRegenTime = 0;
				// lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second
				Player.lifeRegen -= 16;
			}
		}
	}
	*/
}
