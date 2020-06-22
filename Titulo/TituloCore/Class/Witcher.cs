using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Witcher")]
    public class Witcher : IClass
    {
        public Character Self;
        public Witcher(Character Self)
        {
            this.Self = Self;
            HitDice();
            Self.Action.Add("Eldrich Blast", new Action(EldrichBlast));
        }
        public void HitDice()
        {
            Self.HitDice = 6;
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

        public void EldrichBlast()
        {
            Random rand = new Random();
            int Dice = 8;
            Self.Target.ReceiveDmg(1 + rand.Next() % Dice + Self.Modifier("CHA"), "Energy");
        }

        public void AddActions(Character Self)
        {
            this.Self = Self;
            Self.Action.Add("Eldrich Blast", new Action(EldrichBlast));
        }

    }
}
