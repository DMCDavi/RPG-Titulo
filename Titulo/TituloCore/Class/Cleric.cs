using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Cleric")]
    public class Cleric : IClass
    {
        public int ClericLvl;

        /// <summary>
        /// Construtor da classe Cleric
        /// </summary>
        public Cleric(Character Self)
        {
            HitDice(Self);
        }
        /// <summary>
        /// Retorna o lvl de mage
        /// </summary>
        /// <returns></returns>
        public int ClassLvl()
        {
            return ClericLvl;
        }

        /// <summary>
        /// Confere se o personagem pode se tornar mage por multi classe
        /// </summary>
        /// <param name="Self"></param>
        /// <returns></returns>
        public bool CanBe(Character Self)
        {
            if (Self.Atribute["INT"] >= 13)
                return true;
            return false;
        }

        /// <summary>
        /// Define o HitDice do personagem caso essa seja sua classe principal
        /// </summary>
        /// <param name="Self"></param>
        public void HitDice(Character Self)
        {
            ///
            Self.HitDice = 10;
        }

        /// <summary>
        /// Aumenta 1 lvl de <see cref="Cleric"/> no personagem
        /// </summary>
        /// <param name="Self"></param>
        public void LvlUp(Character Self)
        {
            Self.Hpmax += RollHitDice(Self) + Self.Modifier("CON");

        }
        public int RollHitDice(Character Self)
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }

        public void Will(Character Self, Character Target)
        {
            Target.ReceiveDmg(0, "Radiant");
        }

        public void Heal(Character Self, Character Target)
        {
            Target.Hp += 1;
            if (Target.Hp > Target.Hpmax)
                Target.Hp = Target.Hpmax;
        }
    }
}

