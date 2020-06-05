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
        public Mage(Character Self)
        {
            HitDice(Self);
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
            Self.Hpmax += RollHitDice(Self) + Self.Modifier("CON");

        }
        public int RollHitDice(Character Self)
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }
    }
}
