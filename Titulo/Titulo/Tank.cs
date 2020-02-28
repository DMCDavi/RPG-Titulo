using System;
using System.Collections.Generic;
using System.Text;

namespace Titulo
{
    class Tank : Personagem
    {
        public Boolean secret = false;
        public Tank():base()
        {
            HitDice = 20;
        }
        public override void Create()
        {
            Console.WriteLine("Iniciando a definição dos atributos");
            BuyAtributes();
            if(Atributos["STR"] == 1 && Atributos["DEX"] == 1 && Atributos["CON"] == 35 && Atributos["INT"] == 1 && Atributos["WIS"] == 1 && Atributos["CHA"] == 1){
                secret = true;
                Atributos["CON"] *= 2;
            }
            AC = 10 + (Atributos["DEX"] - 10) / 2;
            Hpmax = HitDice + (Atributos["CON"] - 10) / 2;
            Hp = Hpmax;
        }
    }
}
