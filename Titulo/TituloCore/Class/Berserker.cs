using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Berserker")]
    public class Berserker : IClass
    {
        public Character Self;
        public Berserker(Character Self)
        {
            this.Self = Self;
            HitDice();
            Self.NaturalArmor = new Armor ( 10 + Self.Modifier("CON"), 10, -10);
            Self.Resist["Concussion"] = true;
            Self.Resist["Slash"] = true;
            Self.Resist["Piercing"] = true;
        }

        public void HitDice()
        {
            Self.HitDice = 12;
        }

        public void LvlUp()
        {
            Self.Hpmax += RollHitDice() + Self.Modifier("CON");
        }

        public int RollHitDice()
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }
    }
}
