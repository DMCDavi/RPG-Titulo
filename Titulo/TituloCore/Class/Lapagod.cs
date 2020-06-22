using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Lapagod")]
    public class Lapagod : IClass
    {
        public Character Self;
        public Lapagod(Character Self)
        {
            this.Self = Self;
            HitDice();
        }
        public void HitDice()
        {
            Self.HitDice = 20;
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

        public void AddActions(Character Self)
        {
            this.Self = Self;
        }
    }
}
