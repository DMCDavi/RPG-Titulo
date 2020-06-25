using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore.Items
{
	class DamagingPot : Consumable
	{
		public DamagingPot(int Value)
		{
			this.Value = Value;
		}

		public override void Use(Character Target)
		{
			Target.Hp -= Value;
			if (Target.Hp < 0) Target.Hp = 0;
		}
	}
}
