using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization;
using System.Xml;

namespace TituloCore
{
    [DataContract(Name = "Character", Namespace = "http://www.contoso.com")]
    //Lista de objetos de personagem que podem ser serializados
    [KnownType(typeof(Assassin))]
    [KnownType(typeof(Bard))]
    [KnownType(typeof(Berserker))]
    [KnownType(typeof(Cleric))]
    [KnownType(typeof(Mage))]
    [KnownType(typeof(Shielder))]
    [KnownType(typeof(Tank))]
    [KnownType(typeof(Warrior))]
    [KnownType(typeof(Witcher))]
    [KnownType(typeof(Ana))]
    [KnownType(typeof(Bia))]
    [KnownType(typeof(David))]
    [KnownType(typeof(Fernanda))]
    [KnownType(typeof(Gean))]
    [KnownType(typeof(Grhamm))]
    [KnownType(typeof(Joao))]
    [KnownType(typeof(Maria))]
    [KnownType(typeof(Vagner))]
    [KnownType(typeof(Dragonborn))]
    [KnownType(typeof(Dwarf))]
    [KnownType(typeof(Elf))]
    [KnownType(typeof(Goliath))]
    [KnownType(typeof(Human))]
    [KnownType(typeof(Orc))]
    [KnownType(typeof(Armor))]
    [KnownType(typeof(Weapon))]
    public class Character
    {
        [DataMember]
        public string MainClass { get; set; }
        [DataMember]
        public string SpritePath { get; set; }
        [DataMember]
        public IRace Race { get; set; }
        [DataMember]
        public IPersona Persona { get; set; }
        [DataMember]
        public int pts { get; set; } = 30;
        [DataMember]
        public List<IClass> Class { get; set; } = new List<IClass>();
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
        public int posX { get; set; }
        [DataMember]
        public int posY { get; set; }
        [DataMember]
        public int Initiative { get; set; }
        [DataMember]
        public Weapon EquippedWeapon { get; set; }
        [DataMember]
        public Armor EquippedArmor { get; set; }
        [DataMember]
        public int HitDice { get; set; }
        [DataMember]
        private int nHitDice { get; set; }
        [DataMember]
        public Armor NaturalArmor { get; set; }
        [DataMember]
        public List<int> ClassDmgDices;

        public Dictionary<string, IClass> AllClass = new Dictionary<string, IClass> {
            {"Assassin", new Assassin()},
            {"Bard", new Bard()},
            {"Berserker", new Berserker()},
            {"Cleric", new Cleric()},
            {"Mage", new Mage()},
            {"Shielder", new Shielder()},
            {"Tank", new Tank()},
            {"Warrior", new Warrior()},
            {"Witcher", new Witcher()},
        };

        public Dictionary<string, IPersona> AllPersona = new Dictionary<string, IPersona> {
            {"Ana", new Ana()},
            {"Bia", new Bia()},
            {"David", new David()},
            {"Gean", new Gean()},
            {"Fernanda", new Fernanda()},
            {"Grhamm", new Grhamm()},
            {"Joao", new Joao()},
            {"Maria", new Maria()},
            {"Vagner", new Vagner()},
        };

