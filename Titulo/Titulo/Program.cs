﻿using System;

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
            int[] DmgDice = { 6, 6 };
            Weapon DESGRAÇA = new Weapon("Slash","STR",DmgDice, 0, 0, A);
            A.EquippedWeapon = DESGRAÇA;
            A.Attack(B);
            A.Attack(B);
        }
    }
}
