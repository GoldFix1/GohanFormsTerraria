using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using GohanForms.Changes;
using GohanForms.Assets;
using GohanForms.Items;

namespace GohanForms.Items
{
	public class ZSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Z Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Probably contains a huge power");
		}
		public override void SetDefaults()
		{
			Item.damage = 81;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 1000;
			Item.rare = 6;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			//Item.shoot = ProjectileID.EnchantedBeam;
			//Item.shootSpeed = 10f;
		}

        SoundStyle sound = new SoundStyle("GohanForms/Assets/SwordBreaks");

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			target.AddBuff(BuffID.BrokenArmor, 600);
			if (target.type == NPCID.Golem)
			{
				Item.TurnToAir();
                Terraria.DataStructures.IEntitySource entitySource = null;
                Main.LocalPlayer.QuickSpawnItem(entitySource, ItemID.BrokenHeroSword);
                // Item.shoot = ModContent.ProjectileType<ExampleFlailProjectile>();
                Item.shoot = ProjectileID.CrystalShard;
                Item.shoot = ProjectileID.CrystalShard;
                Item.shoot = ProjectileID.CrystalShard;
                Item.shoot = ProjectileID.CrystalShard;
                Item.shootSpeed = 10f;
                SoundEngine.PlaySound(sound.WithVolumeScale(4f).WithPitchOffset(0.8f), player.position);
                //Item.UseSound = SoundID.Item1;
                //SoundEngine.PlaySound(sound.WithVolumeScale(0.5f).WithPitchOffset(0.8f), player.position);

                if (player.whoAmI == Main.myPlayer)
                {
                    // If the player using the item is the client
                    // (explicitely excluded serverside here)

                    //SoundEngine.PlaySound(SoundID.Roar, player.position);


                    int type = ModContent.NPCType<Elder>();

                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        if (!NPC.AnyNPCs(ModContent.NPCType<Elder>()))
                        {
                        // If the player is not in multiplayer, spawn directly
                        NPC.SpawnOnPlayer(player.whoAmI, type);
                        }

                    }
                    else
                    {
                        // If the player is in multiplayer, request a spawn
                        // This will only work if NPCID.Sets.MPAllowedEnemies[type] is true, which we set in MinionBossBody
                        NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: type);
                    }
                }

            }
            if (target.type == NPCID.GolemHead)
            {
                Item.TurnToAir();
                Terraria.DataStructures.IEntitySource entitySource = null;
                Main.LocalPlayer.QuickSpawnItem(entitySource, ItemID.BrokenHeroSword);
                Item.shoot = ProjectileID.CrystalShard;
                Item.shoot = ProjectileID.CrystalShard;
                Item.shoot = ProjectileID.CrystalShard;
                Item.shoot = ProjectileID.CrystalShard;
                Item.shootSpeed = 10f;
                SoundEngine.PlaySound(sound.WithVolumeScale(4f).WithPitchOffset(0.8f), player.position);

                if (player.whoAmI == Main.myPlayer)
                {
                    // If the player using the item is the client
                    // (explicitely excluded serverside here)

                    int type = ModContent.NPCType<Elder>();

                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        if (!NPC.AnyNPCs(ModContent.NPCType<Elder>()))
                        {
                            // If the player is not in multiplayer, spawn directly
                            NPC.SpawnOnPlayer(player.whoAmI, type);
                        }

                    }
                    else
                    {
                        // If the player is in multiplayer, request a spawn
                        // This will only work if NPCID.Sets.MPAllowedEnemies[type] is true, which we set in MinionBossBody
                        NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: type);
                    }
                }

            }
            if (target.type == NPCID.GolemHeadFree)
            {
                Item.TurnToAir();
                Terraria.DataStructures.IEntitySource entitySource = null;
                Main.LocalPlayer.QuickSpawnItem(entitySource, ItemID.BrokenHeroSword);
                Item.shoot = ProjectileID.CrystalShard;
                Item.shoot = ProjectileID.CrystalShard;
                Item.shoot = ProjectileID.CrystalShard;
                Item.shoot = ProjectileID.CrystalShard;
                Item.shootSpeed = 10f;
                SoundEngine.PlaySound(sound.WithVolumeScale(4f).WithPitchOffset(0.8f), player.position);

                if (player.whoAmI == Main.myPlayer)
                {
                    // If the player using the item is the client
                    // (explicitely excluded serverside here)

                    int type = ModContent.NPCType<Elder>();

                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        if (!NPC.AnyNPCs(ModContent.NPCType<Elder>()))
                        {
                            // If the player is not in multiplayer, spawn directly
                            NPC.SpawnOnPlayer(player.whoAmI, type);
                        }

                    }
                    else
                    {
                        // If the player is in multiplayer, request a spawn
                        // This will only work if NPCID.Sets.MPAllowedEnemies[type] is true, which we set in MinionBossBody
                        NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: type);
                    }
                }

            }
            if (target.type == NPCID.GolemFistLeft)
            {
                Item.TurnToAir();
                Terraria.DataStructures.IEntitySource entitySource = null;
                Main.LocalPlayer.QuickSpawnItem(entitySource, ItemID.BrokenHeroSword);
                Item.shoot = ProjectileID.CrystalShard;
                Item.shoot = ProjectileID.CrystalShard;
                Item.shoot = ProjectileID.CrystalShard;
                Item.shoot = ProjectileID.CrystalShard;
                Item.shootSpeed = 10f;
                SoundEngine.PlaySound(sound.WithVolumeScale(4f).WithPitchOffset(0.8f), player.position);

                if (player.whoAmI == Main.myPlayer)
                {
                    // If the player using the item is the client
                    // (explicitely excluded serverside here)

                    int type = ModContent.NPCType<Elder>();

                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        if (!NPC.AnyNPCs(ModContent.NPCType<Elder>()))
                        {
                            // If the player is not in multiplayer, spawn directly
                            NPC.SpawnOnPlayer(player.whoAmI, type);
                        }

                    }
                    else
                    {
                        // If the player is in multiplayer, request a spawn
                        // This will only work if NPCID.Sets.MPAllowedEnemies[type] is true, which we set in MinionBossBody
                        NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: type);
                    }
                }

            }
            if (target.type == NPCID.GolemFistRight)
            {
                Item.TurnToAir();
                Terraria.DataStructures.IEntitySource entitySource = null;
                Main.LocalPlayer.QuickSpawnItem(entitySource, ItemID.BrokenHeroSword);
                Item.shoot = ProjectileID.CrystalShard;
                Item.shoot = ProjectileID.CrystalShard;
                Item.shoot = ProjectileID.CrystalShard;
                Item.shoot = ProjectileID.CrystalShard;
                Item.shootSpeed = 10f;
                SoundEngine.PlaySound(sound.WithVolumeScale(4f).WithPitchOffset(0.8f), player.position);

                if (player.whoAmI == Main.myPlayer)
                {
                    int type = ModContent.NPCType<Elder>();

                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        if (!NPC.AnyNPCs(ModContent.NPCType<Elder>()))
                        {
                            // If the player is not in multiplayer, spawn directly
                            NPC.SpawnOnPlayer(player.whoAmI, type);
                        }
                    }
                    else
                    {
                        // If the player is in multiplayer, request a spawn
                        // This will only work if NPCID.Sets.MPAllowedEnemies[type] is true, which we set in MinionBossBody
                        NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: type);
                    }
                }

            }
        }

        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddIngredient(ItemID.HellstoneBar, 15);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.HallowedBar, 20);
            recipe1.AddIngredient(ItemID.PlatinumBar, 10);
            recipe1.AddIngredient(ItemID.HellstoneBar, 15);
            recipe1.AddIngredient(ItemID.SoulofSight, 5);
            recipe1.AddIngredient(ItemID.SoulofMight, 5);
            recipe1.AddIngredient(ItemID.SoulofFright, 5);
            recipe1.AddTile(TileID.MythrilAnvil);
            recipe1.Register();
        }
	}
}