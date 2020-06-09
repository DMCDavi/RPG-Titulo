﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
    public interface IPersona
    {
        /// <summary>
        /// Busca e retorna a resposta correta para uma determinada pergunta do teste de personalidade
        /// </summary>
        /// <param name="index">Um número que representa a pergunta</param>
        /// <returns>Um número inteiro que representa o número da questão correta da Persona</returns>
        int PersonalityChoice(int index);
        /// <summary>
        /// Busca e retorna a quantidade de pontos de personalidade de Persona
        /// </summary>
        /// <returns>Um número inteiro que representa a quantidade de pontos de personalidade de Persona</returns>
        int PersonalityPoints();
        /// <summary>
        /// Aumenta em 1 a quantidade de pontos de personalidade que a Persona tem
        /// </summary>
        void IncrementPersonalityPoints();
        void AtributeInc(Character Self);
    }
}
