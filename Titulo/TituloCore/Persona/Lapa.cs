using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
    public class Lapa : IPersona
    {
        public int[] CorrectAnswers = new int[10] { 4, 5, 4, 6, 3, 2, 6, 3, 4, 3 };
        private int PersonalityPoint = 0;
        public string Name = "Lapa";
        public void AtributeInc(Character Self)
        {
            Self.Atribute["STR"] = 20;
            Self.Atribute["DEX"] = 20;
            Self.Atribute["CON"] = 20;
            Self.Atribute["INT"] = 20;
            Self.Atribute["WIS"] = 20;
            Self.Atribute["CHA"] = 20;
        }


        public int PersonalityPoints()
        {
            return PersonalityPoint;
        }

        public int PersonalityChoice(int num_pergunta)
        {
            return CorrectAnswers[num_pergunta - 1];
        }

        public void IncrementPersonalityPoints()
        {
            PersonalityPoint++;
        }

        public void PersonaModify(Character Self)
        {
            Self.TotalMove += 0;
        }

        public string PersonaName()
        {
            return Name;
        }
    }
}
