using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Warrior")]
    public class Warrior : IClass
    {
        public Character Self;
        /// <summary>
        /// Construtor da classe Mage
        /// </summary>
        public Warrior(Character Self)
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
            Self.HitDice = 10;
        }

        /// <summary>
        /// Aumenta 1 lvl de <see cref="Warrior"/> no personagem
        /// </summary>
        /// <param name="Self"></param>
        public void LvlUp()
        {
            Self.Hpmax += RollHitDice() + Self.Modifier("CON");
            if (Self.Lvl == 3)
                Self.CritRange = 19;
            if(Self.Lvl == 4)
                Self.Action.Add("Action Surge", new Action<Character>(ActionSurge));
        }
        public int RollHitDice()
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }
        
        public void SecondWind()
        {
            Self.Hp += new Random().Next() % 10 + 1 + Self.Lvl;
        }

        public void ActionSurge(Character Target)
        {
            Self.Attack();
            Self.Attack();
        }

        public void AddActions(Character Self)
        {
            this.Self = Self;
            Self.Action.Add("Second Wind", new Action(SecondWind));
            if (Self.Lvl >= 4)
                Self.Action.Add("Action Surge", new Action<Character>(ActionSurge));
        }

        /// <summary>
        /// Insere as Ações Bônus após serialização
        /// </summary>
        public void AddBonusActions()
        {

        }
    }
}

