using System;
using System.Collections.Generic;
using System.Text;

namespace TituloCore
{
    public class MapBlock
    {
        public bool isEntrance { get; set; } = false;
        public bool isFree { get; set; } = true;
        public bool isRoad { get; set; } = false;
        private Character character;
        public Character CharacterGetSet 
        {
            get => character;
            set
            {
                character = value;
                isFree = false;
            }
        }

        ///// <summary>
        ///// Muda a posição do personagem na matriz do mapa
        ///// </summary>
        ///// <param name="pos_x">Posição do personagem em relação ao eixo x da matriz do mapa</param>
        ///// <param name="pos_y">Posição do personagem em relação ao eixo y da matriz do mapa</param>
        //public void MoveCharacter(int pos_x, int pos_y)
        //{
        //    character
        //}

    }
}
