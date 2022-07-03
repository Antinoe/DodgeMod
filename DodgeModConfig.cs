using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace DodgeMod
{
    [Label("Server Config")]
    public class DodgeModConfig : ModConfig
    {
        //This is here for the Config to work at all.
        public override ConfigScope Mode => ConfigScope.ServerSide;
		
        public static DodgeModConfig Instance;
		
        [Header("General")]
		
        [Label("Enable Dodging")]
        [Tooltip("If false, Players cannot perform Dodges.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableDodging {get; set;}
		
        [Label("Dodge Time")]
        [Tooltip("How long Dodge Immunity lasts.\n[Default: 30]")]
        [Slider]
        [DefaultValue(30)]
        [Range(0, 40)]
        [Increment(5)]
        public int dodgeTime {get; set;}
		
        [Label("Dodge Cooldown")]
        [Tooltip("How long the Dodge Cooldown will be.\n[Default: 50]")]
        [Slider]
        [DefaultValue(50)]
        [Range(0, 100)]
        [Increment(5)]
        public int dodgeCooldown {get; set;}
		
        [Header("Mana Consumption")]
		
        [Label("Enable Dodge Mana Consumption")]
        [Tooltip("If false, Mana will not be drained upon Dodging.\n[Default: On]")]
        [DefaultValue(true)]
        public bool enableDodgeManaConsumption {get; set;}
		
        [Label("Dodge Mana Consumption (Multiplicative)")]
        [Tooltip("How much Mana to consume upon Dodging. (Higher values consume less.)\n[Default: 4]")]
        [Slider]
        [DefaultValue(4)]
        [Range(1, 10)]
        [Increment(1)]
        public int dodgeManaConsumptionMultiplicative {get; set;}
		
        [Label("Dodge Mana Consumption (Additive)")]
        [Tooltip("How much Mana to consume upon Dodging.\n[Default: 5]")]
        [Slider]
        [DefaultValue(5)]
        [Range(0, 100)]
        [Increment(5)]
        public int dodgeManaConsumptionAdditive {get; set;}
		
        [Header("Velocity")]
		
        [Label("Dodge Velocity (On Ground)")]
        [Tooltip("How strong Dodging will be on-ground.\n[Default: 5]")]
        [Slider]
        [DefaultValue(5)]
        [Range(0, 10)]
        [Increment(1)]
        public int dodgeVelocityGround {get; set;}
		
        [Label("Dodge Velocity (Mid Air)")]
        [Tooltip("How strong Dodging will be mid-air.\n[Default: 3]")]
        [Slider]
        [DefaultValue(3)]
        [Range(0, 10)]
        [Increment(1)]
        public int dodgeVelocityAir {get; set;}
		
        [Label("Dodge Velocity (Vertical, On Ground)")]
        [Tooltip("How strong Vertical Dodging will be on-ground.\n[Default: 0]")]
        [Slider]
        [DefaultValue(0)]
        [Range(0, 10)]
        [Increment(1)]
        public int dodgeVelocityGroundVertical {get; set;}
		
        [Label("Dodge Velocity (Vertical, Mid Air)")]
        [Tooltip("How strong Vertical Dodging will be mid-air.\n[Default: 0]")]
        [Slider]
        [DefaultValue(0)]
        [Range(0, 10)]
        [Increment(1)]
        public int dodgeVelocityAirVertical {get; set;}
    }
}