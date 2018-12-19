using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;

namespace Biblioteca
{
    public class ADAT
    {
        // Variable para guardar el numero de ejemplar a prestar:
        public int numEjemplar;

        // Invocamos la base de datos:
        public static bibliotecaDataSet dataSet = new bibliotecaDataSet();
        public static int registrosActualizados;

        // String para coger la conexión:
        string conexion = Properties.Settings.Default.bibliotecaConnectionString.ToString();

        // Cogemos datos de la base de datos:
        public static bibliotecaDataSet.LibroRow libroRow;
        public static bibliotecaDataSet.ejemplarRow ejemplarRow;
        public static bibliotecaDataSet.socioRow socioRow;

        public void InsertarLibro(string codigo, string isbn, string titulo, string editorial, string descripcion)
        {
            // Buscamos el libro para no añadir repetidos:
            BuscarLibro("isbn", isbn);

            if (libroRow == null)
            {
                try
                {
                    // Establecemos conexión:
                    SqlConnection connection = new SqlConnection(this.conexion);
                    connection.Open();
                    Debug.WriteLine("Conexión abierta");

                    // Creamos el constructor para insertar:
                    StringBuilder str_insert = new StringBuilder();
                    str_insert.AppendFormat("Insert Libro values('{0}', '{1}', '{2}', '{3}', '{4}'" +
                        ")", codigo, isbn, titulo, editorial, descripcion);

                    // Creamos Query:
                    SqlCommand comando = new SqlCommand(str_insert.ToString(), connection);

                    // Ejecutar Query:
                    registrosActualizados = comando.ExecuteNonQuery();

                    // Cerramos la conexión:
                    connection.Close();
                    Debug.WriteLine("Conexión cerrada");
                }
                catch (Exception er)
                {
                    MessageBox.Show("Ha ocurrido un error.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    Debug.WriteLine(er.ToString());
                }
            }
        }

        public void InsertarEjemplar(string codigo, DateTime fecha, int numEjemplar)
        {
            BuscarLibro("codigo", codigo);

            try
            {
                // Establecemos conexión:
                SqlConnection connection = new SqlConnection(this.conexion);
                connection.Open();
                Debug.WriteLine("Conexión abierta");

                // Creamos el constructor para insertar:
                StringBuilder str_insert = new StringBuilder();
                str_insert.AppendFormat("Insert ejemplar values('{0}','{1}','{2}','{3}')", codigo, numEjemplar, fecha, "D");

                // Creamos Query:
                SqlCommand comando = new SqlCommand(str_insert.ToString(), connection);

                // Ejecutar Query:
                registrosActualizados = comando.ExecuteNonQuery();

                // Cerramos la conexión:
                connection.Close();
                Debug.WriteLine("Conexión cerrada");
            }
            catch (Exception er)
            {
                MessageBox.Show("Ha ocurrido un error.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                Debug.WriteLine(er.ToString());
            }
        }

        public void BuscarEjemplar(string codigo)
        {
            // Limpiamos la referencia de ejemplar:
            dataSet.ejemplar.Clear();

            try
            {
                // Establecemos conexión:
                SqlConnection connection = new SqlConnection(this.conexion);
                connection.Open();
                Debug.WriteLine("Conexión abierta");

                // Creamos el constructor para insertar:
                StringBuilder str_insert = new StringBuilder();
                str_insert.AppendFormat("Select * from ejemplar Where codigo = " + codigo);

                // Creamos Query:
                SqlDataAdapter adapter = new SqlDataAdapter(str_insert.ToString(), connection);

                // Ejecutamos Query:
                adapter.Fill(dataSet.ejemplar);

                // Cerramos conexión:
                connection.Close();
                Debug.WriteLine("Conexión cerrada");

            }
            catch (Exception er)
            {
                MessageBox.Show("Ha ocurrido un error.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                Debug.WriteLine(er.ToString());
            }

        }

        public void BuscarLibro(string campo, string valor)
        {
            // Limpiamos la referencia a libro:
            dataSet.Libro.Clear();

            try
            {
                // Establecemos conexión:
                SqlConnection connection = new SqlConnection(this.conexion);
                connection.Open();
                Debug.WriteLine("Conexión abierta");

                // Creamos el constructor para insertar:
                StringBuilder str_insert = new StringBuilder();
                str_insert.AppendFormat("Select * from Libro Where " + campo + " = " + valor);

                // Creamos Query:
                SqlDataAdapter adapter = new SqlDataAdapter(str_insert.ToString(), connection);

                // Ejecutamos Query:
                adapter.Fill(dataSet.Libro);

                // Guardamos 'libroRow' si encontramos el libro:
                if (dataSet.Libro.Count == 1)
                {
                    libroRow = dataSet.Libro[0];
                    Debug.WriteLine("Libro guardado");
                }
                else
                {
                    if (dataSet.Libro.Count == 0)
                        libroRow = null;
                }

                // Cerramos la conexión:
                connection.Close();
                Debug.WriteLine("Conexión cerrada");
            }
            catch (Exception er)
            {
                libroRow = null;
                MessageBox.Show("Ha ocurrido un error.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                Debug.WriteLine(er.ToString());
            }
        }

        public void ModificarLibro(string isbn, string titulo, string editorial, string descripcion)
        {
            try
            {
                if (libroRow != null)
                {
                    // Establecemos conexión:
                    SqlConnection connection = new SqlConnection(this.conexion);
                    connection.Open();
                    Debug.WriteLine("Conexión abierta");

                    // Creamos el constructor:
                    StringBuilder str_insert = new StringBuilder();
                    str_insert.AppendFormat("Update Libro set isbn='{0}',titulo='{1}',editorial='{2}',descripcion='{3}' Where codigo='{4}'", isbn, titulo, editorial, descripcion, libroRow.codigo);

                    // Creamos Query:
                    SqlCommand comando = new SqlCommand(str_insert.ToString(), connection);

                    // Ejecutar Query:
                    registrosActualizados = comando.ExecuteNonQuery();

                    // Cerramos la conexión:
                    connection.Close();
                    Debug.WriteLine("Conexión cerrada");
                }
                else
                    MessageBox.Show("Busque un libro", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception er)
            {
                MessageBox.Show("Ha ocurrido un error.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                Debug.WriteLine(er.ToString());
            }
        }

        public void EliminarLibro()
        {
            try
            {
                if (libroRow != null)
                {
                    // Establecemos conexión:
                    SqlConnection connection = new SqlConnection(this.conexion);
                    connection.Open();
                    Debug.WriteLine("Conexión abierta");

                    // Creamos el constructor:
                    StringBuilder str_insert = new StringBuilder();
                    str_insert.AppendFormat("Delete from ejemplar Where codigo = " + libroRow.codigo);
                    str_insert.AppendFormat("Delete from Libro Where codigo = " + libroRow.codigo);

                    // Creamos Query:
                    SqlCommand comando = new SqlCommand(str_insert.ToString(), connection);

                    // Ejecutamos Query:
                    registrosActualizados = comando.ExecuteNonQuery();

                    // Cerramos la conexión:
                    connection.Close();
                    Debug.WriteLine("Conexión cerrada");

                    if (registrosActualizados > 0)
                        libroRow = null;

                    MessageBox.Show("Libro eliminado", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Ha ocurrido un error.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                Debug.WriteLine(er.ToString());
            }
        }

        public void BuscarEjemplarDisponible(string codigo)
        {
            dataSet.ejemplar.Clear();

            try
            {
                // Establecemos conexión:
                SqlConnection connection = new SqlConnection(this.conexion);
                connection.Open();
                Debug.WriteLine("Conexión abierta.");

                // Creamos el constructor para insertar:
                StringBuilder str_insert = new StringBuilder();
                str_insert.AppendFormat("Select top 1 * from Ejemplar Where codigo = " + codigo + " and estado = 'D'");

                // Creamos Query:
                SqlDataAdapter adapter = new SqlDataAdapter(str_insert.ToString(), connection);

                // Ejecutamos Query:
                adapter.Fill(dataSet.ejemplar);

                // Guardamos 'ejemplarRow' si encontramos el libro:
                if (dataSet.ejemplar.Count == 1)
                {
                    ejemplarRow = dataSet.ejemplar[0];
                    Debug.WriteLine("Ejemplar guardado");
                }
                else
                {
                    if (dataSet.ejemplar.Count == 0)
                        ejemplarRow = null;
                }

                // Cerramos conexión:
                connection.Close();
                Debug.WriteLine("Conexión cerrada.");
            }
            catch (Exception er)
            {
                MessageBox.Show("Ha ocurrido un error.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                Debug.WriteLine(er.ToString());
            }
        }

        public void BuscarEjemplarPrestado(string codigo)
        {
            dataSet.ejemplar.Clear();

            try
            {
                // Establecemos conexión:
                SqlConnection connection = new SqlConnection(this.conexion);
                connection.Open();
                Debug.WriteLine("Conexión abierta.");

                // Creamos el constructor para insertar:
                StringBuilder str_insert = new StringBuilder();
                str_insert.AppendFormat("Select top 1 * from Ejemplar Where codigo = " + codigo + " and estado = 'P'");

                // Creamos Query:
                SqlDataAdapter adapter = new SqlDataAdapter(str_insert.ToString(), connection);

                // Ejecutamos Query:
                adapter.Fill(dataSet.ejemplar);

                // Guardamos 'ejemplarRow' si encontramos el libro:
                if (dataSet.ejemplar.Count == 1)
                {
                    ejemplarRow = dataSet.ejemplar[0];
                    Debug.WriteLine("Ejemplar guardado");
                }
                else
                {
                    if (dataSet.ejemplar.Count == 0)
                        ejemplarRow = null;
                }

                // Cerramos conexión:
                connection.Close();
                Debug.WriteLine("Conexión cerrada.");
            }
            catch (Exception er)
            {
                MessageBox.Show("Ha ocurrido un error.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                Debug.WriteLine(er.ToString());
            }
        }

        public void PrestarLibro()
        {
            if (ejemplarRow != null)
            {
                try
                {
                    // Establecemos conexión:
                    SqlConnection connection = new SqlConnection(this.conexion);
                    connection.Open();
                    Debug.WriteLine("Conexión abierta.");

                    


                    // CAMBIAR EL ESTADO DEL LIBRO A PRESTADO (P)
                    // Creamos constructor:
                    StringBuilder str_insert = new StringBuilder();
                    str_insert.AppendFormat("Update ejemplar set estado ='P' where codigo = " + ejemplarRow.codigo +
                        " and numeroEjemp =" + ejemplarRow.numeroEjemp);

                    // Creamos Query:
                    SqlCommand comando = new SqlCommand(str_insert.ToString(), connection);

                    // Ejecutamos Query:
                    registrosActualizados = comando.ExecuteNonQuery();
                    
                    //Cerramos conexión.
                    connection.Close();
                    Debug.WriteLine("Conexión cerrada.");
                }
                catch (Exception er)
                {
                    MessageBox.Show("Ha ocurrido un error.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    Debug.WriteLine(er.ToString());
                }
            }
        }

        public void DevolverLibro()
        {
            if (ejemplarRow != null)
            {
                try
                {
                    // Establecemos conexión:
                    SqlConnection connection = new SqlConnection(this.conexion);
                    connection.Open();
                    Debug.WriteLine("Conexión abierta.");

                    // Creamos constructor:
                    StringBuilder str_insert = new StringBuilder();
                    str_insert.AppendFormat("Update ejemplar set estado ='D' where codigo = " + ejemplarRow.codigo +
                        " and numeroEjemp =" + ejemplarRow.numeroEjemp);

                    // Creamos Query:
                    SqlCommand comando = new SqlCommand(str_insert.ToString(), connection);

                    // Ejecutamos Query:
                    registrosActualizados = comando.ExecuteNonQuery();

                    //Cerramos conexión.
                    connection.Close();
                    Debug.WriteLine("Conexión cerrada.");
                }
                catch (Exception er)
                {
                    MessageBox.Show("Ha ocurrido un error.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    Debug.WriteLine(er.ToString());
                }
            }
        }

        public void AgregarSocio(string codigo, string dni, string nombre, string apellidos, string direccion, string correo, string telefono)
        {
            BuscarSocio(codigo);

            if (socioRow == null)
            {
                try
                {
                    // Establecemos conexión:
                    SqlConnection connection = new SqlConnection(this.conexion);
                    connection.Open();
                    Debug.WriteLine("Conexión abierta");

                    // Creamos el constructor para insertar:
                    StringBuilder str_insert = new StringBuilder();
                    str_insert.AppendFormat("Insert Socio values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}'" +
                        ")", codigo, dni, nombre, apellidos, direccion, correo, telefono);

                    // Creamos Query:
                    SqlCommand comando = new SqlCommand(str_insert.ToString(), connection);

                    // Ejecutar Query:
                    registrosActualizados = comando.ExecuteNonQuery();

                    // Cerramos la conexión:
                    connection.Close();
                    Debug.WriteLine("Conexión cerrada");
                    MessageBox.Show("Socio añadido", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception er)
                {
                    MessageBox.Show("Ha ocurrido un error.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    Debug.WriteLine(er.ToString());
                }
            }
            else
                MessageBox.Show("Código de socio ya utilizado", "", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void BuscarSocio(string codigo)
        {
            // Limpiamos la referencia a socio:
            dataSet.socio.Clear();

            try
            {
                // Establecemos conexión:
                SqlConnection connection = new SqlConnection(this.conexion);
                connection.Open();
                Debug.WriteLine("Conexión abierta");

                // Creamos el constructor para insertar:
                StringBuilder str_insert = new StringBuilder();
                str_insert.AppendFormat("Select * from socio Where codigo = " + codigo);

                // Creamos Query:
                SqlDataAdapter adapter = new SqlDataAdapter(str_insert.ToString(), connection);

                // Ejecutamos Query:
                adapter.Fill(dataSet.socio);

                // Guardamos 'libroRow' si encontramos el libro:
                if (dataSet.socio.Count == 1)
                {
                    socioRow = dataSet.socio[0];
                    Debug.WriteLine("Socio guardado");
                }
                else
                {
                    if (dataSet.socio.Count == 0)
                        socioRow = null;
                }

                // Cerramos la conexión:
                connection.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show("Ha ocurrido un error.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                Debug.WriteLine(er.ToString());
            }
        }

        public void BuscarPrestamo()
        {

        }
    }
}
