using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContract(Name = "Armor", Namespace = "http://www.contoso.com")]
    public class Armor : Equipment
    {
        [DataMember]
        int BaseAc;
        [DataMember]
        int MaxDex;
        [DataMember]
        int MinDex;
        [DataMember]
        int DexBonus;
        //int MagicBonus = 0;

        /// <summary>
        /// Construtor da classe armor
        /// </summary>
        /// <param name="BaseAc">Valor base de Ac</param>
        /// <param name="MaxDex">Máximo modificador de dextreza</param>
        /// <param name="MinDex">Menor modificador de dextreza</param>
        /// <param name="Owner"></param>
        public Armor(int BaseAc, int MaxDex, int MinDex, string Name)
        {
            this.Name = Name;
            this.BaseAc = BaseAc;
            this.MaxDex = MaxDex;
            this.MinDex = MinDex;
        }

        public override void Equip(Character Owner)
        {
            if (this.Owner == null)
                this.Owner = Owner;
            if (Owner.EquippedArmor != null)
                Owner.EquippedArmor.Unequip();
            Owner.EquippedArmor = this;
            Owner.Inventory.Remove(this);

            DexBonus = Owner.Modifier("DEX");
            if (DexBonus > MaxDex)
                DexBonus = MaxDex;
            if (DexBonus < MinDex)
                DexBonus = MinDex;
            //MagicPassive();
        }

        public override void Unequip()
        {
            if (this.Owner != null)
            {
                Owner.EquippedArmor = null;
                Owner.Inventory.Add(this);
            }
            else
                Console.WriteLine("Erro: Equipamento sem dono");
        }

        public int Ac()
        {
            return BaseAc + DexBonus;
        }

        /*   
        public void MagicPassive()
        {

        }
        */
    }
}
