using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Audio;

namespace DodgeMod
{
    public class DodgePlayer : ModPlayer
    {
		public static DodgePlayer ModPlayer(Player Player)
		{
			return Player.GetModPlayer<DodgePlayer>();
		}
		
		//Sounds.
		//Question: Why declare the audio like this?
		//Answer: A simple step in Code Optimization. If we were to declare this sound many times over in different places, it would get messy very quickly.
		public static readonly SoundStyle DodgeOnGround = new SoundStyle("DodgeMod/Sounds/DodgeOnGround");
		public static readonly SoundStyle DodgeInAir = new SoundStyle("DodgeMod/Sounds/DodgeInAir");
		
		//Thank you for the remastered code, Scooterboot.
		int dodgeCooldown = 0; //Cooldown before the Player can Dodge again.
		int dodgeTime = 0; //How long the Dodging effect lasts.
		public override void PostUpdate()
		{
			if (DodgeMod.Dodge.JustPressed && DodgeModConfig.Instance.enableDodging && dodgeCooldown <= 0)
			{
				int dodgeDirection = Player.direction; //Dodge Direction will be whichever direction the Player is facing.
				if (Player.controlRight)
				{
						dodgeDirection = 1;
				}
				else if (Player.controlLeft)
				{
						dodgeDirection = -1;
				}
				
				if (!Player.mount.Active && Player.statMana >= Player.statManaMax / DodgeModConfig.Instance.dodgeManaConsumptionMultiplicative + DodgeModConfig.Instance.dodgeManaConsumptionAdditive) //If the Player isn't mounted, and Mana is greater than or equal to the desired config option.
				{
					dodgeTime = DodgeModConfig.Instance.dodgeTime; //How long to Dodge for.
					dodgeCooldown = DodgeModConfig.Instance.dodgeCooldown; //Cooldown for Dodging.
					if (DodgeModConfig.Instance.enableDodgeManaConsumption)
					{
						Player.statMana -= Player.statManaMax / DodgeModConfig.Instance.dodgeManaConsumptionMultiplicative + DodgeModConfig.Instance.dodgeManaConsumptionAdditive;
					}
					if (Player.velocity.Y == 0) //Dodging on-ground.
					{
						Player.velocity.X += DodgeModConfig.Instance.dodgeVelocityGround * dodgeDirection;
						SoundEngine.PlaySound(DodgeOnGround, Player.position);
						if (Player.controlUp) //Dodging upward mid-air.
						{
							Player.velocity.Y -= DodgeModConfig.Instance.dodgeVelocityGroundVertical;
						}
					}
					else //Dodging mid-air.
					{
						Player.velocity.X += DodgeModConfig.Instance.dodgeVelocityAir * dodgeDirection;
						SoundEngine.PlaySound(DodgeInAir, Player.position);
						if (Player.controlUp) //Dodging upward mid-air.
						{
							Player.velocity.Y -= DodgeModConfig.Instance.dodgeVelocityAirVertical;
						}
					}
					
				}
			}
			
			if (dodgeCooldown > 0)
			{
				dodgeCooldown--;
				dodgeTime--;
			}
			
			if (dodgeTime > 0)
			{
				Player.delayUseItem = true;
				Player.immune = true;
				Player.immuneTime = dodgeTime; //As long as the Player is Dodging, they are Immune.
			}
		}
    }
}