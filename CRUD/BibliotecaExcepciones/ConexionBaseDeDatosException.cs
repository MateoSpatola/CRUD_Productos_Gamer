namespace BibliotecaExcepciones
{
    /// <summary>
    /// Excepción que se lanza cuando hay un error de conexión a la base de datos.
    /// </summary>
    public class ConexionBaseDeDatosException : Exception
    {
        /// <summary>
        /// Constructor de la excepción con un mensaje específico.
        /// </summary>
        /// <param name="mensaje">Mensaje descriptivo del error.</param>
        public ConexionBaseDeDatosException(string mensaje) : base(mensaje)
        {

        }

        /// <summary>
        /// Constructor de la excepción con un mensaje específico y una excepción interna.
        /// </summary>
        /// <param name="mensaje">Mensaje descriptivo del error.</param>
        /// <param name="innerException">Excepción interna que causó la excepción.</param>
        public ConexionBaseDeDatosException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}
