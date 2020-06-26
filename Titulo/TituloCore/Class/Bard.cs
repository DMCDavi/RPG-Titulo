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
        [DataMember]
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
                Self.Action.Add("Dance", new Action<string>(Dance));
                Self.Action.Add("Stop Dancing", new Action(StopDancing));
            }
        }

        public int RollHitDice()
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }

        public void Song(string song)
        {
            if(song != "Earth")
                song = "Hunter";
            //Escolher Fire ou Fury
            if (song == "Earth")
                SongEarth();
            else if (song == "Hunter")
                SongHunter();
            Dancing = true;
        }

        public void Dance(string dance)
        {
            if(dance != "Fury")
                dance = "Fire";
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
        }
        public void AddBonusActions()
        {
            Self.BonusAction.Add("Song", new Action<string>(Song));
            Self.BonusAction.Add("Stop Singing", new Action(StopSinging));
            if (Self.Lvl >= 4)
            {
                Self.BonusAction.Add("Dance", new Action<string>(Dance));
                Self.BonusAction.Add("Stop Dancing", new Action(StopDancing));
            }
        }

        // IA
        public void EndOfTurn()
        {
            
        }

        private bool Chase;
        public bool TurnIA()
        {
            int dx = Self.posX - Self.Target.posX;
            int dy = Self.posY - Self.Target.posY;
            // Define se vai perseguir
            if (Math.Abs(dx) < 6 && Math.Abs(dy) < 6)
                Chase = true;
            if (Math.Abs(dx) <= 1 && Math.Abs(dy) <= 1)
                Chase = false;
            if (Math.Abs(Self.Target.posX - Self.HomeX) > 15 || Math.Abs(Self.Target.posY - Self.HomeY) > 15)
                Chase = false;
            if (Self.TurnMove > 0 && Chase)
            {
                if (Self.Chase())
                {
                    return true;
                }
            }
            if (Math.Abs(dx) > Self.EquippedWeapon.Range && Math.Abs(dy) > Self.EquippedWeapon.Range)
            {
                if (Self.bonusaction)
                {
                    Self.BonusAction["Dash"].DynamicInvoke();
                    Self.bonusaction = false;
                    return true;
                }
            }
            if (Math.Abs(dx) > Self.EquippedWeapon.Range && Math.Abs(dy) > Self.EquippedWeapon.Range)
            {
                if (Self.action)
                {
                    Self.Action["Attack"].DynamicInvoke();
                    Self.action = false;
                    return true;
                }
                else if (Self.TurnMove > 0)
                {
                    // Alvo mais a direita da casa
                    if (Self.Target.posX >= Self.posX && Self.posX >= Self.HomeX)
                    {
                        if (Self.RightMoveIA())
                            return true;
                    }
                    // Alvo mais a esquerda da casa
                    if (Self.Target.posX <= Self.posX && Self.posX <= Self.HomeX)
                    {
                        if (Self.LeftMoveIA())
                            return true;
                    }
                    // Alvo mais a cima da casa
                    if (Self.Target.posY <= Self.posY && Self.posY <= Self.HomeY)
                    {
                        if (Self.UpMoveIA())
                            return true;
                    }
                    // Alvo mais a baixo da casa
                    if (Self.Target.posY >= Self.posY && Self.posY >= Self.HomeY)
                    {
                        if (Self.DownMoveIA())
                            return true;
                    }
                }
            }
            if (Self.action)
            {
                Self.Action["Dash"].DynamicInvoke();
                Self.action = false;
                return true;
            }
            return false;
        }
    }
}
