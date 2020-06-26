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

		public override void Use(Character User)
		{
			User.Target.Hp -= Value;
			if (User.Target.Hp < 0) User.Target.Hp = 0;
			this.Drop(User);
		}
	}
}
