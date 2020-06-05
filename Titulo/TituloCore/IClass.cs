using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
    public interface IClass
    {
        void HitDice(Character Self);
        int RollHitDice(Character Self);
        void LvlUp(Character Self);
    }
}
