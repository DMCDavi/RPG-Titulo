using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
    public class Joao : IPersona
    {
        //vetor que guarda as respostas corretas para cara pergunta, sendo que cada pergunta está representada pelo indice do vetor
        public int[] CorrectAnswers = new int[10] { 3, 2, 5, 3, 4, 1, 2, 1, 5, 4 };
        private int PersonalityPoint = 0;
        public string Name = "Joao";
        public void AtributeInc(Personagem Self)
        {
            Self.Atribute["STR"] += 10;
            Self.Atribute["DEX"] -= 1;
            Self.Atribute["CON"] += 10;
            Self.Atribute["INT"] += 10;
            Self.Atribute["WIS"] += 10;
            Self.Atribute["CHA"] -= 1;
        }

        public int PersonalityPoints()
        {
            return PersonalityPoint;
        }

        public int PersonalityChoice(int num_pergunta)
        {
            return CorrectAnswers[num_pergunta - 1];
        }
        public string PersonaName()
        {
            return Name;
        }

        public void IncrementPersonalityPoints()
        {
            PersonalityPoint++;
        }

        public void PersonaModify(Personagem Self)
        {
            Self.TotalMove += 0;

        }

        public void SetSpritePersona(Personagem Self)
        {
            Self.SpritePath = "Sprite/Joao/";
        }
    }
}
