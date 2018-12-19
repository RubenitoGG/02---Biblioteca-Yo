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

namespace Biblioteca
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_mantLibros_Click(object sender, RoutedEventArgs e)
        {
            VentanaLibro newVentana = new VentanaLibro();
            newVentana.Show();
        }

        private void btn_registrarPrest_Click(object sender, RoutedEventArgs e)
        {
            VentanaRegistrar newVentana = new VentanaRegistrar();
            newVentana.Show();
        }

        private void btn_devolbverPrest_Click(object sender, RoutedEventArgs e)
        {
            VentanaDevolver newVentana = new VentanaDevolver();
            newVentana.Show();
        }
    }
}
