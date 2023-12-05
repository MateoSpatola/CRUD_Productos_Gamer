using System.Text;

namespace Entidades
{
    /// <summary>
    /// Clase que representa un monitor gamer.
    /// </summary>
    public class Monitor : ProductoGamer
    {
        private int tasaDeRefresco;
        private int pulgadas;
        private ETipoPanel tipoPanel;

        public Monitor() : base()
        {

        }

        /// <summary>
        /// Constructor de Monitor que inicializa sus propiedades básicas y características específicas del monitor.
        /// </summary>
        /// <param name="id">Id del monitor.</param>
        /// <param name="nombre">Nombre del monitor.</param>
        /// <param name="marca">Marca autorizada del monitor.</param>
        /// <param name="costo">Costo del monitor.</param>
        /// <param name="tasaDeRefresco">Tasa de refresco del monitor.</param>
        /// <param name="pulgadas">Tamaño en pulgadas del monitor.</param>
        /// <param name="tipoPanel">Tipo de panel del monitor.</param>
        public Monitor(int id, string nombre, EMarcasAutorizadas marca, double costo, int tasaDeRefresco, int pulgadas, ETipoPanel tipoPanel)
            : base(id, nombre, marca, costo)
        {
            tipoProducto = "Monitor";
            this.tasaDeRefresco = tasaDeRefresco;
            this.pulgadas = pulgadas;
            this.tipoPanel = tipoPanel;
        }

        /// <summary>
        /// Constructor de Monitor que inicializa sus propiedades básicas, stock y características específicas del monitor.
        /// </summary>
        /// <param name="id">Id del monitor.</param>
        /// <param name="nombre">Nombre del monitor.</param>
        /// <param name="marca">Marca autorizada del monitor.</param>
        /// <param name="costo">Costo del monitor.</param>
        /// <param name="stock">Cantidad en stock del monitor.</param>
        /// <param name="tasaDeRefresco">Tasa de refresco del monitor.</param>
        /// <param name="pulgadas">Tamaño en pulgadas del monitor.</param>
        /// <param name="tipoPanel">Tipo de panel del monitor.</param>
        public Monitor(int id, string nombre, EMarcasAutorizadas marca, double costo, int stock, int tasaDeRefresco, int pulgadas, ETipoPanel tipoPanel)
            : base(id, nombre, marca, costo, stock)
        {
            tipoProducto = "Monitor";
            this.tasaDeRefresco = tasaDeRefresco;
            this.pulgadas = pulgadas;
            this.tipoPanel = tipoPanel;
        }

        /// <summary>
        /// Constructor de Monitor que inicializa sus propiedades básicas, stock, garantía y características específicas del monitor.
        /// </summary>
        /// <param name="id">Id del monitor.</param>
        /// <param name="nombre">Nombre del monitor.</param>
        /// <param name "marca">Marca autorizada del monitor.</param>
        /// <param name="costo">Costo del monitor.</param>
        /// <param name="stock">Cantidad en stock del monitor.</param>
        /// <param name="tieneGarantia">Indica si el monitor tiene garantía.</param>
        /// <param name="tasaDeRefresco">Tasa de refresco del monitor.</param>
        /// <param name="pulgadas">Tamaño en pulgadas del monitor.</param>
        /// <param name="tipoPanel">Tipo de panel del monitor.</param>
        public Monitor(int id, string nombre, EMarcasAutorizadas marca, double costo, int stock, bool tieneGarantia, int tasaDeRefresco, int pulgadas, ETipoPanel tipoPanel)
            : base(id, nombre, marca, costo, stock, tieneGarantia)
        {
            tipoProducto = "Monitor";
            this.tasaDeRefresco = tasaDeRefresco;
            this.pulgadas = pulgadas;
            this.tipoPanel = tipoPanel;
        }

        public int TasaDeRefresco
        {
            get { return this.tasaDeRefresco; }
            set { this.tasaDeRefresco = value; }
        }

        public int Pulgadas
        {
            get { return this.pulgadas; }
            set { this.pulgadas = value; }
        }

        public ETipoPanel TipoPanel
        {
            get { return this.tipoPanel; }
            set { this.tipoPanel = value; }
        }

        public override void CalcularPrecioFinal()
        {
            this.PrecioFinal = (double)(this.Costo * 1.3);
        }

        public override string Disponibilidad()
        {
            string retorno = "Producto agotado";
            if (this.Stock > 0)
            {
                retorno = "Disponible solo en tienda en línea";
            }
            return retorno;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($" - Tasa De Refresco: {this.tasaDeRefresco}");
            sb.Append($" - Pulgadas: {this.pulgadas}");
            sb.Append($" - Tipo Panel: {this.tipoPanel}");
            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Monitor)
            {
                retorno = (this == (Monitor)obj);
            }
            return retorno;
        }

    }
}
