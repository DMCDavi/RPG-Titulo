using System;
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
        private List<MapBlock> ImgBlocks;
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

            //Criando entradas de cavernas
            map_matrix[10, 17].isEntrance = true;// Caverna 1
            map_matrix[7, 27].isEntrance = true; // Caverna 2
            map_matrix[6, 50].isEntrance = true; // Caverna 3
            map_matrix[19, 67].isEntrance = true;// Caverna 4

            //Criando entradas de casas
            map_matrix[29, 72].isEntrance = true;// Casa 1
            map_matrix[36, 69].isEntrance = true;// Casa 2
            map_matrix[31, 43].isEntrance = true;// Casa 3
            map_matrix[35, 27].isEntrance = true;// Casa 4
            map_matrix[22, 34].isEntrance = true;// Casa 5
            map_matrix[29, 16].isEntrance = true;// Casa 6 (Casa de Lapa)
            map_matrix[40, 8].isEntrance = true; // Casa 7
            map_matrix[16, 14].isEntrance = true;// Casa 8 (Taverna)
            map_matrix[15, 26].isEntrance = true;// Casa 9
            map_matrix[14, 40].isEntrance = true;// Casa 10

            //Criando obstáculos
            map_matrix[3, 6].isFree = false;
            map_matrix[3, 7].isFree = false;
            map_matrix[2, 7].isFree = false;
            map_matrix[2, 8].isFree = false;
            map_matrix[2, 9].isFree = false;
            map_matrix[41, 7].isFree = false;
            map_matrix[42, 5].isFree = false;
            map_matrix[42, 9].isFree = false;
            map_matrix[42, 8].isFree = false;
            map_matrix[42, 7].isFree = false;
            map_matrix[42, 5].isFree = false;
            map_matrix[40, 9].isFree = false;
            map_matrix[40, 11].isFree = false;
            map_matrix[39, 13].isFree = false;
            map_matrix[39, 15].isFree = false;
            map_matrix[39, 11].isFree = false;
            map_matrix[39, 10].isFree = false;
            map_matrix[38, 12].isFree = false;
            map_matrix[38, 13].isFree = false;
            map_matrix[37, 14].isFree = false;
            map_matrix[36, 14].isFree = false;
            map_matrix[36, 10].isFree = false;
            map_matrix[35, 11].isFree = false;

            //Criando personagens
            map_matrix[30, 72].SetCharacter(new Character("Shielder", "Human", "Vagner"));// Casa 1
            map_matrix[30, 72].GetCharacter().posY = 30;
            map_matrix[30, 72].GetCharacter().posX = 72;
            map_matrix[37, 69].SetCharacter(new Character("Mage", "Dwarf", "David"));// Casa 2
            map_matrix[37, 69].GetCharacter().posY = 37;
            map_matrix[37, 69].GetCharacter().posX = 69;
            map_matrix[32, 43].SetCharacter(new Character("Witcher", "Dragonborn", "Ana"));// Casa 3
            map_matrix[32, 43].GetCharacter().posY = 32;
            map_matrix[32, 43].GetCharacter().posX = 43;
            map_matrix[23, 34].SetCharacter(new Character("Warrior", "Elf", "Maria"));// Casa 5
            map_matrix[23, 34].GetCharacter().posY = 23;
            map_matrix[23, 34].GetCharacter().posX = 34;
            map_matrix[30, 16].SetCharacter(new Character("Lapagod", "God", "Lapa"));// Casa 6 (Casa de Lapa)
            map_matrix[30, 16].GetCharacter().posY = 30;
            map_matrix[30, 16].GetCharacter().posX = 16;
            map_matrix[41, 8].SetCharacter(new Character("Shielder", "Goliath", "Bia")); // Casa 7
            map_matrix[41, 8].GetCharacter().posY = 41;
            map_matrix[41, 8].GetCharacter().posX = 8;
            map_matrix[17, 14].SetCharacter(new Character("Berserker", "Human", "Gean"));// Casa 8 (Taverna)
            map_matrix[17, 14].GetCharacter().posY = 17;
            map_matrix[17, 14].GetCharacter().posX = 14;
            map_matrix[16, 26].SetCharacter(new Character("Cleric", "Elf", "Grhamm"));// Casa 9
            map_matrix[16, 26].GetCharacter().posY = 16;
            map_matrix[16, 26].GetCharacter().posX = 26;
            map_matrix[15, 40].SetCharacter(new Character("Bard", "Human", "Joao"));// Casa 10
            map_matrix[15, 40].GetCharacter().posY = 15;
            map_matrix[15, 40].GetCharacter().posX = 40;

            //Armazena todos os blocos do mapa que possuem imagens
            ImgBlocks = new List<MapBlock>
            {
                map_matrix[30, 72],
                map_matrix[37, 69],
                map_matrix[32, 43],
                map_matrix[23, 34],
                map_matrix[30, 16],
                map_matrix[41, 8],
                map_matrix[17, 14],
                map_matrix[16, 26],
                map_matrix[15, 40]
            };


        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            player = e.Parameter as Character;
            map_matrix[player.posY, player.posX].isFree = false;
            persona_name = player.PersonaName;
            race_name = player.RaceName;

            //Preenche o mapa com as imagens dos blocos
            foreach (MapBlock block in ImgBlocks)
            {
                Debug.WriteLine(block.GetCharacter().PersonaName);
                block.SetImage(new Image(), "ms-appx:///Assets/Personagens/" + block.GetCharacter().PersonaName + "/Sem_fundo/" + block.GetCharacter().PersonaName + "_" + block.GetCharacter().RaceName + ".png", -80 + (block.GetCharacter().posX - player.posX) * 80, 0 + (block.GetCharacter().posY - player.posY) * 80, 0 + (player.posX - block.GetCharacter().posX) * 80, 80 + (player.posY - block.GetCharacter().posY) * 80);
                MapGrid.Children.Add(block.GetImage());
                Grid.SetColumnSpan(block.GetImage(), 16);
                Grid.SetRowSpan(block.GetImage(), 9);
            }

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

                    //Movimenta todas imagens presentes no mapa
                    foreach (MapBlock block in ImgBlocks)
                    {
                        block.imgMargin.Top += 80;
                        block.imgMargin.Bottom -= 80;
                        block.GetImage().Margin = block.imgMargin;
                    }

                }
                else if (grid_y - 1 >= 0)
                {
                    grid_y--;
                    Grid.SetRow(CharacterImg, grid_y);
                    player.posY--;
                }
                map_matrix[player.posY + 1, player.posX].isFree = true;
                map_matrix[player.posY, player.posX].isFree = false;
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

                    //Movimenta todas imagens presentes no mapa
                    foreach (MapBlock block in ImgBlocks)
                    {
                        block.imgMargin.Bottom += 80;
                        block.imgMargin.Top -= 80;
                        block.GetImage().Margin = block.imgMargin;
                    }

                }
                else if (grid_y + 1 <= 8)
                {
                    grid_y++;
                    Grid.SetRow(CharacterImg, grid_y);
                    player.posY++;
                }
                map_matrix[player.posY - 1, player.posX].isFree = true;
                map_matrix[player.posY, player.posX].isFree = false;
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

                    //Movimenta todas imagens presentes no mapa
                    foreach (MapBlock block in ImgBlocks)
                    {
                        block.imgMargin.Left += 80;
                        block.imgMargin.Right -= 80;
                        block.GetImage().Margin = block.imgMargin;
                    }

                }
                else if (grid_x - 1 >= 0)
                {
                    grid_x--;
                    Grid.SetColumn(CharacterImg, grid_x);
                    player.posX--;
                }
                map_matrix[player.posY, player.posX + 1].isFree = true;
                map_matrix[player.posY, player.posX].isFree = false;
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

                    //Movimenta todas imagens presentes no mapa
                    foreach (MapBlock block in ImgBlocks)
                    {
                        block.imgMargin.Right += 80;
                        block.imgMargin.Left -= 80;
                        block.GetImage().Margin = block.imgMargin;
                    }

                }
                else if (grid_x + 1 <= 15)
                {
                    grid_x++;
                    Grid.SetColumn(CharacterImg, grid_x);
                    player.posX++;
                }
                map_matrix[player.posY, player.posX - 1].isFree = true;
                map_matrix[player.posY, player.posX].isFree = false;
            }
        }

        /// <summary>
        /// Ao apertar uma seta, o personagem se move de acordo à direção apontada
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            base.OnKeyDown(e);
            grid_x = Grid.GetColumn(CharacterImg);
            grid_y = Grid.GetRow(CharacterImg);
            margin = MapImg.Margin;

            //Seta a margem de cada imagem presente no mapa
            foreach (var block in ImgBlocks)
            {
                block.imgMargin = block.GetImage().Margin;
            }

            if (e.Key == Windows.System.VirtualKey.Up)
                Up();
            else if (e.Key == Windows.System.VirtualKey.Down)
                Down();
            else if (e.Key == Windows.System.VirtualKey.Left)
                Left();
            else if (e.Key == Windows.System.VirtualKey.Right)
                Right();
            Debug.WriteLine("POS X PLAYER: " + player.posX);
            Debug.WriteLine("POS Y PLAYER: " + player.posY);
            //Se o bloco que o personagem se moveu for uma entrada, sua imagem desaparece
            if (map_matrix[player.posY, player.posX].isEntrance)
                CharacterImg.Visibility = Visibility.Collapsed;
            else
                CharacterImg.Visibility = Visibility.Visible;
        }
    }
}
