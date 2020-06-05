using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
    public class Dragonborn : IRace
    {
        public void AtributeInc(Character Self)
        {
            Self.Atribute["STR"] += 2;
            Self.Atribute["DEX"] += 0;
            Self.Atribute["CON"] += 1;
            Self.Atribute["INT"] += 0;
            Self.Atribute["WIS"] += 0;
            Self.Atribute["CHA"] += 2;
        }

        public void Language(Character Self)
        {
            Self.LearnLang("Common");
            Self.LearnLang("Dragonborn");
        }

        public void Speed(Character Self)
        {
            Self.TotalMove = 6;
        }
    }
}
