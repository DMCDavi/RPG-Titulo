using System;
using System.Collections.Generic;
using System.Text;

namespace Titulo
{
    class Elf : IRace
    {
        public void AtributeInc(Personagem Self)
        {
            Self.Atributos["STR"] -= 2;
            Self.Atributos["DEX"] += 1;
            Self.Atributos["CON"] += 1;
            Self.Atributos["INT"] += 2;
            Self.Atributos["WIS"] += 1;
            Self.Atributos["CHA"] += 2;
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
