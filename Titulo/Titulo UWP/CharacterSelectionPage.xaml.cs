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
using Windows.Storage;
using System.Collections;
using System.Runtime.Serialization;
using System.Xml;
using TituloCore;
using System.Diagnostics;
using Windows.UI.Xaml.Media.Imaging;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace Titulo_UWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class CharacterSelectionPage : Page
    {


        private StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        private List<Character> PersList = new List<Character>();
        private List<TextBlock> AllNicknames, AllClasses, AllPersonas, AllRaces;
        private List<Button> AllDeleteButtons;
        private string[] RaceNames = { "Human", "Human", "Human", "Human" };
        private string[] PersonaNames = { "Gean", "Gean", "Gean", "Gean" };
        private int tag_delete_button = 1, character_selected = 1;
        public CharacterSelectionPage()
        {
            this.InitializeComponent();
            AllNicknames = new List<TextBlock> {
                Nickname1,
                Nickname2,
                Nickname3,
                Nickname4
            };
            AllClasses = new List<TextBlock> {
                Class1,
                Class2,
                Class3,
                Class4
            };
            AllPersonas = new List<TextBlock> {
                Persona1,
                Persona2,
                Persona3,
                Persona4
            };
            AllRaces = new List<TextBlock> {
                Race1,
                Race2,
                Race3,
                Race4
            };
            AllDeleteButtons = new List<Button> {
                DeleteButton1,
                DeleteButton2,
                DeleteButton3,
                DeleteButton4
            };
            ReadObject("PersonagensList.xml");
        }

        /// <summary>
        /// Mostra na tela a resposta da escolha do personagem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Char_Click(object sender, RoutedEventArgs e)
        {
            SelectButton.Visibility = Visibility.Visible;
            character_selected = int.Parse(((Button)sender).Tag.ToString());
            //Se for um novo personagem o texto do botão muda e a imagem do personagem colapsa
            if (AllNicknames[character_selected - 1].Text.Equals("New Character"))
            {
                CharacterImg.Visibility = Visibility.Collapsed;
                SelectButton.Content = "Create";
            }
            //Senão, mostra a respectiva imagem do personagem clicado e muda o texto do botão para "Select"
            else
            {
                ChangeCharImage(PersonaNames[character_selected - 1], RaceNames[character_selected - 1]);
                CharacterImg.Visibility = Visibility.Visible;
                SelectButton.Content = "Select";
            }
        }

        /// <summary>
        /// Tenta mudar a imagem do personagem
        /// </summary>
        /// <param name="persona_name">Nome do personagem do jeito que está na pasta e no arquivo</param>
        /// <param name="race_name">Nome da raça do personagem do jeito que está na pasta e no arquivo</param>
        private void ChangeCharImage(string persona_name, string race_name)
        {
            try
            {
                CharacterImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Personagens/" + persona_name + "/Sem_fundo/" + persona_name + "_" + race_name + ".png"));
            }
            catch (Exception)
            {
                Debug.WriteLine("ERRO: Nenhuma imagem foi encontrada");
            }
        }

        /// <summary>
        /// Deleta o personagem caso o usuário confirme a remoção
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content.ToString() == "Sim")
            {
                PersList.Remove(PersList[tag_delete_button - 1]);
                WriteObject("PersonagensList.xml");
                ReadObject("PersonagensList.xml");
                //Navega para a mesma página para recarregá-la
                this.Frame.Navigate(typeof(CharacterSelectionPage));
            }
            if (DeletePopup.IsOpen) { DeletePopup.IsOpen = false; }

        }

        /// <summary>
        /// Mostra um popup de confirmação da remoção
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowPopupOffsetClicked(object sender, RoutedEventArgs e)
        {
            //Salva na variável qual botão foi acionado
            tag_delete_button = int.Parse(((Button)sender).Tag.ToString());
            if (!DeletePopup.IsOpen) { DeletePopup.IsOpen = true; }
        }

        /// <summary>
        /// Navega para o mapa caso o usuário escolha um personagem ou direciona para o teste de personalidade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectButton.Content.Equals("Create"))
                this.Frame.Navigate(typeof(PersonalityTest));
            else
                this.Frame.Navigate(typeof(Map), PersList[character_selected - 1]);
        }

        /// <summary>
        /// Preenche todos os cards com os personagens salvos no arquivo
        /// </summary>
        private void FillData()
        {
            int counter = 0;
            foreach (Character item in PersList)
            {
                RaceNames[counter] = PersList[counter].RaceName;
                PersonaNames[counter] = PersList[counter].PersonaName;
                AllNicknames[counter].Visibility = Visibility.Visible;
                AllClasses[counter].Visibility = Visibility.Visible;
                AllPersonas[counter].Visibility = Visibility.Visible;
                AllRaces[counter].Visibility = Visibility.Visible;
                AllDeleteButtons[counter].Visibility = Visibility.Visible;
                AllNicknames[counter].Text = PersList[counter].Nickname;
                AllClasses[counter].Text = "Classe: " + PersList[counter].MainClass;
                AllPersonas[counter].Text = "Herói: " + PersonaNames[counter];
                AllRaces[counter].Text = "Raça: " + RaceNames[counter];
                PersList[counter].Action.Clear();
                counter++;
            }
        }

        /// <summary>
        /// Cria um arquivo e o preenche com uma lista de personagens
        /// </summary>
        /// <param name="fileName">Nome do arquivo</param>
        private void WriteObject(string fileName)
        {
            string filePath = localFolder.Path + "\\" + fileName;
            FileStream writer = new FileStream(filePath, FileMode.Create);
            DataContractSerializer ser = new DataContractSerializer(typeof(List<Character>));
            ser.WriteObject(writer, PersList);
            writer.Close();
        }

        /// <summary>
        /// Lê um arquivo e armazena numa variável a lista de personagens que possui
        /// </summary>
        /// <param name="fileName">Nome do arquivo</param>
        private void ReadObject(string fileName)
        {
            string filePath = localFolder.Path + "\\" + fileName;
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                    DataContractSerializer ser = new DataContractSerializer(typeof(List<Character>));
                    List<Character> deserializedPersList = (List<Character>)ser.ReadObject(reader, true);
                    reader.Close();
                    fs.Close();
                    PersList = deserializedPersList;
                }
                FillData();
            }
            catch (FileNotFoundException)
            {
                Debug.WriteLine("ERRO: Não foi encontrado nenhum arquivo");
            }
            catch (Exception)
            {
                Debug.WriteLine("ERRO: Não existe nenhum conteúdo no arquivo");
            }

        }

    }
}