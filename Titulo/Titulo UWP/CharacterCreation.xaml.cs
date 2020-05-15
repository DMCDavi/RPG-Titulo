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
using Titulo;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace Titulo_UWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class CharacterCreation : Page
    {
        Personagem pers = new Personagem("Tank", new Human(), new Vagner());
        public CharacterCreation()
        {
            this.InitializeComponent();
            str.Text = pers.Atribute["STR"].ToString();
            dex.Text = pers.Atribute["DEX"].ToString();
            con.Text = pers.Atribute["CON"].ToString();
            intl.Text = pers.Atribute["INT"].ToString();
            wis.Text = pers.Atribute["WIS"].ToString();
            cha.Text = pers.Atribute["CHA"].ToString();
            score.Text = pers.pts.ToString();
        }

        /// <summary>
        /// Tenta aumentar em 1 ponto a atributo força
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Str_Plus_Click(object sender, RoutedEventArgs e)
        {
            pers.BuyAtributes("STR", 1);
            str.Text = pers.Atribute["STR"].ToString();
            score.Text = pers.pts.ToString();
        }

        /// <summary>
        /// Tenta diminuir em 1 ponto a atributo força
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Str_Minus_Click(object sender, RoutedEventArgs e)
        {
            pers.BuyAtributes("STR", 2);
            str.Text = pers.Atribute["STR"].ToString();
            score.Text = pers.pts.ToString();
        }

        /// <summary>
        /// Tenta aumentar em 1 ponto a atributo destreza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dex_Plus_Click(object sender, RoutedEventArgs e)
        {
            pers.BuyAtributes("DEX", 1);
            dex.Text = pers.Atribute["DEX"].ToString();
            score.Text = pers.pts.ToString();
        }

        /// <summary>
        /// Tenta diminuir em 1 ponto a atributo destreza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dex_Minus_Click(object sender, RoutedEventArgs e)
        {
            pers.BuyAtributes("DEX", 2);
            dex.Text = pers.Atribute["DEX"].ToString();
            score.Text = pers.pts.ToString();
        }

        /// <summary>
        /// Tenta aumentar em 1 ponto a atributo constituição
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Con_Plus_Click(object sender, RoutedEventArgs e)
        {
            pers.BuyAtributes("CON", 1);
            con.Text = pers.Atribute["CON"].ToString();
            score.Text = pers.pts.ToString();
        }

        /// <summary>
        /// Tenta diminuir em 1 ponto a atributo constituição
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Con_Minus_Click(object sender, RoutedEventArgs e)
        {
            pers.BuyAtributes("CON", 2);
            con.Text = pers.Atribute["CON"].ToString();
            score.Text = pers.pts.ToString();
        }
        /// <summary>
        /// Tenta aumentar em 1 ponto a atributo inteligencia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Int_Plus_Click(object sender, RoutedEventArgs e)
        {
            pers.BuyAtributes("INT", 1);
            intl.Text = pers.Atribute["INT"].ToString();
            score.Text = pers.pts.ToString();
        }
        /// <summary>
        /// Tenta diminuir em 1 ponto a atributo inteligencia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Int_Minus_Click(object sender, RoutedEventArgs e)
        {
            pers.BuyAtributes("INT", 2);
            intl.Text = pers.Atribute["INT"].ToString();
            score.Text = pers.pts.ToString();
        }
        /// <summary>
        /// Tenta aumentar em 1 ponto a atributo sabedoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wis_Plus_Click(object sender, RoutedEventArgs e)
        {
            pers.BuyAtributes("WIS", 1);
            wis.Text = pers.Atribute["WIS"].ToString();
            score.Text = pers.pts.ToString();
        }
        /// <summary>
        /// Tenta diminuir em 1 ponto a atributo sabedoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wis_Minus_Click(object sender, RoutedEventArgs e)
        {
            pers.BuyAtributes("WIS", 2);
            wis.Text = pers.Atribute["WIS"].ToString();
            score.Text = pers.pts.ToString();
        }
        /// <summary>
        /// Tenta aumentar em 1 ponto a atributo carisma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cha_Plus_Click(object sender, RoutedEventArgs e)
        {
            pers.BuyAtributes("CHA", 1);
            cha.Text = pers.Atribute["CHA"].ToString();
            score.Text = pers.pts.ToString();
        }
        /// <summary>
        /// Tenta diminuir em 1 ponto a atributo carisma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cha_Minus_Click(object sender, RoutedEventArgs e)
        {
            pers.BuyAtributes("CHA", 2);
            cha.Text = pers.Atribute["CHA"].ToString();
            score.Text = pers.pts.ToString();
        }

        private void BGRadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
