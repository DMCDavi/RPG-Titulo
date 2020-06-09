using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContract(Name = "Armor", Namespace = "http://www.contoso.com")]
    public class Armor
    {
        int BaseAc;
        int MaxDex;
        int MinDex;
        Character Owner;
        int DexBonus;
        int MagicBonus = 0;

        /// <summary>
        /// Construtor da classe armor
        /// </summary>
        /// <param name="BaseAc">Valor base de Ac</param>
        /// <param name="MaxDex">Máximo modificador de dextreza</param>
        /// <param name="MinDex">Menor modificador de dextreza</param>
        /// <param name="Owner"></param>
        public Armor(int BaseAc, int MaxDex, int MinDex)
        {
            this.BaseAc = BaseAc;
            this.MaxDex = MaxDex;
            this.MinDex = MinDex;
        }

        public void Equip(Character Owner)
        {
            this.Owner = Owner;
            DexBonus = Owner.Modifier("DEX");
            if (DexBonus > MaxDex)
                DexBonus = MaxDex;
            if (DexBonus < MinDex)
                DexBonus = MinDex;
            //MagicPassive();
        }

        public void UnEquip()
        {
            Owner = null;
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
