using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Assassin")]
    public class Assassin : IClass
    {
        public int AssassinLvl;
        Character Self;
        /// <summary>
        /// Construtor da classe Assasin
        /// </summary>
        public Assassin(Character Self)
        {
            this.Self = Self;
            HitDice();
            Self.Action.Add("Morthal Blow", new Action(MortalBlow));
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


    }
}
