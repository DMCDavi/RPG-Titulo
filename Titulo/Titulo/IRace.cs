using System;
using System.Collections.Generic;
using System.Text;

namespace Titulo
{
    interface IRace
    {
        public virtual void SetRace(Personagem Self, string Race)
        {
            if(Race == "Human")
            {
                //Linguagem
                Self.Languages.Add("Common");
                Console.WriteLine("Escolha um idioma para aprender");
                Console.ReadLine();
                //Modificando atributos
                Self.Atributos["STR"]++;
                Self.Atributos["DEX"]++;
                Self.Atributos["CON"]++;
                Self.Atributos["INT"]++;
                Self.Atributos["WIS"]++;
                Self.Atributos["CHA"]++;
            }
        }
    }
}
