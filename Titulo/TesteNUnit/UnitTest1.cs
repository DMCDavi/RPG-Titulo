using NUnit.Framework;
using Titulo;

namespace TesteNUnit
{
    [TestFixture]
    public class Tests
    {/*
        [TestCase]
        public void AtributeInc()
        {
            Ana atribute = new Ana();
            Assert.Pass();
        }
        */
        [TestCase]
        public void TotalMagicSpaces()
        {
            Personagem personagem = new Personagem("Tank", new Human(), new Vagner());
            Assert.AreEqual(0,personagem.TotalMagicSpaces(3));
        }
        [TestCase]
        public void ConjurationLvl()
        {
            Personagem personagem = new Personagem("Mage", new Human(), new Vagner());
            Assert.AreEqual(0, personagem.ConjurationLvl());
        }


    }
}