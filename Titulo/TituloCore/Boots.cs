﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TituloCore
{
	[DataContract(Name = "Boots", Namespace = "http://www.contoso.com")]
	public class Boots : Equipment
	{
		public int Speed;
		public Boots(int Speed)
		{
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
				Owner.TotalMove -= Speed;
			}
			else
				Console.WriteLine("Erro: Equipamento sem dono");
		}


		public void AddBonuses(Character Owner)
		{
			Owner.TotalMove += Speed;
		}
	}
}
