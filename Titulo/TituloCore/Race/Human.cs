using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
    public class Human : IRace
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
            Self.LearnLang("Common");
            //string Language;
            //Console.WriteLine("Escolha um idioma");
            //Language = Console.ReadLine();
            //Self.LearnLang(Language);
        }

        public void Speed(Personagem Self)
        {
            Self.TotalMove = 6;
        }
    }
}
