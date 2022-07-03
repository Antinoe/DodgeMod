using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace DodgeMod
{
	public class DodgeMod : Mod
	{
		public static ModKeybind Dodge;
		
        public override void Load()
        {
            Dodge = KeybindLoader.RegisterKeybind(this, "Dodge", "LeftControl");
        }
        
        public override void Unload()
        {
            Dodge = null;
        }
    }
}
