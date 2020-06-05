using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
    public class Goliath : IRace
    {
        public void AtributeInc(Character Self)
        {
            Self.Atribute["STR"] += 3;
            Self.Atribute["DEX"] += 0;
            Self.Atribute["CON"] += 2;
            Self.Atribute["INT"] += 0;
            Self.Atribute["WIS"] += 1;
            Self.Atribute["CHA"] += 0;
        }

        public void Language(Character Self)
        {
            Self.LearnLang("Common");
            Self.LearnLang("Goliath");
        }

        public void Speed(Character Self)
        {
            Self.TotalMove = 6;
        }
    }
}
