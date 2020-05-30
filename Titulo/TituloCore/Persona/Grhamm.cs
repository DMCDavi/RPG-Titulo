﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Titulo
{
    public class Grhamm : IPersona
    {
        //vetor que guarda as respostas corretas para cara pergunta, sendo que cada pergunta está representada pelo indice do vetor
        public int[] CorrectAnswers = new int[10] { 6, 1, 4, 3, 3, 2, 3, 2, 1, 3 };
        private int PersonalityPoint = 0;
        public string Name = "Grhamm";
        public void AtributeInc(Personagem Self)
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
            Self.SpritePath = "Sprite/Grhamm/";
        }
    }
}
