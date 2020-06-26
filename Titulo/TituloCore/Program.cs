using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TituloCore
{
    class Program
    {
        static int[] vet = Enumerable.Range(0,501).ToArray();
        static long sharedtotal;
        static object objBlock = new object();


        public static void addRangeOfValues(int ini, int fim)
        {
            while(ini<fim)
            {
                lock(objBlock)
                {
                    Console.WriteLine("vet[{0}] = {1}", ini, vet[ini]);
                    sharedtotal += vet[ini];
                }
                ini++;
            }
        }

        static void Main(string[] args)
        {
            /*
            List<Task> tasks = new List<Task>();
            int rangeSize = 10;
            int rangeStart = 0;

            while(rangeStart < vet.Length)
            {
                int rangeEnd = rangeStart + rangeSize;
                if(rangeEnd > vet.Length)
                {
                    rangeEnd = vet.Length;
                }

                int rs = rangeStart;
                int re = rangeEnd;
                tasks.Add(Task.Run(() => addRangeOfValues(rs, re)));
                rangeStart = rangeEnd;
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("The total is : {0}", sharedtotal);


            System.Console.ReadLine();*/
            //teste
            string classe = "Tank";
            Character A = new Character(classe, "Human", "Vagner");
            Character B = new Character("Tank", "Human", "Vagner")
            {
                Hpmax = 100,
                Hp = 100,
                
            }; 
            /*
            A.Create();
            B.Create();
            */
            int[] DmgDice = { 6, 6 };
            Weapon DESGRAÇA = new Weapon("Slash","STR",DmgDice, 0, 0, 1, "DESGRAÇA");
            Armor Pica = new Armor(10, -10, 10, "Pica");
            DESGRAÇA.Equip(A);
            Pica.Equip(B);
            A.EquippedWeapon = DESGRAÇA;
            A.Target = B;
            A.Attack();
            A.Attack();
        }
    }
}
