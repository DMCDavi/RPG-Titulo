using System;
using System.Collections.Generic;
using System.Text;

namespace Titulo
{
    class Human : IRace
    {
        public void AtributeInc(Personagem Self)
        {
            Self.Atribute["STR"] += 1;
            Self.Atribute["DEX"] += 1;
            Self.Atribute["CON"] += 1;
            Self.Atribute["INT"] += 1;
            Self.Atribute["WIS"] += 1;
            Self.Atribute["CHA"] += 1;
        }

        public void Language(Personagem Self)
        {
            Self.Languages.Add("Common");
            string Language;
            Console.WriteLine("Escolha um idioma");
            Language = Console.ReadLine();
            Self.Languages.Add(Language);
        }

        public void Speed(Personagem Self)
        {
            Self.TotalMove = 6;
        }
    }
}
