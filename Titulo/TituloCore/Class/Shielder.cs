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
            Self.Action.Add("Colossus Vengeance", new Action<Character>(ColossusVengeance));
        }
        public void HitDice()
        {
            Self.HitDice = 20;
        }

        public void LvlUp()
        {
            Self.Hpmax += RollHitDice() + Self.Modifier("CON");

            if(Self.Lvl == 4)
                Self.Action.Add("Blood Sacrifice", new Action<Character>(BloodSacrifice));
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
        public void ColossusVengeance(Character Target)
        {
            Self.Attack();
            Target.ReceiveDmg((Self.Hpmax - Self.Hp) / 2, "Necrotic");
        }
    }
}
