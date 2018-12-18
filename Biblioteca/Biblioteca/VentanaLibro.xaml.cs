using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Lógica de interacción para VentanaLibro.xaml
    /// </summary>
    public partial class VentanaLibro : Window
    {
        // Clase que conecta a la base de datos:
        ADAT adat = new ADAT();

        public VentanaLibro()
        {
            InitializeComponent();
            rellenarCombo();
        }

        private void rellenarCombo()
        {
            for (int i = 0; i < ADAT.dataSet.Libro.DefaultView.Table.Columns.Count; i++)
                cbCampos.Items.Add(ADAT.dataSet.Libro.DefaultView.Table.Columns[i].ColumnName);
        }

        private void btn_registrar_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_codigo.Text) && !String.IsNullOrEmpty(txt_isbn.Text) && !String.IsNullOrEmpty(txt_titulo.Text)
                && !String.IsNullOrEmpty(txt_editorial.Text) && !String.IsNullOrEmpty(txt_descripcion.Text))
            {
                adat.InsertarLibro(txt_codigo.Text, txt_isbn.Text, txt_titulo.Text, txt_editorial.Text, txt_descripcion.Text);

                mostrarEjemplares();
                limpiarCampos();
            }
            else
                MessageBox.Show("Faltan campos por cubrir", "", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void limpiarCampos()
        {
            txt_codigo.Text = "";
            txt_isbn.Text = "";
            txt_titulo.Text = "";
            txt_editorial.Text = "";
            txt_descripcion.Text = "";

            txt_codigo_buscar.Text = "";
            txt_numEjemplar.Text = "";
            dp_FechaPublicacion.Text = "";

            cbCampos.SelectedItem = null;
            tbBusqueda.Text = "";

            dgEjemplares.ItemsSource = "";
        }

        private void btn_GuardarEjemplar_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_codigo_buscar.Text) && !String.IsNullOrEmpty(dp_FechaPublicacion.Text) && !String.IsNullOrEmpty(txt_numEjemplar.Text))
            {
                adat.InsertarEjemplar(txt_codigo_buscar.Text, Convert.ToDateTime(dp_FechaPublicacion.Text), Convert.ToInt32(txt_numEjemplar.Text));
                mostrarEjemplares();

                txt_codigo_buscar.Text = "";
                dp_FechaPublicacion.Text = "";
                txt_numEjemplar.Text = "";

                mostrarLibro();
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

        private void btn_buscarLibro_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbBusqueda.Text) && cbCampos.SelectedItem != null)
            {
                adat.BuscarLibro(cbCampos.SelectedItem.ToString(), tbBusqueda.Text);

                if (ADAT.libroRow != null)
                {
                    mostrarLibro();
                    mostrarEjemplares();
                }
                else
                    MessageBox.Show("Libro no encontrado", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Faltan campos por cubrir", "", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void mostrarLibro()
        {
            txt_codigo.Text = ADAT.libroRow.codigo.ToString();
            txt_isbn.Text = ADAT.libroRow.isbn.ToString();
            txt_titulo.Text = ADAT.libroRow.titulo.ToString();
            txt_editorial.Text = ADAT.libroRow.editorial.ToString();
            txt_descripcion.Text = ADAT.libroRow.descripcion.ToString();
        }

        private void btNuevo_Click(object sender, RoutedEventArgs e)
        {
            limpiarCampos();
            dgEjemplares.ItemsSource = "";
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            adat.EliminarLibro();
            limpiarCampos();
        }

        private void btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(txt_isbn.Text) && !String.IsNullOrEmpty(txt_titulo.Text)
                && !String.IsNullOrEmpty(txt_editorial.Text) && !String.IsNullOrEmpty(txt_descripcion.Text))
            adat.ModificarLibro(txt_isbn.Text, txt_titulo.Text, txt_editorial.Text, txt_descripcion.Text);

            limpiarCampos();
        }
    }
}
