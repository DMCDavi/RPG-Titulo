using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
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
    }
}
