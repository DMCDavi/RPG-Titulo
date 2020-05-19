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

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace Titulo_UWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class CharacterSelectionPage : Page
    {
        public CharacterSelectionPage()
        {
            this.InitializeComponent();
        }
        public int selected;
        private void Char1_Click(object sender, RoutedEventArgs e)
        {
            selected = 1;
            if (Char1.Content.Equals("New Character"))
            {
                SelectButton.Content = "Create";
            }
            else
            {
                SelectButton.Content = "Select";
            }
        }

        private void Char2_Click(object sender, RoutedEventArgs e)
        {
            selected = 2;
            if (Char2.Content.Equals("New Character"))
            {
                SelectButton.Content = "Create";
            }
            else
            {
                SelectButton.Content = "Select";
            }
        }

        private void Char3_Click(object sender, RoutedEventArgs e)
        {
            selected = 3;
            if (Char3.Content.Equals("New Character"))
            {
                SelectButton.Content = "Create";
            }
            else
            {
                SelectButton.Content = "Select";
            }
        }

        private void Char4_Click(object sender, RoutedEventArgs e)
        {
            selected = 4;
            if (Char4.Content.Equals("New Character"))
            {
                SelectButton.Content = "Create";
            }
            else
            {
                SelectButton.Content = "Select";
            }
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            //façam o front dessa budega
            this.Frame.Navigate(typeof(CharacterCreation));
        }
    }
}