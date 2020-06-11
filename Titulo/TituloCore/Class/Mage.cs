using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Mage")]
    public class Mage : IClass
    {
        public Character Self;
        public int MageLvl;

        /// <summary>
        /// Construtor da classe Mage
        /// </summary>
        public Mage(Character Self)
        {
            this.Self = Self;
            HitDice();
        }


        /// <summary>
        /// Define o HitDice do personagem caso essa seja sua classe principal
        /// </summary>
        /// <param name="Self"></param>
        public void HitDice()
        {
            Self.HitDice = 6;
        }

        /// <summary>
        /// Aumenta 1 lvl de <see cref="Mage"/> no personagem
        /// </summary>
        /// <param name="Self"></param>
        public void LvlUp()
        {
            Self.Hpmax += RollHitDice() + Self.Modifier("CON");
        }
        public int RollHitDice()
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }

        public void Bolt(Character Target)
        {
            Target.Hp += Self.Modifier("INT");
            if (Target.Hp > Target.Hpmax)
                Target.Hp = Target.Hpmax;
            Self.ReceiveDmg(Self.Modifier("INT"), "Necrotic");
        }
        public void Storm(Character Target)
        {
            Target.Hp += 10*Self.Modifier("INT");
            if (Target.Hp > Target.Hpmax)
                Target.Hp = Target.Hpmax;
            Self.ReceiveDmg(10*Self.Modifier("INT"), "Necrotic");
        }
    }
}
