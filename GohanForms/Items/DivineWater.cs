using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using GohanForms.Transformations;

namespace GohanForms.Items
{
	// Making an item like Life Fruit (That goes above 500) involves a lot of code, as there are many things to consider.
	// (An alternate that approaches 500 can simply follow vanilla code, however.):
	// You can't make player.statLifeMax more than 500 (it won't save), so you'll have to maintain your extra life within your mod.
	// Within your ModPlayer, you need to save/load a count of usages. You also need to sync the data to other players.
	internal class DivineWater : ModItem
	{
        public const int MaxExampleLifeFruits = 50;
        public const int LifePerFruit = 1;
        public override void SetStaticDefaults() {
			Tooltip.SetDefault("You will be able to become stronger");
		}

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 1;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(gold: 1);

            //Item.healLife = 100; // While we change the actual healing value in GetHealLife, Item.healLife still needs to be higher than 0 for the item to be considered a healing item
            //Item.potion = true; // Makes it so this item applies potion sickness on use and allows it to be used with quick heal
        }

        /*
		public override bool CanUseItem(Player player) {
			// Any mod that changes statLifeMax to be greater than 500 is broken and needs to fix their code.
			// This check also prevents this item from being used before vanilla health upgrades are maxed out.
			return player.statLifeMax == 400;
		}
		*/
        public override bool? UseItem(Player player) 
		{

			player.AddBuff(ModContent.BuffType<CKBuff>(), 3600);

            if (player.statLifeMax == 400)
            {
            player.AddBuff(BuffID.Weak, 2700);
            player.AddBuff(BuffID.Slow, 1800);
            player.AddBuff(BuffID.Darkness, 2700);
            player.AddBuff(BuffID.Venom, 2000);
            }
            else
            {
                player.AddBuff(BuffID.Weak, 2700);
                player.AddBuff(BuffID.Slow, 1800);
                player.AddBuff(BuffID.Darkness, 2700);
                player.AddBuff(BuffID.Venom, 6000);
            }

            return true;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.

	}
}
