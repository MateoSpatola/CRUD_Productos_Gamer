namespace App
{
    /// <summary>
    /// Formulario para visualizar el historial de usuarios logueados.
    /// </summary>
    public partial class FrmVisualizadorLog : Form
    {
        /// <summary>
        /// Constructor de la clase FrmVisualizadorLog.
        /// Inicializa el formulario.
        /// </summary>
        public FrmVisualizadorLog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Manejador del evento Load del formulario.
        /// Carga el historial de usuarios en el control richTextBoxHistorial al cargar el formulario.
        /// </summary>
        private void FrmVisualizadorLog_Load(object sender, EventArgs e)
        {
            this.richTextBoxHistorial.Text = LeerHistorialUsuarios(@"..\..\..\Archivos\usuarios.log");
        }

        /// <summary>
        /// Lee el historial de usuarios desde un archivo de texto.
        /// </summary>
        /// <param name="ruta">La ruta del archivo que contiene el historial de usuarios.</param>
        /// <returns>El contenido del historial de usuarios como una cadena.</returns>
        private static string LeerHistorialUsuarios(string ruta)
        {
            string historial = string.Empty;
            try
            {
                if (File.Exists(ruta))
                {
                    using (StreamReader sr = new StreamReader(ruta))
                    {
                        historial = sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al intentar recuperar el archivo: \n({ex.Message})", "ERROR :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return historial;
        }

        /// <summary>
        /// Manejador del evento Click del botón "Salir".
        /// Cierra el formulario cuando se hace clic en el botón "Salir".
        /// </summary>
        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
