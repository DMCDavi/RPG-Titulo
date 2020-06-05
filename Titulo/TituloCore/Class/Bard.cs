using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
    public class Bard : IClass
    {
        public int BardLvl;

        /// <summary>
        /// Construtor da classe Bard
        /// </summary>
        public Bard(Character Self)
        {
            HitDice(Self);
        }

        /// <summary>
        /// Retorna o lvl de mage
        /// </summary>
        /// <returns></returns>
        public int ClassLvl()
        {
            return BardLvl;
        }


        /// <summary>
        /// Define o HitDice do personagem caso essa seja sua classe principal
        /// </summary>
        /// <param name="Self"></param>
        public void HitDice(Character Self)
        {
            Self.HitDice = 10;
        }

        /// <summary>
        /// Aumenta 1 lvl de <see cref="Bard"/> no personagem
        /// </summary>
        /// <param name="Self"></param>
        public void LvlUp(Character Self)
        {
            Self.Lvl++;
            BardLvl++;

            Self.Hpmax += RollHitDice(Self) + Self.Modifier("CON");
        }

        public int RollHitDice(Character Self)
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }
    }
}
