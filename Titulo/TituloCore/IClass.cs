using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
    public interface IClass
    {
        void HitDice(Character Self);
        void LvlUp(Character Self);
        bool CanBe(Character Self);
        //void ReceiveDmg(Personagem Self, int dmg);
        int ClassLvl();
        

    }
}
