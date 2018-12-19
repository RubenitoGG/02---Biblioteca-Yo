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
using System.Windows.Shapes;

namespace Biblioteca
{
    /// <summary>
    /// Lógica de interacción para VentanaRegistrar.xaml
    /// </summary>
    public partial class VentanaRegistrar : Window
    {
        ADAT adat = new ADAT();
        public VentanaRegistrar()
        {
            InitializeComponent();
            rellenarCombo();
        }
        
        private void rellenarCombo()
        {
            cbCampos.Items.Add("codigo");
            cbCampos.Items.Add("isbn");
            cbCampos.Items.Add("titulo");
        }

        private void btn_buscarLibro_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(tbBusqueda.Text) && cbCampos.SelectedItem != null)
            {
                adat.BuscarLibro(cbCampos.SelectedItem.ToString(), tbBusqueda.Text);

                if (ADAT.libroRow != null)
                    mostrarEjemplares();
                else
                    MessageBox.Show("Libro no encontrado", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Faltan campos por cubrir", "", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void mostrarEjemplares()
        {
            dgEjemplares.ItemsSource = "";

            if (ADAT.libroRow != null)
            {
                adat.BuscarEjemplar(ADAT.libroRow.codigo);
                dgEjemplares.ItemsSource = ADAT.dataSet.ejemplar;
            }
        }

        private void botonPedir_Click(object sender, RoutedEventArgs e)
        {
            if( ADAT.libroRow != null)
            {
                adat.BuscarEjemplarDisponible(ADAT.libroRow.codigo);
                adat.PrestarLibro();

                adat.BuscarEjemplar(ADAT.libroRow.codigo);
                dgEjemplares.ItemsSource = ADAT.dataSet.ejemplar;
            }
            else
                MessageBox.Show("Busque un libro primero", "", MessageBoxButton.OK, MessageBoxImage.Error);

        }
    }
}
