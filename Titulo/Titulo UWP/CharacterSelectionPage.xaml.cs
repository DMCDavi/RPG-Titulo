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


        StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        public List<Character> PersList = new List<Character>();
        public List<TextBlock> AllNicknames, AllClasses, AllPersonas, AllRaces;
        string[] RaceNames = { "Human", "Human", "Human", "Human" };
        string[] PersonaNames = { "Gean", "Gean", "Gean", "Gean" };
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
            ReadObject("PersonagensList.xml");
            int counter = 0;
            //Preenche todos os cards com os personagens salvos no arquivo
            foreach (Character item in PersList)
            {
                string[] race_splited = PersList[counter].Race.ToString().Split(".");
                RaceNames[counter] = race_splited[1];
                PersonaNames[counter] = PersList[counter].Persona.PersonaName();
                AllNicknames[counter].Visibility = Visibility.Visible;
                AllClasses[counter].Visibility = Visibility.Visible;
                AllPersonas[counter].Visibility = Visibility.Visible;
                AllRaces[counter].Visibility = Visibility.Visible;
                AllNicknames[counter].Text = PersList[counter].Nickname;
                AllClasses[counter].Text = "Classe: " + PersList[counter].MainClass;
                AllPersonas[counter].Text = "Herói: " + PersonaNames[counter];
                AllRaces[counter].Text = "Raça: " + RaceNames[counter];
                counter++;
            }
        }
        public int selected;
        private void Char1_Click(object sender, RoutedEventArgs e)
        {
            SelectButton.Visibility = Visibility.Visible;
            selected = 1;
            if (Nickname1.Text.Equals("New Character"))
            {
                CharacterImg.Visibility = Visibility.Collapsed;
                SelectButton.Content = "Create";
            }
            else
            {
                CharacterImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Personagens/" + PersonaNames[0] + "/Sem_fundo/" + PersonaNames[0] + "_" + RaceNames[0] + ".png"));
                CharacterImg.Visibility = Visibility.Visible;
                SelectButton.Content = "Select";
            }
        }

        private void Char2_Click(object sender, RoutedEventArgs e)
        {
            SelectButton.Visibility = Visibility.Visible;
            selected = 2;
            if (Nickname2.Text.Equals("New Character"))
            {
                CharacterImg.Visibility = Visibility.Collapsed;
                SelectButton.Content = "Create";
            }
            else
            {
                CharacterImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Personagens/" + PersonaNames[1] + "/Sem_fundo/" + PersonaNames[1] + "_" + RaceNames[1] + ".png"));
                CharacterImg.Visibility = Visibility.Visible;
                SelectButton.Content = "Select";
            }
        }

        private void Char3_Click(object sender, RoutedEventArgs e)
        {
            SelectButton.Visibility = Visibility.Visible;
            selected = 3;
            if (Nickname3.Text.Equals("New Character"))
            {
                CharacterImg.Visibility = Visibility.Collapsed;
                SelectButton.Content = "Create";
            }
            else
            {
                CharacterImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Personagens/" + PersonaNames[2] + "/Sem_fundo/" + PersonaNames[2] + "_" + RaceNames[2] + ".png"));
                CharacterImg.Visibility = Visibility.Visible;
                SelectButton.Content = "Select";
            }
        }

        private void Char4_Click(object sender, RoutedEventArgs e)
        {
            SelectButton.Visibility = Visibility.Visible;
            selected = 4;
            if (Nickname4.Text.Equals("New Character"))
            {
                CharacterImg.Visibility = Visibility.Collapsed;
                SelectButton.Content = "Create";
            }
            else
            {
                CharacterImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Personagens/" + PersonaNames[3] + "/Sem_fundo/" + PersonaNames[3] + "_" + RaceNames[3] + ".png"));
                CharacterImg.Visibility = Visibility.Visible;
                SelectButton.Content = "Select";
            }
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectButton.Content.Equals("Create"))
                this.Frame.Navigate(typeof(PersonalityTest));
            else
                this.Frame.Navigate(typeof(Map));
        }

        /// <summary>
        /// Lê um arquivo e armazena numa variável a lista de personagens que possui
        /// </summary>
        /// <param name="fileName">Nome do arquivo</param>
        public void ReadObject(string fileName)
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