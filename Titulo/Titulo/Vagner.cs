using System;
using System.Collections.Generic;
using System.Text;

namespace Titulo
{
    class Vagner : IPersona
    {
        public void AtributeInc(Personagem Self)
        {
            Self.Atributos["STR"] += 2;
            Self.Atributos["DEX"] -= 3;
            Self.Atributos["CON"] += 5;
            Self.Atributos["INT"] += 3;
            Self.Atributos["WIS"] += 1;
            Self.Atributos["CHA"] -= 3;
        }

        public void PersonaModify(Personagem Self)
        {
            Self.TotalMove += 0;

        }

        public void SetSpritePersona(Personagem Self)
        {
            Self.SpritePath = "Sprite/Vagner/";
        }
    }
}
