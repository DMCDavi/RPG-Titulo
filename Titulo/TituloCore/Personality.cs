using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Titulo
{
    public class Personality
    {
        Ana ana = new Ana();
        Bia bia = new Bia();
        David davi = new David();
        Fernanda fernanda = new Fernanda();
        Gean gean = new Gean();
        Grhamm grhamm = new Grhamm();
        Joao joao = new Joao();
        Maria maria = new Maria();
        Vagner vagner = new Vagner();

        public List<IPersona> AllPersona;
        public Personality()
        {
            //Lista com todas as Personas
            AllPersona = new List<IPersona>
            {
                ana,
                bia,
                davi,
                fernanda,
                gean,
                grhamm,
                joao,
                maria,
                vagner
            };
        }
        public static string PersonaChosen;

        /// <summary>
        /// Checa cada Persona para adicionar um ponto de personalidade naquelas que possuem as respostas certas para a pergunta em específico
        /// </summary>
        /// <param name="question">Um número inteiro que representa o número da pergunta</param>
        /// <param name="answer">Um número inteiro que representa o número da resposta para a pergunta</param>
        public void TestaPersona(int question, int answer)
        {
            //loop que checa cada Persona
            foreach (IPersona persona in AllPersona)
                //Se o usuário escolheu a resposta correta da Persona, a pontuação de personalidade aumentará em 1
                if (persona.PersonalityChoice(question) == answer)
                    persona.IncrementPersonalityPoints();
        }

        /// <summary>
        /// Busca quem é o vencedor do teste de personalidade
        /// </summary>
        /// <returns>Uma string que representa o nome da Persona vencedora do teste de personalidade</returns>
        public string GetPersonalityWinner()
        {
            int maior_pontuacao = 0;
            //Busca a maior pontuação entre as Personas
            foreach (IPersona persona in AllPersona)
                if (persona.PersonalityPoints() > maior_pontuacao)
                    maior_pontuacao = persona.PersonalityPoints();
            //Busca e retorna o nome da Persona com maior pontuação
            foreach (IPersona persona in AllPersona)
                if (maior_pontuacao == persona.PersonalityPoints())
                    return persona.PersonaName();
            return "David";
        }
    }
}
