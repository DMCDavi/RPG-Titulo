using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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

namespace Titulo_UWP
{
    public class MapBlock
    {
        public Thickness imgMargin;
        private Image ObjImg;
        public Object block { get; set; }

        /// <summary>
        /// Seta e configura a imagem referente ao objeto que compõe o bloco do mapa
        /// </summary>
        /// <param name="obj_img">Imagem do objeto</param>
        /// <param name="src">Caminho onde se encontra a imagem</param>
        /// <param name="margin_top">Margem do top da imagem</param>
        /// <param name="margin_bottom">Margem do pé da imagem</param>
        /// <param name="margin_left">Margem da esquerda da imagem</param>
        /// <param name="margin_right">Margem da direita da imagem</param>
        /// <param name="height">Altura da imagem</param>
        /// <param name="width">Largura da imagem</param>
        public void SetImage(Image obj_img, string src, int margin_left, int margin_top, int margin_right, int margin_bottom, int height = 100, int width = 100)
        {
            ObjImg = obj_img;
            ObjImg.Source = new BitmapImage(new Uri(src));
            ObjImg.Width = width;
            ObjImg.Height = height;
            imgMargin = ObjImg.Margin;
            imgMargin.Top = margin_top;
            imgMargin.Bottom = margin_bottom;
            imgMargin.Left = margin_left;
            imgMargin.Right = margin_right;
            ObjImg.Margin = imgMargin;
        }

        /// <summary>
        /// Retorna a imagem referente ao objeto que compõe o bloco do mapa
        /// </summary>
        /// <returns></returns>
        public Image GetImage()
        {
            return ObjImg;
        }

    }
}
