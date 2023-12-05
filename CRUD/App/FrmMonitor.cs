namespace App
{
    /// <summary>
    /// Formulario para la gestión de monitores gamer.
    /// </summary>
    public partial class FrmMonitor : FrmProducto
    {
        public Entidades.Monitor? monitor;
        private int tasaDeRefresco;
        private int pulgadas;
        private ETipoPanel tipoPanel;

        /// <summary>
        /// Constructor de la clase FrmMonitor.
        /// Inicializa el formulario y carga los datos en los ComboBoxes.
        /// </summary>
        public FrmMonitor()
        {
            InitializeComponent();
            this.CargarComboBoxes();
        }

        /// <summary>
        /// Constructor de la clase FrmMonitor que recibe un monitor existente para editar.
        /// </summary>
        public FrmMonitor(Entidades.Monitor monitor) : base(monitor)
        {
            InitializeComponent();
            this.Text = "Modificar Monitor";
            this.CargarComboBoxes();
            this.textBoxTasaDeRefresco.Text = monitor.TasaDeRefresco.ToString();
            this.textBoxPulgadas.Text = monitor.Pulgadas.ToString();
            this.comboBoxTipoPanel.SelectedIndex = this.comboBoxTipoPanel.Items.IndexOf(monitor.TipoPanel);
        }

        /// <summary>
        /// Carga los valores en los ComboBoxes del formulario.
        /// </summary>
        private void CargarComboBoxes()
        {
            this.comboBoxTipoPanel.DataSource = Enum.GetValues(typeof(ETipoPanel));
        }

        /// <summary>
        /// Manejador del evento Click del botón "Aceptar".
        /// Realiza la validación de campos y asigna los valores ingresados al monitor.
        /// </summary>
        public override void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (base.ValidarCampos() && this.ValidarCamposEspecificos())
            {
                base.AsignarValores();
                this.AsignarValoresEspecificos();
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// Valida los campos específicos del formulario.
        /// </summary>
        /// <returns>True si los campos específicos son válidos, de lo contrario, false.</returns>
        protected bool ValidarCamposEspecificos()
        {
            if (!int.TryParse(this.textBoxTasaDeRefresco.Text, out int auxTasaDeRefresco) || auxTasaDeRefresco == 0)
            {
                MessageBox.Show("Debe llenar el campo obligatorio 'Tasa De Refresco'.", "Error :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(this.textBoxPulgadas.Text, out int auxPulgadas) || auxPulgadas == 0)
            {
                MessageBox.Show("Debe llenar el campo obligatorio 'Pulgadas'.", "Error :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Asigna los valores específicos del monitor y crea una instancia de monitor.
        /// </summary>
        protected void AsignarValoresEspecificos()
        {
            this.tasaDeRefresco = int.Parse(this.textBoxTasaDeRefresco.Text);
            this.pulgadas = int.Parse(this.textBoxPulgadas.Text);
            this.tipoPanel = (ETipoPanel)this.comboBoxTipoPanel.SelectedItem;

            if (base.stock == 0 && !base.tieneGarantia)
            {
                this.monitor = new Entidades.Monitor(base.id, base.nombre, base.marca, base.costo, this.tasaDeRefresco, this.pulgadas, this.tipoPanel);
            }
            else if (!base.tieneGarantia)
            {
                this.monitor = new Entidades.Monitor(base.id, base.nombre, base.marca, base.costo, base.stock, this.tasaDeRefresco, this.pulgadas, this.tipoPanel);
            }
            else
            {
                this.monitor = new Entidades.Monitor(base.id, base.nombre, base.marca, base.costo, base.stock, base.tieneGarantia, this.tasaDeRefresco, this.pulgadas, this.tipoPanel);
            }
            base.producto = this.monitor;
        }

        /// <summary>
        /// Valida que el evento KeyPress solo permita ingresar números en un campo de texto.
        /// </summary>
        private void textBoxTasaDeRefresco_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.ValidarSoloNumeros(e);
        }

        /// <summary>
        /// Valida que el evento KeyPress solo permita ingresar números en un campo de texto.
        /// </summary>
        private void textBoxPulgadas_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.ValidarSoloNumeros(e);
        }
    }
}
