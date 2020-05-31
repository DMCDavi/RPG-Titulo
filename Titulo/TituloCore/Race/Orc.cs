using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
    public class Orc : IRace
    {
        public void AtributeInc(Character Self)
        {
            Self.Atribute["STR"] += 3;
            Self.Atribute["DEX"] += 1;
            Self.Atribute["CON"] += 2;
            Self.Atribute["INT"] -= 3;
            Self.Atribute["WIS"] += 1;
            Self.Atribute["CHA"] -= 2;
        }

        public void Language(Character Self)
        {
            Self.LearnLang("Common");
            Self.LearnLang("Orc");
        }

        public void Speed(Character Self)
        {
            Self.TotalMove = 7;
        }
    }
}
