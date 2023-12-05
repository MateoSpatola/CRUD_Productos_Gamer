using System.Data.SqlClient;
using System.Threading;
using BibliotecaExcepciones;

namespace Entidades
{
    /// <summary>
    /// Clase que proporciona acceso a la base de datos para la gestión de productos gamers.
    /// </summary
    public class AccesoInventario
    {
        private static string cadena_conexion;
        private SqlConnection conexion;
        private SqlCommand comando;

        static AccesoInventario()
        {
            AccesoInventario.cadena_conexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=INVENTARIO_SP_DB;Integrated Security=True";
        }

        /// <summary>
        /// Agrega un producto gamer a la base de datos.
        /// </summary>
        /// <param name="productoGamer">Producto gamer a agregar.</param>
        /// <returns>True si la operación fue exitosa, false en caso contrario.</returns>
        public bool AgregarProductoGamer(ProductoGamer productoGamer)
        {
            bool retorno = false;
            try
            {
                using (this.conexion = new SqlConnection(AccesoInventario.cadena_conexion))
                {
                    string commandText = "INSERT INTO ProductosGamer (tipoProducto, nombre, marca, costo, precioFinal, stock, tieneGarantia, " +
                                         "tasaDeRefresco, pulgadas, tipoPanel, botonesProgramables, dpiMaximo, " +
                                         "esInalambrico, tipoTeclado, tieneIluminacionRGB) " +
                                         "VALUES(@tipoProducto, @nombre, @marca, @costo, @precioFinal, @stock, @tieneGarantia, " +
                                         "@tasaDeRefresco, @pulgadas, @tipoPanel, @botonesProgramables, @dpiMaximo, " +
                                         "@esInalambrico, @tipoTeclado, @tieneIluminacionRGB)";

                    this.comando = new SqlCommand(commandText, this.conexion);
                    AsignarParametros(productoGamer);

                    this.conexion.Open();

                    int filasAfectadas = this.comando.ExecuteNonQuery();
                    retorno = (filasAfectadas == 1);
                }
            }
            catch (SqlException ex)
            {
                throw new ConexionBaseDeDatosException("Error de conexión a la base de datos.", ex);
            }
            catch (Exception ex)
            {
                throw new OperacionFallidaException("Error al agregar el producto.", ex);
            }
            return retorno;
        }

