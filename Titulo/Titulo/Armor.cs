using System;
using System.Collections.Generic;
using System.Text;

namespace Titulo
{
    public class Armor
    {
        int BaseAc;
        int MaxDex;
        int MinDex;
        Personagem Owner;
        int DexBonus;

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
            if (DexBonus > MaxDex)
                DexBonus = MaxDex;
            if (DexBonus < MinDex)
                DexBonus = MinDex;
        }

        public void Equip(Personagem Owner)
        {
            this.Owner = Owner;
            DexBonus = Owner.Modifier("DEX");
            MagicPassive();
        }

        public void UnEquip()
        {
            Owner = null;
        }

        public int Ac()
        {
            return BaseAc + DexBonus;
        }

        public void MagicPassive()
        {

        }
    }
}
