using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore.Class
{
    class Lapagod : IClass
    {
        public Lapagod(Character Self)
        {

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
    }
}
