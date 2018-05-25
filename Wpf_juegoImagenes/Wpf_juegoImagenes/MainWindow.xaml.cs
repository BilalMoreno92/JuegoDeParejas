using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Wpf_juegoImagenes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int contadorLevantadas = 0;
        static int contadorAcertadas = 0;
        static int nIntentos = 0;

        List<Image> imagenesAnadidas = new List<Image>();
        List<Image> imagenesLevantadas = new List<Image>();


        public MainWindow()
        {
            InitializeComponent();
            LlenarGridAlea();
        }

        private void LlenarGridAlea()
        {
            BitmapImage img1 = new BitmapImage(new Uri("./Imagenes/img1.jpg", UriKind.Relative));
            BitmapImage img2 = new BitmapImage(new Uri("./Imagenes/img2.jpg", UriKind.Relative));
            BitmapImage img3 = new BitmapImage(new Uri("./Imagenes/img3.jpg", UriKind.Relative));
            BitmapImage img4 = new BitmapImage(new Uri("./Imagenes/img4.jpg", UriKind.Relative));
            BitmapImage img5 = new BitmapImage(new Uri("./Imagenes/img5.jpg", UriKind.Relative));
            BitmapImage img6 = new BitmapImage(new Uri("./Imagenes/img6.jpg", UriKind.Relative));

            List<BitmapImage> ListaImagenes = new List<BitmapImage>();
            Random rnd = new Random();
            int pos = 0;
            int contador = 1;

            ListaImagenes.Add(img1);
            ListaImagenes.Add(img1);
            ListaImagenes.Add(img2);
            ListaImagenes.Add(img2);
            ListaImagenes.Add(img3);
            ListaImagenes.Add(img3);
            ListaImagenes.Add(img4);
            ListaImagenes.Add(img4);
            ListaImagenes.Add(img5);
            ListaImagenes.Add(img5);
            ListaImagenes.Add(img6);
            ListaImagenes.Add(img6);

            for (int i = 0; i < grdGrid.RowDefinitions.Count; i++)
                for (int j = 0; j < grdGrid.ColumnDefinitions.Count; j++)
                {
                    pos = rnd.Next(ListaImagenes.Count);

                    Image img = new Image();
                    img.Name = "_img" + contador;
                    img.Stretch = Stretch.Fill;
                    img.Visibility = System.Windows.Visibility.Hidden;
                    img.Source = ListaImagenes[pos];
                    ListaImagenes.RemoveAt(pos);

                    //Posiciono la imágen en la celda
                    Grid.SetRow(img, i);
                    Grid.SetColumn(img, j);

                    grdGrid.Children.Add(img);

                    contador++;

                    imagenesAnadidas.Add(img);
                }
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            string row;
            string column;

            Image tmp = sender as Image;
            if (tmp != null)
            {
                column = Grid.GetColumn(tmp).ToString();
                row = Grid.GetRow(tmp).ToString();
            }

            tmp.Visibility = Visibility.Visible;
        }

        private void Juego(int nCarta)
        {
            //Si la carta está oculta, la pone visible.
            if (imagenesAnadidas[nCarta].Visibility == System.Windows.Visibility.Hidden)
            {
                imagenesAnadidas[nCarta].Visibility = System.Windows.Visibility.Visible;
                ++contadorLevantadas;

                imagenesLevantadas.Add(imagenesAnadidas[nCarta]);


                //Si solo hay una visible, la deja tal cual.
                if (contadorLevantadas == 1)
                    return;



                //Si hay dos cartas visibles y al compararlas son diferentes, se ocultan de nuevo.
                if (contadorLevantadas == 2 && imagenesAnadidas[nCarta].Source != imagenesLevantadas[0].Source)
                {
                    string titulo = "CASI";
                    string mensaje = "Pareja incorrecta";
                    MessageBoxButton boton = MessageBoxButton.OK;
                    MessageBoxImage imagen = MessageBoxImage.Exclamation;
                    MessageBoxResult resultado = MessageBox.Show(mensaje, titulo, boton, imagen);
                    nIntentos++;

                    //Se ocultan las 2 cartas de nuevo
                    imagenesAnadidas[nCarta].Visibility = System.Windows.Visibility.Hidden;
                    imagenesLevantadas[0].Visibility = System.Windows.Visibility.Hidden;

                    //La lista de cartas levantadas se queda vacía, ya que se ocultan.
                    imagenesLevantadas.Clear();
                    contadorLevantadas = 0;

                }
                else //Si se encuentra la pareja
                {
                    contadorAcertadas++;

                    //La lista de cartas levantadas se queda vacía.
                    imagenesLevantadas.Clear();
                    contadorLevantadas = 0;

                    if (contadorAcertadas == 6)
                    {
                        string titulo = "¡GANASTE!";
                        string mensaje = "¡Encontraste las parejas!" + "\n" + "Número de intentos: " + nIntentos;
                        MessageBoxButton boton = MessageBoxButton.OK;
                        MessageBoxImage imagen = MessageBoxImage.Information;
                        MessageBoxResult resultado = MessageBox.Show(mensaje, titulo, boton, imagen);
                    }
                }

            }
        }

        #region Eventos de las imágenes

        private void img_00_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Juego(0);
        }

        private void img_01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Juego(1);
        }

        private void img_02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Juego(2);
        }

        private void img_03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Juego(3);
        }

        private void img_04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Juego(4);
        }

        private void img_05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Juego(5);
        }

        private void img_06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Juego(6);
        }

        private void img_07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Juego(7);
        }

        private void img_08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Juego(8);
        }

        private void img_09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Juego(9);
        }

        private void img_10_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Juego(10);
        }

        private void img_11_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Juego(11);
        }

        #endregion
    }
}
