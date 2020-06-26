using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Shielder")]
    public class Shielder : IClass
    {
        public Character Self;
        [DataMember]
        int[] DmgDice;
        [DataMember]
        Weapon Apprentice_Shield;
        [DataMember]
        Armor Apprentice_Chainmail_Armor;
        [DataMember]
        Boots Apprentice_Boots;
        public Shielder(Character Self)
        {
            this.Self = Self;
            HitDice();
            EquipBaseSet(Self);
        }

        public void EquipBaseSet(Character Self)
        {
            DmgDice = new int[] { 6, 6 };
            Apprentice_Shield = new Weapon("Concussive", "STR", DmgDice, 100, 0, 2, "Apprentice_Shield");
            Apprentice_Chainmail_Armor = new Armor(10, -10, 20);
            Apprentice_Boots = new Boots(1, "Apprentice_Boots");

            Apprentice_Shield.Equip(Self);
            Apprentice_Chainmail_Armor.Equip(Self);
            Apprentice_Boots.Equip(Self);
        }
        public void HitDice()
        {
            Self.HitDice = 20;
        }

        public void LvlUp()
        {
            Self.Hpmax += RollHitDice() + Self.Modifier("CON");

            if(Self.Lvl == 4)
                Self.Action.Add("Blood Sacrifice", new Action(BloodSacrifice));
        }
        public int RollHitDice()
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }

        public void BloodSacrifice()
        {
            Random rand = new Random();
            int dmg = Self.Hpmax * (1 + rand.Next()%20)/20;
            Self.Target.ReceiveDmg(dmg, "Necrotic");
            if (dmg >= Self.Hp)
                dmg = Self.Hp-1;
            Self.ReceiveDmg(dmg, "Necrotic");
        }
        public void ColossusVengeance()
        {
            Self.Attack();
            Self.Target.ReceiveDmg((Self.Hpmax - Self.Hp) / 2, "Necrotic");
        }

        public void AddActions(Character Self)
        {
            this.Self = Self;
            Self.Action.Add("Colossus Vengeance", new Action(ColossusVengeance));
            if (Self.Lvl >= 4)
                Self.Action.Add("Blood Sacrifice", new Action(BloodSacrifice));
        }

        /// <summary>
        /// Insere as Ações Bônus após serialização
        /// </summary>
        public void AddBonusActions()
        {

        }
    }
}
