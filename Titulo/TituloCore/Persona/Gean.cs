using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
    public class Gean : IPersona
    {
        //vetor que guarda as respostas corretas para cara pergunta, sendo que cada pergunta está representada pelo indice do vetor
        public int[] CorrectAnswers = new int[10] { 5, 4, 3, 4, 1, 2, 8, 2, 1, 1 };
        private int PersonalityPoint = 0;
        public void AtributeInc(Character Self)
        {
            Self.Atribute["STR"] += 4;
            Self.Atribute["DEX"] += 1;
            Self.Atribute["CON"] += 2;
            Self.Atribute["INT"] -= 1;
            Self.Atribute["WIS"] -= 2;
            Self.Atribute["CHA"] -= 3;
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

    }
}
