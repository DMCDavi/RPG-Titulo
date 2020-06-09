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
using Windows.UI.Xaml.Media.Imaging;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace Titulo_UWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class Map : Page
    {
        private Character player;
        private string persona_name = "David", race_name = "Human";
        private Thickness margin;
        private MapBlock[,] map_matrix = new MapBlock[43, 77];
        private int grid_y = 0, grid_x = 0;

        public Map()
        {
            this.InitializeComponent();
            CriandoMapa();
            margin = MapImg.Margin;
        }

        /// <summary>
        /// Cria a matriz que referencia o mapa
        /// </summary>
        private void CriandoMapa()
        {
            for (int i = 0; i < 43; i++)
            {
                for (int j = 0; j < 77; j++)
                {
                    map_matrix[i, j] = new MapBlock();
                }
            }
            map_matrix[3, 6].isFree = false;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            player = e.Parameter as Character;
            persona_name = player.PersonaName;
            string[] race_splited = player.Race.ToString().Split(".");
            race_name = race_splited[1];

            try
            {
                CharacterImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Personagens/" + persona_name + "/Sem_fundo/" + persona_name + "_" + race_name + ".png"));
            }
            catch (Exception)
            {
                Debug.WriteLine("ERRO: Nenhuma imagem foi encontrada");
            }
            base.OnNavigatedTo(e);

        }

        /// <summary>
        /// Movimenta o personagem pra cima
        /// </summary>
        private void Up()
        {
            //Verifica se o bloco que o personagem está tentando ir está livre ou não
            if (player.posY - 1 >= 0 && map_matrix[player.posY - 1, player.posX].isFree)
            {
                //Se o personagem estiver na posição 2 do eixo y da grid e o mapa não estiver chegado no limite, o mapa se move, senão o personagem se move
                if (grid_y == 2 && margin.Top != 0)
                {
                    margin.Top += 80;
                    margin.Bottom -= 80;
                    MapImg.Margin = margin;
                    player.posY--;
                }
                else if (grid_y - 1 >= 0)
                {
                    grid_y--;
                    Grid.SetRow(CharacterImg, grid_y);
                    player.posY--;
                }
            }
        }

        /// <summary>
        /// Movimenta o personagem pra baixo
        /// </summary>
        private void Down()
        {
            //Verifica se o bloco que o personagem está tentando ir está livre ou não
            if (player.posY + 1 < 43 && map_matrix[player.posY + 1, player.posX].isFree)
            {
                //Se o personagem estiver na posição 6 do eixo y da grid e o mapa não estiver chegado no limite, o mapa se move, senão o personagem se move
                if (grid_y == 6 && margin.Bottom != 0)
                {
                    margin.Bottom += 80;
                    margin.Top -= 80;
                    MapImg.Margin = margin;
                    player.posY++;
                }
                else if (grid_y + 1 <= 8)
                {
                    grid_y++;
                    Grid.SetRow(CharacterImg, grid_y);
                    player.posY++;
                }
            }
        }

        /// <summary>
        /// Movimenta o personagem pra esquerda
        /// </summary>
        private void Left()
        {
            //Verifica se o bloco que o personagem está tentando ir está livre ou não
            if (player.posX - 1 >= 0 && map_matrix[player.posY, player.posX - 1].isFree)
            {
                //Se o personagem estiver na posição 3 do eixo x da grid e o mapa não estiver chegado no limite, o mapa se move, senão o personagem se move
                if (grid_x == 3 && margin.Left != 0)
                {
                    margin.Left += 80;
                    margin.Right -= 80;
                    MapImg.Margin = margin;
                    player.posX--;
                }
                else if (grid_x - 1 >= 0)
                {
                    grid_x--;
                    Grid.SetColumn(CharacterImg, grid_x);
                    player.posX--;
                }
            }
        }

        /// <summary>
        /// Movimenta o personagem pra direita
        /// </summary>
        private void Right()
        {
            //Verifica se o bloco que o personagem está tentando ir está livre ou não
            if (player.posX + 1 < 77 && map_matrix[player.posY, player.posX + 1].isFree)
            {
                //Se o personagem estiver na posição 12 do eixo x da grid e o mapa não estiver chegado no limite, o mapa se move, senão o personagem se move
                if (grid_x == 12 && margin.Right != 0)
                {
                    margin.Right += 80;
                    margin.Left -= 80;
                    MapImg.Margin = margin;
                    player.posX++;
                }
                else if (grid_x + 1 <= 15)
                {
                    grid_x++;
                    Grid.SetColumn(CharacterImg, grid_x);
                    player.posX++;
                }

            }
        }

        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            base.OnKeyDown(e);
            grid_x = Grid.GetColumn(CharacterImg);
            grid_y = Grid.GetRow(CharacterImg);
            margin = MapImg.Margin;
            if (e.Key == Windows.System.VirtualKey.Up)
                Up();
            else if (e.Key == Windows.System.VirtualKey.Down)
                Down();
            else if (e.Key == Windows.System.VirtualKey.Left)
                Left();
            else if (e.Key == Windows.System.VirtualKey.Right)
                Right();
            if (map_matrix[player.posY, player.posX].isEntrance)
                CharacterImg.Visibility = Visibility.Collapsed;
            else
                CharacterImg.Visibility = Visibility.Visible;
        }
    }
}
