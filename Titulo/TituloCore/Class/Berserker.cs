using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TituloCore
{
    [DataContractAttribute(Name = "Berserker")]
    public class Berserker : IClass
    {
        public Character Self;
        private bool Rage = false;
        [DataMember]
        private int RageDmg = 2;
        public Berserker(Character Self)
        {
            this.Self = Self;
            HitDice();
            Self.NaturalArmor = new Armor ( 10 + Self.Modifier("CON"), 10, -10);
        }

        public void HitDice()
        {
            Self.HitDice = 12;
        }

        public void LvlUp()
        {
            Self.Hpmax += RollHitDice() + Self.Modifier("CON");
            RageDmg += 2;
        }

        public int RollHitDice()
        {
            Random rand = new Random();
            return 1 + rand.Next() % Self.HitDice;
        }

        public void RageOn()
        {
            Rage = true;
            Self.Resist["Concussion"] = true;
            Self.Resist["Slash"] = true;
            Self.Resist["Piercing"] = true;
        }

        public void RageOFF()
        {
            Rage = false;
            Self.Resist["Concussion"] = false;
            Self.Resist["Slash"] = false;
            Self.Resist["Piercing"] = false;
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
                    if (Rage)
                        Self.Target.ReceiveDmg(RageDmg, Self.EquippedWeapon.Atributo);
                    return true;
                }
                if (acerto >= Self.Target.Ac())
                {
                    Self.EquippedWeapon.DealDmg(Self.Target);
                    if (Rage)
                        Self.Target.ReceiveDmg(RageDmg, Self.EquippedWeapon.Atributo);
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
        /// <summary>
        /// Insere as Ações Bônus após serialização
        /// </summary>
        public void AddBonusActions()
        {
            Self.BonusAction.Add("Rage ON", new Action(RageOn));
            Self.BonusAction.Add("Rage OFF", new Action(RageOFF));
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
            RageOn();
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
