using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Witcher")]
    public class Witcher : IClass
    {
        public Character Self;
        [DataMember]
        int[] DmgDice;
        [DataMember]
        Weapon Apprentice_Staff;
        [DataMember]
        Armor Apprentice_Cloth_Armor;
        [DataMember]
        Boots Apprentice_Boots;
        public Witcher(Character Self)
        {
            this.Self = Self;
            HitDice();
            EquipBaseSet(Self);
        }
        public void EquipBaseSet(Character Self)
        {
            DmgDice = new int[] { 6, 6 };
            Apprentice_Staff = new Weapon("Necrotic", "INT", DmgDice, 100, 0, 2, "Apprentice_Staff");
            Apprentice_Cloth_Armor = new Armor(10, -10, 20, "Apprentice_Cloth_Armor");
            Apprentice_Boots = new Boots(1, "Apprentice_Boots");

            Apprentice_Staff.Equip(Self);
            Apprentice_Cloth_Armor.Equip(Self);
            Apprentice_Boots.Equip(Self);
        }
        public void HitDice()
        {
            Self.HitDice = 6;
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

        public void EldrichBlast()
        {
            Random rand = new Random();
            int Dice = 8;
            Self.Target.ReceiveDmg(1 + rand.Next() % Dice + Self.Modifier("CHA"), "Energy");
        }

        public void AddActions(Character Self)
        {
            this.Self = Self;
            Self.Action.Add("Eldrich Blast", new Action(EldrichBlast));
        }

        /// <summary>
        /// Insere as Ações Bônus após serialização
        /// </summary>
        public void AddBonusActions()
        {

        }
    }
}
