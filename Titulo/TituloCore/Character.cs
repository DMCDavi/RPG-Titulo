﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization;
using System.Xml;

namespace TituloCore
{
    [DataContract(Name = "Character", IsReference = true)]
    //Lista de objetos de personagem que podem ser serializados
    [KnownType(typeof(Item))]
    [KnownType(typeof(Assassin))]
    [KnownType(typeof(Bard))]
    [KnownType(typeof(Berserker))]
    [KnownType(typeof(Cleric))]
    [KnownType(typeof(Lapagod))]
    [KnownType(typeof(Mage))]
    [KnownType(typeof(Shielder))]
    [KnownType(typeof(Warrior))]
    [KnownType(typeof(Witcher))]
    [KnownType(typeof(Ana))]
    [KnownType(typeof(Bia))]
    [KnownType(typeof(David))]
    [KnownType(typeof(Fernanda))]
    [KnownType(typeof(Gean))]
    [KnownType(typeof(Grhamm))]
    [KnownType(typeof(Joao))]
    [KnownType(typeof(Lapa))]
    [KnownType(typeof(Maria))]
    [KnownType(typeof(Vagner))]
    [KnownType(typeof(Dragonborn))]
    [KnownType(typeof(Dwarf))]
    [KnownType(typeof(Elf))]
    [KnownType(typeof(God))]
    [KnownType(typeof(Goliath))]
    [KnownType(typeof(Human))]
    [KnownType(typeof(Orc))]
    [KnownType(typeof(Armor))]
    [KnownType(typeof(Weapon))]
    [KnownType(typeof(Boots))]
    public class Character
    {
        public MapBlockCore[,] Map;
        [DataMember]
        public string MainClass { get; set; }
        [DataMember]
        public string PersonaName { get; set; }
        [DataMember]
        public string RaceName { get; set; }
        [DataMember]
        public IClass CharacterClass { get; set; }
        [DataMember]
        public IRace Race { get; set; }
        [DataMember]
        public IPersona Persona { get; set; }
        [DataMember]
        public int pts { get; set; } = 30;
        [DataMember]
        public string Nickname { get; set; }
        [DataMember]
        public ArrayList Languages { get; set; } = new ArrayList();
        [DataMember]
        public int Lvl { get; set; }
        [DataMember]
        public int Exp { get; set; }
        [DataMember]
        public int Hpmax { get; set; }
        [DataMember]
        public int Hp { get; set; }
        [DataMember]
        public int TotalMove { get; set; }
        [DataMember]
        public int posX { get; set; } = 27;
        [DataMember]
        public int posY { get; set; } = 36;
        public int HomeX { get; set; }
        public int HomeY { get; set; }
        [DataMember]
        public int Initiative { get; set; }
        [DataMember]
        public Weapon EquippedWeapon { get; set; }
        [DataMember]
        public Armor EquippedArmor { get; set; }
        [DataMember]
        public Boots EquippedBoots { get; set; }
        [DataMember]
        public int HitDice { get; set; }
        [DataMember]
        public List<int> ClassDmgDices { get; set; }
        [DataMember]
        public int CritRange { get; set; }
        [DataMember]
        public int AcBonus { get; set; }
        [DataMember]
        public Character Target { get; set; }
        [DataMember]
        public List<Item> Inventory = new List<Item>();
        public int TurnMove { get; set; }
        public void SelectClass()
        {
            if (MainClass == "Assassin")
                CharacterClass = new Assassin(this);
            if (MainClass == "Bard")
                CharacterClass = new Bard(this);
            if (MainClass == "Berserker")
                CharacterClass = new Berserker(this);
            if (MainClass == "Cleric")
                CharacterClass = new Cleric(this);
            if (MainClass == "Lapagod")
                CharacterClass = new Lapagod(this);
            if (MainClass == "Mage")
                CharacterClass = new Mage(this);
            if (MainClass == "Shielder")
                CharacterClass = new Shielder(this);
            if (MainClass == "Warrior")
                CharacterClass = new Warrior(this);
            if (MainClass == "Witcher")
                CharacterClass = new Witcher(this);
        }

        public Dictionary<string, IPersona> AllPersona = new Dictionary<string, IPersona> {
            {"Ana", new Ana()},
            {"Bia", new Bia()},
            {"David", new David()},
            {"Gean", new Gean()},
            {"Fernanda", new Fernanda()},
            {"Grhamm", new Grhamm()},
            {"Joao", new Joao()},
            {"Lapa", new Lapa()},
            {"Maria", new Maria()},
            {"Vagner", new Vagner()},
        };

        public Dictionary<string, IRace> AllRace = new Dictionary<string, IRace> {
            {"Dragonborn", new Dragonborn()},
            {"Dwarf", new Dwarf()},
            {"Elf", new Elf()},
            {"God", new God()},
            {"Goliath", new Goliath()},
            {"Human", new Human()},
            {"Orc", new Orc()},
        };

