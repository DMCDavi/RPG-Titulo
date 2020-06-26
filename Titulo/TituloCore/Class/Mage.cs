﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Mage")]
    public class Mage : IClass
    {
        public Character Self;
        [DataMember]
        int[] DmgDice;
        [DataMember]
        Weapon Apprentice_Staff;
        [DataMember]
        Armor Apprentice_Cloth_Armor;
        [DataMember]
        Boots Apprentice_Boots;
        /// <summary>
        /// Construtor da classe Mage
        /// </summary>
        public Mage(Character Self)
        {
            this.Self = Self;
            HitDice();
            EquipBaseSet(Self);
        }

        public void EquipBaseSet(Character Self)
        {
            DmgDice = new int[] { 10 };
            Apprentice_Staff = new Weapon("Fire", "INT", DmgDice, 0, 0, 5, "Apprentice_Staff");
            Apprentice_Cloth_Armor = new Armor(13, -10, 20, "Apprentice_Cloth_Armor");
            Apprentice_Boots = new Boots(1, "Apprentice_Boots");

            Apprentice_Staff.Equip(Self);
            Apprentice_Cloth_Armor.Equip(Self);
            Apprentice_Boots.Equip(Self);
        }


        /// <summary>
        /// Define o HitDice do personagem caso essa seja sua classe principal
        /// </summary>
        /// <param name="Self"></param>
        public void HitDice()
        {
            Self.HitDice = 6;
        }

        /// <summary>
        /// Aplica os efeitos da classe por passar de nível
        /// </summary>
        /// <param name="Self"></param>
        public void LvlUp()
        {
            Self.Hpmax += RollHitDice() + Self.Modifier("CON");
            if(Self.Lvl == 4)
                Self.Action.Add("Element Storm", new Action(ElementStorm));
        }
        public int RollHitDice()
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }

        public void ElementBolt()
        {
            // Escolher elemento
            int dmg = 1 + new Random().Next() % 10 + Self.Modifier("INT");
            Self.Target.ReceiveDmg(dmg, "Energy");
        }
        public void ElementStorm()
        {
            // Escolher elemento
            Random rand = new Random();
            int dmg = 1 + rand.Next() % 10;
            for (int i = 0; i < Self.Lvl; i++)
            {
                dmg += 1 + rand.Next() % 8;
            }
            Self.Target.ReceiveDmg(dmg, "Energy");
        }

        public void AddActions(Character Self)
        {
            this.Self = Self;
            Self.Action.Add("Element Bolt", new Action(ElementBolt));
            if (Self.Lvl >= 4)
                Self.Action.Add("Element Storm", new Action(ElementStorm));
        }

        /// <summary>
        /// Insere as Ações Bônus após serialização
        /// </summary>
        public void AddBonusActions()
        {

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
