using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;
using TituloCore;

namespace Titulo_UWP
{
    public class MapParams
    {
        public string winner { get; set; }
        public MediaPlayer media_player { get; set; }
        public Character character { get; set; }
    }
}
