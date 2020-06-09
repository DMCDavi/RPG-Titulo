using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Bard")]
    public class Bard : IClass
    {
        public int BardLvl;

        /// <summary>
        /// Construtor da classe Bard
        /// </summary>
        public Bard(Character Self)
        {
            HitDice(Self);
        }

        /// <summary>
        /// Retorna o lvl de mage
        /// </summary>
        /// <returns></returns>
        public int ClassLvl()
        {
            return BardLvl;
        }


        /// <summary>
        /// Define o HitDice do personagem caso essa seja sua classe principal
        /// </summary>
        /// <param name="Self"></param>
        public void HitDice(Character Self)
        {
            Self.HitDice = 10;
        }

        /// <summary>
        /// Aumenta 1 lvl de <see cref="Bard"/> no personagem
        /// </summary>
        /// <param name="Self"></param>
        public void LvlUp(Character Self)
        {
            Self.Lvl++;
            BardLvl++;

            Self.Hpmax += RollHitDice(Self) + Self.Modifier("CON");
        }

        public int RollHitDice(Character Self)
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }

        public void DanceFire(Character Self)
        {
            for (int i = 0; i < Self.Lvl; i++)
            {
                Self.ClassDmgDices.Add(6);
            }
        }

        public void DanceFireOFF(Character Self)
        {
            Self.ClassDmgDices.Clear();
        }

        public void DanceFury(Character Self)
        {
            Self.MagicBonus["DEX"] += 2;
            if (Self.Lvl >= 3)
                Self.MagicBonus["DEX"] += 2;
        }

        public void DanceFuryOFF(Character Self)
        {
            Self.MagicBonus["DEX"] -= 2;
            if (Self.Lvl >= 3)
                Self.MagicBonus["DEX"] -= 2;
        }

        public void SongEarth(Character Self)
        {
            Self.AcBonus += 2;
        }

        public void SongEarthOFF(Character Self)
        {
            Self.AcBonus -= 2;
        }

        public void SongHunter(Character Self)
        {
            Self.CritRange -= 2;
        }
        public void SongHunterOFF(Character Self)
        {
            Self.CritRange += 2;
        }
    }
}
