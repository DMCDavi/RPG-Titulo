using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
    public class David : IPersona
    {
        //vetor que guarda as respostas corretas para cara pergunta, sendo que cada pergunta está representada pelo indice do vetor
        public int[] CorrectAnswers = new int[10] { 1, 2, 2, 1, 5, 2, 1, 3, 2, 4 };
        private int PersonalityPoint = 0;
        public void AtributeInc(Character Self)
        {
            Self.Atribute["STR"] += 3;
            Self.Atribute["DEX"] += 2;
            Self.Atribute["CON"] += 1;
            Self.Atribute["INT"] -= 1;
            Self.Atribute["WIS"] -= 2;
            Self.Atribute["CHA"] -= 3;
        }

        public void PersonaModify(Character Self)
        {
            Self.TotalMove += 0;

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
    }
}
