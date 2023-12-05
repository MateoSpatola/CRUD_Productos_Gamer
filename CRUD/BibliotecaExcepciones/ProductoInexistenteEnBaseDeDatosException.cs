namespace BibliotecaExcepciones
{
    /// <summary>
    /// Excepción que se lanza cuando un producto no existe en la base de datos.
    /// </summary>
    public class ProductoInexistenteEnBaseDeDatosException : Exception
    {
        /// <summary>
        /// Constructor de la excepción con un mensaje específico.
        /// </summary>
        /// <param name="mensaje">Mensaje descriptivo del error.</param>
        public ProductoInexistenteEnBaseDeDatosException(string mensaje) : base(mensaje)
        {
        }

        /// <summary>
        /// Constructor de la excepción con un mensaje específico y una excepción interna.
        /// </summary>
        /// <param name="mensaje">Mensaje descriptivo del error.</param>
        /// <param name="innerException">Excepción interna que causó la excepción.</param>
        public ProductoInexistenteEnBaseDeDatosException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
    }

}
