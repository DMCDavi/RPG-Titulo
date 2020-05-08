using System;
using System.Collections.Generic;
using System.Text;

namespace Titulo
{
    class Ana : IPersona
    {
        public void AtributeInc(Personagem Self)
        {
            Self.Atribute["STR"] += 2;
            Self.Atribute["DEX"] -= 3;
            Self.Atribute["CON"] += 5;
            Self.Atribute["INT"] += 3;
            Self.Atribute["WIS"] += 1;
            Self.Atribute["CHA"] -= 3;
        }

        public void PersonaModify(Personagem Self)
        {
            Self.TotalMove += 0;

        }

        public void SetSpritePersona(Personagem Self)
        {
            Self.SpritePath = "Sprite/Ana/";
        }
    }
}
