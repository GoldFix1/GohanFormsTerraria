using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.Localization;

namespace GohanForms.Items
{
    [AutoloadEquip(EquipType.Head)]
    internal class GohanHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            //ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false; // Dont draw head
            //ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Example: Wizards Hat
            ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true; // Example: Masks
            //ArmorIDs.Head.Sets.DrawBackHair[Item.headSlot] = true;
            //ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;

            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.LightRed;

            Item.defense = 0;
        }

        public override void AddRecipes()
        {
            Mod DBT = ModLoader.GetMod("DBZMODPORT");
            Recipe recipeDB = CreateRecipe(1);
            recipeDB.AddIngredient(ItemID.Silk, 5);
            recipeDB.AddIngredient(DBT, "FourStarDB", 1);
            recipeDB.AddTile(DBT.Find<ModTile>("ZTable"));
            recipeDB.Register();
        }
    }
}