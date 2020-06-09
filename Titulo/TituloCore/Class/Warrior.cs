using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Warrior")]
    public class Warrior : IClass
    {

        /// <summary>
        /// Construtor da classe Mage
        /// </summary>
        public Warrior(Character Self)
        {
            HitDice(Self);
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
        /// Aumenta 1 lvl de <see cref="Warrior"/> no personagem
        /// </summary>
        /// <param name="Self"></param>
        public void LvlUp(Character Self)
        {
            Self.Hpmax += RollHitDice(Self) + Self.Modifier("CON");
            if (Self.Lvl == 3)
                Self.CritRange = 19;

        }
        public int RollHitDice(Character Self)
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }
        
        public void SecondWind(Character Self)
        {
            Self.Hp += new Random().Next() % 10 + 1 + Self.Lvl;
        }

        public void ActionSurge(Character Self, Character Target)
        {
            Self.Attack(Target);
            Self.Attack(Target);
        }
    }
}