        [DataMember]
        public Dictionary<string, int> Atribute = new Dictionary<string, int> {
            {"STR", 6},
            {"DEX", 6},
            {"CON", 6},
            {"INT", 6},
            {"WIS", 6},
            {"CHA", 6}
        };

        [DataMember]
        public Dictionary<string, int> MagicBonus = new Dictionary<string, int> {
            {"STR", 0},
            {"DEX", 0},
            {"CON", 0},
            {"INT", 0},
            {"WIS", 0},
            {"CHA", 0}
        };

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
        public Dictionary<string, Delegate> Action = new Dictionary<string, Delegate>();
        [DataMember]
        public Dictionary<string, Delegate> BonusAction = new Dictionary<string, Delegate>();

        /// <summary>
        /// Carrega os métodos após desserialização
        /// </summary>
        public void LoadButtons()
        {
            DefineAction();
            DefineBonusAction();
        }
        public void DefineAction()
        {
            if(!Action.ContainsKey("Attack"))
                Action.Add("Attack", new Func<bool>(() => Attack()));
            if(!Action.ContainsKey("Dash"))
                Action.Add("Dash", new Action(Dash));
            CharacterClass.AddActions(this);
        }

        public void DefineBonusAction()
        {
            //Add useitem
            CharacterClass.AddBonusActions();
        }

        /// <summary>
        /// Ação de disparada
        /// </summary>
        public void Dash()
        {
            TurnMove += TotalMove;
        }

        /// <summary>
        /// Construtor do personagem
        /// </summary>
        /// <param name="Class"></param>
        /// <param name="Race"></param>
        public Character(string Class, string Race, string Persona)
        {
            MainClass = Class;
            RaceName = Race;
            PersonaName = Persona;
            this.Race = AllRace[Race];
            Exp = 0;
            Lvl = 1;
            this.Persona = AllPersona[Persona];
            this.Persona.AtributeInc(this);
            this.Race.Speed(this);
            this.Race.Language(this);
            this.Race.AtributeInc(this);
            SelectClass();
            Hpmax = HitDice + Modifier("CON");
            Hpmax *= 10;
            Hp = Hpmax;
    
            
            CritRange = 20;
        }

        /// <summary>
        /// Retorna o bonus que é aplicado em testes que o personagem é proficiente
        /// sendo testada
        /// </summary>
        /// <returns></returns>
        public int Proficiency()
        {
            return 2 + (Lvl - 1) / 4;
        }

        /// <summary>
        /// Retorna o modificador do atributo
        /// Sendo Testada
        /// </summary>
        /// <param name="atribute"></param>
        /// <returns></returns>
        public int Modifier(string atribute)
        {
            int mod = Atribute[atribute] / 2 - 5;
            mod += MagicBonus[atribute];
            return mod;
        }

