using System;
using System.Collections.Generic;
using System.Text;

namespace Titulo
{
    public interface IClass
    {
        void HitDice(Personagem Self);
        void LvlUp(Personagem Self);
        bool CanBe(Personagem Self);
        int ClassLvl();
        

    }
}
