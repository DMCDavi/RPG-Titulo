using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TituloCore
{
    [DataContract(Name = "Weapon", Namespace = "http://www.contoso.com")]
    public class Weapon : Equipment
    {
        [DataMember]
        public string Tipo;
        [DataMember]
        public string Atributo;
        [DataMember]
        public List<int> Dices = new List<int>();
        [DataMember]
        public int HitBonus;
        [DataMember]
        public int DmgBonus;
        [DataMember]
        public int Range;


        /// <summary>
        /// Construtor da arma
        /// </summary>
        /// <param name="Owner">Dono da arma</param>
        /// <param name="Hit">Bônus padrão  de acerto</param>
        /// <param name="Damage">Bônus padrão de dano</param>
        /// <param name="Tipo">Tipo de dano</param>
        /// <param name="Atributo">Atributo que a arma usa</param>
        /// <param name="Dices">Vetor com dados de dano</param>
        public Weapon(string Tipo, string Atributo, int[] Dices, int Hit, int Damage, int Range, string Name)
        {
            this.Name = Name;
            this.Tipo = Tipo;
            this.Atributo = Atributo;
            foreach (int dice in Dices)
            {
                this.Dices.Add(dice);
            }
            HitBonus = Hit;
            DmgBonus = Damage;
            this.Range = Range;
        }

        public override void Equip(Character Owner)
        {
            if (this.Owner == null)
                this.Owner = Owner;
            if (Owner.EquippedWeapon != null)
                Owner.EquippedWeapon.Unequip();
            Owner.EquippedWeapon = this;
            Owner.Inventory.Remove(this);
        }

        public override void Unequip()
        {
            if (this.Owner != null)
            {
                Owner.EquippedWeapon = null;
                Owner.Inventory.Add(this);
            }
            else
                Console.WriteLine("Erro: Equipamento sem dono");
        }



        /// <summary>
        /// Aplica o dano de um ataque com a arma
        /// </summary>
        /// <param name="Target">Alvo do ataque</param>
        /// <returns></returns>
        public void DealDmg(Character Target)
        {
            int damage = 0, daninho = 0;
            Random rand = new Random();
            foreach (int Dice in Dices)
            {
                daninho = 1 + (rand.Next() % Dice);
                damage += daninho;
            }
            damage += DmgBonus;
            damage += Owner.Modifier(Atributo);
            Target.ReceiveDmg(damage, this.Tipo);
        }
        public void CriticalDmg(Character Target)
        {
            int damage = 0, daninho = 0;
            Random rand = new Random();
            foreach (int Dice in Dices)
            {
                daninho = 1 + (rand.Next() % Dice);
                damage += daninho;
            }
            foreach (int Dice in Dices)
            {
                daninho = 1 + (rand.Next() % Dice);
                damage += daninho;
            }
            damage += DmgBonus;
            damage += Owner.Modifier(Atributo);
            Target.ReceiveDmg(damage, this.Tipo);
        }
    }
}
