using System;

namespace Titulo
{
    class Program
    {
        static void Main(string[] args)
        {
            //teste
            string classe = "Tank";
            Personagem A = new Personagem(classe, new Human());
            Personagem B = new Personagem("Tank", new Human())
            {
                Hpmax = 100,
                Hp = 100
            }; 
            A.Create();
            int[] krai = { 6, 6 };
            Weapon DESGRAÇA = new Weapon("DESGRAÇA","STR",krai, 0, 0, A);
            A.Arminha = DESGRAÇA;
            A.Attack(B);
            A.Attack(B);
        }
    }
}
