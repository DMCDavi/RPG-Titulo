using System;
using System.Collections.Generic;
using System.Text;

namespace Titulo
{
    class Elf : IRace
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
            Self.Languages.Add("Common");
            Self.Languages.Add("Elf");
        }

        public void Speed(Personagem Self)
        {
            Self.TotalMove = 6;
        }
    }
}
