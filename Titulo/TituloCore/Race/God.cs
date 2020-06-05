using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore.Race
{
    public class God : IRace
    {
        public void AtributeInc(Character Self)
        {
            Self.Atribute["STR"] -= 2;
            Self.Atribute["DEX"] += 1;
            Self.Atribute["CON"] += 1;
            Self.Atribute["INT"] += 2;
            Self.Atribute["WIS"] += 1;
            Self.Atribute["CHA"] += 2;
        }

        public void Language(Character Self)
        {
            Self.LearnLang("Todas");
            Self.LearnLang("God");
        }

        public void Speed(Character Self)
        {
            Self.TotalMove = 6;
        }
    }
}
