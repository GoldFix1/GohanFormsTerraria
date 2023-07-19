using Microsoft.Xna.Framework;
using Terraria;
using DBZGoatLib;
using DBZGoatLib.Handlers;
using Terraria.ModLoader;
using Terraria.ID;
using GohanForms.Assets;

namespace GohanForms.Items
{
    internal class MysticItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Potential Unleashed UNLOCK");
            Tooltip.SetDefault("Unleashes (yes) new power");
        }

        public override void SetDefaults()
        {
            Item.consumable = true;
            Item.potion = false;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.noMelee = true;
            Item.scale = 1f;
            Item.rare = 7;
        }

        public override bool? UseItem(Player player)
        {
            var GOHPlayer = player.GetModPlayer<GOHPlayer>();
            return !GOHPlayer.MysticAchieved;
        }

        public override void OnConsumeItem(Player player)
        {
            var GOHPlayer = player.GetModPlayer<GOHPlayer>();
            if (!GOHPlayer.MysticAchieved)
            {
                GOHPlayer.MysticAchieved = true;
            }
        }
    }
}
