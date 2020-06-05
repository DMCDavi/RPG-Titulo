using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore.Race
{
    public class God : IRace
    {
        public void AtributeInc(Character Self)
        {
            Self.pts = 999;
        }

        public void Language(Character Self)
        {
            Self.LearnLang("Todas");
            Self.LearnLang("God");
        }

        public void Speed(Character Self)
        {
            Self.TotalMove = 6;
        }
    }
}
