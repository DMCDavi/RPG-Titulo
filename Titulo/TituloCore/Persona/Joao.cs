using System;
using System.Collections.Generic;
using System.Text;

namespace Titulo
{
    class Joao : IPersona
    {
        public void AtributeInc(Personagem Self)
        {
            Self.Atribute["STR"] += 10;
            Self.Atribute["DEX"] -= 1;
            Self.Atribute["CON"] += 10;
            Self.Atribute["INT"] += 10;
            Self.Atribute["WIS"] += 10;
            Self.Atribute["CHA"] -= 1;
        }

        public void PersonaModify(Personagem Self)
        {
            Self.TotalMove += 0;

        }

        public void SetSpritePersona(Personagem Self)
        {
            Self.SpritePath = "Sprite/Joao/";
        }
    }
}
