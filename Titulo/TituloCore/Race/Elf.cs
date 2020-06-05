using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
    public class Elf : IRace
    {
        public void AtributeInc(Character Self)
        {
            Self.Atribute["STR"] -= 2;
            Self.Atribute["DEX"] += 2;
            Self.Atribute["CON"] -= 2;
            Self.Atribute["INT"] += 3;
            Self.Atribute["WIS"] += 1;
            Self.Atribute["CHA"] += 0;
        }

        public void Language(Character Self)
        {
            Self.LearnLang("Common");
            Self.LearnLang("Elf");
        }

        public void Speed(Character Self)
        {
            Self.TotalMove = 6;
        }
    }
}
