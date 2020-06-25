using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
    public interface IClass
    {
        void HitDice();
        int RollHitDice();
        void LvlUp();
        void AddActions(Character Self);
        void AddBonusActions();
        //void TurnIA();
    }
}
