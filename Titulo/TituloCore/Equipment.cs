using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TituloCore
{
	[DataContract(Name = "Equipment", Namespace = "http://www.contoso.com")]
	public abstract class Equipment : Item
	{
		public abstract void Equip(Character Owner);
		public abstract void Unequip();
    }
}
