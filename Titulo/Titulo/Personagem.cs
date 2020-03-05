﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Titulo
{
    public class Personagem
    {
        public IRace Race { get; set; }
        public string MainClass;
        public Dictionary<string, IClass> Class = new Dictionary<string, IClass>();
        public string nickname { get; set; }

        public Dictionary<string, IClass> AllClass = new Dictionary<string, IClass> {
            {"Tank", new Tank()},
            {"Mage", new Mage()}
        };

        public Dictionary<string,int> Atributos = new Dictionary<string, int> {
            {"STR", 1},
            {"DEX", 1},
            {"CON", 1},
            {"INT", 1},
            {"WIS", 1},
            {"CHA", 1}
        };

        /// <summary>
        /// Imunidade a um tipo de dano zera todo dano recebido daquele tipo
        /// </summary>
        public Dictionary<string, bool> Imune = new Dictionary<string, bool>
        {
            {"Slash", false},
            {"Concussion", false},
            {"Piercing", false},
            {"Acid", false},
            {"Eletric", false},
            {"Energy", false},
            {"Fire", false},
            {"Ice", false},
            {"Necrotic", false},
            {"Psychic", false},
            {"Radiante", false},
            {"Thunder", false},
            {"Poison", false}
        };

        /// <summary>
        /// Resistencia a um tipo de dano divide por 2 todo dano recebido daquele tipo
        /// </summary>
        public Dictionary<string, bool> Resist = new Dictionary<string, bool>
        {
            {"Slash", false},
            {"Concussion", false},
            {"Piercing", false},
            {"Acid", false},
            {"Eletric", false},
            {"Energy", false},
            {"Fire", false},
            {"Ice", false},
            {"Necrotic", false},
            {"Psychic", false},
            {"Radiante", false},
            {"Thunder", false},
            {"Poison", false}
        };

        /// <summary>
        /// Vulnerabilidade a um tipo de dano dobra todo dano recebido daquele tipo
        /// </summary>
        public Dictionary<string, bool> Vulnerable = new Dictionary<string, bool>
        {
            {"Slash", false},
            {"Concussion", false},
            {"Piercing", false},
            {"Acid", false},
            {"Eletric", false},
            {"Energy", false},
            {"Fire", false},
            {"Ice", false},
            {"Necrotic", false},
            {"Psychic", false},
            {"Radiante", false},
            {"Thunder", false},
            {"Poison", false}
        };

        public ArrayList Languages = new ArrayList();
        public int AC { get; set; }
        public int Lvl { get; set; }
        public int Exp { get; set; }
        public int Hpmax { get; set; }
        public int Hp { get; set; }
        public int TotalMove { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
        public int Initiative { get; set; }
        public Weapon Arminha { get; set; }
        public int HitDice;
        private int nHitDice;

        /// <summary>
        /// Retorna o lvl de conjuração do personagem
        /// </summary>
        /// <returns></returns>
        public int ConjurationLvl()
        {
            int ConjLvl = 0;
            if(Class["Mage"] != null)
                ConjLvl += Class["Mage"].ClassLvl();
            

            return ConjLvl;
        }

        public int TotalMagicSpaces(int Lvl)
        {
            int ConjLvl = ConjurationLvl();
            if ((ConjLvl + 1) / 2 < Lvl)
                return 0;
            if(Lvl == 1)
            {
                if(ConjLvl < 4)
                    return 1 + ConjLvl;
                return 4;
            }
            if(Lvl == 2)
            {
                if (ConjLvl == 3)
                    return 2;
                return 3;
            }
            if(Lvl == 3)
            {
                if (ConjLvl == 5)
                    return 2;
                return 3;
            }
            if(Lvl == 4)
            {
                if (ConjLvl < 10)
                    return ConjLvl - 6;
                return 3;
            }
            if(Lvl == 5)
            {
                if (ConjLvl == 9)
                    return 1;
                return 2;
            }
            if(Lvl == 6)
            {
                if (ConjLvl > 18)
                    return 2;
                return 1;
            }
            if(Lvl == 7)
            {
                if (ConjLvl == 20)
                    return 2;
                return 1;
            }
            return 1;
        }

        /// <summary>
        /// Construtor do personagem
        /// </summary>
        /// <param name="Class"></param>
        /// <param name="Race"></param>
        public Personagem(string Class, IRace Race)
        {
            MainClass = Class;
            this.Class.Add(Class, AllClass[Class]);
            this.Race = Race;
            Exp = 0;
            Lvl = 1;
            nHitDice = 1;
        }

        /// <summary>
        /// Retorna o bonus que é aplicado em testes que o personagem é proficiente
        /// </summary>
        /// <returns></returns>
        public int Proficiency()
        {
            return 2 + (Lvl - 1) / 4;
        }

        /// <summary>
        /// Retorna o modificador do atributo
        /// </summary>
        /// <param name="atribute"></param>
        /// <returns></returns>
        public int Modifier(string atribute)
        {
            return Atributos[atribute] / 2 - 5;
        }

        /// <summary>
        /// Função que determina se o personagem entende o idioma
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public bool Understood(string language)
        {
            foreach (string Language in Languages)
            {
                if(language == Language)
                {
                    return true;
                }
            }
            return false;
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
        /// Printa os atributos atuais
        /// </summary>
        public void ShowAtributes()
        {
            Console.WriteLine($"STR: {Atributos["STR"]}\nDEX: {Atributos["DEX"]}\nCON: {Atributos["CON"]}\nINT: {Atributos["INT"]}\nWIS: {Atributos["WIS"]}\nCHA: {Atributos["CHA"]}\n");
        }

        /// <summary>
        /// Realiza a compra de atributos da criação de personagem
        /// </summary>
        public void BuyAtributes()
        {
            RollHitDice();
            int pts = 175;
            while (true)
            {
                Console.WriteLine($"Voce tem {pts}\n\n");
                ShowAtributes();
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
        public virtual void Create()
        {
            Console.WriteLine("Iniciando a definição dos atributos");
            BuyAtributes();
            Race.AtributeInc(this);
            Race.Speed(this);
            Race.Language(this);
            Class[MainClass].HitDice(this);
            AC = 10 + (Atributos["DEX"] - 10) / 2;
            Hpmax = HitDice + (Atributos["CON"] - 10) / 2;
            Hp = Hpmax;
            Console.Clear();
            Console.WriteLine("Seus atributos após bonus da raça:");
            ShowAtributes();

            
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

        /// <summary>
        /// Rola um hit dice para curar (disponível ao realizar um descanso curto ou longo
        /// </summary>
        public void RollHitDice()
        {
            Random rand = new Random();
            if (nHitDice > 0 && Hp < Hpmax)
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
                int acerto = dice + Proficiency() + (Atributos[Arminha.Atributo] - 10) / 2 + Arminha.HitBonus;
                Console.WriteLine($"Dado: {dice}\nAcerto: {acerto}\n");
                if (acerto >= Target.AC)
                {
                    Console.WriteLine($"Hp do alvo antes: {Target.Hp}/{Target.Hpmax}");
                    int dano = Arminha.Dmg() + Atributos[Arminha.Atributo]/2 - 5;
                    Target.ReceiveDmg(dano, Arminha.Tipo);
                    Console.WriteLine($"Dano total: {dano}");
                    Console.WriteLine($"Hp dp alvo depois: {Target.Hp}/{Target.Hpmax}");
                }
                else
                {
                    Console.WriteLine("Errou!");
                }
            }
        }

        /// <summary>
        /// Aplica dano de um tipo
        /// </summary>
        /// <param name="dmg">Dano bruto</param>
        /// <param name="tipo">Tipo de dano</param>
        public void ReceiveDmg(int dmg, string tipo)
        {
            if (Imune[tipo])
                dmg = 0;
            if (Resist[tipo])
                dmg /= 2;
            if (Vulnerable[tipo])
                dmg *= 2;
            if (dmg <= 0)
                dmg = 1;
            Hp -= dmg;
        }


        /// <summary>
        /// Adiciona uma nova classe ao personagem
        /// </summary>
        /// <param name="Class"></param>
        public void MultiClass(string Class)
        {
            if (AllClass[Class].CanBe(this))
            {
                this.Class.Add(Class, AllClass[Class]);
            }
        }

        /// <summary>
        /// Aumenta o lvl de uma das classes do personagem
        /// </summary>
        /// <param name="Class"></param>
        public void LvlUp(string Class)
        {
            this.Class[Class].LvlUp(this);
        }

    }
}
