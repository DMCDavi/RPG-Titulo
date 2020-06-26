using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Witcher")]
    public class Witcher : IClass
    {
        public Character Self;
        public Witcher(Character Self)
        {
            this.Self = Self;
            HitDice();
        }
        public void HitDice()
        {
            Self.HitDice = 6;
        }

        public void LvlUp()
        {
            Self.Hpmax += RollHitDice() + Self.Modifier("CON");

        }
        public int RollHitDice()
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }

        public void EldrichBlast()
        {
            Random rand = new Random();
            int Dice = 8;
            Self.Target.ReceiveDmg(1 + rand.Next() % Dice + Self.Modifier("CHA"), "Energy");
        }

        public void AddActions(Character Self)
        {
            this.Self = Self;
            Self.Action.Add("Eldrich Blast", new Action(EldrichBlast));
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