        /// <summary>
        /// Obtiene una lista de productos gamers desde la base de datos.
        /// </summary>
        /// <returns>Lista de productos gamers.</returns>
        public List<ProductoGamer> ObtenerListaProductosGamer()
        {
            List<ProductoGamer> listaProductos = new List<ProductoGamer>();
            try
            {
                using (this.conexion = new SqlConnection(AccesoInventario.cadena_conexion))
                {
                    string commandText = "SELECT id, tipoProducto, nombre, marca, costo, stock, tieneGarantia, " +
                                         "tasaDeRefresco, pulgadas, tipoPanel, botonesProgramables, dpiMaximo, " +
                                         "esInalambrico, tipoTeclado, tieneIluminacionRGB FROM ProductosGamer ";

                    this.comando = new SqlCommand(commandText, this.conexion);
                    this.conexion.Open();
                    SqlDataReader reader = this.comando.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string tipoProducto = reader["tipoProducto"].ToString();
                        string? nombre = reader["nombre"].ToString();
                        EMarcasAutorizadas marca = (EMarcasAutorizadas)Enum.Parse(typeof(EMarcasAutorizadas), reader["marca"].ToString());
                        double costo = (double)reader["costo"];
                        int stock = Convert.ToInt32(reader["stock"]);
                        bool tieneGarantia = reader["tieneGarantia"].ToString() == "Si" ? true : false;

                        if (tipoProducto == "Monitor")
                        {
                            int tasaDeRefresco = Convert.ToInt32(reader["tasaDeRefresco"]);
                            int pulgadas = Convert.ToInt32(reader["pulgadas"]);
                            ETipoPanel tipoPanel = (ETipoPanel)Enum.Parse(typeof(ETipoPanel), reader["tipoPanel"].ToString());
                            Monitor monitor = new Monitor(id, nombre, marca, costo, stock, tieneGarantia, tasaDeRefresco, pulgadas, tipoPanel);
                            listaProductos.Add(monitor);
                        }
                        else if (tipoProducto == "Mouse")
                        {
                            int botonesProgramables = Convert.ToInt32(reader["botonesProgramables"]);
                            int dpiMaximo = Convert.ToInt32(reader["dpiMaximo"]);
                            bool esInalambrico = reader["esInalambrico"].ToString() == "Si" ? true : false;
                            Mouse mouse = new Mouse(id, nombre, marca, costo, stock, tieneGarantia, botonesProgramables, dpiMaximo, esInalambrico);
                            listaProductos.Add(mouse);
                        }
                        else if (tipoProducto == "Teclado")
                        {
                            ETipoTeclado tipoTeclado = (ETipoTeclado)Enum.Parse(typeof(ETipoTeclado), reader["tipoTeclado"].ToString());
                            bool tieneIluminacionRGB = reader["tieneIluminacionRGB"].ToString() == "Si" ? true : false;
                            bool esInalambrico = reader["esInalambrico"].ToString() == "Si" ? true : false;
                            Teclado teclado = new Teclado(id, nombre, marca, costo, stock, tieneGarantia, tipoTeclado, tieneIluminacionRGB, esInalambrico);
                            listaProductos.Add(teclado);
                        }
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                throw new ConexionBaseDeDatosException("Error de conexión a la base de datos.", ex);
            }
            catch (Exception ex)
            {
                throw new OperacionFallidaException("Error al obtener los productos.", ex);
            }
            return listaProductos;
        }

        /// <summary>
        /// Modifica un producto gamer en la base de datos.
        /// </summary>
        /// <param name="productoGamer">Producto gamer modificado.</param>
        /// <returns>True si la operación fue exitosa, false en caso contrario.</returns>
        public bool ModificarProductoGamer(ProductoGamer productoGamer)
        {
            bool retorno = false;
            try
            {
                using (this.conexion = new SqlConnection(AccesoInventario.cadena_conexion))
                {
                    string commandText = "UPDATE ProductosGamer SET tipoProducto = @tipoProducto, nombre = @nombre, marca = @marca, " +
                                         "costo = @costo, precioFinal = @precioFinal, stock = @stock, tieneGarantia = @tieneGarantia, " +
                                         "tasaDeRefresco = @tasaDeRefresco, pulgadas = @pulgadas, tipoPanel = @tipoPanel," +
                                         " botonesProgramables = @botonesProgramables, dpiMaximo = @dpiMaximo, esInalambrico = @esInalambrico, " +
                                         "tipoTeclado = @tipoTeclado, tieneIluminacionRGB = @tieneIluminacionRGB WHERE id = @id";
                    
                    this.comando = new SqlCommand(commandText, this.conexion);
                    AsignarParametros(productoGamer);
                    this.conexion.Open();

                    int filasAfectadas = this.comando.ExecuteNonQuery();
                    if (filasAfectadas == 0)
                    {
                        throw new ProductoInexistenteEnBaseDeDatosException("El producto que intentas modificar no existe en la base de datos.");
                    }
                    retorno = (filasAfectadas == 1);
                }
            }
            catch (SqlException ex)
            {
                throw new ConexionBaseDeDatosException("Error de conexión a la base de datos.", ex);
            }
            catch (Exception ex)
            {
                throw new OperacionFallidaException("Error al modificar el producto.", ex);
            }
            return retorno;
        }

        /// <summary>
        /// Elimina un producto gamer de la base de datos.
        /// </summary>
        /// <param name="productoGamer">Producto gamer a eliminar.</param>
        /// <returns>True si la operación fue exitosa, false en caso contrario.</returns>
        public bool EliminarProductoGamer(ProductoGamer productoGamer)
        {
            bool retorno = false;
            try
            {
                using (this.conexion = new SqlConnection(AccesoInventario.cadena_conexion))
                {
                    string commandText = "DELETE FROM ProductosGamer WHERE id = @id";
                    this.comando = new SqlCommand(commandText, this.conexion);
                    this.comando.Parameters.AddWithValue("@id", productoGamer.Id);
                    this.conexion.Open();

                    int filasAfectadas = this.comando.ExecuteNonQuery();
                    if (filasAfectadas == 0)
                    {
                        throw new ProductoInexistenteEnBaseDeDatosException("El producto que intentas eliminar no existe en la base de datos.");
                    }
                    retorno = (filasAfectadas == 1);;
                }
            }
            catch (SqlException ex)
            {
                throw new ConexionBaseDeDatosException("Error de conexión a la base de datos.", ex);
            }
            catch (Exception ex)
            {
                throw new OperacionFallidaException("Error al eliminar el producto.", ex);
            }
            return retorno;
        }

        /// <summary>
        /// Asigna los parámetros del producto gamer al comando SQL.
        /// </summary>
        /// <param name="productoGamer">Producto gamer del cual asignar los parámetros.</param>
        private void AsignarParametros(ProductoGamer productoGamer)
        {
            this.comando.Parameters.AddWithValue("@id", productoGamer.Id);
            this.comando.Parameters.AddWithValue("@tipoProducto", productoGamer.TipoProducto);
            this.comando.Parameters.AddWithValue("@nombre", productoGamer.Nombre);
            this.comando.Parameters.AddWithValue("@marca", productoGamer.Marca.ToString());
            this.comando.Parameters.AddWithValue("@costo", productoGamer.Costo);
            productoGamer.CalcularPrecioFinal();
            this.comando.Parameters.AddWithValue("@precioFinal", productoGamer.PrecioFinal);
            this.comando.Parameters.AddWithValue("@stock", productoGamer.Stock);
            this.comando.Parameters.AddWithValue("@tieneGarantia", productoGamer.TieneGarantia ? "Si" : "No");

            if (productoGamer is Monitor monitor)
            {
                AsignarParametrosMonitor(monitor);
            }
            else if (productoGamer is Mouse mouse)
            {
                AsignarParametrosMouse(mouse);
            }
            else if (productoGamer is Teclado teclado)
            {
                AsignarParametrosTeclado(teclado);
            }
        }

        /// <summary>
        /// Asigna los parámetros específicos de un monitor al comando SQL.
        /// </summary>
        /// <param name="monitor">Monitor del cual asignar los parámetros específicos.</param>
        private void AsignarParametrosMonitor(Monitor monitor)
        {
            this.comando.Parameters.AddWithValue("@tasaDeRefresco", monitor.TasaDeRefresco);
            this.comando.Parameters.AddWithValue("@pulgadas", monitor.Pulgadas);
            this.comando.Parameters.AddWithValue("@tipoPanel", monitor.TipoPanel.ToString());
            this.comando.Parameters.AddWithValue("@botonesProgramables", DBNull.Value);
            this.comando.Parameters.AddWithValue("@dpiMaximo", DBNull.Value);
            this.comando.Parameters.AddWithValue("@esInalambrico", DBNull.Value);
            this.comando.Parameters.AddWithValue("@tipoTeclado", DBNull.Value);
            this.comando.Parameters.AddWithValue("@tieneIluminacionRGB", DBNull.Value);
        }

        /// <summary>
        /// Asigna los parámetros específicos de un mouse al comando SQL.
        /// </summary>
        /// <param name="mouse">Mouse del cual asignar los parámetros específicos.</param>
        private void AsignarParametrosMouse(Mouse mouse)
        {
            this.comando.Parameters.AddWithValue("@tasaDeRefresco", DBNull.Value);
            this.comando.Parameters.AddWithValue("@pulgadas", DBNull.Value);
            this.comando.Parameters.AddWithValue("@tipoPanel", DBNull.Value);
            this.comando.Parameters.AddWithValue("@botonesProgramables", mouse.BotonesProgramables);
            this.comando.Parameters.AddWithValue("@dpiMaximo", mouse.DpiMaximo);
            this.comando.Parameters.AddWithValue("@esInalambrico", mouse.EsInalambrico ? "Si" : "No");
            this.comando.Parameters.AddWithValue("@tipoTeclado", DBNull.Value);
            this.comando.Parameters.AddWithValue("@tieneIluminacionRGB", DBNull.Value);
        }

        /// <summary>
        /// Asigna los parámetros específicos de un teclado al comando SQL.
        /// </summary>
        /// <param name="teclado">Teclado del cual asignar los parámetros específicos.</param>
        private void AsignarParametrosTeclado(Teclado teclado)
        {
            this.comando.Parameters.AddWithValue("@tasaDeRefresco", DBNull.Value);
            this.comando.Parameters.AddWithValue("@pulgadas", DBNull.Value);
            this.comando.Parameters.AddWithValue("@tipoPanel", DBNull.Value);
            this.comando.Parameters.AddWithValue("@botonesProgramables", DBNull.Value);
            this.comando.Parameters.AddWithValue("@dpiMaximo", DBNull.Value);
            this.comando.Parameters.AddWithValue("@esInalambrico", teclado.EsInalambrico ? "Si" : "No");
            this.comando.Parameters.AddWithValue("@tipoTeclado", teclado.TipoTeclado.ToString());
            this.comando.Parameters.AddWithValue("@tieneIluminacionRGB", teclado.TieneIluminacionRGB ? "Si" : "No");
        }
    }
}
