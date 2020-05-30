﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
    public class Warrior : IClass
    {
        public int WarriorLvl;

        /// <summary>
        /// Construtor da classe Mage
        /// </summary>
        public Warrior()
        {
            WarriorLvl = 1;
        }

        /// <summary>
        /// Retorna o lvl de mage
        /// </summary>
        /// <returns></returns>
        public int ClassLvl()
        {
            return WarriorLvl;
        }

        /// <summary>
        /// Confere se o personagem pode se tornar mage por multi classe
        /// </summary>
        /// <param name="Self"></param>
        /// <returns></returns>
        public bool CanBe(Personagem Self)
        {
            if (Self.Atribute["INT"] >= 13)
                return true;
            return false;
        }

        /// <summary>
        /// Define o HitDice do personagem caso essa seja sua classe principal
        /// </summary>
        /// <param name="Self"></param>
        public void HitDice(Personagem Self)
        {
            ///
            Self.HitDice = 10;
        }

        /// <summary>
        /// Aumenta 1 lvl de <see cref="Warrior"/> no personagem
        /// </summary>
        /// <param name="Self"></param>
        public void LvlUp(Personagem Self)
        {
            Self.Lvl++;
            WarriorLvl++;
            
            Random HitDice = new Random();
            Console.Clear(); ;
            int Result = 1 + HitDice.Next() % 20;
            Self.Hpmax += Result + Self.Modifier("CON");
            Self.Hp += Result + Self.Modifier("CON");
        }
    }
}

