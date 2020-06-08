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

        private int pos_y = 0, pos_x = 0;
        public Map()
        {
            this.InitializeComponent();
            margin = MapImg.Margin;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            player = e.Parameter as Character;
            persona_name = player.Persona.PersonaName();
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
            if (pos_y == 1 && margin.Top < -80)
            {
                margin.Top += 80;
                margin.Bottom -= 80;
                MapImg.Margin = margin;
            }
            else if(pos_y - 1 >= 0)
            {
                pos_y--;
                Grid.SetRow(CharacterImg, pos_y);
            }
        }

        /// <summary>
        /// Movimenta o personagem pra baixo
        /// </summary>
        private void Down()
        {
            if (pos_y == 5 && margin.Bottom < -80)
            {
                margin.Bottom += 80;
                margin.Top -= 80;
                MapImg.Margin = margin;
            }
            else if (pos_y + 1 <= 8)
            {
                pos_y++;
                Grid.SetRow(CharacterImg, pos_y);
            }
        }

        /// <summary>
        /// Movimenta o personagem pra esquerda
        /// </summary>
        private void Left()
        {
            if (pos_x == 3 && margin.Left < -160)
            {
                margin.Left += 80;
                margin.Right -= 80;
                MapImg.Margin = margin;
            }
            else if (pos_x - 1 >= 0)
            {
                pos_x--;
                Grid.SetColumn(CharacterImg, pos_x);
            }
        }

        /// <summary>
        /// Movimenta o personagem pra direita
        /// </summary>
        private void Right()
        {
            if (pos_x == 11 && margin.Right < -160)
            {
                margin.Right += 80;
                margin.Left -= 80;
                MapImg.Margin = margin;
            }
            else if (pos_x + 1 <= 15)
            {
                pos_x++;
                Grid.SetColumn(CharacterImg, pos_x);
            }
        }

        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            base.OnKeyDown(e);
            pos_x = Grid.GetColumn(CharacterImg);
            pos_y = Grid.GetRow(CharacterImg);
            Thickness margin = MapImg.Margin;
            if (e.Key == Windows.System.VirtualKey.Up)
                Up();
            else if (e.Key == Windows.System.VirtualKey.Down)
                Down();
            else if (e.Key == Windows.System.VirtualKey.Left)
                Left();
            else if (e.Key == Windows.System.VirtualKey.Right)
                Right();
        }
    }
}
