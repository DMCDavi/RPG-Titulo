using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Cleric")]
    public class Cleric : IClass
    {
        public Character Self;
        [DataMember]
        int[] DmgDice;
        [DataMember]
        Weapon Apprentice_Wand;
        [DataMember]
        Armor Apprentice_Cloth_Armor;
        [DataMember]
        Boots Apprentice_Boots;
        /// <summary>
        /// Construtor da classe Cleric
        /// </summary>
        public Cleric(Character Self)
        {
            this.Self = Self;
            HitDice();
            EquipBaseSet(Self);
        }

        public void EquipBaseSet(Character Self)
        {
            DmgDice = new int[] { 6, 6 };
            Apprentice_Wand = new Weapon("Radiante", "INT", DmgDice, 100, 0, 2, "Apprentice_Wand");
            Apprentice_Cloth_Armor = new Armor(10, -10, 20, "Apprentice_Cloth_Armor");
            Apprentice_Boots = new Boots(1, "Apprentice_Boots");

            Apprentice_Wand.Equip(Self);
            Apprentice_Cloth_Armor.Equip(Self);
            Apprentice_Boots.Equip(Self);
        }


        /// <summary>
        /// Define o HitDice do personagem caso essa seja sua classe principal
        /// </summary>
        /// <param name="Self"></param>
        public void HitDice()
        {
            Self.HitDice = 10;
        }

        /// <summary>
        /// Aumenta 1 lvl de <see cref="Cleric"/> no personagem
        /// </summary>
        /// <param name="Self"></param>
        public void LvlUp()
        {
            Self.Hpmax += RollHitDice() + Self.Modifier("CON");
            if(Self.Lvl == 4)
                Self.Action.Add("Smite", new Action(Smite));

        }
        public int RollHitDice()
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }

        public void Smite()
        {
            Self.Target.ReceiveDmg(0, "Radiant");
        }

        public void Heal()
        {
            Self.Target.Hp += 1;
            if (Self.Target.Hp > Self.Target.Hpmax)
                Self.Target.Hp = Self.Target.Hpmax;
        }

        public void AddActions(Character Self)
        {
            this.Self = Self;
            Self.Action.Add("Heal", new Action(Heal));
            if (Self.Lvl >= 4)
                Self.Action.Add("Smite", new Action(Smite));
        }

        /// <summary>
        /// Insere as Ações Bônus após serialização
        /// </summary>
        public void AddBonusActions()
        {

        }
    }
}

