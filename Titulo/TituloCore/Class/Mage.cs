using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Mage")]
    public class Mage : IClass
    {
        public Character Self;
        public int MageLvl;

        /// <summary>
        /// Construtor da classe Mage
        /// </summary>
        public Mage(Character Self)
        {
            this.Self = Self;
            HitDice();
            Self.Action.Add("Element Bolt", new Action<Character>(ElementBolt));
        }


        /// <summary>
        /// Define o HitDice do personagem caso essa seja sua classe principal
        /// </summary>
        /// <param name="Self"></param>
        public void HitDice()
        {
            Self.HitDice = 6;
        }

        /// <summary>
        /// Aplica os efeitos da classe por passar de nível
        /// </summary>
        /// <param name="Self"></param>
        public void LvlUp()
        {
            Self.Hpmax += RollHitDice() + Self.Modifier("CON");
            if(Self.Lvl == 4)
                Self.Action.Add("Element Storm", new Action<Character>(ElementStorm));
        }
        public int RollHitDice()
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }

        public void ElementBolt(Character Target)
        {
            // Escolher elemento
            int dmg = 1 + new Random().Next() % 10 + Self.Modifier("INT");
            Target.ReceiveDmg(dmg, "Energy");
        }
        public void ElementStorm(Character Target)
        {
            // Escolher elemento
            Random rand = new Random();
            int dmg = 1 + rand.Next() % 10;
            for (int i = 0; i < Self.Lvl; i++)
            {
                dmg += 1 + rand.Next() % 8;
            }
            Target.ReceiveDmg(dmg, "Energy");
        }
    }
}
