using System;
using System.Collections.Generic;
using System.Text;

namespace Titulo
{
    abstract class Personagem
    {
        string nickmane;
        public Dictionary<string,int> Atributos = new Dictionary<string, int> {
            {"STR", 1},
            {"DEX", 1},
            {"CON", 1},
            {"INT", 1},
            {"WIS", 1},
            {"CHA", 1}
        };
        public int AC { get; set; }
        public int lvl { get; set; }
        public int Hpmax { get; set; }
        public int Hp { get; set; }
        public int TotalMove { get; set; }
        public int Proficiency { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
        public int Initiative { get; set; }
        public Weapon Arminha { get; set; }

        public int HitDice;
        private int nHitDice;

        public Personagem()
        {
            lvl = 1;
            Proficiency = 2;
            TotalMove = 6;
            nHitDice = 1;
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

        /// <summary>
        /// Realiza a compra de atributos da criação de personagem
        /// </summary>
        public void BuyAtributes()
        {
            rollHitDice();
            int pts = 175;
            while (true)
            {
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
                Console.Clear();
                if(a == "done")
                {
                    break;
                }

            }
        }

        /// <summary>
        /// Inicializa o personagem
        /// </summary>
        public virtual void create()
        {
            Console.WriteLine("Iniciando a definição dos atributos");
            BuyAtributes();
            AC = 10 + (Atributos["DEX"] - 10)/2;
            Hpmax = HitDice + (Atributos["CON"] - 10) / 2;
            Hp = Hpmax;
        }

        /// <summary>
        /// Vai ter um botão com a lista de Reações
        /// </summary>
        public void Reaction()
        {
            //escolha
            //AdO();
        }

        /// <summary>
        /// Vai ter um botão com essa lista de ações
        /// </summary>
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
        /// <summary>
        /// Vai ter um botão com a lista de ações bonus
        /// </summary>
        public void BonusAction()
        {
            //Ataque com segunda arma
            //Magias de bonus action
            //Ação ardilosa (Ladino)
        }
        public void rollHitDice()
        {
            Random rand = new Random();
            if (nHitDice > 0)
            {
                Hp += 1 + rand.Next()%HitDice;
                if(Hp > Hpmax)
                {
                    Hp = Hpmax;
                }
            }
        }
        
        /// <summary>
        /// Testa se da pra atacar
        /// </summary>
        /// <param name="Target">Alvo</param>
        /// <returns></returns>
        public bool canAttack(Personagem Target)
        {
            return true; //Testando

            if(Math.Abs(Target.posX - posX) <= 1 && Math.Abs(Target.posY - posY) <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Função de ataque
        /// </summary>
        /// <param name="Target">Alvo</param>
        public void Attack(Personagem Target)
        {
            Random rand = new Random();
            if(canAttack(Target))
            {
                int dice = rand.Next() % 20 + 1;
                int acerto = dice + Proficiency + (Atributos[Arminha.Atributo] - 10) / 2;
                Console.WriteLine($"Dado: {dice}\nAcerto: {acerto}\n");
                if (acerto >= Target.AC)
                {
                    Console.WriteLine($"Hp do alvo antes: {Target.Hp}/{Target.Hpmax}");
                    int dano = Arminha.Dmg() + (Atributos[Arminha.Atributo] - 10) / 2;
                    Target.Hp -= dano;
                    Console.WriteLine($"Dano total: {dano}");
                    Console.WriteLine($"Hp dp alvo depois: {Target.Hp}/{Target.Hpmax}");
                }
                else
                {
                    Console.WriteLine("Errou!");
                }
            }
        }


    }
}
