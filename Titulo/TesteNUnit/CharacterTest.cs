using NUnit.Framework;
using TituloCore;

namespace TesteNUnit
{   
    [TestFixture]
    public class CharacterTest
    {
        [TestCase]
        //Rever teste
        public void Understood()
        {
            Character personagem = new Character("Tank", "Human", "Vagner");
            personagem.LearnLang("PT");
            Assert.IsTrue(personagem.Understood("PT"));
        }
        [Test]
        public void canAttack()
        {
            Character personagem = new Character("Tank", "Human", "Vagner");
            Assert.IsTrue(personagem.canAttack(personagem));
        }

        [TestCase]
        //Rever teste
        public void ReceiveDmg()
        {
            int dmg = 10;
            string tipo = "Slash";
            Character personagem = new Character("Tank", "Human", "Vagner");
            personagem.Hp = 100;
            personagem.ReceiveDmg(dmg,tipo);
            Assert.AreEqual(90, personagem.Hp);
        }
        [TestCase]
        public void Proficiency()
        {
            Character personagem = new Character("Tank", "Human", "Vagner");
            personagem.Lvl = 3;
            Assert.AreEqual(2, personagem.Proficiency());
        }
        [TestCase]
        public void Modifier()
        {
            Character personagem = new Character("Tank", "Human", "Vagner");
            personagem.Atribute["STR"] = 9;
            personagem.MagicBonus["STR"] = 3;
            Assert.AreEqual(2,personagem.Modifier("STR"));
        }
        [TestCase("PT")]
        [TestCase("EN")]
        [TestCase("KUNJIN")]
        public void LearnLang(string Lang)
        {
            Character personagem = new Character("Tank", "Human", "Vagner");
            personagem.LearnLang(Lang);
            Assert.IsTrue(personagem.Understood(Lang));
        }
        [TestCase]
        public void Move()
        {
            Character personagem = new Character("Tank", "Human", "Vagner");
            personagem.posX = 3;
            personagem.posY = 3;
            personagem.Move(6, 0);
            Assert.AreEqual(6,personagem.posX);
            Assert.AreEqual(0,personagem.posY);
        }
        [TestCase]
        public void BuyAtributes()
        {
            Character personagem = new Character("Tank", "Human", "Vagner");
            personagem.Atribute["STR"] = 9;
            personagem.BuyAtributes("STR", 1);
            Assert.AreEqual(10, personagem.Atribute["STR"],"ta de brinks?");
        }
        [TestCase]
        public void Ac()
        {
            int aux;
            Character personagem = new Character("Tank", "Human", "Vagner");
            personagem.Atribute["DEX"] = 10;
            personagem.MagicBonus["DEX"] = 5;
            aux = personagem.EquippedArmor.Ac();
            Assert.AreEqual(aux, personagem.Ac());

        }
    }
}