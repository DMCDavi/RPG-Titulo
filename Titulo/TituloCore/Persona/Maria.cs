using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
    public class Maria : IPersona
    {
        //vetor que guarda as respostas corretas para cara pergunta, sendo que cada pergunta está representada pelo indice do vetor
        public int[] CorrectAnswers = new int[10] { 4, 4, 3, 5, 3, 1, 4, 4, 4, 2 };
        private int PersonalityPoint = 0;
        public void AtributeInc(Character Self)
        {
            Self.Atribute["STR"] += 2;
            Self.Atribute["DEX"] -= 3;
            Self.Atribute["CON"] += 5;
            Self.Atribute["INT"] += 3;
            Self.Atribute["WIS"] += 1;
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
