using System;

namespace Titulo
{
    class Program
    {
        static void Main(string[] args)
        {
            //teste
            Personagem A = new Tank();
            Personagem B = new Tank();
            B.Hpmax = 100;
            B.Hp = 100;
            A.BuyAtributes();
            int[] krai = { 6, 6 };
            Weapon DESGRAÇA = new Weapon("DESGRAÇA","CON",krai);
            A.Arminha = DESGRAÇA;
            A.Attack(B);
        }
    }
}
