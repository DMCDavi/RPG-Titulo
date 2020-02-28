using System;
using System.Collections.Generic;
using System.Text;

namespace Titulo
{
    class Weapon
    {
        public string Tipo;
        public string Atributo;
        public int[] Dices;
        public int HitBonus;
        public int DmgBonus;

        /// <summary>
        /// Construtor da arma
        /// </summary>
        /// <param name="Tipo">Nome da arma</param>
        /// <param name="Atributo">Atributo que ela usa</param>
        /// <param name="Dices">Vetor com dados de dano</param>
        public Weapon(string Tipo, string Atributo, int[] Dices, int Hit, int Damage)
        {
            this.Tipo = Tipo;
            this.Atributo = Atributo;
            this.Dices = Dices;
            HitBonus = Hit;
            DmgBonus = Damage;
        }

        /// <summary>
        /// Roda os dados de dano da arma
        /// </summary>
        /// <returns></returns>
        public int Dmg()
        {
            int damage = 0, daninho = 0;
            Random rand = new Random();
            Console.WriteLine("\nDados de dano:");
            foreach(int Dice in Dices)
            {
                daninho = 1 + (rand.Next() % Dice);
                Console.WriteLine($"{daninho}");
                damage += daninho;
            }
            damage += DmgBonus;
            return damage;
        }
    }
}
