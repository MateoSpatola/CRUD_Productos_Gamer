namespace BibliotecaExcepciones
{
    /// <summary>
    /// Excepción que se lanza cuando una operación falla.
    /// </summary>
    public class OperacionFallidaException : Exception
    {
        /// <summary>
        /// Constructor de la excepción con un mensaje específico.
        /// </summary>
        /// <param name="mensaje">Mensaje descriptivo del error.</param>
        public OperacionFallidaException(string mensaje) : base(mensaje)
        {
        }

        /// <summary>
        /// Constructor de la excepción con un mensaje específico y una excepción interna.
        /// </summary>
        /// <param name="mensaje">Mensaje descriptivo del error.</param>
        /// <param name="innerException">Excepción interna que causó la excepción.</param>
        public OperacionFallidaException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
    }

}

