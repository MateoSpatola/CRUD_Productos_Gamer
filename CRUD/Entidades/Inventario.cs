namespace Entidades
{
    /// <summary>
    /// Clase que representa un inventario de productos.
    /// </summary>
    public class Inventario<T> : IAcomodable<T>
        where T : class, IProducto
    {
        private List<T> productos;

        /// <summary>
        /// Constructor por defecto de Inventario.
        /// Inicializa la lista de productos.
        /// </summary>
        public Inventario()
        {
            this.productos = new List<T>();
        }

        public List<T> Productos
        {
            get { return this.productos; }
            set { this.productos = value; }
        }

        /// <summary>
        /// Organiza el inventario acomodando cada producto.
        /// </summary>
        public void OrganizarInventario()
        {
            foreach (T producto in this.productos)
            {
                this.Acomodar(producto);
            }
        }

        /// <summary>
        /// Acomoda un producto en el inventario.
        /// </summary>
        /// <param name="producto">Producto a acomodar.</param>
        /// <returns>Mensaje indicando que se está acomodando el producto.</returns>
        public string Acomodar(T producto)
        {
            return $"Acomodando el {producto.TipoProducto.ToLower()}: {producto.Nombre}";
        }


        /// <summary>
        /// Compara un inventario con un producto para verificar si el producto existe en el inventario.
        /// </summary>
        /// <param name="i">El inventario a comparar.</param>
        /// <param name="p">El producto a buscar en el inventario.</param>
        /// <returns>True si el producto existe en el inventario; de lo contrario, false.</returns>
        public static bool operator ==(Inventario<T> i, T p)
        {
            bool retorno = false;
            foreach (T producto in i.productos)
            {
                if (producto == p)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Compara un inventario con un producto para verificar si el producto no existe en el inventario.
        /// </summary>
        /// <param name="i">El inventario a comparar.</param>
        /// <param name="p">El producto a buscar en el inventario.</param>
        /// <returns>True si el producto no existe en el inventario; de lo contrario, false.</returns>
        public static bool operator !=(Inventario<T> i, T p)
        {
            return !(i == p);
        }

        /// <summary>
        /// Agrega un producto al inventario si no existe en el mismo.
        /// </summary>
        /// <param name="i">El inventario al que se agregará el producto.</param>
        /// <param name="p">El producto a agregar al inventario.</param>
        /// <returns>El inventario actualizado con el producto, si se agregó con éxito.</returns>
        public static Inventario<T> operator +(Inventario<T> i, T p)
        {
            if (i != p)
            {
                i.productos.Add(p);
            }
            return i;
        }

        /// <summary>
        /// Elimina un producto del inventario si existe en el mismo.
        /// </summary>
        /// <param name="i">El inventario del que se eliminará el producto.</param>
        /// <param name="p">El producto a eliminar del inventario.</param>
        /// <returns>El inventario actualizado sin el producto, si se eliminó con éxito.</returns>
        public static Inventario<T> operator -(Inventario<T> i, T p)
        {
            if (i == p)
            {
                i.productos.Remove(p);
            }
            return i;
        }

        /// <summary>
        /// Compara dos productos por su stock en orden ascendente.
        /// </summary>
        public static int OrdenarProductosPorStockAscendente(T p1, T p2)
        {
            if (p1.Stock < p2.Stock)
                return -1;
            else if (p1.Stock > p2.Stock)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// Compara dos productos por su stock en orden descendente.
        /// </summary>
        public static int OrdenarProductosPorStockDescendente(T p1, T p2)
        {
            if (p1.Stock > p2.Stock)
                return -1;
            else if (p1.Stock < p2.Stock)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// Compara dos productos por su nombre en orden ascendente.
        /// </summary>
        public static int OrdenarProductosPorNombreAscendente(T p1, T p2)
        {
            int comparacion = String.Compare(p1.Nombre, p2.Nombre);
            if (comparacion < 0)
                return -1;
            else if (comparacion > 0)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// Compara dos productos por su nombre en orden descendente.
        /// </summary>
        public static int OrdenarProductosPorNombreDescendente(T p1, T p2)
        {
            int comparacion = String.Compare(p1.Nombre, p2.Nombre);
            if (comparacion > 0)
                return -1;
            else if (comparacion < 0)
                return 1;
            else
                return 0;
        }
    }
}

