using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Berserker")]
    public class Berserker : IClass
    {
        public Berserker(Character Self)
        {
            HitDice(Self);
            Self.NaturalArmor = new Armor ( 10+Self.Modifier("CON"), 10, -10);
        }

        public void HitDice(Character Self)
        {
            Self.HitDice = 12;
        }

        public void LvlUp(Character Self)
        {
            Self.Hpmax += RollHitDice(Self) + Self.Modifier("CON");
            Self.ClassDmgDices.Add(4);
        }

        public int RollHitDice(Character Self)
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }
    }
}
