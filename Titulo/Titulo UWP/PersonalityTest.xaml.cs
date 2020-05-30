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
using TituloCore;
using System.Diagnostics;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace Titulo_UWP
{
    /// <summary>
    /// Uma página onde será realizada a apresentação da história do jogo e um teste de personalidade
    /// </summary>
    public sealed partial class PersonalityTest : Page
    {
        int num_panel = 1, num_answer = 1;
        public List<StackPanel> AllQuestionPanels;
        Personality PTest = new Personality();
        public PersonalityTest()
        {
            this.InitializeComponent();
            //Lista com todos os paineis de perguntas e o ultimo panel
            AllQuestionPanels = new List<StackPanel> { Panel_2, Panel_3, Panel_4, Panel_5, Panel_6, Panel_7, Panel_8, Panel_9, Panel_10, Panel_11, Panel_12 };
        }

        private void NextStep_Click(object sender, RoutedEventArgs e)
        {
            //Modifica a visibilidade dos paineis ao clicar no botão, para avançar as perguntas
            if (num_panel == 1)
            {
                Panel_1.Visibility = Visibility.Collapsed;
                Panel_2.Visibility = Visibility.Visible;
                num_answer = 1;
                num_panel++;
                return;
            }
            //Se guardar o dinheiro da pergunta da empada o usuário falha no teste
            else if (num_panel == 7 && num_answer == 3)
            {
                Panel_7.Visibility = Visibility.Collapsed;
                Panel_13.Visibility = Visibility.Visible;
                num_answer = 1;
                num_panel = 13;
                NextStep.Content = "Tentar novamente";
                return;
            }
            //Se chamar Lapa de Lapa na aula dele, o usuário falha no teste
            else if (num_panel == 10 && num_answer == 3)
            {
                Panel_10.Visibility = Visibility.Collapsed;
                Panel_14.Visibility = Visibility.Visible;
                num_answer = 1;
                num_panel = 14;
                NextStep.Content = "Tentar novamente";
            }
            //Se tiver completado o teste de personalidade, redireciona o usuário para a página de criação do personagem
            else if (num_panel == 12)
            {
                num_answer = 1;
                this.Frame.Navigate(typeof(CharacterCreation), PTest.GetPersonalityWinner());
            }
            //Se tiver falhado no teste de personalidade, redireciona o usuário para a página de seleção de personagens
            else if (num_panel == 13 || num_panel == 14)
            {
                num_answer = 1;
                this.Frame.Navigate(typeof(CharacterSelectionPage));
            }
            else
                foreach (var panel in AllQuestionPanels.Select((value, index) => new { value, index }))
                {
                    if (num_panel == panel.index + 2)
                    {
                        //Diminuiu-se 1 unidade de num_panel porque existe um painel antes de iniciarem as perguntas
                        PTest.TestaPersona(num_panel - 1, num_answer);
                        panel.value.Visibility = Visibility.Collapsed;
                        AllQuestionPanels[panel.index + 1].Visibility = Visibility.Visible;
                        num_answer = 1;
                        num_panel++;
                        return;
                    }
                }

        }

        private void Check_Test(object sender, RoutedEventArgs e)
        {
            //Armazena o número da resposta
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                num_answer = Int16.Parse(rb.Tag.ToString());
            }
        }
    }
}
