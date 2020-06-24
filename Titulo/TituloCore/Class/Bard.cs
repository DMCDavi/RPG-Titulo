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
        private int FireDmg = 3;
        private bool fire = false, fury = false, earth = false, hunter = false;
        public bool Singing = false, Dancing = false;

        /// <summary>
        /// Construtor da classe Bard
        /// </summary>
        public Bard(Character Self)
        {
            this.Self = Self;
            HitDice();
            Self.Action.Remove("Attack");
            Self.Action.Add("Attack", new Func<bool>(() => Attack()));
            Self.Action.Add("Song", new Action(Song));
            Self.Action.Add("Stop Singing", new Action(StopSinging));
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
            FireDmg += 1;

            if (Self.Lvl == 4)
            {
                Self.Action.Add("Dance", new Action(Dance));
                Self.Action.Add("Stop Dancing", new Action(StopDancing));
            }
        }

        public int RollHitDice()
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }

        public void Song()
        {
            string song = "Hunter";
            //Escolher Fire ou Fury
            if (song == "Earth")
                SongEarth();
            else if (song == "Hunter")
                SongHunter();
            Dancing = true;
        }

        public void Dance()
        {
            string dance = "Fire";
            //Escolher Fire ou Fury
            if (dance == "Fire")
                DanceFire();
            else if (dance == "Fury")
                DanceFury();
            Dancing = true;
        }

        public void StopDancing()
        {
            if (fire)
                DanceFireOFF();
            else if (fury)
                DanceFuryOFF();
            Dancing = false;
        }

        public void StopSinging()
        {
            if (earth)
                SongEarthOFF();
            else if (hunter)
                SongHunterOFF();
            Singing = false;
        }

        public void DanceFire()
        {
            fire = true;
        }

        public void DanceFireOFF()
        {
            fire = false;
        }

        public void DanceFury()
        {
            Self.MagicBonus["DEX"] += 2;
            if (Self.Lvl >= 3)
                Self.MagicBonus["DEX"] += 2;
            fury = true;
        }

        public void DanceFuryOFF()
        {
            Self.MagicBonus["DEX"] -= 2;
            if (Self.Lvl >= 3)
                Self.MagicBonus["DEX"] -= 2;
            fury = false;
        }

        public void SongEarth()
        {
            Self.AcBonus += 2;
            earth = true;
        }

        public void SongEarthOFF()
        {
            Self.AcBonus -= 2;
            earth = false;
        }

        public void SongHunter()
        {
            Self.CritRange -= 2;
            hunter = true;
        }
        public void SongHunterOFF()
        {
            Self.CritRange += 2;
            hunter = false;
        }

        public bool Attack()
        {
            Random rand = new Random();
            if (Self.canAttack(Self.Target))
            {
                int dice = 1 + rand.Next() % 20;
                int acerto = dice + Self.Proficiency() + Self.Modifier(Self.EquippedWeapon.Atributo) + Self.EquippedWeapon.HitBonus;
                if (dice >= Self.CritRange)
                {
                    Self.EquippedWeapon.CriticalDmg(Self.Target);
                    if (fire)
                        Self.Target.ReceiveDmg(FireDmg, Self.EquippedWeapon.Atributo);
                    return true;
                }
                if (acerto >= Self.Target.Ac())
                {
                    Self.EquippedWeapon.DealDmg(Self.Target);
                    if (fire)
                        Self.Target.ReceiveDmg(FireDmg, Self.EquippedWeapon.Atributo);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public void AddActions(Character Self)
        {
            this.Self = Self;
            Self.Action.Remove("Attack");
            Self.Action.Add("Attack", new Func<bool>(() => Attack()));
            /*Self.Action.Add("Song", new Action(Song));
            Self.Action.Add("Stop Singing", new Action(StopSinging));
            if (Self.Lvl >= 4)
            {
                Self.Action.Add("Dance", new Action(Dance));
                Self.Action.Add("Stop Dancing", new Action(StopDancing));
            }*/
        }
    }
}
