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
        public Character Self;

        /// <summary>
        /// Construtor da classe Cleric
        /// </summary>
        public Cleric(Character Self)
        {
            this.Self = Self;
            HitDice();
            Self.Action.Add("Heal", new Action(Heal));
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
        /// Aumenta 1 lvl de <see cref="Cleric"/> no personagem
        /// </summary>
        /// <param name="Self"></param>
        public void LvlUp()
        {
            Self.Hpmax += RollHitDice() + Self.Modifier("CON");
            if(Self.Lvl == 4)
                Self.Action.Add("Smite", new Action(Smite));

        }
        public int RollHitDice()
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }

        public void Smite()
        {
            Self.Target.ReceiveDmg(0, "Radiant");
        }

        public void Heal()
        {
            Self.Target.Hp += 1;
            if (Self.Target.Hp > Self.Target.Hpmax)
                Self.Target.Hp = Self.Target.Hpmax;
        }
    }
}

