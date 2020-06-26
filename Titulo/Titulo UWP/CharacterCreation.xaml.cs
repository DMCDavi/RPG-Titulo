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
using Windows.Media.Core;
using Windows.Media.Playback;


// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace Titulo_UWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class CharacterCreation : Page
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private Character pers;
        private string race_name = "Human", class_name = "Assassin", persona_name = "Gean";
        //Variavel que armazena o local onde sao guardados os dados da aplicacao
        private StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        private List<Character> PersList = new List<Character>();
        private Dictionary<string, TextBlock> AllAtributesTxt;
        private int num_btn_atribute = 1;
        private string name_atribute = "STR";

        public CharacterCreation()
        {
            this.InitializeComponent();
            ReadObject("PersonagensList.xml");
            AllAtributesTxt = new Dictionary<string, TextBlock>
            {
                {"STR", str },
                {"DEX", dex },
                {"CON", con },
                {"INT", intl },
                {"WIS", wis },
                {"CHA", cha }
            };
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var parameters = (MapParams)e.Parameter;
            persona_name = parameters.winner;
            mediaPlayer = parameters.media_player;
            mediaPlayer.Pause();
            mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Musicas/MainPage.mp3"));
            mediaPlayer.Play();
            PersonaName.Text = persona_name;
            ChangeCharImages(persona_name, race_name);
            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// Tenta mudar a imagem do personagem e seu plano de fundo
        /// </summary>
        /// <param name="persona_string">Nome do personagem do jeito que está na pasta e no arquivo</param>
        /// <param name="race_string">Nome da raça do personagem do jeito que está na pasta e no arquivo</param>
        private void ChangeCharImages(string persona_string, string race_string)
        {
            try
            {
                CharacterLandscape.Source = new BitmapImage(new Uri("ms-appx:///Assets/Personagens/" + persona_string + "/" + persona_string + "_Landscape.png"));
                CharacterImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Personagens/" + persona_string + "/Sem_fundo/" + persona_string + "_" + race_string + ".png"));
            }
            catch (Exception)
            {
                Debug.WriteLine("ERRO: Nenhuma imagem foi encontrada");
            }
        }

        /// <summary>
        /// Aumenta ou diminui um atributo selecionado pelo usuário
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Atribute_Click(object sender, RoutedEventArgs e)
        {
            //Armazena na variável o nome do atributo que ele irá modificar
            name_atribute = ((Button)sender).Tag.ToString();
            //Armazena na variável o número do botão
            num_btn_atribute = int.Parse(((Button)sender).AccessKey.ToString());
            //Se o número do botão for par, a função incrementa no atrbuto determinado
            if (num_btn_atribute % 2 == 0)
                pers.BuyAtributes(name_atribute, 1);
            //Senão, decrementa
            else
                pers.BuyAtributes(name_atribute, 2);
            AllAtributesTxt[name_atribute].Text = pers.Atribute[name_atribute].ToString();
            score.Text = pers.pts.ToString();
        }

        /// <summary>
        /// Cria e salva o personagem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextStep_Click(object sender, RoutedEventArgs e)
        {
            //Se o usuário já estiver escolhido seus atributos e nickname, salva o personagem
            if (NextStep.Content.ToString() == "Salvar")
            {
                WriteObject("PersonagensList.xml");
                this.Frame.Navigate(typeof(CharacterSelectionPage), mediaPlayer);
            }
            //Senão abre o painel para modificar os atributos
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

        /// <summary>
        /// Seleciona uma classe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Class_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                class_name = rb.Tag.ToString();
            }
        }

        /// <summary>
        /// Seleciona uma raça
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Race_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            race_name = rb.Tag.ToString();
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
        /// Habilita o botão de salvar ao digitar um nickname
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CharName.Text.Length > 0)
                NextStep.Visibility = Visibility.Visible;
            else
                NextStep.Visibility = Visibility.Collapsed;
            //Se o nickname digitado for "Lapa", o personagem vira o DEUS
            if (CharName.Text == "Lapa")
            {
                pers = new Character("Lapagod", "God", "Lapa");
                PersonaName.Text = "Lapa";
                ChangeCharImages("Lapa", "God");
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
            pers.Action.Clear();
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
