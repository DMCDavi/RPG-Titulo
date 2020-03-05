using System;
using System.Collections.Generic;
using System.Text;

namespace Titulo
{
    class Vagner : IPersona
    {
        public void AtributeInc(Personagem Self)
        {
            Self.Atributos["STR"] += 0;
            Self.Atributos["DEX"] += 0;
            Self.Atributos["CON"] += 0;
            Self.Atributos["INT"] += 0;
            Self.Atributos["WIS"] += 0;
            Self.Atributos["CHA"] += 0;
        }
    }
}
