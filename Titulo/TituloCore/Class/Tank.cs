using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
    public class Tank : IClass // Ruler
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
        /// Define o HitDice do personagem caso essa seja sua classe principal
        /// </summary>
        /// <param name="Self"></param>
        public void HitDice(Character Self)
        {
            Self.HitDice = 20;
        }

        /// <summary>
        /// Aumenta 1 lvl de <see cref="Tank"/> no personagem
        /// </summary>
        /// <param name="Self"></param>
        public void LvlUp(Character Self)
        {
            Self.Lvl++;
            TankLvl++;
            Random HitDice = new Random();
            Console.Clear(); ;
            int Result = 1 + HitDice.Next()%20;
            Self.Hpmax += Result + Self.Modifier("CON");
            Self.Hp += Result + Self.Modifier("CON");
        }
        public void ReceiveDmg(Character Self, int dmg)
        {
            dmg -= Self.Modifier("CON");
            if(dmg <= 0)
            {
                dmg = 1;
            }
        }

        public int RollHitDice(Character Self)
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }
    }
}
