using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Warrior")]
    public class Warrior : IClass
    {
        public Character Self;
        [DataMember]
        int[] DmgDice;
        [DataMember]
        Weapon Apprentice_Sword;
        [DataMember]
        Armor Apprentice_Chainmail_Armor;
        [DataMember]
        Boots Apprentice_Boots;
        public Warrior(Character Self)
        {
            this.Self = Self;
            HitDice();
            EquipBaseSet(Self);
        }

        public void EquipBaseSet(Character Self)
        {
            DmgDice = new int[] { 6, 6 };
            Apprentice_Sword = new Weapon("Slash", "STR", DmgDice, 0, 0, 1, "Apprentice_Sword");
            Apprentice_Chainmail_Armor = new Armor(15, -3, 2, "Apprentice_Chainmail_Armor");
            Apprentice_Boots = new Boots(1, "Apprentice_Boots");

            Apprentice_Sword.Equip(Self);
            Apprentice_Chainmail_Armor.Equip(Self);
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
        /// Aumenta 1 lvl de <see cref="Warrior"/> no personagem
        /// </summary>
        /// <param name="Self"></param>
        public void LvlUp()
        {
            Self.Hpmax += RollHitDice() + Self.Modifier("CON");
            if (Self.Lvl == 3)
                Self.CritRange = 19;
            if(Self.Lvl == 4)
                Self.Action.Add("Action Surge", new Action<Character>(ActionSurge));
        }
        public int RollHitDice()
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }
        
        public void SecondWind()
        {
            Self.Hp += new Random().Next() % 10 + 1 + Self.Lvl;
        }

        public void ActionSurge(Character Target)
        {
            if (!Self.action)
            {
                Self.action = true;
                Self.bonusaction = false;
            }
        }

        public void AddActions(Character Self)
        {
            this.Self = Self;
        }

        /// <summary>
        /// Insere as Ações Bônus após serialização
        /// </summary>
        public void AddBonusActions()
        {
            Self.BonusAction.Add("Second Wind", new Action(SecondWind));
            if (Self.Lvl >= 4)
                Self.Action.Add("Action Surge", new Action<Character>(ActionSurge));
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

                }
            }
            if (Math.Abs(dx) <= Self.EquippedWeapon.Range && Math.Abs(dy) <= Self.EquippedWeapon.Range)
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

