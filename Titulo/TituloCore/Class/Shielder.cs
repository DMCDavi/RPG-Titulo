using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Shielder")]
    public class Shielder : IClass
    {
        public Shielder(Character Self)
        {
            HitDice(Self);
        }
        public void HitDice(Character Self)
        {
            Self.HitDice = 20;
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

        public void BloodSacrifice(Character Self, Character Target)
        {
            Random rand = new Random();
            int dmg = Self.Hpmax * (1 + rand.Next()%20)/20;
            Target.ReceiveDmg(dmg, "Necrotic");
            if (dmg >= Self.Hp)
                dmg = Self.Hp-1;
            Self.ReceiveDmg(dmg, "Necrotic");
        }
        public void TitanVengeance(Character Self, Character Target)
        {
            Self.Attack(Target);
            Target.ReceiveDmg((Self.Hpmax - Self.Hp) / 2, "Necrotic");
        }
    }
}
