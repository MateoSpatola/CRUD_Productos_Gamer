using System.Text;

namespace Entidades
{
    /// <summary>
    /// Clase que representa un teclado gamer.
    /// </summary>
    public class Teclado : ProductoGamer, IConfigurable<Teclado>
    {
        private ETipoTeclado tipoTeclado;
        private bool tieneIluminacionRGB;
        private bool esInalambrico;

        public Teclado() : base()
        {
            
        }

        /// <summary>
        /// Constructor de Teclado que inicializa sus propiedades básicas y características específicas de teclado.
        /// </summary>
        /// <param name="id">Id del teclado.</param>
        /// <param name="nombre">Nombre del teclado.</param>
        /// <param name="marca">Marca autorizada del teclado.</param>
        /// <param name="costo">Costo del teclado.</param>
        /// <param name="tipoTeclado">Tipo de teclado.</param>
        /// <param name="tieneIluminacionRGB">Indica si el teclado tiene iluminación RGB.</param>
        /// <param name="esInalambrico">Indica si el teclado es inalámbrico.</param>
        public Teclado(int id, string nombre, EMarcasAutorizadas marca, double costo, ETipoTeclado tipoTeclado, bool tieneIluminacionRGB, bool esInalambrico)
            : base(id, nombre, marca, costo)
        {
            tipoProducto = "Teclado";
            this.tipoTeclado = tipoTeclado;
            this.tieneIluminacionRGB = tieneIluminacionRGB;
            this.esInalambrico = esInalambrico;
        }

        /// <summary>
        /// Constructor de Teclado que inicializa sus propiedades básicas, stock y características específicas de teclado.
        /// </summary>
        /// <param name="id">Id del teclado.</param>
        /// <param name="nombre">Nombre del teclado.</param>
        /// <param name="marca">Marca autorizada del teclado.</param>
        /// <param name="costo">Costo del teclado.</param>
        /// <param name="stock">Cantidad en stock del teclado.</param>
        /// <param name="tipoTeclado">Tipo de teclado.</param>
        /// <param name="tieneIluminacionRGB">Indica si el teclado tiene iluminación RGB.</param>
        /// <param name="esInalambrico">Indica si el teclado es inalámbrico.</param>
        public Teclado(int id, string nombre, EMarcasAutorizadas marca, double costo, int stock, ETipoTeclado tipoTeclado, bool tieneIluminacionRGB, bool esInalambrico)
            : base(id, nombre, marca, costo, stock)
        {
            tipoProducto = "Teclado";
            this.tipoTeclado = tipoTeclado;
            this.tieneIluminacionRGB = tieneIluminacionRGB;
            this.esInalambrico = esInalambrico;
        }

        /// <summary>
        /// Constructor de Teclado que inicializa sus propiedades básicas, stock, garantía y características específicas de teclado.
        /// </summary>
        /// <param name="id">Id del teclado.</param>
        /// <param name="nombre">Nombre del teclado.</param>
        /// <param name="marca">Marca autorizada del teclado.</param>
        /// <param name="costo">Costo del teclado.</param>
        /// <param name="stock">Cantidad en stock del teclado.</param>
        /// <param name="tieneGarantia">Indica si el teclado tiene garantía.</param>
        /// <param name="tipoTeclado">Tipo de teclado (por ejemplo, mecánico, membrana, etc.).</param>
        /// <param name="tieneIluminacionRGB">Indica si el teclado tiene iluminación RGB.</param>
        /// <param name="esInalambrico">Indica si el teclado es inalámbrico.</param>
        public Teclado(int id, string nombre, EMarcasAutorizadas marca, double costo, int stock, bool tieneGarantia, ETipoTeclado tipoTeclado, bool tieneIluminacionRGB, bool esInalambrico)
            : base(id, nombre, marca, costo, stock, tieneGarantia)
        {
            tipoProducto = "Teclado";
            this.tipoTeclado = tipoTeclado;
            this.tieneIluminacionRGB = tieneIluminacionRGB;
            this.esInalambrico = esInalambrico;
        }

        public ETipoTeclado TipoTeclado
        {
            get { return this.tipoTeclado; }
            set { this.tipoTeclado = value; }
        }

        public bool TieneIluminacionRGB
        {
            get { return this.tieneIluminacionRGB; }
            set { this.tieneIluminacionRGB = value; }
        }

        public bool EsInalambrico
        {
            get { return this.esInalambrico; }
            set { this.esInalambrico = value; }
        }

        public override void CalcularPrecioFinal()
        {
            this.PrecioFinal = (double)(this.Costo * 1.40);
        }

        public string ConfigurarConexion()
        {
            return "Configurando la conexion del teclado...";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($" - Tipo Teclado: {this.tipoTeclado}");
            sb.Append(this.tieneIluminacionRGB ? " - Iluminacion RGB: Si" : " - Iluminacion RGB: No");
            sb.Append(this.esInalambrico ? " - Es Inalambrico: Si" : " - Es Inalambrico: No");
            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Teclado)
            {
                retorno = (this == (Teclado)obj);
            }
            return retorno;
        }


    }
}
