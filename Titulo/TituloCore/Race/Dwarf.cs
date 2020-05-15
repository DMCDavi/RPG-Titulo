using System;
using System.Collections.Generic;
using System.Text;

namespace Titulo
{
    public class Dwarf : IRace
    {
        public void AtributeInc(Personagem Self)
        {
            Self.Atribute["STR"] -= 2;
            Self.Atribute["DEX"] += 1;
            Self.Atribute["CON"] += 1;
            Self.Atribute["INT"] += 2;
            Self.Atribute["WIS"] += 1;
            Self.Atribute["CHA"] += 2;
        }

        public void Language(Personagem Self)
        {
            Self.LearnLang("Common");
            Self.LearnLang("Dwarf");
        }

        public void Speed(Personagem Self)
        {
            Self.TotalMove = 6;
        }
    }
}
