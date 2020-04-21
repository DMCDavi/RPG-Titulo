using System;
using System.Collections.Generic;
using System.Text;

namespace Titulo
{
    class Tank : IClass // Ruler
    {
        public Boolean secret;
        public int TankLvl;

        /// <summary>
        /// Construtor da classe Tank
        /// </summary>
        public Tank()
        {
            TankLvl = 1;
            secret = false;
        }

        /// <summary>
        /// Retorna o lvl de Tank
        /// </summary>
        /// <returns></returns>
        public int ClassLvl()
        {
            return TankLvl;
        }

        /// <summary>
        /// Confere se o personagem pode se tornar Tank por multi classe
        /// </summary>
        /// <param name="Self"></param>
        /// <returns></returns>
        public bool CanBe(Personagem Self)
        {
            if(Self.Atribute["CON"] >= 13)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Define o HitDice do personagem caso essa seja sua classe principal
        /// </summary>
        /// <param name="Self"></param>
        public void HitDice(Personagem Self)
        {
            Self.HitDice = 20;
        }

        /// <summary>
        /// Aumenta 1 lvl de <see cref="Tank"/> no personagem
        /// </summary>
        /// <param name="Self"></param>
        public void LvlUp(Personagem Self)
        {
            Self.Lvl++;
            TankLvl++;
            Random HitDice = new Random();
            Console.Clear(); ;
            int Result = 1 + HitDice.Next()%20;
            Self.Hpmax += Result + Self.Modifier("CON");
            Self.Hp += Result + Self.Modifier("CON");
        }
        public void ReceiveDmg(Personagem Self, int dmg)
        {
            dmg -= Self.Modifier("CON");
            if(dmg <= 0)
            {
                dmg = 1;
            }
        }
    }
}
