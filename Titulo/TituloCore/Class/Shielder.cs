using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Shielder")]
    public class Shielder : IClass
    {
        public Character Self;
        public Shielder(Character Self)
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

        public void BloodSacrifice(Character Target)
        {
            Random rand = new Random();
            int dmg = Self.Hpmax * (1 + rand.Next()%20)/20;
            Target.ReceiveDmg(dmg, "Necrotic");
            if (dmg >= Self.Hp)
                dmg = Self.Hp-1;
            Self.ReceiveDmg(dmg, "Necrotic");
        }
        public void TitanVengeance(Character Target)
        {
            Self.Attack(Target);
            Target.ReceiveDmg((Self.Hpmax - Self.Hp) / 2, "Necrotic");
        }
    }
}
