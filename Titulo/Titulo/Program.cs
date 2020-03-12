using System;

namespace Titulo
{
    class Program
    {
        static void Main(string[] args)
        {
            //teste
            string classe = "Tank";
            Personagem A = new Personagem(classe, new Human(), new Vagner());
            Personagem B = new Personagem("Tank", new Human(), new Vagner())
            {
                Hpmax = 100,
                Hp = 100,
                
            }; 
            A.Create();
            B.Create();
            int[] DmgDice = { 6, 6 };
            Weapon DESGRAÇA = new Weapon("Slash","STR",DmgDice, 0, 0, A);
            Armor Pica = new Armor(10, -10, 10);
            Pica.Equip(B);
            A.EquippedWeapon = DESGRAÇA;
            A.Attack(B);
            A.Attack(B);
        }
    }
}
