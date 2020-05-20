using NUnit.Framework;
using Titulo;

namespace TesteNUnit
{   [TestFixture]
    public class Tests
    {
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
        [TestCase]
        //Rever teste
        public void Understood()
        {
            Personagem personagem = new Personagem("Mage", new Human(), new Joao());
            Assert.IsTrue(personagem.Understood("PT"));
        }
        [TestCase]
        public void canAttack()
        {
            Personagem personagem = new Personagem("Mage", new Human(), new Joao());
            Assert.IsTrue(personagem.canAttack(personagem));
        }

        [TestCase]
        //Rever teste
        public void ReceiveDmg()
        {
            int dmg = 10;
            string tipo = "ice";
            Personagem personagem = new Personagem("Mage", new Human(), new David());
            personagem.ReceiveDmg(dmg,tipo);
            Assert.AreEqual(80, personagem.Hp);
        }
       

    }
}