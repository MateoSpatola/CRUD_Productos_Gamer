namespace Entidades
{
    /// <summary>
    /// Clase que contiene los argumentos para eventos relacionados con productos gamer.
    /// </summary>
    public class ProductoEventArgs : EventArgs
    {
        private ProductoGamer producto;

        /// <summary>
        /// Inicializa una nueva instancia de la clase ProductoEventArgs.
        /// </summary>
        /// <param name="producto">Producto gamer asociado a los argumentos.</param>
        public ProductoEventArgs(ProductoGamer producto)
        {
            this.producto = producto;
        }

        /// <summary>
        /// Obtiene o establece el producto gamer asociado a los argumentos.
        /// </summary>
        public ProductoGamer Producto
        {
            get { return producto; }
            set { producto = value; }
        }
    }
}
