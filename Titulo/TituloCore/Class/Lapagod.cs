using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Lapagod")]
    public class Lapagod : IClass
    {
        public Character Self;
        [DataMember]
        int[] DmgDice;
        [DataMember]
        Weapon Master_Fists;
        [DataMember]
        Armor Apprentice_Chainmail_Armor;
        [DataMember]
        Boots Master_Boots;
        public Lapagod(Character Self)
        {
            this.Self = Self;
            HitDice();
            EquipBaseSet(Self);
        }
        public void EquipBaseSet(Character Self)
        {
            DmgDice = new int[] { 100 };
            Master_Fists = new Weapon("Fire", "INT", DmgDice, 100, 0, 2, "Master_Fists");
            Apprentice_Chainmail_Armor = new Armor(15, 0, 20, "Apprentice_Chainmail_Armor");
            Master_Boots = new Boots(1, "Master_Boots");

            Master_Fists.Equip(Self);
            Apprentice_Chainmail_Armor.Equip(Self);
            Master_Boots.Equip(Self);
        }
        public void HitDice()
        {
            Self.HitDice = 20;
        }

        public void LvlUp()
        {
            Self.Hpmax += RollHitDice() + Self.Modifier("CON");
        }

        public int RollHitDice()
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }

        public void AddActions(Character Self)
        {
            this.Self = Self;
        }

        /// <summary>
        /// Insere as Ações Bônus após serialização
        /// </summary>
        public void AddBonusActions()
        {

        }

        //IA
        public void EndOfTurn()
        {

        }
        public bool TurnIA()
        {
            return false;
        }
    }
}
