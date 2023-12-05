using System.Text.Json;

namespace App
{
    /// <summary>
    /// Formulario para el proceso de inicio de sesión de usuarios.
    /// </summary>
    public partial class FrmLogin : Form
    {
        public event DelegadoInicioSesionFallidoEventHandler InicioSesionFallido;
        private int intentosRestantes;
        private Usuario? usuario;
        private Random random;
        private CancellationTokenSource cancellationTokenSource;

        /// <summary>
        /// Obtiene el usuario que ha iniciado sesión.
        /// </summary>
        public Usuario? Usuario
        {
            get { return this.usuario; }
        }

        /// <summary>
        /// Constructor de la clase FrmLogin.
        /// Inicializa el formulario y establece el número de intentos restantes en 3.
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
            this.intentosRestantes = 3;
            this.panelIniciandoSesion.Visible = false;
            this.random = new Random();
            this.cancellationTokenSource = new CancellationTokenSource();
            this.InicioSesionFallido += this.FrmLogin_InicioSesionFallido;
        }

        /// <summary>
        /// Verifica el usuario y contraseña ingresados comparándolos con datos almacenados en el archivo MOCK_DATA.json.
        /// </summary>
        /// <returns>El usuario autenticado si se encuentra, de lo contrario, null.</returns>
        private Usuario Verificar()
        {
            Usuario? retorno = null;
            try
            {
                using (StreamReader sr = new StreamReader(@"..\..\..\Archivos\MOCK_DATA.json"))
                {
                    JsonSerializerOptions opciones = new JsonSerializerOptions();
                    opciones.WriteIndented = true;
                    string json_str = sr.ReadToEnd();
                    List<Usuario> usuarios = JsonSerializer.Deserialize<List<Usuario>>(json_str, opciones);

                    foreach (Usuario item in usuarios)
                    {
                        if (item.correo == this.textBoxUsuario.Text && item.clave == this.textBoxContrasenia.Text)
                        {
                            retorno = item;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retorno;
        }

        /// <summary>
        /// Maneja el evento FormClosing del formulario login y cancela la tarea asociada a un CancellationTokenSource..
        /// </summary>
        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cancellationTokenSource.Cancel();
        }

        /// <summary>
        /// Simula el proceso de inicio de sesión mostrando una barra de progreso y un mensaje.
        /// </summary>
        private void SimularProcesoInicioSesion()
        {
            this.panelIniciandoSesion.Visible = true;
            this.cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            Task hilo = Task.Run(() => ProcesoInicioSesion(this.progressBarInicioSesion, this.labelIniciandoSesion), cancellationToken);
        }

        /// <summary>
        /// Simula un proceso de inicio de sesión mediante la actualización de una barra de progreso y un mensaje.
        /// </summary>
        /// <param name="barraProgreso">Barra de progreso que se actualiza durante el proceso.</param>
        /// <param name="label">Etiqueta que muestra mensajes relacionados con el proceso.</param>
        private void ProcesoInicioSesion(ProgressBar barraProgreso, Label label)
        {
            while (barraProgreso.Value < barraProgreso.Maximum && !cancellationTokenSource.IsCancellationRequested)
            {
                Thread.Sleep(random.Next(5, 25));
                this.IncrementarBarraProgreso(barraProgreso, label);
            }
            if (barraProgreso.Value == barraProgreso.Maximum)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// Incrementa la barra de progreso en 1 unidad y actualiza el mensaje de la etiqueta.
        /// </summary>
        /// <param name="barraProgreso">Barra de progreso que se incrementa.</param>
        /// <param name="label">Etiqueta cuyo texto se actualiza con el progreso.</param>
        private void IncrementarBarraProgreso(ProgressBar barraProgreso, Label label)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    Action<ProgressBar, Label> delegadoIncrementarBarraProgreso = this.IncrementarBarraProgreso;
                    object[] parametros = new object[] { barraProgreso, label };
                    this.Invoke(delegadoIncrementarBarraProgreso, parametros);
                }
                else
                {
                    barraProgreso.Increment(1);
                    label.Text = $"Iniciando sesión... {barraProgreso.Value}%";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador del evento Click del botón "Iniciar sesión".
        /// Realiza la verificación del usuario y contraseña, y maneja los intentos de inicio de sesión.
        /// </summary>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.usuario = this.Verificar();
            if (this.usuario != null)
            {
                this.AgregarUsuarioAlHistorial();
                this.SimularProcesoInicioSesion();
            }
            else
            {
                InicioSesionFallido.Invoke(this, e);
            }
        }

        /// <summary>
        /// Manejador de evento para el inicio de sesión fallido en el formulario FrmLogin.
        /// Decrementa el contador de intentos restantes y muestra mensajes de advertencia.
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento (FrmLogin).</param>
        /// <param name="e">Argumentos del evento de inicio de sesión fallido.</param>
        private void FrmLogin_InicioSesionFallido(object sender, EventArgs e)
        {
            this.intentosRestantes--;
            if (this.intentosRestantes == 0)
            {
                MessageBox.Show($"Alcanzaste el limite de intentos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
            else
            {
                MessageBox.Show($"Intentos restantes: {this.intentosRestantes}", "Usuario y/o contraseña incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Agrega la información del usuario al historial de acceso en el archivo usuarios.log.
        /// </summary>
        private void AgregarUsuarioAlHistorial()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"..\..\..\Archivos\usuarios.log", true))
                {
                    sw.WriteLine(this.usuario.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al intentar guardar el usuario: \n({ex.Message})", "ERROR :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}