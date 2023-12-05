using System.Text;

namespace Entidades
{
    /// <summary>
    /// Clase que representa un mouse gamer.
    /// </summary>
    public class Mouse : ProductoGamer, IConfigurable<Mouse>
    {
        private int botonesProgramables;
        private int dpiMaximo;
        private bool esInalambrico;

        public Mouse() : base()
        {

        }

        /// <summary>
        /// Constructor de Mouse que inicializa sus propiedades básicas y características específicas de mouse.
        /// </summary>
        /// <param name="id">Id del mouse.</param>
        /// <param name="nombre">Nombre del mouse.</param>
        /// <param name="marca">Marca autorizada del mouse.</param>
        /// <param name="costo">Costo del mouse.</param>
        /// <param name="botonesProgramables">Número de botones programables del mouse.</param>
        /// <param name="dpiMaximo">DPI máximo del mouse.</param>
        /// <param name="esInalambrico">Indica si el mouse es inalámbrico.</param>
        public Mouse(int id, string nombre, EMarcasAutorizadas marca, double costo, int botonesProgramables, int dpiMaximo, bool esInalambrico)
            : base(id, nombre, marca, costo)
        {
            tipoProducto = "Mouse";
            this.botonesProgramables = botonesProgramables;
            this.dpiMaximo = dpiMaximo;
            this.esInalambrico = esInalambrico;
        }

        /// <summary>
        /// Constructor de Mouse que inicializa sus propiedades básicas, stock y características específicas de mouse.
        /// </summary>
        /// <param name="id">Id del mouse.</param>
        /// <param name="nombre">Nombre del mouse.</param>
        /// <param name="marca">Marca autorizada del mouse.</param>
        /// <param name="costo">Costo del mouse.</param>
        /// <param name="stock">Cantidad en stock del mouse.</param>
        /// <param name="botonesProgramables">Número de botones programables del mouse.</param>
        /// <param name="dpiMaximo">DPI máximo del mouse.</param>
        /// <param name="esInalambrico">Indica si el mouse es inalámbrico.</param>
        public Mouse(int id, string nombre, EMarcasAutorizadas marca, double costo, int stock, int botonesProgramables, int dpiMaximo, bool esInalambrico)
            : base(id, nombre, marca, costo, stock)
        {
            tipoProducto = "Mouse";
            this.botonesProgramables = botonesProgramables;
            this.dpiMaximo = dpiMaximo;
            this.esInalambrico = esInalambrico;
        }

        /// <summary>
        /// Constructor de Mouse que inicializa sus propiedades básicas, stock, garantía y características específicas de mouse.
        /// </summary>
        /// <param name="id">Id del mouse.</param>
        /// <param name="nombre">Nombre del mouse.</param>
        /// <param name="marca">Marca autorizada del mouse.</param>
        /// <param name="costo">Costo del mouse.</param>
        /// <param name="stock">Cantidad en stock del mouse.</param>
        /// <param name="tieneGarantia">Indica si el mouse tiene garantía.</param>
        /// <param name="botonesProgramables">Número de botones programables del mouse.</param>
        /// <param name="dpiMaximo">DPI máximo del mouse.</param>
        /// <param name="esInalambrico">Indica si el mouse es inalámbrico.</param>
        public Mouse(int id, string nombre, EMarcasAutorizadas marca, double costo, int stock, bool tieneGarantia, int botonesProgramables, int dpiMaximo, bool esInalambrico)
            : base(id, nombre, marca, costo, stock, tieneGarantia)
        {
            tipoProducto = "Mouse";
            this.botonesProgramables = botonesProgramables;
            this.dpiMaximo = dpiMaximo;
            this.esInalambrico = esInalambrico;
        }
        public int BotonesProgramables
        {
            get { return this.botonesProgramables; }
            set { this.botonesProgramables = value; }
        }

        public int DpiMaximo
        {
            get { return this.dpiMaximo; }
            set { this.dpiMaximo = value; }
        }

        public bool EsInalambrico
        {
            get { return this.esInalambrico; }
            set { this.esInalambrico = value; }
        }

        public override void CalcularPrecioFinal()
        {
            this.PrecioFinal = (double)(this.Costo * 1.50);
        }

        public override string Disponibilidad()
        {
            string retorno = "Producto agotado";
            if (this.Stock > 0)
            {
                retorno = "Disponible solo en tiendas físicas";
            }
            return retorno;
        }

        public string ConfigurarConexion()
        {
            return "Configurando la conexion del mouse...";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($" - Botones Programables: {this.botonesProgramables}");
            sb.Append($" - Dpi Maximo: {this.dpiMaximo}");
            sb.Append(this.esInalambrico ? " - Es Inalambrico: Si" : " - Es Inalambrico: No");
            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Mouse)
            {
                retorno = (this == (Mouse)obj);
            }
            return retorno;
        }
    }
}
