﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using TituloCore;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace Titulo_UWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class Map : Page
    {
        public Character player;

        private int pos_y = 0, pos_x = 0;
        public Map()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            player = e.Parameter as Character;
        }

        //Função que movimenta o personagem de acordo à tecla apertada
        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Key == Windows.System.VirtualKey.Up)
            {
                pos_x = Grid.GetColumn(CharacterImg);
                pos_y = Grid.GetRow(CharacterImg);
                if (pos_y - 1 >= 0)
                {
                    pos_y--;
                    Grid.SetRow(CharacterImg, pos_y);
                }
            }
            else if (e.Key == Windows.System.VirtualKey.Down)
            {
                pos_x = Grid.GetColumn(CharacterImg);
                pos_y = Grid.GetRow(CharacterImg);
                if (pos_y + 1 < 8)
                {
                    pos_y++;
                    Grid.SetRow(CharacterImg, pos_y);
                }
            }
            else if (e.Key == Windows.System.VirtualKey.Left)
            {
                pos_x = Grid.GetColumn(CharacterImg);
                pos_y = Grid.GetRow(CharacterImg);
                if (pos_x - 1 >= 0)
                {
                    pos_x--;
                    Grid.SetColumn(CharacterImg, pos_x);
                }
            }
            else if (e.Key == Windows.System.VirtualKey.Right)
            {
                pos_x = Grid.GetColumn(CharacterImg);
                pos_y = Grid.GetRow(CharacterImg);
                if (pos_x + 1 < 15)
                {
                    pos_x++;
                    Grid.SetColumn(CharacterImg, pos_x);
                }
            }
        }
    }
}
