using System;
using System.Collections.Generic;
using System.Text;

namespace Titulo
{
    class Orc : IRace
    {
        public void AtributeInc(Personagem Self)
        {
            Self.Atributos["STR"] += 3;
            Self.Atributos["DEX"] += 1;
            Self.Atributos["CON"] += 2;
            Self.Atributos["INT"] -= 3;
            Self.Atributos["WIS"] += 1;
            Self.Atributos["CHA"] -= 2;
        }

        public void Language(Personagem Self)
        {
            Self.Languages.Add("Common");
            Self.Languages.Add("Orc");
        }

        public void Speed(Personagem Self)
        {
            Self.TotalMove = 7;
        }
    }
}
