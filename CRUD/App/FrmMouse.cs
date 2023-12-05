using Entidades;

namespace App
{
    /// <summary>
    /// Formulario para la gestión de mouses gamer.
    /// </summary>
    public partial class FrmMouse : FrmProducto
    {
        public Mouse? mouse;
        private int botonesProgramables;
        private int dpiMaximo;
        private bool esInalambrico;

        /// <summary>
        /// Constructor de la clase FrmMouse.
        /// Inicializa el formulario y carga los datos en los ComboBoxes.
        /// </summary>
        public FrmMouse()
        {
            InitializeComponent();
            this.CargarComboBoxes();
        }

        /// <summary>
        /// Constructor de la clase FrmMouse que recibe un mouse existente para editar.
        /// </summary>
        public FrmMouse(Mouse mouse) : base(mouse)
        {
            InitializeComponent();
            this.Text = "Modificar Mouse";
            this.CargarComboBoxes();
            this.textBoxBotonesProgramables.Text = mouse.BotonesProgramables.ToString();
            this.textBoxDpiMaximo.Text = mouse.DpiMaximo.ToString();
            if (mouse.EsInalambrico == true)
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
            this.comboBoxInalambrico.Items.Add("Si");
            this.comboBoxInalambrico.Items.Add("No");
            this.comboBoxInalambrico.SelectedItem = "No";
        }

        /// <summary>
        /// Manejador del evento Click del botón "Aceptar".
        /// Realiza la validación de campos y asigna los valores ingresados al mouse.
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
            if (!int.TryParse(this.textBoxDpiMaximo.Text, out int auxDpiMaximo) || auxDpiMaximo == 0)
            {
                MessageBox.Show("Debe llenar el campo obligatorio 'Dpi Maximo'.", "Error :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(this.textBoxBotonesProgramables.Text, out int auxBotonesProgramables) || auxBotonesProgramables == 0)
            {
                MessageBox.Show("Debe llenar el campo obligatorio 'Botones Programables'.", "Error :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Asigna los valores específicos del mouse y crea una instancia de mouse.
        /// </summary>
        protected void AsignarValoresEspecificos()
        {
            this.botonesProgramables = int.Parse(this.textBoxBotonesProgramables.Text);
            this.dpiMaximo = int.Parse(this.textBoxDpiMaximo.Text);
            this.esInalambrico = (this.comboBoxInalambrico.Text == "Si");

            if (base.stock == 0 && !base.tieneGarantia)
            {
                this.mouse = new Mouse(base.id, base.nombre, base.marca, base.costo, this.botonesProgramables, this.dpiMaximo, this.esInalambrico);
            }
            else if (!base.tieneGarantia)
            {
                this.mouse = new Mouse(base.id, base.nombre, base.marca, base.costo, base.stock, this.botonesProgramables, this.dpiMaximo, this.esInalambrico);
            }
            else
            {
                this.mouse = new Mouse(base.id, base.nombre, base.marca, base.costo, base.stock, base.tieneGarantia, this.botonesProgramables, this.dpiMaximo, this.esInalambrico);
            }
            base.producto = this.mouse;
        }

        /// <summary>
        /// Valida que el evento KeyPress solo permita ingresar números en un campo de texto.
        /// </summary>
        private void textBoxBotonesProgramables_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.ValidarSoloNumeros(e);
        }

        /// <summary>
        /// Valida que el evento KeyPress solo permita ingresar números en un campo de texto.
        /// </summary>
        private void textBoxDpiMaximo_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.ValidarSoloNumeros(e);
        }
    }
}
