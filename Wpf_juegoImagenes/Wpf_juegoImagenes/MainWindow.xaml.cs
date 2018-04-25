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

namespace Wpf_juegoImagenes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
                    img.MouseLeftButtonDown += img_MouseLeftButtonDown;
                    img.MouseDown += Image_MouseDown_1;
                    img.Source = ListaImagenes[pos];
                    ListaImagenes.RemoveAt(pos);

                    //Posiciono la imágen en la celda
                    Grid.SetRow(img, i);
                    Grid.SetColumn(img, j);

                    grdGrid.Children.Add(img);

                    contador++;
                }
        }

        void img_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
    }
}
