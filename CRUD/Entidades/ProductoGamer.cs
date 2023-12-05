using System.Text;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase abstracta que representa un producto gamer genérico.
    /// </summary>
    [XmlInclude(typeof(Entidades.Monitor))]
    [XmlInclude(typeof(Entidades.Teclado))]
    [XmlInclude(typeof(Entidades.Mouse))]
    public abstract class ProductoGamer : IProducto
    {
        [XmlElement]
        private int id;
        private string? nombre;
        private EMarcasAutorizadas marca;
        private double costo;
        private double precioFinal;
        private int stock;
        private bool tieneGarantia;
        protected string? tipoProducto;

        /// <summary>
        /// Constructor por defecto de ProductoGamer.
        /// Inicializa el stock a 0 y la garantía a falso.
        /// </summary>
        protected ProductoGamer()
        {
            this.stock = 0;
            this.tieneGarantia = false;
        }

        /// <summary>
        /// Constructor de ProductoGamer con nombre, marca y costo.
        /// </summary>
        /// <param name="id">Id del producto.</param>
        /// <param name="nombre">Nombre del producto.</param>
        /// <param name="marca">Marca autorizada del producto.</param>
        /// <param name="costo">Costo del producto.</param>
        protected ProductoGamer(int id, string nombre, EMarcasAutorizadas marca, double costo)
            : this()
        {
            this.id = id;
            this.nombre = nombre;
            this.marca = marca;
            this.costo = costo;
        }

        /// <summary>
        /// Constructor de ProductoGamer con nombre, marca, costo y stock.
        /// </summary>
        /// <param name="id">Id del producto.</param>
        /// <param name="nombre">Nombre del producto.</param>
        /// <param name="marca">Marca autorizada del producto.</param>
        /// <param name="costo">Costo del producto.</param>
        /// <param name="stock">Stock del producto.</param>
        protected ProductoGamer(int id, string nombre, EMarcasAutorizadas marca, double costo, int stock)
            : this(id, nombre, marca, costo)
        {
            if (stock > 0)
            {
                this.stock = stock;
            }
        }

        /// <summary>
        /// Constructor de ProductoGamer con nombre, marca y costo, stock y garantia.
        /// </summary>
        /// <param name="id">Id del producto.</param>
        /// <param name="nombre">Nombre del producto.</param>
        /// <param name="marca">Marca autorizada del producto.</param>
        /// <param name="costo">Costo del producto.</param>
        /// <param name="stock">Stock del producto.</param>
        /// <param name="tieneGarantia">Garantia del producto.</param>
        protected ProductoGamer(int id, string nombre, EMarcasAutorizadas marca, double costo, int stock, bool tieneGarantia)
            : this(id, nombre, marca, costo, stock)
        {
            this.tieneGarantia = tieneGarantia;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string TipoProducto
        {
            get { return this.tipoProducto; }
            set { this.tipoProducto = value; }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public EMarcasAutorizadas Marca
        {
            get { return this.marca; }
            set { this.marca = value; }
        }

        public double Costo
        {
            get { return this.costo; }
            set { this.costo = value; }
        }

        public double PrecioFinal
        {
            get { return this.precioFinal; }
            set { this.precioFinal = value; }
        }

        public int Stock
        {
            get { return this.stock; }
            set
            {
                if (value > 0)
                {
                    this.stock = value;
                }
            }
        }

        public bool TieneGarantia
        {
            get { return this.tieneGarantia; }
            set { this.tieneGarantia = value; }
        }

        /// <summary>
        /// Método abstracto para calcular el precio final del producto.
        /// </summary>
        public abstract void CalcularPrecioFinal();

        /// <summary>
        /// Método para calcular el precio final del producto con un porcentaje de ganancia.
        /// </summary>
        /// <param name="porcentajeGanancia">Porcentaje de ganancia a aplicar.</param>
        public void CalcularPrecioFinal(double porcentajeGanancia)
        {
            if (porcentajeGanancia > 0)

            {
                this.PrecioFinal = (double)(this.Costo + (this.Costo * porcentajeGanancia / 100));
            }
            else
            {
                this.CalcularPrecioFinal();
            }
        }

        /// <summary>
        /// Método virtual que devuelve la disponibilidad del producto.
        /// </summary>
        /// <returns>Texto que indica la disponibilidad del producto.</returns>
        public virtual string Disponibilidad()
        {
            string retorno = "Producto agotado";
            if (this.Stock > 0)
            {
                retorno = "Disponible en tiendas físicas y en línea";
            }
            return retorno;
        }

        /// <summary>
        /// Sobrecarga del método ToString para obtener una representación de la instancia en forma de cadena.
        /// </summary>
        /// <returns>Cadena que representa la instancia de ProductoGamer.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Id: {this.id}");
            sb.Append($" - Nombre: {this.nombre}");
            sb.Append($" - Marca: {this.marca}");
            sb.Append($" - Costo: {this.costo}");
            sb.Append($" - Precio Final: {this.precioFinal:0.00}");
            sb.Append($" - Stock: {this.stock}");
            sb.Append(this.tieneGarantia ? " - Garantia: Si" : " - Garantia: No");
            return sb.ToString();
        }

        /// <summary>
        /// Compara dos objetos de la clase ProductoGamer para determinar si son iguales.
        /// La igualdad se basa en el nombre y la marca del producto.
        /// </summary>
        /// <param name="p1">Primer objeto ProductoGamer a comparar.</param>
        /// <param name="p2">Segundo objeto ProductoGamer a comparar.</param>
        /// <returns>True si los productos son iguales; de lo contrario, false.</returns>
        public static bool operator ==(ProductoGamer p1, ProductoGamer p2)
        {
            return (p1.nombre == p2.nombre) && (p1.marca == p2.marca);
        }

        /// <summary>
        /// Compara dos objetos de la clase ProductoGamer para determinar si son diferentes.
        /// La diferencia se basa en el nombre y la marca del producto.
        /// </summary>
        /// <param name="p1">Primer objeto ProductoGamer a comparar.</param>
        /// <param name="p2">Segundo objeto ProductoGamer a comparar.</param>
        /// <returns>True si los productos son diferentes; de lo contrario, false.</returns>
        public static bool operator !=(ProductoGamer p1, ProductoGamer p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Determina si el objeto actual es igual a otro objeto de la clase ProductoGamer.
        /// La igualdad se basa en el nombre y la marca del producto.
        /// </summary>
        /// <param name="obj">El objeto a comparar con el objeto actual.</param>
        /// <returns>True si los productos son iguales; de lo contrario, false.</returns>
        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is ProductoGamer)
            {
                retorno = (this == (ProductoGamer)obj);
            }
            return retorno;
        }
    }
}