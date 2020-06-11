using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Bard")]
    public class Bard : IClass
    {
        public Character Self;

        /// <summary>
        /// Construtor da classe Bard
        /// </summary>
        public Bard(Character Self)
        {
            this.Self = Self;
            HitDice();
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
        /// Aumenta 1 lvl de <see cref="Bard"/> no personagem
        /// </summary>
        /// <param name="Self"></param>
        public void LvlUp()
        {
            Self.Hpmax += RollHitDice() + Self.Modifier("CON");
        }

        public int RollHitDice()
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }

        public void DanceFire()
        {
            for (int i = 0; i < Self.Lvl; i++)
            {
                Self.ClassDmgDices.Add(6);
            }
        }

        public void DanceFireOFF()
        {
            Self.ClassDmgDices.Clear();
        }

        public void DanceFury()
        {
            Self.MagicBonus["DEX"] += 2;
            if (Self.Lvl >= 3)
                Self.MagicBonus["DEX"] += 2;
        }

        public void DanceFuryOFF()
        {
            Self.MagicBonus["DEX"] -= 2;
            if (Self.Lvl >= 3)
                Self.MagicBonus["DEX"] -= 2;
        }

        public void SongEarth()
        {
            Self.AcBonus += 2;
        }

        public void SongEarthOFF()
        {
            Self.AcBonus -= 2;
        }

        public void SongHunter()
        {
            Self.CritRange -= 2;
        }
        public void SongHunterOFF()
        {
            Self.CritRange += 2;
        }
    }
}
