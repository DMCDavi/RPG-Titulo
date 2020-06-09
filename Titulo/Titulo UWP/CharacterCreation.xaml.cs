using System;
using System.IO;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TituloCore;
using Windows.UI.Xaml.Media.Imaging;
using System.Xml.Serialization;
using System.Diagnostics;
using Windows.Storage;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;


// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace Titulo_UWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class CharacterCreation : Page
    {
        Character pers;
        string race_name = "Human", class_name = "Assassin", persona_name = "Gean";
        //Variavel que armazena o local onde sao guardados os dados da aplicacao
        StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        public List<Character> PersList = new List<Character>();

        public CharacterCreation()
        {
            this.InitializeComponent();
            ReadObject("PersonagensList.xml");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
                persona_name = e.Parameter.ToString();
            PersonaName.Text = persona_name;
            try
            {
                CharacterLandscape.Source = new BitmapImage(new Uri("ms-appx:///Assets/Personagens/" + persona_name + "/" + persona_name + "_Landscape.png"));
                CharacterImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Personagens/" + persona_name + "/Sem_fundo/" + persona_name + "_" + race_name + ".png"));
            }
            catch (Exception)
            {
                Debug.WriteLine("ERRO: Nenhuma imagem foi encontrada");
            }
            base.OnNavigatedTo(e);
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

        private void NextStep_Click(object sender, RoutedEventArgs e)
        {
            if (NextStep.Content.ToString() == "Salvar")
            {
                WriteObject("PersonagensList.xml");
                this.Frame.Navigate(typeof(CharacterSelectionPage));
            }
            else
            {
                pers = new Character(class_name, race_name, persona_name);
                StackAtributes.Visibility = Visibility.Visible;
                StackClass.Visibility = Visibility.Collapsed;
                StackRace.Visibility = Visibility.Collapsed;
                CharName.Visibility = Visibility.Visible;
                NextStep.Visibility = Visibility.Collapsed;
                NextStep.Content = "Salvar";
                str.Text = pers.Atribute["STR"].ToString();
                dex.Text = pers.Atribute["DEX"].ToString();
                con.Text = pers.Atribute["CON"].ToString();
                intl.Text = pers.Atribute["INT"].ToString();
                wis.Text = pers.Atribute["WIS"].ToString();
                cha.Text = pers.Atribute["CHA"].ToString();
                score.Text = pers.pts.ToString();
            }
        }

        private void Class_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                class_name = rb.Tag.ToString();
            }
        }

        private void Race_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            try
            {
                race_name = rb.Tag.ToString();
                CharacterImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Personagens/" + persona_name + "/Sem_fundo/" + persona_name + "_" + race_name + ".png"));
            }
            catch (Exception)
            {
                Debug.WriteLine("ERRO: Nenhuma imagem foi encontrada");
            }
        }

        private void CharName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CharName.Text.Length > 0)
                NextStep.Visibility = Visibility.Visible;
            else
                NextStep.Visibility = Visibility.Collapsed;
            if (CharName.Text == "Lapa")
            {
                pers = new Character("Lapagod", "God", "Lapa");
                PersonaName.Text = "Lapa";
                CharacterLandscape.Source = new BitmapImage(new Uri("ms-appx:///Assets/Personagens/Lapa/Lapa_Landscape.png"));
                CharacterImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Personagens/Lapa/Sem_fundo/Lapa_God.png"));
                str.Text = pers.Atribute["STR"].ToString();
                dex.Text = pers.Atribute["DEX"].ToString();
                con.Text = pers.Atribute["CON"].ToString();
                intl.Text = pers.Atribute["INT"].ToString();
                wis.Text = pers.Atribute["WIS"].ToString();
                cha.Text = pers.Atribute["CHA"].ToString();
                score.Text = pers.pts.ToString();
            }
            pers.Nickname = CharName.Text;
        }

        /// <summary>
        /// Cria um arquivo e o preenche com uma lista de personagens
        /// </summary>
        /// <param name="fileName">Nome do arquivo</param>
        private void WriteObject(string fileName)
        {
            PersList.Add(pers);
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
