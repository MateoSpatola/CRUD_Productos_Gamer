using Entidades;

namespace App
{
    /// <summary>
    /// Formulario para la gestión de teclados gamer.
    /// </summary>
    public partial class FrmTeclado : FrmProducto
    {
        public Teclado? teclado;
        private ETipoTeclado tipoTeclado;
        private bool tieneIluminacionRGB;
        private bool esInalambrico;

        /// <summary>
        /// Constructor de la clase FrmTeclado.
        /// Inicializa el formulario y carga los datos en los ComboBoxes.
        /// </summary>
        public FrmTeclado()
        {
            InitializeComponent();
            this.CargarComboBoxes();
        }

        /// <summary>
        /// Constructor de la clase FrmTeclado que recibe un teclado existente para editar.
        /// </summary>
        public FrmTeclado(Teclado teclado) : base(teclado)
        {
            InitializeComponent();
            this.Text = "Modificar Teclado";
            this.CargarComboBoxes();
            this.comboBoxTipoTeclado.SelectedItem = teclado.TipoTeclado;
            if (teclado.TieneIluminacionRGB == true)
            {
                this.comboBoxIluminacionRGB.SelectedItem = "Si";
            }
            else
            {
                this.comboBoxIluminacionRGB.SelectedItem = "No";
            }

            if (teclado.EsInalambrico == true)
            {
                this.comboBoxInalambrico.SelectedItem = "Si";
            }
            else
            {
                this.comboBoxInalambrico.SelectedItem = "No";
            }
        }

        /// <summary>
        /// Carga los valores en los ComboBoxes del formulario.
        /// </summary>
        private void CargarComboBoxes()
        {
            this.comboBoxTipoTeclado.DataSource = Enum.GetValues(typeof(ETipoTeclado));
            this.comboBoxIluminacionRGB.Items.Add("Si");
            this.comboBoxIluminacionRGB.Items.Add("No");
            this.comboBoxInalambrico.Items.Add("Si");
            this.comboBoxInalambrico.Items.Add("No");
            this.comboBoxIluminacionRGB.SelectedItem = "No";
            this.comboBoxInalambrico.SelectedItem = "No";
        }

        /// <summary>
        /// Manejador del evento Click del botón "Aceptar".
        /// Realiza la validación de campos y asigna los valores ingresados al teclado.
        /// </summary>
        public override void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (base.ValidarCampos())
            {
                base.AsignarValores();
                this.AsignarValoresEspecificos();
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// Asigna los valores específicos del teclado a sus campos y crea una instancia de teclado.
        /// </summary>
        protected void AsignarValoresEspecificos()
        {
            this.tipoTeclado = (ETipoTeclado)this.comboBoxTipoTeclado.SelectedItem;
            this.tieneIluminacionRGB = (this.comboBoxIluminacionRGB.Text == "Si");
            this.esInalambrico = (this.comboBoxInalambrico.Text == "Si");

            if (base.stock == 0 && !base.tieneGarantia)
            {
                this.teclado = new Entidades.Teclado(base.id, base.nombre, base.marca, base.costo, this.tipoTeclado, this.tieneIluminacionRGB, this.esInalambrico);
            }
            else if (!base.tieneGarantia)
            {
                this.teclado = new Entidades.Teclado(base.id, base.nombre, base.marca, base.costo, base.stock, this.tipoTeclado, this.tieneIluminacionRGB, this.esInalambrico);
            }
            else
            {
                this.teclado = new Entidades.Teclado(base.id, base.nombre, base.marca, base.costo, base.stock, base.tieneGarantia, this.tipoTeclado, this.tieneIluminacionRGB, this.esInalambrico);
            }
            base.producto = this.teclado;
        }
    }
}
