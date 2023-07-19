using Microsoft.Xna.Framework;
using Terraria;
using DBZGoatLib;
using DBZGoatLib.Handlers;
using Terraria.ModLoader;
using Terraria.ID;
using GohanForms.Assets;

namespace GohanForms.Items
{
    internal class POTUNLItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("POTENTIAL UNLOCK");
            Tooltip.SetDefault("Unleashes new power");
        }

        public override void SetDefaults()
        {
            Item.consumable = true;
            Item.potion = true;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.noMelee = true;
            Item.scale = 1f;
            Item.rare = 0;
        }

        public override bool? UseItem(Player player)
        {
            var GOHPlayer = player.GetModPlayer<GOHPlayer>();
            return !GOHPlayer.POTUNLAchieved;
        }

        public override void OnConsumeItem(Player player)
        {
            var GOHPlayer = player.GetModPlayer<GOHPlayer>();
            if (!GOHPlayer.POTUNLAchieved)
            {
                GOHPlayer.POTUNLActive = true;
                GOHPlayer.POTUNLAchieved = true;
            }
        }
    }
}
