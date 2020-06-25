﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TituloCore
{
    [DataContract(Name = "Weapon", Namespace = "http://www.contoso.com")]
    public class Weapon
    {
        Character Owner;
        public string Tipo;
        public string Atributo;
        public List<int> Dices = new List<int>();
        public int HitBonus;
        public int DmgBonus;
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
        public Weapon(string Tipo, string Atributo, int[] Dices, int Hit, int Damage, int Range, Character Owner)
        {
            this.Owner = Owner;
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
