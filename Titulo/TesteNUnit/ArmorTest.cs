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
        [TestCase(5,5,5)]
        public void Ac(int BaseAc, int MaxDex, int MinDex)
        {
            int aux, DexBonus;
            Armor armor = new Armor(BaseAc,MaxDex,MinDex);
            Personagem personagem = new Personagem("Tank", "Human", "Vagner");
            personagem.Atribute["DEX"] = 10;
            personagem.MagicBonus["DEX"] = 5;
            DexBonus = personagem.Modifier("DEX");
            personagem.EquippedArmor = armor;
            personagem.EquippedArmor.Equip(personagem);
            aux = BaseAc + DexBonus;
            Assert.AreEqual(aux,armor.Ac());            
        }
       
    }
}
