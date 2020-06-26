using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
	public class HealingPot : Consumable
	{
		public HealingPot(int Value, String Name)
		{
			this.Value = Value;
			this.Name = Name;
		}
		public override void Use(Character Target)
		{
			Target.Hp += Value;
			if (Target.Hp > Target.Hpmax) Target.Hp = Target.Hpmax;
			this.Drop(Target);
		}
	}
}
