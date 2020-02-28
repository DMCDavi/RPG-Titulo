using System;
using System.Collections.Generic;
using System.Text;

namespace Titulo
{
    class Human : IRace
    {
        public void AtributeInc(Personagem Self)
        {
            Self.Atributos["STR"] += 1;
            Self.Atributos["DEX"] += 1;
            Self.Atributos["CON"] += 1;
            Self.Atributos["INT"] += 1;
            Self.Atributos["WIS"] += 1;
            Self.Atributos["CHA"] += 1;
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