        /// <summary>
        /// Função que determina se o personagem entende o idioma
        /// sendo testada
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public bool Understood(string language)
        {
            foreach (string Language in Languages)
            {
                if (language == Language)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Sendo testada
        /// </summary>
        /// <param name="NewLang"></param>
        public void LearnLang(string NewLang)
        {
            Languages.Add(NewLang);
        }

        /// <summary>
        /// Movimenta o personagem
        /// Sendo testada
        /// </summary>
        /// <param name="x">Posição horizontal</param>
        /// <param name="y">Posição vertical</param>
        public void Move(int x, int y)
        {
            if (true)
            {
                posX = x;
                posY = y;
            }
        }

        /// <summary>
        /// Realiza a compra de Atribute da criação de personagem
        /// sendo testada
        /// </summary>
        public void BuyAtributes(String key, int signal)
        {
            int dpts;
            if (signal == 1)
            {
                dpts = Math.Abs(Modifier(key));
                if (dpts == 0)
                {
                    dpts++;
                }
                if (pts - dpts > 0)
                {
                    pts -= dpts;
                    Atribute[key]++;
                }
            }
            else if (signal == 2 && Atribute[key] > 0)
            {
                dpts = Math.Abs(Modifier(key));
                if (dpts == 0)
                {
                    dpts++;
                }
                if (Atribute[key] > 4)
                {
                    Atribute[key]--;
                    pts += dpts;
                }
            }
        }

        /// <summary>
        /// Armor Class é o valor alvo para o personagem ser acertado
        /// </summary>
        /// <returns></returns>
        public int Ac()
        {
            return EquippedArmor.Ac() + AcBonus;
        }

        /// <summary>
        /// Testa se da pra atacar
        /// Sendo Testada
        /// </summary>
        /// <param name="Target">Alvo</param>
        /// <returns></returns>
        public bool canAttack(Character Target)
        {
            if (Math.Abs(Target.posX - posX) <= EquippedWeapon.Range && Math.Abs(Target.posY - posY) <= EquippedWeapon.Range)
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
        public bool Attack()
        {
            Random rand = new Random();
            if (canAttack(Target))
            {
                int dice = 1 + rand.Next() % 20;
                int acerto = dice + Proficiency() + Modifier(EquippedWeapon.Atributo) + EquippedWeapon.HitBonus;
                if (dice >= CritRange)
                {
                    EquippedWeapon.CriticalDmg(Target);
                    return true;
                }
                if (acerto >= Target.Ac())
                {
                    EquippedWeapon.DealDmg(Target);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Aplica dano de um tipo
        /// Sendo Testada
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
            if(Hp <= 0)
            {
                Hp = 0;
                //isdead
            }
        }

        public void setHome()
        {
            HomeX = posX;
            HomeY = posY;
        }
        

        /// <summary>
        /// Aumenta o lvl de uma das classes do personagem
        /// </summary>
        /// <param name="Class"></param>
        public void LvlUp(string Class)
        {
            Lvl++;
            CharacterClass.LvlUp();
            Hpmax += 9 * (CharacterClass.RollHitDice() + Modifier("CON"));
        }

        /// <summary>
        /// Move uma casa para cima
        /// </summary>
        /// <returns></returns>
        public bool UpMoveIA()
        {
            if (posY - 1 > 0 && Map[posY - 1, posX].block == null && TurnMove > 0 && (Target.posX != posX || Target.posY-1 != posY))
            {
                Map[posY, posX].block = null;
                posY--;
                TurnMove--;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Move uma casa para cima
        /// </summary>
        /// <returns></returns>
        public bool DownMoveIA()
        {
            if (posY + 1 < 43 && Map[posY + 1, posX].block == null && TurnMove > 0 && (Target.posX != posX || Target.posY + 1 != posY))
            {
                Map[posY, posX].block = null;
                posY++;
                TurnMove--;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Move uma casa para cima
        /// </summary>
        /// <returns></returns>
        public bool LeftMoveIA()
        {
            if (posX - 1 > 0 && Map[posY, posX - 1].block == null && TurnMove > 0 && (Target.posX - 1 != posX || Target.posY != posY))
            {
                Map[posY, posX].block = null;
                posX--;
                TurnMove--;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Move uma casa para cima
        /// </summary>
        /// <returns></returns>
        public bool RightMoveIA()
        {
            if (posX + 1 < 77 && Map[posY, posX + 1].block == null && TurnMove > 0 && (Target.posX +1 != posX || Target.posY != posY))
            {
                Map[posY, posX].block = null;
                posX++;
                TurnMove--;
                return true;
            }
            return false;
        }

        //Variaveis auxiliares a IA
        public bool action;
        public bool bonusaction;

        public bool Chase()
        {
            int dx = posX - Target.posX;
            int dy = posY - Target.posY;
            // Distancia em X maior que em Y
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                // Alvo a direita
                if (dx < 0)
                {
                    if (RightMoveIA())
                        return true;
                    else
                    {
                        // Alvo a baixo
                        if (dy < 0)
                        {
                            if (!DownMoveIA())
                            {
                                if(!UpMoveIA())
                                {
                                    return LeftMoveIA();
                                }
                            }
                        }
                        // Alvo a cima
                        else
                        {
                            if (!UpMoveIA())
                            {
                                if(!DownMoveIA())
                                {
                                    return LeftMoveIA();
                                }
                            }
                        }
                    }
                }
                // Alvo a esquerda
                else
                {
                    if (LeftMoveIA())
                        return true;
                    else
                    {
                        // Alvo a baixo
                        if (dy < 0)
                        {
                            if(!DownMoveIA())
                            {
                                if(!UpMoveIA())
                                {
                                    return RightMoveIA();
                                }
                            }
                        }
                        // Alvo a cima
                        else
                        {
                            if(!UpMoveIA())
                            {
                                if (!DownMoveIA())
                                {
                                    return RightMoveIA();
                                }
                            }
                        }
                    }
                }
            }
            // Distancia em Y maior que em X
            else
            {
                // Alvo a baixo
                if (dy < 0)
                {
                    if (DownMoveIA())
                        return true;
                    else
                    {
                        // Alvo a direita
                        if (dx < 0)
                        {
                            if(!RightMoveIA())
                            {
                                if (!LeftMoveIA())
                                {
                                    return UpMoveIA();
                                }
                            }
                        }
                        // Alvo a esquerda
                        else
                        {
                            if (!LeftMoveIA())
                            {
                                if (!RightMoveIA())
                                {
                                    return UpMoveIA();
                                }
                            }
                        }
                    }
                }
                // Alvo a cima
                else
                {
                    if (UpMoveIA())
                        return true;
                    else
                    {
                        // Alvo a direita
                        if (dx < 0)
                        {
                            if (!RightMoveIA())
                            {
                                if (!LeftMoveIA())
                                {
                                    return DownMoveIA();
                                }
                            }
                        }
                        // Alvo a esquerda
                        else
                        {
                            if (!LeftMoveIA())
                            {
                                if (!RightMoveIA())
                                {
                                    return DownMoveIA();
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

    }
}
