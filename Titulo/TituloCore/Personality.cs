using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TituloCore
{
    public class Personality
    {
        private Ana ana = new Ana();
        private Bia bia = new Bia();
        private David davi = new David();
        private Fernanda fernanda = new Fernanda();
        private Gean gean = new Gean();
        private Grhamm grhamm = new Grhamm();
        private Joao joao = new Joao();
        private Maria maria = new Maria();
        private Vagner vagner = new Vagner();
        public Dictionary<string, IPersona> AllPersona { get; set; }
        public Personality()
        {
            AllPersona = new Dictionary<string, IPersona>
            {
                { "Ana", ana },
                { "Bia", bia },
                {"David", davi},
                {"Fernanda", fernanda},
                {"Gean", gean},
                {"Grhamm", grhamm},
                {"Joao", joao},
                {"Maria", maria},
                {"Vagner", vagner},

            };
        }

        /// <summary>
        /// Checa cada Persona para adicionar um ponto de personalidade naquelas que possuem as respostas certas para a pergunta em específico
        /// </summary>
        /// <param name="question">Um número inteiro que representa o número da pergunta</param>
        /// <param name="answer">Um número inteiro que representa o número da resposta para a pergunta</param>
        public void TestaPersona(int question, int answer)
        {
            //loop que checa cada Persona
            foreach (KeyValuePair<string, IPersona> persona in AllPersona)
                //Se o usuário escolheu a resposta correta da Persona, a pontuação de personalidade aumentará em 1
                if (persona.Value.PersonalityChoice(question) == answer)
                    persona.Value.IncrementPersonalityPoints();
        }

        /// <summary>
        /// Busca quem é o vencedor do teste de personalidade
        /// </summary>
        /// <returns>Uma string que representa o nome da Persona vencedora do teste de personalidade</returns>
        public string GetPersonalityWinner()
        {
            int maior_pontuacao = 0;
            //Busca a maior pontuação entre as Personas
            foreach (KeyValuePair<string, IPersona> persona in AllPersona)
                if (persona.Value.PersonalityPoints() > maior_pontuacao)
                    maior_pontuacao = persona.Value.PersonalityPoints();
            //Busca e retorna o nome da Persona com maior pontuação
            foreach (KeyValuePair<string, IPersona> persona in AllPersona)
                if (maior_pontuacao == persona.Value.PersonalityPoints())
                    return persona.Key;
            return "Indefinido";
        }
    }
}
