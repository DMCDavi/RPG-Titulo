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
using Windows.UI;
using Windows.Media.Playback;
using Windows.Media.Core;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace Titulo_UWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class Map : Page
    {
        private Character player, ana, bia, davi, fernanda, geao, grao, joao, lapa, maria, vago, nearest_enemy;
        private string persona_name = "David", race_name = "Human";
        private Thickness margin;
        private MapBlock[,] map_matrix = new MapBlock[43, 77];
        private List<MapBlock> ImgBlocks;
        private List<Character> EnemiesInRange = new List<Character>();
        private int grid_y = 0, grid_x = 0;
        private bool hasEnemyInRange = false, isPlayerTurn = false, moveActivated = false;
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private Image heart_img;
        private List<Image> Inv = new List<Image>();


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

            Inv.Add(item0);
            Inv.Add(item1);
            Inv.Add(item2);
            Inv.Add(item3);
            Inv.Add(item4);
            Inv.Add(item5);
            Inv.Add(item6);
            Inv.Add(item7);
            Inv.Add(item8);
            Inv.Add(item9);
            Inv.Add(item10);
            Inv.Add(item11);
            Inv.Add(item12);
            Inv.Add(item13);
            Inv.Add(item14);
            Inv.Add(item15);
            Inv.Add(item16);
            Inv.Add(item17);
            Inv.Add(item18);
            Inv.Add(item19);
            Inv.Add(item20);
            Inv.Add(item21);
            Inv.Add(item22);
            Inv.Add(item23);
            Inv.Add(item24);

            //Criando entradas de cavernas
            map_matrix[10, 17].block = new Cave();
            map_matrix[7, 27].block = new Cave();
            map_matrix[6, 50].block = new Cave();
            map_matrix[19, 67].block = new Cave();
            map_matrix[13, 70].block = new Cave();

            //Criando entradas de casas
            map_matrix[29, 72].block = new Door();// Casa 1
            map_matrix[36, 69].block = new Door();// Casa 2
            map_matrix[31, 43].block = new Door();// Casa 3
            map_matrix[35, 27].block = new Door();// Casa 4
            map_matrix[22, 34].block = new Door();// Casa 5
            map_matrix[29, 16].block = new Door();// Casa 6 (Casa de Lapa)
            map_matrix[40, 8].block = new Door(); // Casa 7
            map_matrix[16, 14].block = new Door();// Casa 8 (Taverna)
            map_matrix[15, 26].block = new Door();// Casa 9
            map_matrix[14, 40].block = new Door();// Casa 10

            //Criando obstáculos
            map_matrix[3, 6].block = new Obstacle();
            map_matrix[3, 7].block = new Obstacle();
            map_matrix[2, 7].block = new Obstacle();
            map_matrix[2, 8].block = new Obstacle();
            map_matrix[2, 9].block = new Obstacle();
            map_matrix[41, 7].block = new Obstacle();
            map_matrix[42, 9].block = new Obstacle();
            map_matrix[41, 6].block = new Obstacle();
            map_matrix[42, 5].block = new Obstacle();
            map_matrix[40, 11].block = new Obstacle();
            map_matrix[39, 13].block = new Obstacle();
            map_matrix[39, 15].block = new Obstacle();
            map_matrix[39, 11].block = new Obstacle();
            map_matrix[39, 10].block = new Obstacle();
            map_matrix[38, 12].block = new Obstacle();
            map_matrix[38, 13].block = new Obstacle();
            map_matrix[37, 14].block = new Obstacle();
            map_matrix[36, 14].block = new Obstacle();
            map_matrix[36, 10].block = new Obstacle();
            map_matrix[35, 11].block = new Obstacle();
            map_matrix[36, 16].block = new Obstacle();
            map_matrix[37, 17].block = new Obstacle();
            map_matrix[38, 17].block = new Obstacle();
            map_matrix[37, 18].block = new Obstacle();
            map_matrix[38, 21].block = new Obstacle();
            map_matrix[37, 21].block = new Obstacle();
            map_matrix[36, 21].block = new Obstacle();
            map_matrix[35, 21].block = new Obstacle();
            map_matrix[37, 20].block = new Obstacle();
            map_matrix[35, 20].block = new Obstacle();
            map_matrix[35, 22].block = new Obstacle();
            map_matrix[41, 18].block = new Obstacle();
            map_matrix[40, 19].block = new Obstacle();
            map_matrix[40, 19].block = new Obstacle();
            map_matrix[42, 19].block = new Obstacle();
            map_matrix[42, 20].block = new Obstacle();
            map_matrix[42, 21].block = new Obstacle();
            map_matrix[39, 23].block = new Obstacle();
            map_matrix[39, 24].block = new Obstacle();
            map_matrix[40, 24].block = new Obstacle();
            map_matrix[38, 24].block = new Obstacle();
            map_matrix[38, 23].block = new Obstacle();
            map_matrix[36, 25].block = new Obstacle();
            map_matrix[36, 28].block = new Obstacle();
            map_matrix[42, 59].block = new Obstacle();
            map_matrix[12, 42].block = new Obstacle();
            map_matrix[11, 42].block = new Obstacle();
            map_matrix[10, 42].block = new Obstacle();
            map_matrix[13, 30].block = new Obstacle();
            map_matrix[13, 29].block = new Obstacle();
            map_matrix[13, 28].block = new Obstacle();
            map_matrix[12, 30].block = new Obstacle();
            map_matrix[12, 31].block = new Obstacle();
            map_matrix[12, 32].block = new Obstacle();
            map_matrix[12, 33].block = new Obstacle();
            map_matrix[12, 34].block = new Obstacle();
            map_matrix[12, 35].block = new Obstacle();
            map_matrix[12, 36].block = new Obstacle();
            map_matrix[12, 37].block = new Obstacle();
            map_matrix[13, 23].block = new Obstacle();
            map_matrix[12, 23].block = new Obstacle();
            map_matrix[11, 23].block = new Obstacle();
            map_matrix[10, 23].block = new Obstacle();
            map_matrix[9, 23].block = new Obstacle();

            //Casa do player
            map_matrix[35, 25].block = new House();
            map_matrix[34, 25].block = new House();
            map_matrix[33, 25].block = new House();
            map_matrix[32, 25].block = new House();
            map_matrix[31, 25].block = new House();
            map_matrix[31, 26].block = new House();
            map_matrix[31, 27].block = new House();
            map_matrix[31, 28].block = new House();
            map_matrix[32, 28].block = new House();
            map_matrix[33, 28].block = new House();
            map_matrix[34, 28].block = new House();
            map_matrix[35, 28].block = new House();
            map_matrix[35, 26].block = new House();
            map_matrix[34, 27].block = new House();

            //Casa de Bia
            map_matrix[36, 6].block = new House();
            map_matrix[36, 7].block = new House();
            map_matrix[36, 8].block = new House();
            map_matrix[36, 9].block = new House();
            map_matrix[36, 6].block = new House();
            map_matrix[37, 8].block = new House();
            map_matrix[37, 7].block = new House();
            map_matrix[37, 6].block = new House();
            map_matrix[37, 9].block = new House();
            map_matrix[38, 9].block = new House();
            map_matrix[38, 8].block = new House();
            map_matrix[38, 7].block = new House();
            map_matrix[38, 6].block = new House();
            map_matrix[39, 9].block = new House();
            map_matrix[39, 8].block = new House();
            map_matrix[39, 7].block = new House();
            map_matrix[39, 6].block = new House();
            map_matrix[40, 6].block = new House();
            map_matrix[40, 7].block = new House();
            map_matrix[40, 9].block = new House();

            //Casa de Ana
            map_matrix[27, 41].block = new House();
            map_matrix[27, 42].block = new House();
            map_matrix[27, 43].block = new House();
            map_matrix[27, 44].block = new House();
            map_matrix[28, 41].block = new House();
            map_matrix[28, 42].block = new House();
            map_matrix[28, 43].block = new House();
            map_matrix[28, 44].block = new House();
            map_matrix[29, 41].block = new House();
            map_matrix[29, 42].block = new House();
            map_matrix[29, 43].block = new House();
            map_matrix[29, 44].block = new House();
            map_matrix[30, 41].block = new House();
            map_matrix[30, 42].block = new House();
            map_matrix[30, 43].block = new House();
            map_matrix[30, 44].block = new House();
            map_matrix[31, 41].block = new House();
            map_matrix[31, 42].block = new House();
            map_matrix[31, 44].block = new House();

            //Casa de David
            map_matrix[36, 67].block = new House();
            map_matrix[36, 68].block = new House();
            map_matrix[36, 70].block = new House();
            map_matrix[35, 67].block = new House();
            map_matrix[35, 68].block = new House();
            map_matrix[35, 69].block = new House();
            map_matrix[35, 70].block = new House();
            map_matrix[34, 67].block = new House();
            map_matrix[34, 68].block = new House();
            map_matrix[34, 69].block = new House();
            map_matrix[34, 70].block = new House();
            map_matrix[33, 67].block = new House();
            map_matrix[33, 68].block = new House();
            map_matrix[33, 69].block = new House();
            map_matrix[33, 70].block = new House();
            map_matrix[32, 67].block = new House();
            map_matrix[32, 68].block = new House();
            map_matrix[32, 69].block = new House();
            map_matrix[32, 70].block = new House();

            //Casa de Vagner
            map_matrix[25, 74].block = new House();
            map_matrix[25, 73].block = new House();
            map_matrix[25, 72].block = new House();
            map_matrix[25, 71].block = new House();
            map_matrix[26, 74].block = new House();
            map_matrix[26, 73].block = new House();
            map_matrix[26, 72].block = new House();
            map_matrix[26, 71].block = new House();
            map_matrix[27, 74].block = new House();
            map_matrix[27, 73].block = new House();
            map_matrix[27, 72].block = new House();
            map_matrix[27, 71].block = new House();
            map_matrix[28, 74].block = new House();
            map_matrix[28, 73].block = new House();
            map_matrix[28, 72].block = new House();
            map_matrix[28, 71].block = new House();
            map_matrix[29, 74].block = new House();
            map_matrix[29, 73].block = new House();
            map_matrix[29, 72].block = new House();
            map_matrix[29, 71].block = new House();

            //Casa de João
            map_matrix[12, 38].block = new House();
            map_matrix[12, 39].block = new House();
            map_matrix[12, 40].block = new House();
            map_matrix[12, 41].block = new House();
            map_matrix[13, 38].block = new House();
            map_matrix[13, 39].block = new House();
            map_matrix[13, 40].block = new House();
            map_matrix[13, 41].block = new House();
            map_matrix[14, 38].block = new House();
            map_matrix[14, 39].block = new House();
            map_matrix[14, 41].block = new House();

            //Casa de Grhamm
            map_matrix[13, 27].block = new House();
            map_matrix[13, 26].block = new House();
            map_matrix[13, 25].block = new House();
            map_matrix[13, 24].block = new House();
            map_matrix[14, 24].block = new House();
            map_matrix[15, 24].block = new House();
            map_matrix[14, 25].block = new House();
            map_matrix[15, 25].block = new House();
            map_matrix[14, 26].block = new House();
            map_matrix[15, 27].block = new House();
            map_matrix[14, 27].block = new House();

            //Casa de Maria
            map_matrix[18, 33].block = new House();
            map_matrix[18, 34].block = new House();
            map_matrix[18, 35].block = new House();
            map_matrix[18, 36].block = new House();
            map_matrix[19, 33].block = new House();
            map_matrix[19, 34].block = new House();
            map_matrix[19, 35].block = new House();
            map_matrix[19, 36].block = new House();
            map_matrix[20, 33].block = new House();
            map_matrix[20, 34].block = new House();
            map_matrix[20, 35].block = new House();
            map_matrix[20, 36].block = new House();
            map_matrix[21, 33].block = new House();
            map_matrix[21, 34].block = new House();
            map_matrix[21, 35].block = new House();
            map_matrix[21, 36].block = new House();
            map_matrix[22, 33].block = new House();
            map_matrix[22, 35].block = new House();
            map_matrix[22, 36].block = new House();

            //Casa de Gean
            map_matrix[11, 11].block = new House();
            map_matrix[12, 11].block = new House();
            map_matrix[13, 11].block = new House();
            map_matrix[14, 11].block = new House();
            map_matrix[15, 11].block = new House();
            map_matrix[16, 11].block = new House();
            map_matrix[16, 12].block = new House();
            map_matrix[16, 13].block = new House();
            map_matrix[11, 14].block = new House();
            map_matrix[11, 10].block = new House();
            map_matrix[12, 10].block = new House();
            map_matrix[13, 10].block = new House();
            map_matrix[14, 10].block = new House();
            map_matrix[15, 10].block = new House();
            map_matrix[16, 10].block = new House();
            map_matrix[16, 15].block = new House();
            map_matrix[10, 12].block = new House();
            map_matrix[10, 13].block = new House();
            map_matrix[10, 14].block = new House();
            map_matrix[12, 15].block = new House();
            map_matrix[13, 15].block = new House();
            map_matrix[14, 15].block = new House();
            map_matrix[15, 15].block = new House();
            map_matrix[16, 15].block = new House();

            //Casa de Lapa
            map_matrix[23, 14].block = new House();
            map_matrix[23, 15].block = new House();
            map_matrix[23, 16].block = new House();
            map_matrix[23, 17].block = new House();
            map_matrix[23, 18].block = new House();
            map_matrix[24, 19].block = new House();
            map_matrix[24, 20].block = new House();
            map_matrix[24, 19].block = new House();
            map_matrix[24, 20].block = new House();
            map_matrix[25, 19].block = new House();
            map_matrix[26, 20].block = new House();
            map_matrix[27, 19].block = new House();
            map_matrix[27, 20].block = new House();
            map_matrix[28, 19].block = new House();
            map_matrix[28, 20].block = new House();
            map_matrix[29, 19].block = new House();
            map_matrix[29, 20].block = new House();
            map_matrix[25, 20].block = new House();
            map_matrix[29, 12].block = new House();
            map_matrix[29, 13].block = new House();
            map_matrix[29, 14].block = new House();
            map_matrix[29, 15].block = new House();
            map_matrix[29, 17].block = new House();
            map_matrix[29, 18].block = new House();
            map_matrix[29, 19].block = new House();
            map_matrix[28, 12].block = new House();
            map_matrix[28, 13].block = new House();
            map_matrix[28, 14].block = new House();
            map_matrix[28, 15].block = new House();
            map_matrix[27, 12].block = new House();
            map_matrix[26, 12].block = new House();
            map_matrix[25, 12].block = new House();
            map_matrix[24, 13].block = new House();
            map_matrix[24, 12].block = new House();

            //Criando água profunda
            map_matrix[33, 58].block = new Water();
            map_matrix[32, 58].block = new Water();
            map_matrix[30, 58].block = new Water();
            map_matrix[30, 57].block = new Water();
            map_matrix[29, 57].block = new Water();
            map_matrix[29, 56].block = new Water();
            map_matrix[28, 56].block = new Water();
            map_matrix[28, 55].block = new Water();
            map_matrix[27, 56].block = new Water();
            map_matrix[29, 59].block = new Water();
            map_matrix[28, 60].block = new Water();
            map_matrix[27, 61].block = new Water();
            map_matrix[26, 62].block = new Water();
            map_matrix[25, 62].block = new Water();
            map_matrix[24, 63].block = new Water();
            map_matrix[23, 63].block = new Water();
            map_matrix[22, 64].block = new Water();
            map_matrix[22, 63].block = new Water();
            map_matrix[22, 62].block = new Water();
            map_matrix[23, 62].block = new Water();
            map_matrix[24, 62].block = new Water();
            map_matrix[24, 61].block = new Water();
            map_matrix[25, 61].block = new Water();
            map_matrix[26, 61].block = new Water();
            map_matrix[26, 60].block = new Water();
            map_matrix[27, 60].block = new Water();
            map_matrix[27, 59].block = new Water();
            map_matrix[28, 59].block = new Water();
            map_matrix[28, 58].block = new Water();
            map_matrix[28, 57].block = new Water();

            //Criando montanhas
            map_matrix[2, 0].block = new Mountain();
            map_matrix[3, 1].block = new Mountain();
            map_matrix[3, 2].block = new Mountain();
            map_matrix[3, 3].block = new Mountain();
            map_matrix[2, 4].block = new Mountain();
            map_matrix[2, 5].block = new Mountain();
            map_matrix[1, 6].block = new Mountain();
            map_matrix[1, 7].block = new Mountain();
            map_matrix[0, 7].block = new Mountain();
            map_matrix[9, 0].block = new Mountain();
            map_matrix[8, 1].block = new Mountain();
            map_matrix[7, 2].block = new Mountain();
            map_matrix[7, 3].block = new Mountain();
            map_matrix[6, 4].block = new Mountain();
            map_matrix[6, 5].block = new Mountain();
            map_matrix[5, 6].block = new Mountain();
            map_matrix[5, 7].block = new Mountain();
            map_matrix[5, 8].block = new Mountain();
            map_matrix[6, 8].block = new Mountain();
            map_matrix[7, 8].block = new Mountain();
            map_matrix[7, 7].block = new Mountain();
            map_matrix[7, 6].block = new Mountain();
            map_matrix[8, 5].block = new Mountain();
            map_matrix[8, 4].block = new Mountain();
            map_matrix[9, 3].block = new Mountain();
            map_matrix[9, 2].block = new Mountain();
            map_matrix[10, 1].block = new Mountain();
            map_matrix[11, 0].block = new Mountain();
            map_matrix[5, 10].block = new Mountain();
            map_matrix[6, 10].block = new Mountain();
            map_matrix[6, 11].block = new Mountain();
            map_matrix[6, 12].block = new Mountain();
            map_matrix[7, 13].block = new Mountain();
            map_matrix[7, 14].block = new Mountain();
            map_matrix[8, 15].block = new Mountain();
            map_matrix[8, 16].block = new Mountain();
            map_matrix[8, 17].block = new Mountain();
            map_matrix[8, 18].block = new Mountain();
            map_matrix[8, 19].block = new Mountain();
            map_matrix[7, 20].block = new Mountain();
            map_matrix[7, 21].block = new Mountain();
            map_matrix[6, 22].block = new Mountain();
            map_matrix[6, 23].block = new Mountain();
            map_matrix[5, 24].block = new Mountain();
            map_matrix[5, 25].block = new Mountain();
            map_matrix[5, 26].block = new Mountain();
            map_matrix[5, 27].block = new Mountain();
            map_matrix[5, 28].block = new Mountain();
            map_matrix[4, 29].block = new Mountain();
            map_matrix[4, 30].block = new Mountain();
            map_matrix[5, 30].block = new Mountain();
            map_matrix[3, 31].block = new Mountain();
            map_matrix[3, 32].block = new Mountain();
            map_matrix[2, 33].block = new Mountain();
            map_matrix[2, 34].block = new Mountain();
            map_matrix[2, 35].block = new Mountain();
            map_matrix[2, 36].block = new Mountain();
            map_matrix[3, 37].block = new Mountain();
            map_matrix[5, 38].block = new Mountain();
            map_matrix[4, 38].block = new Mountain();
            map_matrix[6, 39].block = new Mountain();
            map_matrix[6, 40].block = new Mountain();
            map_matrix[7, 41].block = new Mountain();
            map_matrix[7, 42].block = new Mountain();
            map_matrix[7, 43].block = new Mountain();
            map_matrix[8, 44].block = new Mountain();
            map_matrix[8, 45].block = new Mountain();
            map_matrix[9, 46].block = new Mountain();
            map_matrix[9, 47].block = new Mountain();
            map_matrix[7, 10].block = new Mountain();
            map_matrix[8, 10].block = new Mountain();
            map_matrix[8, 11].block = new Mountain();
            map_matrix[8, 12].block = new Mountain();
            map_matrix[9, 13].block = new Mountain();
            map_matrix[9, 14].block = new Mountain();
            map_matrix[10, 15].block = new Mountain();
            map_matrix[10, 16].block = new Mountain();
            map_matrix[9, 17].block = new Mountain();
            map_matrix[10, 18].block = new Mountain();
            map_matrix[10, 19].block = new Mountain();
            map_matrix[9, 20].block = new Mountain();
            map_matrix[9, 21].block = new Mountain();
            map_matrix[8, 22].block = new Mountain();
            map_matrix[8, 23].block = new Mountain();
            map_matrix[7, 24].block = new Mountain();
            map_matrix[7, 25].block = new Mountain();
            map_matrix[7, 26].block = new Mountain();
            map_matrix[6, 26].block = new Mountain();
            map_matrix[6, 27].block = new Mountain();
            map_matrix[6, 28].block = new Mountain();
            map_matrix[7, 28].block = new Mountain();
            map_matrix[6, 29].block = new Mountain();
            map_matrix[6, 30].block = new Mountain();
            map_matrix[5, 31].block = new Mountain();
            map_matrix[5, 32].block = new Mountain();
            map_matrix[4, 33].block = new Mountain();
            map_matrix[4, 34].block = new Mountain();
            map_matrix[4, 35].block = new Mountain();
            map_matrix[4, 36].block = new Mountain();
            map_matrix[5, 37].block = new Mountain();
            map_matrix[6, 38].block = new Mountain();
            map_matrix[7, 39].block = new Mountain();
            map_matrix[8, 39].block = new Mountain();
            map_matrix[8, 40].block = new Mountain();
            map_matrix[9, 41].block = new Mountain();
            map_matrix[9, 42].block = new Mountain();
            map_matrix[9, 43].block = new Mountain();
            map_matrix[10, 44].block = new Mountain();
            map_matrix[10, 45].block = new Mountain();
            map_matrix[10, 46].block = new Mountain();
            map_matrix[10, 47].block = new Mountain();
            map_matrix[11, 46].block = new Mountain();
            map_matrix[11, 47].block = new Mountain();
            map_matrix[0, 16].block = new Mountain();
            map_matrix[1, 17].block = new Mountain();
            map_matrix[1, 18].block = new Mountain();
            map_matrix[1, 19].block = new Mountain();
            map_matrix[1, 20].block = new Mountain();
            map_matrix[2, 21].block = new Mountain();
            map_matrix[2, 22].block = new Mountain();
            map_matrix[1, 22].block = new Mountain();
            map_matrix[0, 23].block = new Mountain();
            map_matrix[0, 24].block = new Mountain();
            map_matrix[0, 44].block = new Mountain();
            map_matrix[1, 44].block = new Mountain();
            map_matrix[1, 45].block = new Mountain();
            map_matrix[1, 46].block = new Mountain();
            map_matrix[2, 47].block = new Mountain();
            map_matrix[3, 47].block = new Mountain();
            map_matrix[4, 48].block = new Mountain();
            map_matrix[5, 49].block = new Mountain();
            map_matrix[5, 50].block = new Mountain();
            map_matrix[6, 51].block = new Mountain();
            map_matrix[6, 52].block = new Mountain();
            map_matrix[7, 53].block = new Mountain();
            map_matrix[7, 54].block = new Mountain();
            map_matrix[7, 55].block = new Mountain();
            map_matrix[8, 56].block = new Mountain();
            map_matrix[8, 57].block = new Mountain();
            map_matrix[9, 58].block = new Mountain();
            map_matrix[9, 59].block = new Mountain();
            map_matrix[10, 60].block = new Mountain();
            map_matrix[10, 61].block = new Mountain();
            map_matrix[10, 62].block = new Mountain();
            map_matrix[10, 63].block = new Mountain();
            map_matrix[10, 64].block = new Mountain();
            map_matrix[9, 65].block = new Mountain();
            map_matrix[9, 66].block = new Mountain();
            map_matrix[8, 67].block = new Mountain();
            map_matrix[8, 68].block = new Mountain();
            map_matrix[7, 69].block = new Mountain();
            map_matrix[6, 69].block = new Mountain();
            map_matrix[5, 70].block = new Mountain();
            map_matrix[4, 70].block = new Mountain();
            map_matrix[3, 71].block = new Mountain();
            map_matrix[2, 71].block = new Mountain();
            map_matrix[1, 72].block = new Mountain();
            map_matrix[1, 73].block = new Mountain();
            map_matrix[1, 74].block = new Mountain();
            map_matrix[1, 75].block = new Mountain();
            map_matrix[0, 75].block = new Mountain();
            map_matrix[11, 49].block = new Mountain();
            map_matrix[15, 52].block = new Mountain();
            map_matrix[16, 69].block = new Mountain();
            map_matrix[9, 76].block = new Mountain();
            map_matrix[10, 75].block = new Mountain();
            map_matrix[11, 75].block = new Mountain();
            map_matrix[12, 75].block = new Mountain();
            map_matrix[11, 76].block = new Mountain();
            map_matrix[12, 51].block = new Mountain();
            map_matrix[14, 70].block = new Mountain();
            map_matrix[12, 73].block = new Mountain();
            map_matrix[15, 70].block = new Mountain();
            map_matrix[10, 49].block = new Mountain();
            map_matrix[10, 50].block = new Mountain();
            map_matrix[11, 51].block = new Mountain();
            map_matrix[11, 76].block = new Mountain();
            map_matrix[14, 52].block = new Mountain();
            map_matrix[14, 53].block = new Mountain();
            map_matrix[15, 54].block = new Mountain();
            map_matrix[16, 55].block = new Mountain();
            map_matrix[16, 56].block = new Mountain();
            map_matrix[16, 57].block = new Mountain();
            map_matrix[16, 58].block = new Mountain();
            map_matrix[16, 59].block = new Mountain();
            map_matrix[17, 60].block = new Mountain();
            map_matrix[18, 61].block = new Mountain();
            map_matrix[18, 62].block = new Mountain();
            map_matrix[18, 63].block = new Mountain();
            map_matrix[18, 64].block = new Mountain();
            map_matrix[18, 65].block = new Mountain();
            map_matrix[18, 66].block = new Mountain();
            map_matrix[17, 67].block = new Mountain();
            map_matrix[16, 68].block = new Mountain();
            map_matrix[15, 69].block = new Mountain();
            map_matrix[13, 71].block = new Mountain();
            map_matrix[12, 72].block = new Mountain();
            map_matrix[11, 73].block = new Mountain();
            map_matrix[12, 49].block = new Mountain();
            map_matrix[12, 50].block = new Mountain();
            map_matrix[13, 51].block = new Mountain();
            map_matrix[13, 76].block = new Mountain();
            map_matrix[16, 52].block = new Mountain();
            map_matrix[16, 53].block = new Mountain();
            map_matrix[17, 54].block = new Mountain();
            map_matrix[18, 55].block = new Mountain();
            map_matrix[18, 56].block = new Mountain();
            map_matrix[18, 57].block = new Mountain();
            map_matrix[18, 58].block = new Mountain();
            map_matrix[18, 59].block = new Mountain();
            map_matrix[19, 60].block = new Mountain();
            map_matrix[20, 61].block = new Mountain();
            map_matrix[20, 62].block = new Mountain();
            map_matrix[20, 63].block = new Mountain();
            map_matrix[20, 64].block = new Mountain();
            map_matrix[20, 65].block = new Mountain();
            map_matrix[20, 66].block = new Mountain();
            map_matrix[19, 66].block = new Mountain();
            map_matrix[18, 67].block = new Mountain();
            map_matrix[18, 68].block = new Mountain();
            map_matrix[17, 69].block = new Mountain();
            map_matrix[15, 71].block = new Mountain();
            map_matrix[14, 72].block = new Mountain();
            map_matrix[13, 73].block = new Mountain();
            map_matrix[9, 49].block = new Mountain();
            map_matrix[36, 52].block = new Mountain();
            map_matrix[35, 53].block = new Mountain();
            map_matrix[35, 54].block = new Mountain();
            map_matrix[42, 53].block = new Mountain();
            map_matrix[41, 52].block = new Mountain();
            map_matrix[41, 52].block = new Mountain();
            map_matrix[40, 52].block = new Mountain();
            map_matrix[39, 52].block = new Mountain();
            map_matrix[38, 51].block = new Mountain();
            map_matrix[37, 51].block = new Mountain();
            map_matrix[36, 51].block = new Mountain();
            map_matrix[35, 52].block = new Mountain();
            map_matrix[34, 53].block = new Mountain();
            map_matrix[36, 51].block = new Mountain();
            map_matrix[35, 52].block = new Mountain();
            map_matrix[34, 53].block = new Mountain();
            map_matrix[36, 51].block = new Mountain();
            map_matrix[34, 54].block = new Mountain();
            map_matrix[36, 51].block = new Mountain();
            map_matrix[38, 61].block = new Mountain();
            map_matrix[37, 60].block = new Mountain();
            map_matrix[36, 59].block = new Mountain();
            map_matrix[36, 60].block = new Mountain();
            map_matrix[35, 59].block = new Mountain();
            map_matrix[35, 58].block = new Mountain();
            map_matrix[35, 57].block = new Mountain();
            map_matrix[35, 56].block = new Mountain();
            map_matrix[36, 56].block = new Mountain();
            map_matrix[36, 57].block = new Mountain();
            map_matrix[36, 58].block = new Mountain();
            map_matrix[39, 61].block = new Mountain();
            map_matrix[40, 61].block = new Mountain();
            map_matrix[41, 61].block = new Mountain();
            map_matrix[42, 61].block = new Mountain();

            int[] DmgDice = { 6, 6 };
            //Criando Items
            Weapon ShildDoDiabo = new Weapon("Concussion", "STR", DmgDice, 100, 9, 2, "ShildDoDiabo");
            Armor ArmaduraDoCavaleiroDasTrevas = new Armor(10, -10, 20, "ArmaduraDoCavaleiroDasTrevas");
            HealingPot Agua = new HealingPot(10, "Agua");
            HealingPot PocaoHp = new HealingPot(25, "PocaoHp");
            DamagingPot PocaoDeDano = new DamagingPot(25, "DamagingPot");

            //Colocando os itens na matriz do mapa
            map_matrix[41, 10].block = ShildDoDiabo;
            ((Item)map_matrix[41, 10].block).posY = 41;
            ((Item)map_matrix[41, 10].block).posX = 10;
            map_matrix[42, 10].block = ArmaduraDoCavaleiroDasTrevas;
            ((Item)map_matrix[42, 10].block).posY = 42;
            ((Item)map_matrix[42, 10].block).posX = 10;
            map_matrix[40, 26].block = Agua;
            ((Item)map_matrix[40, 26].block).posY = 40;
            ((Item)map_matrix[40, 26].block).posX = 26;
            map_matrix[22, 26].block = PocaoHp;
            ((Item)map_matrix[22, 26].block).posY = 22;
            ((Item)map_matrix[22, 26].block).posX = 26;

            //Criando personagens
            vago = new Character("Shielder", "Human", "Vagner");
            davi = new Character("Mage", "Dwarf", "David");
            ana = new Character("Witcher", "Dragonborn", "Ana");
            maria = new Character("Warrior", "Elf", "Maria");
            lapa = new Character("Lapagod", "God", "Lapa");
            bia = new Character("Assassin", "Elf", "Bia");
            geao = new Character("Berserker", "Human", "Gean");
            grao = new Character("Cleric", "Elf", "Grhamm");
            joao = new Character("Bard", "Dragonborn", "Joao");
            fernanda = new Character("Mage", "Orc", "Fernanda");

            //Colocando os personagens na matriz do mapa
            map_matrix[30, 72].block = vago;// Casa 1
            ((Character)map_matrix[30, 72].block).posY = 30;
            ((Character)map_matrix[30, 72].block).posX = 72;
            map_matrix[37, 69].block = davi;// Casa 2
            ((Character)map_matrix[37, 69].block).posY = 37;
            ((Character)map_matrix[37, 69].block).posX = 69;
            map_matrix[32, 43].block = ana;// Casa 3
            ((Character)map_matrix[32, 43].block).posY = 32;
            ((Character)map_matrix[32, 43].block).posX = 43;
            map_matrix[3, 43].block = fernanda;// Casa 4
            ((Character)map_matrix[3, 43].block).posY = 3;
            ((Character)map_matrix[3, 43].block).posX = 43;
            map_matrix[23, 34].block = maria;// Casa 5
            ((Character)map_matrix[23, 34].block).posY = 23;
            ((Character)map_matrix[23, 34].block).posX = 34;
            map_matrix[30, 16].block = lapa;// Casa 6 (Casa de Lapa)
            ((Character)map_matrix[30, 16].block).posY = 30;
            ((Character)map_matrix[30, 16].block).posX = 16;
            map_matrix[41, 8].block = bia; // Casa 7
            ((Character)map_matrix[41, 8].block).posY = 41;
            ((Character)map_matrix[41, 8].block).posX = 8;
            map_matrix[17, 14].block = geao;// Casa 8 (Taverna)
            ((Character)map_matrix[17, 14].block).posY = 17;
            ((Character)map_matrix[17, 14].block).posX = 14;
            map_matrix[16, 26].block = grao;// Casa 9
            ((Character)map_matrix[16, 26].block).posY = 16;
            ((Character)map_matrix[16, 26].block).posX = 26;
            map_matrix[15, 40].block = joao;// Casa 10
            ((Character)map_matrix[15, 40].block).posY = 15;
            ((Character)map_matrix[15, 40].block).posX = 40;

            //Armazena todos os blocos do mapa que possuem imagens
            ImgBlocks = new List<MapBlock>
            {
                //Characters
                map_matrix[30, 72],
                map_matrix[37, 69],
                map_matrix[32, 43],
                map_matrix[3, 43],
                map_matrix[23, 34],
                map_matrix[30, 16],
                map_matrix[41, 8],
                map_matrix[17, 14],
                map_matrix[16, 26],
                map_matrix[15, 40],
                //Items
                map_matrix[41, 10],
                map_matrix[42,10],
                map_matrix[40,26],
                map_matrix[22,26]
            };
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var parameters = (MapParams)e.Parameter;
            player = parameters.character;
            mediaPlayer = parameters.media_player;
            mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Musicas/Map.mp3"));
            mediaPlayer.Play();
            persona_name = player.PersonaName;
            race_name = player.RaceName;
            player.LoadButtons();
            AddLife(PlayerHp, player.Hp, player.Hpmax);
            AddBonusButtons();

            //Cria os botões de ataque referentes à classe do personagem
            foreach (KeyValuePair<string, Delegate> action in player.Action)
            {
                Button action_btn = new Button();
                action_btn.Content = action.Key;
                action_btn.Name = action.Key;
                action_btn.MinWidth = 220;
                action_btn.FontFamily = new FontFamily("Times New Roman");
                action_btn.Foreground = new SolidColorBrush(Colors.Black);
                action_btn.FontSize = 20;
                action_btn.Click += Attack_Click;
                ActionPanel.Children.Add(action_btn);
            }

            //Preenche o mapa com as imagens dos blocos
            foreach (MapBlock map_block in ImgBlocks)
            {
                if (map_block.block.GetType() == typeof(Character))
                    map_block.SetImage(new Image(), "ms-appx:///Assets/Personagens/" + ((Character)map_block.block).PersonaName + "/Sem_fundo/" + ((Character)map_block.block).PersonaName + "_" + ((Character)map_block.block).RaceName + ".png", -80 + (((Character)map_block.block).posX - player.posX) * 80, 0 + (((Character)map_block.block).posY - player.posY) * 80, 0 + (player.posX - ((Character)map_block.block).posX) * 80, 80 + (player.posY - ((Character)map_block.block).posY) * 80);
                else if (((Item)map_block.block) != null)
                    map_block.SetImage(new Image(), "ms-appx:///Assets/Itens/" + ((Item)map_block.block).Name + ".png", -80 + (((Item)map_block.block).posX - player.posX) * 80, 0 + (((Item)map_block.block).posY - player.posY) * 80, 0 + (player.posX - ((Item)map_block.block).posX) * 80, 80 + (player.posY - ((Item)map_block.block).posY) * 80);
                MapGrid.Children.Add(map_block.GetImage());
                Grid.SetColumnSpan(map_block.GetImage(), 16);
                Grid.SetRowSpan(map_block.GetImage(), 9);
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
        /// Cria os botões de ataque bônus referentes à classe do personagem
        /// </summary>
        private void AddBonusButtons()
        {
            BonusPanel.Children.Clear();
            foreach (KeyValuePair<string, Delegate> action_bonus in player.BonusAction)
            {
                Button action_btn = new Button();
                action_btn.Content = action_bonus.Key;
                action_btn.Name = action_bonus.Key;
                action_btn.MinWidth = 220;
                action_btn.FontFamily = new FontFamily("Times New Roman");
                action_btn.Foreground = new SolidColorBrush(Colors.Black);
                action_btn.FontSize = 20;
                action_btn.Click += Bonus_Click;
                BonusPanel.Children.Add(action_btn);
            }
        }

        /// <summary>
        /// Adiciona os botões de song e dance do bardo
        /// </summary>
        /// <param name="bonus_type">Recebe "Dance" ou "Song" para dizer o tipo de ataque</param>
        private void AddBardButtons(string bonus_type)
        {
            if (bonus_type == "Dance" || bonus_type == "Song")
            {
                List<string> options = new List<string>();
                if (bonus_type == "Dance")
                {
                    options.Add("Fury");
                    options.Add("Fire");
                }
                else if (bonus_type == "Song")
                {
                    options.Add("Earth");
                    options.Add("Hunter");
                }
                BonusPanel.Children.Clear();
                foreach (string option_str in options)
                {
                    Button action_btn = new Button();
                    action_btn.Content = option_str;
                    action_btn.Name = option_str;
                    action_btn.MinWidth = 220;
                    action_btn.FontFamily = new FontFamily("Times New Roman");
                    action_btn.Foreground = new SolidColorBrush(Colors.Black);
                    action_btn.FontSize = 20;
                    action_btn.Click += Bonus_Click;
                    BonusPanel.Children.Add(action_btn);
                }
            }
        }

        /// <summary>
        /// Adiciona corações de vida ao personagem
        /// </summary>
        /// <param name="panel">Painel que conterá os corações</param>
        /// <param name="hp">Quantidade de vida do personagem</param>
        /// <param name="hp_max">Quantidade de vida máxima do personagem</param>
        private void AddLife(StackPanel panel, int hp, int hp_max)
        {
            int qnt_heart = 0;
            qnt_heart = hp * 10 / hp_max;
            panel.Children.Clear();
            for (int i = 0; i < qnt_heart; i++)
            {
                heart_img = new Image();
                heart_img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Mapa/Heart.png"));
                heart_img.HorizontalAlignment = HorizontalAlignment.Left;
                heart_img.VerticalAlignment = VerticalAlignment.Top;
                heart_img.Height = 40;
                panel.Children.Add(heart_img);
            }
        }

        private void RenderInventory()
        {
            try
            {
                charBota.Source = new BitmapImage(new Uri("ms-appx:///Assets/Itens/" + player.EquippedBoots.Name + ".png"));
                charArmadura.Source = new BitmapImage(new Uri("ms-appx:///Assets/Itens/" + player.EquippedArmor.Name + ".png"));
                charArma.Source = new BitmapImage(new Uri("ms-appx:///Assets/Itens/" + player.EquippedWeapon.Name + ".png"));
            }
            catch
            {

            }
            int i = 0;
            foreach (Image img in Inv)
            {
                try
                {
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Itens/" + player.Inventory[i].Name + ".png"));
                }
                catch
                {
                    break;
                }
                i++;
            }
        }

        private void EquipInInventory(object sender, RoutedEventArgs e)
        {
            int i = 0;
            for(i = 0; i < Inv.Count(); i++)
            {
                if (((Button)sender).Content == Inv[i]) break;
            }

            if (i > player.Inventory.Count()) return;

            if(player.Inventory[i].GetType().IsSubclassOf(typeof(Equipment)))
            {
                ((Equipment)player.Inventory[i]).Equip(player);
            }else if (player.Inventory[i].GetType().IsSubclassOf(typeof(Consumable)))
            {
                ((Consumable)player.Inventory[i]).Use(player);
            }
            RenderInventory();
        }

        private void OpenInventory(object sender, RoutedEventArgs e) { }

        private void OpenInventoryB()
        {
            Inventory.Visibility = Visibility.Visible;

            RenderInventory();
            
        }

        private void CloseInventoryB()
        {
            Inventory.Visibility = Visibility.Collapsed;
        }


        /// <summary>
        /// Começa o turno do inimigo que está no raio do player
        /// </summary>
        /// <param name="enemy">Inimigo que irá começar o turno</param>
        private void EnemyTurn(Character enemy)
        {
            int[] DmgDice = { 6, 6 };
            Weapon armafoda = new Weapon("Slash", "STR", DmgDice, 100, 0, 1, "armafoda");
            armafoda.Equip(enemy);
            //enemy.EquippedWeapon = armafoda;
            enemy.Target = player;
            enemy.Action["Attack"].DynamicInvoke();
            AddLife(PlayerHp, enemy.Target.Hp, enemy.Target.Hpmax);
            //Se o player morrer tira todas as referências do personagem no mapa
            if (enemy.Target.Hp == 0)
            {
                ChangePlayerTurnStatus(false);
                DeathPanel.Visibility = Visibility.Visible;
                CharacterImg.Visibility = Visibility.Collapsed;
                PlayerHp.Children.Clear();
                enemy.Target = null;
            }
            else
                ChangePlayerTurnStatus(true);
        }

        /// <summary>
        /// Termina o turno do player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SkipTurn(object sender, RoutedEventArgs e)
        {
            if (player.Hp != 0 && isPlayerTurn)
            {
                SkipButton.Visibility = Visibility.Collapsed;
                ChangePlayerTurnStatus(false);
                foreach (var enemy in EnemiesInRange)
                {
                    if (player == null)
                        break;
                    EnemyTurn(enemy);
                }
            }
        }

        /// <summary>
        /// Navega para a tela de seleção dos personagens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavigateSelection(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
            mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Musicas/MainPage.mp3"));
            mediaPlayer.Play();
            this.Frame.Navigate(typeof(CharacterSelectionPage), mediaPlayer);
        }

        private void MoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPlayerTurn)
            {
                moveActivated = true;
                MoveButton.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Usa uma ação bônus do player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bonus_Click(object sender, RoutedEventArgs e)
        {
            if (hasEnemyInRange && player.Hp != 0 && isPlayerTurn)
            {
                BonusPanel.Visibility = Visibility.Visible;
                
                player.Target = nearest_enemy;
                if (player.CharacterClass.GetType() == typeof(Bard) && (((Button)sender).Name == "Song" || ((Button)sender).Name == "Dance"))
                    AddBardButtons(((Button)sender).Name);
                else if (((Button)sender).Name == "Fire" || ((Button)sender).Name == "Fury")
                {
                    player.BonusAction["Dance"].DynamicInvoke(((Button)sender).Name);
                    AddBonusButtons();
                    BonusButton.Visibility = Visibility.Collapsed;
                    BonusPanel.Visibility = Visibility.Collapsed;
                }
                else if (((Button)sender).Name == "Earth" || ((Button)sender).Name == "Hunter")
                {
                    player.BonusAction["Song"].DynamicInvoke(((Button)sender).Name);
                    if (((Button)sender).Name == "Earth")
                    {
                        mediaPlayer.Pause();
                        mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Musicas/Witcher.mp3"));
                        mediaPlayer.Play();
                    }
                    else if (((Button)sender).Name == "Hunter")
                    {
                        mediaPlayer.Pause();
                        mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Musicas/Mothers Hymn.mp3"));
                        mediaPlayer.Play();
                    }
                    AddBonusButtons();
                    BonusButton.Visibility = Visibility.Collapsed;
                    BonusPanel.Visibility = Visibility.Collapsed;
                }
                else if (((Button)sender).Name == "Stop Singing")
                {
                    mediaPlayer.Pause();
                    mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Musicas/Combat.mp3"));
                    mediaPlayer.Play();
                }
                else
                {
                    player.BonusAction[((Button)sender).Name].DynamicInvoke();
                    BonusButton.Visibility = Visibility.Collapsed;
                    BonusPanel.Visibility = Visibility.Collapsed;
                }
                AddLife(EnemyHp, player.Target.Hp, player.Target.Hpmax);

                //Se o inimigo morrer tira todas as referências do personagem no mapa
                if (player.Target.Hp == 0)
                {
                    EnemyHp.Children.Clear();
                    foreach (MapBlock map_block in ImgBlocks)
                        if (((Character)map_block.block).posY == player.Target.posY && ((Character)map_block.block).posX == player.Target.posX)
                        {
                            MapGrid.Children.Remove(map_block.GetImage());
                            ImgBlocks.Remove(map_block);
                            break;
                        }
                    map_matrix[player.Target.posY, player.Target.posX].block = null;
                    player.Target = null;
                    nearest_enemy = null;
                    SearchEnemies(10);
                }
            }
        }

        /// <summary>
        /// Usa uma ação do player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            if (hasEnemyInRange && player.Hp != 0 && isPlayerTurn)
            {
                ActionPanel.Visibility = Visibility.Visible;
                player.Target = nearest_enemy;
                player.Action[((Button)sender).Name].DynamicInvoke();
                AddLife(EnemyHp, player.Target.Hp, player.Target.Hpmax);
                //Se o inimigo morrer tira todas as referências do personagem no mapa
                if (player.Target.Hp == 0)
                {
                    EnemyHp.Children.Clear();
                    foreach (MapBlock map_block in ImgBlocks)
                        if (((Character)map_block.block).posY == player.Target.posY && ((Character)map_block.block).posX == player.Target.posX)
                        {
                            MapGrid.Children.Remove(map_block.GetImage());
                            ImgBlocks.Remove(map_block);
                            break;
                        }
                    map_matrix[player.Target.posY, player.Target.posX].block = null;
                    player.Target = null;
                    nearest_enemy = null;
                    SearchEnemies(10);
                }
                ActionButton.Visibility = Visibility.Collapsed;
                ActionPanel.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Movimenta o personagem pra cima
        /// </summary>
        private void Up()
        {
            //Verifica se o bloco que o personagem está tentando ir está livre ou não
            if (player.posY - 1 >= 0 && (map_matrix[player.posY - 1, player.posX].block == null || map_matrix[player.posY - 1, player.posX].block.GetType() == typeof(Cave) || map_matrix[player.posY - 1, player.posX].block.GetType() == typeof(Door) || map_matrix[player.posY - 1, player.posX].block.GetType() == typeof(Door) || map_matrix[player.posY - 1, player.posX].block.GetType().IsSubclassOf(typeof(Item))))
            {
                //Se o personagem estiver na posição 2 do eixo y da grid e o mapa não estiver chegado no limite, o mapa se move, senão o personagem se move
                if (grid_y == 2 && margin.Top <= -400)
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
                player.TurnMove--;
            }
        }

        /// <summary>
        /// Movimenta o personagem pra baixo
        /// </summary>
        private void Down()
        {
            //Verifica se o bloco que o personagem está tentando ir está livre ou não
            if (player.posY + 1 < 43 && (map_matrix[player.posY + 1, player.posX].block == null || map_matrix[player.posY + 1, player.posX].block.GetType() == typeof(Cave) || map_matrix[player.posY + 1, player.posX].block.GetType() == typeof(Door) || map_matrix[player.posY + 1, player.posX].block.GetType().IsSubclassOf(typeof(Item))))
            {
                //Se o personagem estiver na posição 6 do eixo y da grid e o mapa não estiver chegado no limite, o mapa se move, senão o personagem se move
                if (grid_y == 6 && margin.Bottom <= -400)
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
                player.TurnMove--;
            }
        }

        /// <summary>
        /// Movimenta o personagem pra esquerda
        /// </summary>
        private void Left()
        {
            //Verifica se o bloco que o personagem está tentando ir está livre ou não
            if (player.posX - 1 >= 0 && (map_matrix[player.posY, player.posX - 1].block == null || map_matrix[player.posY, player.posX - 1].block.GetType() == typeof(Cave) || map_matrix[player.posY, player.posX - 1].block.GetType() == typeof(Door) || map_matrix[player.posY, player.posX - 1].block.GetType().IsSubclassOf(typeof(Item))))
            {
                //Se o personagem estiver na posição 3 do eixo x da grid e o mapa não estiver chegado no limite, o mapa se move, senão o personagem se move
                if (grid_x == 3 && margin.Left <= -400)
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
                player.TurnMove--;
            }
        }

        /// <summary>
        /// Movimenta o personagem pra direita
        /// </summary>
        private void Right()
        {
            //Verifica se o bloco que o personagem está tentando ir está livre ou não
            if (player.posX + 1 < 77 && (map_matrix[player.posY, player.posX + 1].block == null || map_matrix[player.posY, player.posX + 1].block.GetType() == typeof(Door) || map_matrix[player.posY, player.posX + 1].block.GetType() == typeof(Cave) || map_matrix[player.posY, player.posX + 1].block.GetType().IsSubclassOf(typeof(Item))))
            {
                //Se o personagem estiver na posição 12 do eixo x da grid e o mapa não estiver chegado no limite, o mapa se move, senão o personagem se move
                if (grid_x == 12 && margin.Right <= -400)
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
                player.TurnMove--;
            }
        }

        /// <summary>
        /// Procura num raio os inimigos do mapa
        /// </summary>
        /// <param name="enemy_range">Raio de busca</param>
        private void SearchEnemies(int enemy_range)
        {
            if (player.Hp != 0)
            {
                hasEnemyInRange = false;
                nearest_enemy = null;
                EnemiesInRange.Clear();
                //Verifica se existe algum inimigo no raio do personagem
                for (int i = player.posY - enemy_range; i < player.posY + enemy_range; i++)
                {
                    for (int j = player.posX - enemy_range; j < player.posX + enemy_range; j++)
                    {
                        if (i >= 0 && i < 43 && j >= 0 && j < 77 && map_matrix[i, j].block != null && map_matrix[i, j].block.GetType() == typeof(Character))
                        {
                            hasEnemyInRange = true;
                            EnemiesInRange.Add((Character)map_matrix[i, j].block);

                            //Armazena o inimigo mais próximo ao player
                            if (nearest_enemy == null || (nearest_enemy != null && Math.Sqrt(Math.Pow(nearest_enemy.posX - player.posX, 2) + Math.Pow(nearest_enemy.posY - player.posY, 2)) > Math.Sqrt(Math.Pow(((Character)map_matrix[i, j].block).posX - player.posX, 2) + Math.Pow(((Character)map_matrix[i, j].block).posY - player.posY, 2))))
                                nearest_enemy = (Character)map_matrix[i, j].block;
                        }

                    }
                }
                if (nearest_enemy != null)
                {
                    EnemyName.Text = nearest_enemy.PersonaName;
                    AddLife(EnemyHp, nearest_enemy.Hp, nearest_enemy.Hpmax);
                }
                //Se tiver algum inimigo no raio e se o turno já não estiver ativado, ativa o modo dos turnos
                if (hasEnemyInRange && !isPlayerTurn)
                {
                    mediaPlayer.Pause();
                    mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Musicas/Combat.mp3"));
                    mediaPlayer.Play();
                    ChangePlayerTurnStatus(true);
                }
                //Senão tiver inimigos no raio desativa o modo dos turnos
                else if (!hasEnemyInRange && isPlayerTurn)
                {
                    mediaPlayer.Pause();
                    mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Musicas/Map.mp3"));
                    mediaPlayer.Play();
                    ChangePlayerTurnStatus(false);
                    nearest_enemy = null;
                }
            }
        }

        /// <summary>
        /// Ativa ou desativa o modo de turno do player
        /// </summary>
        /// <param name="is_player_turn">Armazena se é ou não o turno do player</param>
        private void ChangePlayerTurnStatus(bool is_player_turn)
        {
            Visibility visibility = new Visibility();
            if (is_player_turn)
                visibility = Visibility.Visible;
            else
                visibility = Visibility.Collapsed;
            isPlayerTurn = is_player_turn;
            moveActivated = false;
            player.TurnMove = player.TotalMove;
            ActionButton.Visibility = visibility;
            ActionPanel.Visibility = visibility;
            BonusButton.Visibility = visibility;
            BonusPanel.Visibility = visibility;
            MoveButton.Visibility = visibility;
            Scrollpaper.Visibility = visibility;
            EnemyName.Visibility = visibility;
            SkipButton.Visibility = visibility;
            EnemyHp.Visibility = visibility;
            PlayerHp.Visibility = visibility;
        }

        /// <summary>
        /// Ao apertar uma seta, o personagem se move de acordo à direção apontada
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            base.OnKeyDown(e);
            //Movimenta se não tiver no turno do player ou se tiver e não tiver chegado no limite de movimentos
            if (player.Hp != 0)
            {
                if (e.Key == Windows.System.VirtualKey.V && Inventory.Visibility == Visibility.Collapsed)
                    OpenInventoryB();
                else if (e.Key == Windows.System.VirtualKey.V && Inventory.Visibility == Visibility.Visible)
                    CloseInventoryB();

                if (!isPlayerTurn || (isPlayerTurn && player.TurnMove > 0 && moveActivated))
                {
                    grid_x = Grid.GetColumn(CharacterImg);
                    grid_y = Grid.GetRow(CharacterImg);
                    margin = MapImg.Margin;

                    //Seta a margem de cada imagem presente no mapa
                    foreach (var block in ImgBlocks)
                        block.imgMargin = block.GetImage().Margin;

                    if (e.Key == Windows.System.VirtualKey.W)
                        Up();
                    else if (e.Key == Windows.System.VirtualKey.S)
                        Down();
                    else if (e.Key == Windows.System.VirtualKey.A)
                        Left();
                    else if (e.Key == Windows.System.VirtualKey.D)
                        Right();
                    //Se o bloco que o personagem se moveu for uma entrada, sua imagem desaparece
                    if (map_matrix[player.posY, player.posX].block != null && (map_matrix[player.posY, player.posX].block.GetType() == typeof(Cave) || map_matrix[player.posY, player.posX].block.GetType() == typeof(Door)))
                        CharacterImg.Visibility = Visibility.Collapsed;
                    else
                        CharacterImg.Visibility = Visibility.Visible;
                    //Se i bkici qye i oersibagen se moveu for um item, o item é adicionado no inventário
                    if (map_matrix[player.posY, player.posX].block != null && (map_matrix[player.posY, player.posX].block.GetType().IsSubclassOf(typeof(Item))))
                    {
                        ((Item)map_matrix[player.posY, player.posX].block).PickUp(player);

                        foreach (MapBlock map_block in ImgBlocks)
                        {
                            if (map_block.block.GetType().IsSubclassOf(typeof(Item)))
                            {
                                if (((Item)map_block.block).posX == player.posX && ((Item)map_block.block).posY == player.posY)
                                {
                                    MapGrid.Children.Remove(map_block.GetImage());
                                    ImgBlocks.Remove(map_block);
                                    break;
                                }
                            }
                        }
                        map_matrix[player.posY, player.posX].block = null;
                    }
                    SearchEnemies(10);
                }
            }
        }
    }
}
