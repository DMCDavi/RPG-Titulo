using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
    public class Mage : IClass
    {
        public int MageLvl;

        /// <summary>
        /// Construtor da classe Mage
        /// </summary>
        public Mage()
        {
            MageLvl = 1;
        }

        /// <summary>
        /// Retorna o lvl de mage
        /// </summary>
        /// <returns></returns>
        public int ClassLvl()
        {
            return MageLvl;
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
            Self.HitDice = 6;
        }

        /// <summary>
        /// Aumenta 1 lvl de <see cref="Mage"/> no personagem
        /// </summary>
        /// <param name="Self"></param>
        public void LvlUp(Character Self)
        {
            Self.Lvl++;
            MageLvl++;
            Random HitDice = new Random();
            Console.Clear(); ;
            int Result = 1 + HitDice.Next() % 20;
            Self.Hpmax += Result + Self.Modifier("CON");
            Self.Hp += Result + Self.Modifier("CON");
        }
    }
}
