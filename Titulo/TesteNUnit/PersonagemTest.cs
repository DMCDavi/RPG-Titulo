using NUnit.Framework;
using Titulo;

namespace TesteNUnit
{   [TestFixture]
    public class Tests
    {
        [TestCase]
        public void TotalMagicSpaces()
        {
            Personagem personagem = new Personagem("Tank", "Human", "Vagner");
            Assert.AreEqual(0,personagem.TotalMagicSpaces(3));
        }
        [TestCase]
        public void ConjurationLvl()
        {
            Personagem personagem = new Personagem("Tank", "Human", "Vagner");
            Assert.AreEqual(0, personagem.ConjurationLvl());
        }
        [TestCase]
        //Rever teste
        public void Understood()
        {
            Personagem personagem = new Personagem("Tank", "Human", "Vagner");
            Assert.IsTrue(personagem.Understood("PT"));
        }
        [TestCase]
        public void canAttack()
        {
            Personagem personagem = new Personagem("Tank", "Human", "Vagner");
            Assert.IsTrue(personagem.canAttack(personagem));
        }

        [TestCase]
        //Rever teste
        public void ReceiveDmg()
        {
            int dmg = 10;
            string tipo = "ice";
            Personagem personagem = new Personagem("Tank", "Human", "Vagner");
            personagem.ReceiveDmg(dmg,tipo);
            Assert.AreEqual(80, personagem.Hp);
        }
        [TestCase]
        public void Proficiency()
        {
            Personagem personagem = new Personagem("Tank", "Human", "Vagner");
            personagem.Lvl = 3;
            Assert.AreEqual(1, personagem.Proficiency());
        }
        [TestCase]
        public void Modifier()
        {
            Personagem personagem = new Personagem("Tank", "Human", "Vagner");
            personagem.Atribute["STR"] = 9;
            personagem.MagicBonus["STR"] = 3;
            Assert.AreEqual(6,personagem.Modifier("STR"));
        }
        [TestCase("PT")]
        [TestCase("EN")]
        [TestCase("KUNJIN")]
        public void LearnLang(string Lang)
        {
            Personagem personagem = new Personagem("Tank", "Human", "Vagner");
            personagem.LearnLang(Lang);
            Assert.IsTrue(personagem.Understood(Lang));
        }
        [TestCase]
        public void Move()
        {
            Personagem personagem = new Personagem("Tank", "Human", "Vagner");
            personagem.posX = 3;
            personagem.posY = 3;
            personagem.Move(6, 0);
            Assert.AreEqual(6,personagem.posX);
            Assert.AreEqual(0,personagem.posY);
        }
        [TestCase]
        public void BuyAtributes()
        {
            Personagem personagem = new Personagem("Tank", "Human", "Vagner");
            personagem.Atribute["STR"] = 9;
            personagem.BuyAtributes("STR",1);
            Assert.AreEqual(7,personagem.Atribute["STR"]);
        }


    }
}