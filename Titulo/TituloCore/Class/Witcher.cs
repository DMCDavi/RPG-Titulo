using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Witcher")]
    public class Witcher : IClass
    {
        public Witcher(Character Self)
        {
            HitDice(Self);
        }
        public void HitDice(Character Self)
        {
            Self.HitDice = 6;
        }

        public void LvlUp(Character Self)
        {
            Self.Hpmax += RollHitDice(Self) + Self.Modifier("CON");

        }
        public int RollHitDice(Character Self)
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }

        public void EldrichBlast(Character Self, Character Target)
        {
            Random rand = new Random();
            int Dice = 8;
            Target.ReceiveDmg(1 + rand.Next() % Dice + Self.Modifier("CHA"), "Energy");
        }
    }
}
