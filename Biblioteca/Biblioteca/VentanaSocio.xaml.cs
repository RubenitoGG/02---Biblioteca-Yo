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
    /// Lógica de interacción para VentanaSocio.xaml
    /// </summary>
    public partial class VentanaSocio : Window
    {
        ADAT adat = new ADAT();
        public VentanaSocio()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_codigo.Text) && !String.IsNullOrEmpty(txt_dni.Text) && !String.IsNullOrEmpty(txt_nombre.Text)
                && !String.IsNullOrEmpty(txt_apellido.Text) && !String.IsNullOrEmpty(txt_direccion.Text)
                && !String.IsNullOrEmpty(txt_correo.Text) && !String.IsNullOrEmpty(txt_telefono.Text))
            {
                adat.AgregarSocio(txt_codigo.Text, txt_dni.Text, txt_nombre.Text, txt_apellido.Text, txt_direccion.Text, txt_correo.Text, txt_telefono.Text);
                limpiarCampos();
            }
            else
                MessageBox.Show("Faltan campos por cubrir", "", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void limpiarCampos()
        {
            txt_codigo.Text = "";
            txt_apellido.Text = "";
            txt_correo.Text = "";
            txt_direccion.Text = "";
            txt_dni.Text = "";
            txt_nombre.Text = "";
            txt_telefono.Text = "";
        }
    }
}
