using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Assassin")]
    public class Assassin : IClass
    {
        public int AssassinLvl;

        /// <summary>
        /// Construtor da classe Mage
        /// </summary>
        public Assassin(Character Self)
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
        /// Aumenta 1 lvl de <see cref="Assassin"/> no personagem
        /// </summary>
        /// <param name="Self"></param>
        public void LvlUp(Character Self)
        {
            Self.Lvl++;
            AssassinLvl++;

            Self.Hpmax += RollHitDice(Self) + Self.Modifier("CON");
        }

        public int RollHitDice(Character Self)
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }

        public void LethalBlow(Character Self, Character Target)
        {

            if(Target.Hp<Self.Lvl*5)
            {
                Target.ReceiveDmg(10, Self.EquippedWeapon.Atributo);
            }
        }
    }
}
