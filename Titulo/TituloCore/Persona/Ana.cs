using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
    public class Ana : IPersona
    {
        //vetor que guarda as respostas corretas para cara pergunta, sendo que cada pergunta está representada pelo indice do vetor
        public int[] CorrectAnswers = new int[10] { 4, 5, 4, 6, 3, 2, 6, 3, 4, 3 };
        private int PersonalityPoint = 0;
        public void AtributeInc(Character Self)
        {
            Self.Atribute["STR"] += 3;
            Self.Atribute["DEX"] += 3;
            Self.Atribute["CON"] += 3;
            Self.Atribute["INT"] += 5;
            Self.Atribute["WIS"] += 1;
            Self.Atribute["CHA"] += 10;
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
