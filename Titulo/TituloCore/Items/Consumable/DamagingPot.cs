using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
	public class DamagingPot : Consumable
	{
		public DamagingPot(int Value, string Name)
		{
			this.Value = Value;
			this.Name = Name;
		}

		public override void Use(Character Target)
		{
			Target.Hp -= Value;
			if (Target.Hp < 0) Target.Hp = 0;
		}
	}
}