        public Dictionary<string, IRace> AllRace = new Dictionary<string, IRace> {
            {"Dragonborn", new Dragonborn()},
            {"Dwarf", new Dwarf()},
            {"Elf", new Elf()},
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

        /// <summary>
        /// Retorna o lvl de conjuração do personagem
        /// Sendo Testada
        /// </summary>
        /// <returns></returns>
        public int ConjurationLvl()
        {
            int ConjLvl = 0;
            foreach (IClass iclass in Class)
            {
                if (iclass.GetType() == new Mage().GetType())
                {
                    ConjLvl += iclass.ClassLvl();
                }
            }

            /*if(Class["Mage"] != null)
                ConjLvl += Class["Mage"].ClassLvl();
            */

            return ConjLvl;
        }
        /// <summary>
        /// Sendo testada
        /// </summary>
        /// <param name="Lvl"></param>
        /// <returns></returns>
        public int TotalMagicSpaces(int Lvl)
        {
            int ConjLvl = ConjurationLvl();
            if ((ConjLvl + 1) / 2 < Lvl)
                return 0;
            if (Lvl == 1)
            {
                if (ConjLvl < 4)
                    return 1 + ConjLvl;
                return 4;
            }
            if (Lvl == 2)
            {
                if (ConjLvl == 3)
                    return 2;
                return 3;
            }
            if (Lvl == 3)
            {
                if (ConjLvl == 5)
                    return 2;
                return 3;
            }
            if (Lvl == 4)
            {
                if (ConjLvl < 10)
                    return ConjLvl - 6;
                return 3;
            }
            if (Lvl == 5)
            {
                if (ConjLvl == 9)
                    return 1;
                return 2;
            }
            if (Lvl == 6)
            {
                if (ConjLvl > 18)
                    return 2;
                return 1;
            }
            if (Lvl == 7)
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
        public Character(string Class, string Race, string Persona)
        {
            MainClass = Class;
            this.Class.Add(AllClass[Class]);
            this.Race = AllRace[Race];
            Exp = 0;
            Lvl = 1;
            nHitDice = 1;
            this.Persona = AllPersona[Persona];
            this.Persona.AtributeInc(this);
            this.Race.Speed(this);
            this.Race.Language(this);
            this.Race.AtributeInc(this);
            this.Class[0].HitDice(this);
            Hpmax = HitDice + Modifier("CON");
            Hp = Hpmax;
            NaturalArmor = new Armor(10, -10, 20);
            EquippedArmor = NaturalArmor;
            EquippedArmor.Equip(this);
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
        /// Printa os Atribute atuais
        /// </summary>
        public void ShowAtributes()
        {
            Console.WriteLine($"STR: {Atribute["STR"]}\nDEX: {Atribute["DEX"]}\nCON: {Atribute["CON"]}\nINT: {Atribute["INT"]}\nWIS: {Atribute["WIS"]}\nCHA: {Atribute["CHA"]}\n");
        }

        /// <summary>
        /// Realiza a compra de Atribute da criação de personagem
        /// sendo testada
        /// </summary>
        public void BuyAtributes(String key, int signal)
        {
            RollHitDice();
            ShowAtributes();
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
        /// Rola um hit dice para curar (disponível ao realizar um descanso curto ou longo
        /// </summary>
        public void RollHitDice()
        {
            Random rand = new Random();
            if (nHitDice > 0 && Hp < Hpmax)
            {
                Hp += 1 + rand.Next() % HitDice;
                if (Hp > Hpmax)
                {
                    Hp = Hpmax;
                }
            }
        }

        public int Ac()
        {
            return EquippedArmor.Ac();
        }

        /// <summary>
        /// Testa se da pra atacar
        /// Sendo Testada
        /// </summary>
        /// <param name="Target">Alvo</param>
        /// <returns></returns>
        public bool canAttack(Character Target)
        {
            return true; //testando

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
        public void Attack(Character Target)
        {
            Random rand = new Random();
            if (canAttack(Target))
            {
                int dice = rand.Next() % 20 + 1;
                int acerto = dice + Proficiency() + Modifier(EquippedWeapon.Atributo) + EquippedWeapon.HitBonus;
                Console.WriteLine($"Dado: {dice}\nAcerto: {acerto}\n");
                if (acerto >= Target.Ac())
                {
                    Console.WriteLine($"Hp do alvo antes: {Target.Hp}/{Target.Hpmax}");
                    EquippedWeapon.DealDmg(Target);
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
        /// Sendo Testada
        /// </summary>
        /// <param name="dmg">Dano bruto</param>
        /// <param name="tipo">Tipo de dano</param>
        public void ReceiveDmg(int dmg, string tipo)
        {
            /*foreach(IClass iclass in Class)
            {
                iclass.ReceiveDmg(this, dmg);
            }*/

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
                this.Class.Add(AllClass[Class]);
            }
        }

        /// <summary>
        /// Aumenta o lvl de uma das classes do personagem
        /// </summary>
        /// <param name="Class"></param>
        public void LvlUp(string Class)
        {
            //this.Class[Class].LvlUp(this);
        }

    }
}
