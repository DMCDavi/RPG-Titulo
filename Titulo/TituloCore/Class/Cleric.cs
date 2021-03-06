﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Cleric")]
    public class Cleric : IClass
    {
        public Character Self;
        [DataMember]
        int[] DmgDice;
        [DataMember]
        Weapon Apprentice_Wand;
        [DataMember]
        Armor Apprentice_Cloth_Armor;
        [DataMember]
        Boots Apprentice_Boots;
        /// <summary>
        /// Construtor da classe Cleric
        /// </summary>
        public Cleric(Character Self)
        {
            this.Self = Self;
            HitDice();
            EquipBaseSet(Self);
        }

        public void EquipBaseSet(Character Self)
        {
            DmgDice = new int[] { 4, 6 };
            Apprentice_Wand = new Weapon("Radiante", "INT", DmgDice, 0, 0, 1, "Apprentice_Wand");
            Apprentice_Cloth_Armor = new Armor(15, -3, 2, "Apprentice_Cloth_Armor");
            Apprentice_Boots = new Boots(1, "Apprentice_Boots");

            Apprentice_Wand.Equip(Self);
            Apprentice_Cloth_Armor.Equip(Self);
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
        /// Aumenta 1 lvl de <see cref="Cleric"/> no personagem
        /// </summary>
        /// <param name="Self"></param>
        public void LvlUp()
        {
            Self.Hpmax += RollHitDice() + Self.Modifier("CON");
            if(Self.Lvl == 4)
                Self.Action.Add("Smite", new Action(Smite));

        }
        public int RollHitDice()
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }

        public void Smite()
        {
            Self.Target.ReceiveDmg(0, "Radiant");
        }

        public void Heal()
        {
            Self.Target.Hp += 1;
            if (Self.Target.Hp > Self.Target.Hpmax)
                Self.Target.Hp = Self.Target.Hpmax;
        }

        public void AddActions(Character Self)
        {
            this.Self = Self;
            Self.Action.Add("Heal", new Action(Heal));
            if (Self.Lvl >= 4)
                Self.Action.Add("Smite", new Action(Smite));
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

