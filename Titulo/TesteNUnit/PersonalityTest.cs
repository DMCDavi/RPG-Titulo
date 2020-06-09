using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TituloCore;

namespace TesteNUnit
{
    [TestFixture]
    class PersonalityTest
    {
        [TestCase(1,1)]
        [TestCase(2, 5)]
        [TestCase(3, 2)]
        [TestCase(4, 5)]
        [TestCase(5, 3)]
        [TestCase(6, 2)]
        [TestCase(7, 5)]
        [TestCase(8, 4)]
        [TestCase(9, 1)]
        [TestCase(10, 3)]
        public void TestaPersona(int question, int answer)
        {

            Personality personality = new Personality();
            
            personality.TestaPersona(question, answer);
            Assert.AreEqual(1, personality.AllPersona["Bia"].PersonalityPoints());
        }
        [TestCase(1, 1)]
        public void GetPersonalityWinner(int question, int answer)
        {
            
            Personality personality = new Personality();       
            personality.TestaPersona(question, answer);
            Assert.AreEqual("Bia", personality.GetPersonalityWinner());
        }
    }
}
