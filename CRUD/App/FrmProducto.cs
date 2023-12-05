using Entidades;

namespace App
{
    /// <summary>
    /// Formulario base para la gestión de productos gamers.
    /// </summary>
    public partial class FrmProducto : Form
    {
        protected int id;
        protected ProductoGamer? producto;
        protected string? nombre;
        protected EMarcasAutorizadas marca;
        protected double costo;
        protected int stock;
        protected bool tieneGarantia;

        /// <summary>
        /// Obtiene el producto gamer creado o modificado en el formulario.
        /// </summary>
        public ProductoGamer? Producto
        {
            get { return this.producto; }
        }

        /// <summary>
        /// Constructor de la clase FrmProducto.
        /// Inicializa el formulario y carga los datos en los ComboBoxes.
        /// </summary>
        public FrmProducto()
        {
            InitializeComponent();
            this.CargarComboBoxes();
        }

        /// <summary>
        /// Constructor de la clase FrmProducto que recibe un producto existente para editar.
        /// </summary>
        public FrmProducto(ProductoGamer producto) : this()
        {
            this.id = producto.Id;
            this.textBoxNombre.Text = producto.Nombre;
            this.comboBoxMarca.SelectedIndex = this.comboBoxMarca.Items.IndexOf(producto.Marca);
            this.textBoxCosto.Text = producto.Costo.ToString();
            this.textBoxStock.Text = producto.Stock.ToString();
            if (producto.TieneGarantia == true)
            {
                this.comboBoxGarantia.SelectedItem = "Si";
            }
            else
            {
                this.comboBoxGarantia.SelectedItem = "No";
            }
        }

        /// <summary>
        /// Carga los valores en los ComboBoxes del formulario.
        /// </summary>
        private void CargarComboBoxes()
        {
            this.comboBoxMarca.DataSource = Enum.GetValues(typeof(EMarcasAutorizadas));
            this.comboBoxGarantia.Items.Add("Si");
            this.comboBoxGarantia.Items.Add("No");
            this.comboBoxGarantia.SelectedItem = "No";
        }

        /// <summary>
        /// Manejador del evento Click del botón "Aceptar".
        /// Realiza la validación de campos y asigna los valores ingresados al producto.
        /// </summary>
        public virtual void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (this.ValidarCampos())
            {
                this.AsignarValores();
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// Realiza la validación de campos antes de aceptar la operación.
        /// </summary>
        /// <returns>True si los campos son válidos; de lo contrario, false.</returns>
        protected bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(this.textBoxNombre.Text))
            {
                MessageBox.Show("Debe llenar el campo obligatorio 'Nombre'.", "Error :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!double.TryParse(this.textBoxCosto.Text, out double auxCosto) || auxCosto == 0)
            {
                MessageBox.Show("Debe llenar el campo obligatorio 'Costo'.", "Error :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(this.textBoxStock.Text, out int auxStock))
            {
                this.stock = 0;
            }
            else
            {
                this.stock = auxStock;
            }
            this.tieneGarantia = (this.comboBoxGarantia.Text == "Si");
            return true;
        }

        /// <summary>
        /// Asigna los valores de los campos a los atributos del producto.
        /// </summary>
        protected void AsignarValores()
        {
            this.nombre = this.textBoxNombre.Text;
            this.marca = (EMarcasAutorizadas)this.comboBoxMarca.SelectedItem;
            this.costo = double.Parse(this.textBoxCosto.Text);
        }

        /// <summary>
        /// Manejador del evento Click del botón "Cancelar".
        /// Cierra el formulario sin guardar cambios.
        /// </summary>
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Valida que el evento KeyPress solo permita números en el campo.
        /// </summary>
        protected void ValidarSoloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("Ingrese un numero.", "Operacion Invalida :(", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Valida que el evento KeyPress solo permita números y un decimal en el campo de costo.
        /// </summary>
        protected void ValidarSoloNumerosYDecimales(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                if ((sender as TextBox).Text.Contains(","))
                {
                    MessageBox.Show("Ya ha ingresado una coma.", "Operación Inválida :(", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Handled = true;
                }
            }
            else if (e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar))
            {
                this.ValidarSoloNumeros(e);
            }
        }

        /// <summary>
        /// Manejador del evento KeyPress del campo de costo.
        /// Valida que solo se ingresen números y un decimal.
        /// </summary>
        private void textBoxCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.ValidarSoloNumerosYDecimales(sender, e);
        }

        /// <summary>
        /// Manejador del evento KeyPress del campo de stock.
        /// Valida que solo se ingresen números.
        /// </summary>
        private void textBoxStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.ValidarSoloNumeros(e);
        }
    }
}
