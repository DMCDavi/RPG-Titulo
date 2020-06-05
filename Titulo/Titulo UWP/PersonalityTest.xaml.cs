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
        public StackPanel[,] AllAnswerPanels;
        public PersonalityTest()
        {
            this.InitializeComponent();
            //Lista com todos os paineis de perguntas e o ultimo panel
            AllQuestionPanels = new List<StackPanel> {
                Panel_2,
                Panel_3,
                Panel_4,
                Panel_5,
                Panel_6,
                Panel_7,
                Panel_8,
                Panel_9,
                Panel_10,
                Panel_11,
                Panel_12
            };
            AllAnswerPanels = new StackPanel[10, 8] {
                 {Answer_1_1, Answer_1_2, Answer_1_3, Answer_1_4, Answer_1_5, Answer_1_6, null, null },
                 {Answer_2_1, Answer_2_2, Answer_2_3, Answer_2_4, Answer_2_5, null, null, null },
                 {Answer_3_1, Answer_3_2, Answer_3_3, Answer_3_4, Answer_3_5, null, null, null },
                 {Answer_4_1, Answer_4_2, Answer_4_3, Answer_4_4, Answer_4_5, Answer_4_6, null, null },
                 {Answer_5_1, Answer_5_2, Answer_5_3, Answer_5_4, Answer_5_5, Answer_5_6, null, null },
                 {Answer_6_1, Answer_6_2, null, null, null, null, null, null },
                 {Answer_7_1, Answer_7_2, Answer_7_3, Answer_7_4, Answer_7_5, Answer_7_6, Answer_7_7, Answer_7_8 },
                 {Answer_8_1, Answer_8_2, Answer_8_3, Answer_8_4, null, null, null, null },
                 {Answer_9_1, Answer_9_2, null, Answer_9_4, Answer_9_5, null, null, null },
                 {Answer_10_1, Answer_10_2, Answer_10_3, Answer_10_4, null, null, null, null },
        };
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
            else if (num_panel == 12)
            {
                Panel_12.Visibility = Visibility.Collapsed;
                Panel_13.Visibility = Visibility.Visible;
                num_answer = 1;
                num_panel++;
                return;
            }
            else if (num_panel == 13)
            {
                Panel_13.Visibility = Visibility.Collapsed;
                Panel_14.Visibility = Visibility.Visible;
                num_answer = 1;
                num_panel++;
                return;
            }
            //Se guardar o dinheiro da pergunta da empada o usuário falha no teste
            else if (num_panel == 7 && num_answer == 3)
            {
                Panel_7.Visibility = Visibility.Collapsed;
                Panel_15.Visibility = Visibility.Visible;
                num_answer = 1;
                num_panel = 15;
                NextStep.Content = "Voltar";
                return;
            }
            //Se chamar Lapa de Lapa na aula dele, o usuário falha no teste
            else if (num_panel == 10 && num_answer == 3)
            {
                Panel_10.Visibility = Visibility.Collapsed;
                Panel_16.Visibility = Visibility.Visible;
                num_answer = 1;
                num_panel = 16;
                NextStep.Content = "Voltar";
            }
            //Se tiver completado o teste de personalidade, redireciona o usuário para a página de criação do personagem
            else if (num_panel == 14)
            {
                num_answer = 1;
                this.Frame.Navigate(typeof(CharacterCreation), PTest.GetPersonalityWinner());
            }
            //Se tiver falhado no teste de personalidade, redireciona o usuário para a página de seleção de personagens
            else if (num_panel == 15 || num_panel == 16)
            {
                num_answer = 1;
                this.Frame.Navigate(typeof(CharacterSelectionPage));
            }
            else
                foreach (var panel in AllQuestionPanels.Select((value, index) => new { value, index }))
                {
                    if (num_panel == panel.index + 2)
                    {
                        //Caso o painel da pergunta esteja aberto, o sistema colapsa o painel, contabiliza a resposta do usuário e torna visivel a história da resposta
                        if (panel.value.Visibility == Visibility.Visible)
                        {
                            //Diminuiu-se 1 unidade de num_panel porque existe um painel antes de iniciarem as perguntas
                            PTest.TestaPersona(num_panel - 1, num_answer);
                            panel.value.Visibility = Visibility.Collapsed;
                            AllAnswerPanels[num_panel - 2, num_answer - 1].Visibility = Visibility.Visible;
                        }
                        //Caso o painel da pergunta não esteja aberto, o sistema colapsa o painel da resposta e torna visível o painel da próxima pergunta
                        else
                        {
                            AllAnswerPanels[num_panel - 2, num_answer - 1].Visibility = Visibility.Collapsed;
                            num_answer = 1;
                            num_panel++;
                            AllQuestionPanels[panel.index + 1].Visibility = Visibility.Visible;
                        }
                        return;
                    }
                }

        }

        private void RichTextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

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
