using System;
using System.Collections.Generic;
using System.Text;

namespace Titulo
{
    abstract class Personagem
    {
        string nickmane;
        Dictionary<string,int> Atributos = new Dictionary<string, int> {
            {"STR", 10},
            {"DEX", 10},
            {"CON", 10},
            {"INT", 10},
            {"WIS", 10},
            {"CHA", 10}
        };
        public int lvl { get; set; }
        public int Hpmax { get; set; }
        public int Hp { get; set; }
        public int TotalMove { get; set; }
        public int Proficiency { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }

        public int HitDice;

        public Personagem()
        {
            lvl = 1;
            Proficiency = 2;
            TotalMove = 6;
        }
        /// <summary>
        /// Movimenta o personagem
        /// </summary>
        /// <param name="x">Posição horizontal</param>
        /// <param name="y">Posição vertical</param>
        public void Move(int x,  int y)
        {
            if (true)
            {
                posX = x;
                posY = y;
            }
        }
        public void atributos()
        {
            int pts = 25;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Voce tem {pts}\n\n");
                Console.WriteLine($"STR: {Atributos["STR"]}\nDEX: {Atributos["DEX"]}\nCON: {Atributos["CON"]}\nINT: {Atributos["INT"]}\nWIS: {Atributos["WIS"]}\nCHA: {Atributos["CHA"]}\n");
                Console.WriteLine("Q q tu q mudah?");
                var key = Console.ReadLine();
                Console.WriteLine($"Vai aumentar(1) ou diminuir(2)?");
                var a = Console.ReadLine();
                Console.WriteLine("Quanto?");
                int b = int.Parse(Console.ReadLine());
                while (b>0)
                {
                    b--;
                    if (a == "1")
                    {
                        pts -= Math.Abs(Atributos[key] / 2 - 5);
                        Atributos[key]++;
                    }
                    else if (a == "2")
                    {
                        Atributos[key]--;
                        pts += Math.Abs(Atributos[key] / 2 - 5);
                    }
                    else
                    {
                        Console.WriteLine("Ta de brinquedo?");
                    }
                }
                Console.WriteLine("Para encerrar digite done");
                a = Console.ReadLine();
                if(a == "done")
                {
                    break;
                }

            }
        }
        
        public void Reaction()
        {
            //escolha
            //AdO();
        }
        public void Action()
        {
            //Atacar
            //Magia
            //Flee
            //Mover dnv
            //Esconder
            //Postura de defesa
            //Preperar ação
            //Procurar
        }
        public void BonusAction()
        {
            //Ataque com segunda arma
            //Magias de bonus action
            //Ação ardilosa (Ladino)
        }
    }
}
