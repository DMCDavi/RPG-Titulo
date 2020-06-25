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
            Self.Action.Add("Rage ON", new Action(RageOn));
            Self.Action.Add("Rage OFF", new Action(RageOFF));
        }
    }
}
