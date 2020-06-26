using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TituloCore;

namespace TesteNUnit
{
    [TestFixture]
    public class ArmorTest
    {
        [TestCase(10,5,-5)]
        public void Ac(int BaseAc, int MaxDex, int MinDex)
        {
            Armor armor = new Armor(BaseAc,MaxDex,MinDex, "armor");
            Character personagem = new Character("Shielder", "Human", "Vagner");
            personagem.Atribute["DEX"] = 10;
            personagem.EquippedArmor = armor;
            personagem.EquippedArmor.Equip(personagem);
            Assert.AreEqual(10, armor.Ac());            
        }
       
    }
}
