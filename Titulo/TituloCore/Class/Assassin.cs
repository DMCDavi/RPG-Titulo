using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace TituloCore
{
    [DataContractAttribute(Name = "Assassin")]
    public class Assassin : IClass
    {
        Character Self;
        /// <summary>
        /// Construtor da classe Assasin
        /// </summary>
        public Assassin(Character Self)
        {
            this.Self = Self;
            HitDice();
            //EquipBaseSet(Self);
        }

        public void EquipBaseSet(Character Self)
        {
            int[] DmgDice = { 6, 6 };
            Weapon Dagger = new Weapon("Slash", "STR", DmgDice, 100, 0, 2);
            Armor Leather_Armor = new Armor(10, -10, 20);
            Boots Fleeting_Boots = new Boots(3);

            Dagger.Equip(Self);
            Leather_Armor.Equip(Self);
            Fleeting_Boots.Equip(Self);

            if (Self.EquippedBoots != null)
            {
                Debug.WriteLine("deu bom");
            }
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
        /// Aumenta 1 lvl de <see cref="Assassin"/> no personagem
        /// </summary>
        /// <param name="Self"></param>
        public void LvlUp()
        {
            if(Self.Lvl == 4)
                Self.Action.Add("Lethal Blow", new Action(LethalBlow));
            //player.Action["Morthal Blow"].DynamicInvoke(Target);

            Self.Hpmax += RollHitDice() + Self.Modifier("CON");
        }

        public int RollHitDice()
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }

        public void LethalBlow()
        {
            Self.Attack();

            Random rand = new Random();
            int lethal = 1 + rand.Next() % 20 + Self.Lvl - Self.Target.Lvl;
            lethal /= 20;
            lethal *= Self.Target.Hpmax;
            if (Self.Target.Hp < lethal)
            {
                Self.Target.ReceiveDmg(10, Self.EquippedWeapon.Atributo);//mata
            }
            //definir recarga
        }

        public void MortalBlow()
        {
            Self.EquippedWeapon.CriticalDmg(Self.Target);
            //definir recarga
        }

        public void AddActions(Character Self)
        {
            this.Self = Self;
            Self.Action.Add("Morthal Blow", new Action(MortalBlow));
            if (Self.Lvl >= 4)
                Self.Action.Add("Lethal Blow", new Action(LethalBlow));
        }
        public void AddBonusActions()
        {
            Self.BonusAction.Add("Dash", new Action(Self.Dash));
        }

    }
}
