using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TituloCore
{
	[DataContract(Name = "Consumable", Namespace = "http://www.contoso.com")]
	public abstract class Consumable : Item
	{
		public int Value;
		public abstract void Use(Character Target);
	}
}
