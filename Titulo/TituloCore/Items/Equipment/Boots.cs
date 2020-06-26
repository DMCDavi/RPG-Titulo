using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TituloCore
{
	[DataContract(Name = "Boots", Namespace = "http://www.contoso.com")]
	public class Boots : Equipment
	{
		[DataMember]
		public int Speed;
		public Boots(int Speed, string Name)
		{
			this.Name = Name;
			this.Speed = Speed;
		}
		public override void Equip(Character Owner)
		{
			if (this.Owner == null)
				this.Owner = Owner;
			if (Owner.EquippedBoots != null)
				Owner.EquippedBoots.Unequip();
			Owner.EquippedBoots = this;
			Owner.Inventory.Remove(this);
			AddBonuses(Owner);
		}

		public override void Unequip()
		{
			if (this.Owner != null)
			{
				Owner.EquippedBoots = null;
				Owner.Inventory.Add(this);
				Owner.TotalMove -= this.Speed;
			}
			else
				Console.WriteLine("Erro: Equipamento sem dono");
		}


		public void AddBonuses(Character Owner)
		{
			Owner.TotalMove += this.Speed;
		}
	}
}
