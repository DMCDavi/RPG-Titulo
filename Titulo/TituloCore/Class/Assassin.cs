using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace TituloCore
{
    [DataContractAttribute(Name = "Assassin", IsReference =true)]
    public class Assassin : IClass
    {
        Character Self;
        int MortalCD;
        int LethalCD;
        [DataMember]
        int[] DmgDice;
        [DataMember]
        Weapon Apprentice_Dagger;
        [DataMember]
        Armor Apprentice_Leather_Armor;
        [DataMember]
        Boots Apprentice_Boots;
        /// <summary>
        /// Construtor da classe Assasin
        /// </summary>
        public Assassin(Character Self)
        {
            this.Self = Self;
            HitDice();
            EquipBaseSet(Self);
        }

        public void EquipBaseSet(Character Self)
        {
            DmgDice = new int[] { 6, 6 };
            Apprentice_Dagger = new Weapon("Slash", "DEX", DmgDice, 0, 0, 1, "Apprentice_Dagger");
            Apprentice_Leather_Armor = new Armor(10, -10, 20, "Apprentice_Leather_Armor");
            Apprentice_Boots = new Boots(1, "Apprentice_Boots");

            Apprentice_Dagger.Equip(Self);
            Apprentice_Leather_Armor.Equip(Self);
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
            if (Self.Attack())
            {
                Random rand = new Random();
                int lethal = 1 + rand.Next() % 20 + Self.Lvl - Self.Target.Lvl;
                lethal /= 20;
                lethal *= Self.Target.Hpmax;
                if (Self.Target.Hp < lethal)
                {
                    Self.Target.ReceiveDmg(10, Self.EquippedWeapon.Atributo);//mata
                }
            }

        }

        public void MortalBlow()
        {
            if (Math.Abs(Self.Target.posX - Self.posX) <= Self.EquippedWeapon.Range && Math.Abs(Self.Target.posY - Self.posY) <= Self.EquippedWeapon.Range)
            {
                Self.EquippedWeapon.CriticalDmg(Self.Target);
                MortalCD += 3;
            }
            //definir recarga
        }

        public void AddActions(Character Self)
        {
            this.Self = Self;
            Self.Action.Add("Mortal Blow", new Action(MortalBlow));
            if (Self.Lvl >= 4)
                Self.Action.Add("Lethal Blow", new Action(LethalBlow));
        }
        public void AddBonusActions()
        {
            Self.BonusAction.Add("Dash", new Action(Self.Dash));
        }
        public void EndOfTurn()
        {
            if(MortalCD > 0)
            {
                MortalCD--;
            }
            if(LethalCD > 0)
            {
                LethalCD--;
            }
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
            if(Self.TurnMove > 0 && Chase)
            {
                if(Self.Chase())
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
            if(Math.Abs(dx) <= Self.EquippedWeapon.Range && Math.Abs(dy) <= Self.EquippedWeapon.Range)
            {
                if (Self.action)
                {
                    if(Self.Target.Hp/Self.Target.Hpmax <= 0.5 && Self.Lvl >= 4 && LethalCD == 0)
                    {
                        Self.Action["Lethal Blow"].DynamicInvoke();
                        Self.action = false;
                        return true;
                    }
                    else if(MortalCD == 0)
                    {
                        Self.Action["Mortal Blow"].DynamicInvoke();
                        Self.action = false;
                        return true;
                    }
                    else
                    {
                        Self.Action["Attack"].DynamicInvoke();
                        Self.action = false;
                        return true;
                    }
                }
                else if(Self.TurnMove > 0)
                {
                    // Alvo mais a direita da casa
                    if (Self.Target.posX >= Self.posX && Self.posX >= Self.HomeX)
                    {
                        if(Self.RightMoveIA())
                            return true;
                    }
                    // Alvo mais a esquerda da casa
                    if (Self.Target.posX <= Self.posX && Self.posX <= Self.HomeX)
                    {
                        if(Self.LeftMoveIA())
                            return true;
                    }
                    // Alvo mais a cima da casa
                    if (Self.Target.posY <= Self.posY && Self.posY <= Self.HomeY)
                    {
                        if(Self.UpMoveIA())
                            return true;
                    }
                    // Alvo mais a baixo da casa
                    if (Self.Target.posY >= Self.posY && Self.posY >= Self.HomeY)
                    {
                        if(Self.DownMoveIA())
                            return true;
                    }
                }
            }
            if(Self.action)
            {
                Self.Action["Dash"].DynamicInvoke();
                Self.action = false;
                return true;
            }
            return false;
        }
    }
}
