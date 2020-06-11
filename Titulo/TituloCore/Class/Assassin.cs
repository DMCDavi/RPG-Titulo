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
            Self.Action.Add("Morthal Blow", new Action<Character>(MortalBlow));
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
                Self.Action.Add("Lethal Blow", new Action<Character>(LethalBlow));
            //player.Action["Morthal Blow"].DynamicInvoke(Target);

            Self.Hpmax += RollHitDice() + Self.Modifier("CON");
        }

        public int RollHitDice()
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }

        public void LethalBlow(Character Target)
        {
            Self.Attack(Target);

            Random rand = new Random();
            int lethal = 1 + rand.Next() % 20 + Self.Lvl - Target.Lvl;
            lethal /= 20;
            lethal *= Target.Hpmax;
            if (Target.Hp < lethal)
            {
                Target.ReceiveDmg(10, Self.EquippedWeapon.Atributo);//mata
            }
            //definir recarga
        }

        public void MortalBlow(Character Target)
        {
            Self.EquippedWeapon.CriticalDmg(Target);
            //definir recarga
        }


    }
}
