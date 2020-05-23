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
    public sealed partial class PersonalityTest : Page
    {

        int num_panel = 1, num_tag = 1;
        public PersonalityTest()
        {
            this.InitializeComponent();
        }

        private void NextStep_Click(object sender, RoutedEventArgs e)
        {
            if (num_panel == 1)
            {
                Panel_1.Visibility = Visibility.Collapsed;
                Panel_2.Visibility = Visibility.Visible;
                num_tag = 1;
                num_panel++;
            }
            else if (num_panel == 2)
            {
                Panel_2.Visibility = Visibility.Collapsed;
                Panel_3.Visibility = Visibility.Visible;
                num_tag = 1;
                num_panel++;
            }
            else if (num_panel == 3)
            {
                Panel_3.Visibility = Visibility.Collapsed;
                Panel_4.Visibility = Visibility.Visible;
                num_tag = 1;
                num_panel++;
            }
            else if (num_panel == 4)
            {
                Panel_4.Visibility = Visibility.Collapsed;
                Panel_5.Visibility = Visibility.Visible;
                num_tag = 1;
                num_panel++;
            }
            else if (num_panel == 5)
            {
                Panel_5.Visibility = Visibility.Collapsed;
                Panel_6.Visibility = Visibility.Visible;
                num_tag = 1;
                num_panel++;
            }
            else if (num_panel == 6)
            {
                Panel_6.Visibility = Visibility.Collapsed;
                Panel_7.Visibility = Visibility.Visible;
                num_tag = 1;
                num_panel++;
            }
            else if (num_panel == 7)
            {
                if (num_tag == 3)
                {
                    Panel_7.Visibility = Visibility.Collapsed;
                    Panel_13.Visibility = Visibility.Visible;
                    num_tag = 1;
                    num_panel = 13;
                    NextStep.Content = "Tentar novamente";
                }
                else
                {
                    Panel_7.Visibility = Visibility.Collapsed;
                    Panel_8.Visibility = Visibility.Visible;
                    num_tag = 1;
                    num_panel++;
                }
            }
            else if (num_panel == 8)
            {
                Panel_8.Visibility = Visibility.Collapsed;
                Panel_9.Visibility = Visibility.Visible;
                num_tag = 1;
                num_panel++;
            }
            else if (num_panel == 9)
            {
                Panel_9.Visibility = Visibility.Collapsed;
                Panel_10.Visibility = Visibility.Visible;
                num_tag = 1;
                num_panel++;
            }
            else if (num_panel == 10)
            {
                if (num_tag == 3)
                {
                    Panel_10.Visibility = Visibility.Collapsed;
                    Panel_14.Visibility = Visibility.Visible;
                    num_tag = 1;
                    num_panel = 14;
                    NextStep.Content = "Tentar novamente";
                }
                else
                {
                    Panel_10.Visibility = Visibility.Collapsed;
                    Panel_11.Visibility = Visibility.Visible;
                    num_tag = 1;
                    num_panel++;
                }
            }
            else if (num_panel == 11)
            {
                Panel_11.Visibility = Visibility.Collapsed;
                Panel_12.Visibility = Visibility.Visible;
                num_tag = 1;
                num_panel++;
            }
            else if (num_panel == 12)
            {
                num_tag = 1;
                this.Frame.Navigate(typeof(CharacterCreation));
            }
            else if (num_panel == 13 || num_panel == 14)
            {
                num_tag = 1;
                this.Frame.Navigate(typeof(CharacterSelectionPage));
            }
        }

        private void Check_Test(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                num_tag = Int16.Parse(rb.Tag.ToString());
            }
        }
    }
}
