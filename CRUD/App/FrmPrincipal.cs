using BibliotecaExcepciones;
using Entidades;
using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace App
{
    /// <summary>
    /// Formulario principal de la aplicación para la gestión de productos gamer.
    /// </summary>
    public partial class FrmPrincipal : Form
    {
        public event EventHandler<ProductoEventArgs> ProductoAgregado;
        public event EventHandler<ProductoEventArgs> ProductoModificado;
        public event EventHandler<ProductoEventArgs> ProductoEliminado;
        private Inventario<ProductoGamer> inventario;
        private OpenFileDialog openFileDialog;
        private Usuario usuario;
        private AccesoInventario accesoInventario;
        private Random random;
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;
        private Task hiloAcomodarProductos;
        private int productoAcomodadoActual;

        /// <summary>
        /// Constructor de la clase FrmPrincipal.
        /// Inicializa componentes, crea instancias de objetos necesarios y establece manejadores de eventos.
        /// </summary>
        public FrmPrincipal()
        {
            InitializeComponent();
            this.inventario = new Inventario<ProductoGamer>();
            this.openFileDialog = new OpenFileDialog();
            this.accesoInventario = new AccesoInventario();
            this.random = new Random();
            this.cancellationTokenSource = new CancellationTokenSource();
            this.ProductoAgregado += FrmPrincipal_ProductoAgregado;
            this.ProductoModificado += FrmPrincipal_ProductoModificado;
            this.ProductoEliminado += FrmPrincipal_ProductoEliminado;
        }

        /// <summary>
        /// Constructor de la clase FrmPrincipal que recibe un usuario y actualiza los label con el usuario logueado y la fecha actual.
        /// </summary>
        public FrmPrincipal(Usuario usuario) : this()
        {
            this.usuario = usuario;
            this.labelUsuario.Text = $"Bienvenido {usuario.nombre}!";
        }

        /// <summary>
        /// Manejador de evento para el evento Load del formulario principal.
        /// Realiza acciones al cargar el formulario, como actualizar el ListBox, iniciar un proceso en segundo plano
        /// para actualizar la hora en tiempo real y ocultar un panel.
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento (formulario principal).</param>
        /// <param name="e">Argumentos del evento de carga del formulario.</param>
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.ActualizarListBox(true);
            Task.Run(() => IniciarProcesoActualizarHoraEnTiempoReal(this.labelFecha));
            this.panelAcomodar.Visible = false;
        }

        /// <summary>
        /// Manejador de evento para el cierre del formulario principal.
        /// Muestra un mensaje de confirmación antes de cerrar la aplicación.
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento (formulario principal).</param>
        /// <param name="e">Argumentos del evento de cierre del formulario.</param>
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Seguro que desea salir?", "ATENCION!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                this.cancellationTokenSource.Cancel();
            }
        }

        /// <summary>
        /// Actualiza el ListBox de productos mostrando sus detalles e incluyendo el precio final.
        /// </summary>
        /// <param name="desdeBaseDeDatos">
        /// Indica si se debe obtener la lista de productos desde la base de datos. 
        /// Si es true, se actualiza la lista desde la base de datos; si es false, se utiliza la lista existente en memoria.
        /// </param>
        private void ActualizarListBox(bool desdeBaseDeDatos)
        {
            try
            {
                this.listBoxProductos.Items.Clear();
                if (desdeBaseDeDatos)
                {
                    this.inventario.Productos = accesoInventario.ObtenerListaProductosGamer();
                }
                foreach (ProductoGamer producto in this.inventario.Productos)
                {
                    producto.CalcularPrecioFinal();
                    this.listBoxProductos.Items.Add(producto.ToString());
                }
            }
            catch (ConexionBaseDeDatosException ex)
            {
                MessageBox.Show($"{ex.Message} \nError: {ex.InnerException.Message} \nOrigen: {ex.Source}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OperacionFallidaException ex)
            {
                MessageBox.Show($"{ex.Message} \nError: {ex.InnerException.Message} \nOrigen: {ex.Source}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Abre el formulario de producto para agregar un nuevo producto al inventario.
        /// Invoca el evento ProductoAgregado si la operación es exitosa.
        /// </summary>
        /// <param name="form">El formulario de producto para agregar.</param>

        private void AgregarProducto(FrmProducto form)
        {
            try
            {
                if (this.usuario.perfil != "vendedor")
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        ProductoAgregado.Invoke(this, new ProductoEventArgs(form.Producto));
                    }
                }
                else
                {
                    MessageBox.Show("No tiene permisos para agregar un producto.\nConsulte con un supervisor o administrador.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (ConexionBaseDeDatosException ex)
            {
                MessageBox.Show($"{ex.Message} \nError: {ex.InnerException.Message} \nOrigen: {ex.Source}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OperacionFallidaException ex)
            {
                MessageBox.Show($"{ex.Message} \nError: {ex.InnerException.Message} \nOrigen: {ex.Source}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador de evento para el evento ProductoAgregado en el formulario principal.
        /// Agrega un nuevo producto al inventario y actualiza la ListBox si la operación es exitosa.
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento (formulario principal).</param>
        /// <param name="e">Argumentos del evento de producto agregado.</param>
        private void FrmPrincipal_ProductoAgregado(object? sender, ProductoEventArgs e)
        {
            if (accesoInventario.AgregarProductoGamer(e.Producto))
            {
                this.inventario += e.Producto;
                MessageBox.Show("Producto agregado con exito :)");
            }
            else
            {
                MessageBox.Show("No se ha podido agregar el producto :(");
            }
            this.ActualizarListBox(true);
        }


        /// <summary>
        /// Abre el formulario para agregar un nuevo monitor al inventario.
        /// </summary>
        private void agregarMonitor_Click(object sender, EventArgs e)
        {
            FrmMonitor frmMonitor = new FrmMonitor();
            this.AgregarProducto(frmMonitor);
        }

        /// <summary>
        /// Abre el formulario para agregar un nuevo teclado al inventario.
        /// </summary>
        private void agregarTeclado_Click(object sender, EventArgs e)
        {
            FrmTeclado frmTeclado = new FrmTeclado();
            this.AgregarProducto(frmTeclado);
        }

        /// <summary>
        /// Abre el formulario para agregar un nuevo mouse al inventario.
        /// </summary>
        private void agregarMouse_Click(object sender, EventArgs e)
        {
            FrmMouse frmMouse = new FrmMouse();
            this.AgregarProducto(frmMouse);
        }

        /// <summary>
        /// Manejador de evento para el evento Click del botón de modificar en el formulario principal.
        /// Abre el formulario de producto para modificar un producto existente en el inventario.
        /// Invoca el evento ProductoModificado si la operación es exitosa.
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento (botón de modificar).</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.usuario.perfil != "vendedor")
                {
                    int indice = this.listBoxProductos.SelectedIndex;
                    if (indice == -1)
                    {
                        MessageBox.Show("NO SE HA SELECCIONADO NINGUN ITEM");
                    }
                    else
                    {
                        ProductoGamer producto = this.inventario.Productos[indice];
                        this.ProductoModificado.Invoke(this, new ProductoEventArgs(producto));
                    }
                }
                else
                {
                    MessageBox.Show("No tiene permisos para modificar un producto.\nConsulte con un supervisor o administrador.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (ConexionBaseDeDatosException ex)
            {
                MessageBox.Show($"{ex.Message} \nError: {ex.InnerException.Message} \nOrigen: {ex.Source}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OperacionFallidaException ex)
            {
                MessageBox.Show($"{ex.Message} \nError: {ex.InnerException.Message} \nOrigen: {ex.Source}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ProductoInexistenteEnBaseDeDatosException ex)
            {
                MessageBox.Show($"{ex.Message} \nError: {ex.InnerException.Message} \nOrigen: {ex.Source}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador de evento para el evento ProductoModificado en el formulario principal.
        /// Abre el formulario de producto específico para el tipo de producto a modificar.
        /// Invoca el evento ProductoModificado si la operación de modificación es exitosa.
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento (formulario principal).</param>
        /// <param name="e">Argumentos del evento de producto modificado.</param>
        private void FrmPrincipal_ProductoModificado(object? sender, ProductoEventArgs e)
        {
            FrmProducto frmProducto;
            if (e.Producto is Entidades.Monitor)
            {
                frmProducto = new FrmMonitor((Entidades.Monitor)e.Producto);
            }
            else if (e.Producto is Teclado)
            {
                frmProducto = new FrmTeclado((Teclado)e.Producto);
            }
            else
            {
                frmProducto = new FrmMouse((Mouse)e.Producto);
            }

            frmProducto.ShowDialog();
            if (frmProducto.DialogResult == DialogResult.OK)
            {
                if (accesoInventario.ModificarProductoGamer(frmProducto.Producto))
                {
                    e.Producto = frmProducto.Producto;
                    this.ActualizarListBox(true);
                    MessageBox.Show("Producto modificado con exito :)");
                }
                else
                {
                    MessageBox.Show("No se ha podido modificar el producto :(");
                }
            }
        }

        /// <summary>
        /// Manejador de evento para el evento Click del botón de eliminar en el formulario principal.
        /// Elimina un producto del inventario si el usuario tiene permisos de administrador y confirma la operación.
        /// Invoca el evento ProductoEliminado si la operación es exitosa.
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento (botón de eliminar).</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.usuario.perfil == "administrador")
                {
                    int indice = this.listBoxProductos.SelectedIndex;
                    if (indice == -1)
                    {
                        MessageBox.Show("NO SE HA SELECCIONADO NINGUN ITEM");
                    }
                    else
                    {
                        if (MessageBox.Show("Seguro que desea eliminar este producto?", "ATENCION!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            ProductoEliminado.Invoke(this, new ProductoEventArgs(this.inventario.Productos[indice]));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No tiene permisos para eliminar un producto.\nConsulte con un administrador.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (ConexionBaseDeDatosException ex)
            {
                MessageBox.Show($"{ex.Message} \nError: {ex.InnerException.Message} \nOrigen: {ex.Source}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OperacionFallidaException ex)
            {
                MessageBox.Show($"{ex.Message} \nError: {ex.InnerException.Message} \nOrigen: {ex.Source}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ProductoInexistenteEnBaseDeDatosException ex)
            {
                MessageBox.Show($"{ex.Message} \nError: {ex.InnerException.Message} \nOrigen: {ex.Source}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador de evento para el evento ProductoEliminado en el formulario principal.
        /// Elimina un producto del inventario y actualiza la ListBox si la operación es exitosa.
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento (formulario principal).</param>
        /// <param name="e">Argumentos del evento de producto eliminado.</param>
        private void FrmPrincipal_ProductoEliminado(object? sender, ProductoEventArgs e)
        {
            if (accesoInventario.EliminarProductoGamer(e.Producto))
            {
                this.inventario -= e.Producto;
                this.ActualizarListBox(true);
                MessageBox.Show("Producto eliminado con exito :)");
            }
            else
            {
                MessageBox.Show("No se ha podido eliminar el producto :(");
            }
        }

        /// <summary>
        /// Inicia un proceso asíncrono para actualizar la hora en tiempo real en un intervalo de 1 segundo.
        /// </summary>
        /// <param name="label">Etiqueta donde se mostrará la hora actualizada en tiempo real.</param>
        private async void IniciarProcesoActualizarHoraEnTiempoReal(Label label)
        {
            while (true)
            {
                this.ActualizarHoraEnTiempoReal(label);
                await Task.Delay(1000);
            }
        }

        /// <summary>
        /// Actualiza la etiqueta con la fecha y hora actual en tiempo real.
        /// </summary>
        /// <param name="label">Etiqueta donde se mostrará la hora actualizada en tiempo real.</param>
        private void ActualizarHoraEnTiempoReal(Label label)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    DelegadoHoraEnTiempoReal<Label> delegadoHoraEnTiempoReal = this.ActualizarHoraEnTiempoReal;
                    this.Invoke(delegadoHoraEnTiempoReal, label);
                }
                else
                {
                    label.Text = $"Fecha y hora actual: {DateTime.Now}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Inicia un proceso para acomodar productos de forma asíncrona.
        /// </summary>
        private void IniciarProcesoAcomodarProductos()
        {
            this.cancellationTokenSource = new CancellationTokenSource();
            this.cancellationToken = cancellationTokenSource.Token;
            this.panelAcomodar.Visible = true;
            this.progressBarPanel.Value = 0;
            this.hiloAcomodarProductos = Task.Run(() => ProcesoAcomodarProductos(this.progressBarPanel, this.labelPorcentajePanel, this.labelAcomodarPanel), this.cancellationToken);
        }

        /// <summary>
        /// Realiza el proceso de acomodar productos de forma asíncrona.
        /// </summary>
        /// <param name="barraProgreso">Barra de progreso que indica el avance del proceso.</param>
        /// <param name="labelPorcentaje">Etiqueta que muestra el porcentaje de avance.</param>
        /// <param name="labelAcomodar">Etiqueta que muestra el estado del proceso de acomodo.</param>
        private void ProcesoAcomodarProductos(ProgressBar barraProgreso, Label labelPorcentaje, Label labelAcomodar)
        {
            while (barraProgreso.Value < barraProgreso.Maximum && !this.cancellationTokenSource.IsCancellationRequested)
            {
                this.IncrementarBarraProgreso(barraProgreso, labelPorcentaje, labelAcomodar);
                Thread.Sleep(random.Next(1000, 3000));
            }
            this.FinalizarProcesoAcomodarProductos(barraProgreso, labelAcomodar);
        }

        /// <summary>
        /// Incrementa la barra de progreso y muestra el porcentaje y estado de acomodo actualizado.
        /// </summary>
        /// <param name="barraProgreso">Barra de progreso que se incrementará.</param>
        /// <param name="labelPorcentaje">Etiqueta que muestra el porcentaje de avance.</param>
        /// <param name="labelAcomodar">Etiqueta que muestra el estado del proceso de acomodo.</param>
        private void IncrementarBarraProgreso(ProgressBar barraProgreso, Label labelPorcentaje, Label labelAcomodar)
        {
            try
            {
                int totalProductos = this.inventario.Productos.Count();
                int incremento = 100 / totalProductos;
                if (this.InvokeRequired)
                {
                    DelegadoIncrementarBarraProgreso<ProgressBar, Label, Label> delegadoIncrementarBarraProgreso = this.IncrementarBarraProgreso;
                    object[] parametros = new object[] { barraProgreso, labelPorcentaje, labelAcomodar };
                    this.Invoke(delegadoIncrementarBarraProgreso, parametros);
                }
                else
                {
                    barraProgreso.Increment(incremento);
                    labelPorcentaje.Text = $"{barraProgreso.Value}%";
                    if (this.productoAcomodadoActual < totalProductos)
                    {
                        labelAcomodar.Text = this.inventario.Acomodar(this.inventario.Productos[this.productoAcomodadoActual]);
                        this.productoAcomodadoActual += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Finaliza el proceso de acomodar productos y muestra el estado final en la etiqueta.
        /// </summary>
        /// <param name="barraProgreso">Barra de progreso del proceso.</param>
        /// <param name="label">Etiqueta que muestra el estado del proceso.</param>
        private void FinalizarProcesoAcomodarProductos(ProgressBar barraProgreso, Label label)
        {
            if (InvokeRequired)
            {
                DelegadoFinalizarProceso<ProgressBar, Label> delegadoFinalizarProceso = FinalizarProcesoAcomodarProductos;
                object[] parametros = new object[] { barraProgreso, label };
                this.Invoke(delegadoFinalizarProceso, parametros);
            }
            else
            {
                if (barraProgreso.Value == barraProgreso.Maximum)
                {
                    label.Text = "          Estado proceso: FINALIZADO";
                }
                else
                {

                    label.Text = "          Estado proceso: CANCELADO";
                }
            }
        }

        /// <summary>
        /// Manejador de evento para el evento Click del botón para cerrar el panel de acomodo en el formulario principal.
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento (botón para cerrar el panel).</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void buttonCerrarPanel_Click(object sender, EventArgs e)
        {
            this.panelAcomodar.Visible = false;
        }

        /// <summary>
        /// Manejador de evento para el evento Click del botón para reiniciar el panel de acomodo en el formulario principal.
        /// Cancela el proceso de acomodo actual, espera a que el hilo termine y reinicia el proceso de acomodo.
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento (botón para reiniciar el panel).</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private async void buttonReiniciarPanel_Click(object sender, EventArgs e)
        {
            this.cancellationTokenSource.Cancel();
            while (!this.hiloAcomodarProductos.IsCompleted)
            {
                await Task.Delay(1000);
            }
            this.productoAcomodadoActual = 0;
            this.IniciarProcesoAcomodarProductos();
        }

        /// <summary>
        /// Manejador de evento para el evento Click del botón para cancelar el panel de acomodo en el formulario principal.
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento (botón para cancelar el panel).</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void buttonCancelarPanel_Click(object sender, EventArgs e)
        {
            this.cancellationTokenSource.Cancel();
        }

        /// <summary>
        /// Manejador de evento para el evento Click del menú "Acomodar productos" en el formulario principal.
        /// Inicia el proceso de acomodo de productos.
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento (menú "Acomodar productos").</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void acomodarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IniciarProcesoAcomodarProductos();
        }


        /// <summary>
        /// Abre el visualizador de registros de usuario y permite al usuario ver los registros de actividad.
        /// </summary>
        private void visualizadorLog_Click(object sender, EventArgs e)
        {
            FrmVisualizadorLog frmVisualizadorLog = new FrmVisualizadorLog();
            frmVisualizadorLog.ShowDialog();
        }

        /// <summary>
        /// Muestra la disponibilidad del producto seleccionado en un cuadro de diálogo.
        /// </summary>
        private void verDisponibilidad_Click(object sender, EventArgs e)
        {
            int indice = this.listBoxProductos.SelectedIndex;
            if (indice == -1)
            {
                MessageBox.Show("NO SE HA SELECCIONADO NINGUN ITEM");
            }
            else
            {
                MessageBox.Show(this.inventario.Productos[indice].Disponibilidad(), "Disponibilidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Deserializa datos desde un archivo XML en la ruta especificada y actualiza la lista de productos en el inventario.
        /// </summary>
        /// <param name="ruta">La ruta del archivo XML a deserializar.</param>
        private void DeserializarXml(string ruta)
        {
            try
            {
                if (File.Exists(ruta))
                {
                    using (XmlTextReader reader = new XmlTextReader(ruta))
                    {
                        XmlSerializer ser = new XmlSerializer((typeof(List<ProductoGamer>)));

                        this.inventario.Productos = (List<ProductoGamer>)ser.Deserialize(reader);
                    }
                }
                this.ActualizarListBox(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al intentar recuperar el archivo: \n({ex.Message})", "ERROR :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Serializa la lista de productos en el inventario y guarda los datos en un archivo XML en la ruta especificada.
        /// </summary>
        /// <param name="ruta">La ruta del archivo XML en el que se guardarán los datos serializados.</param>
        private void SerializarXml(string ruta)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(ruta, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer((typeof(List<ProductoGamer>)));
                    ser.Serialize(writer, this.inventario.Productos);
                }
                MessageBox.Show("Archivo guardado con exito :)", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al intentar guardar el archivo: \n({ex.Message})", "ERROR :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador de evento para el evento Click del botón para abrir un archivo de backup en el formulario principal.
        /// Abre un cuadro de diálogo para seleccionar un archivo XML de backup, deserializa el contenido y deshabilita las opciones de eliminar, modificar y agregar.
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento (botón para abrir un archivo de backup).</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void abrirBackup_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Filter = "Archivo xml |*.xml";
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.DeserializarXml(this.openFileDialog.FileName);
                this.eliminar.Enabled = false;
                this.modificar.Enabled = false;
                this.agregarToolStripMenuItem.Enabled = false;
            }
        }

        /// <summary>
        /// Serializa y guarda los datos de la lista de productos en un nuevo archivo XML seleccionado por el usuario.
        /// </summary>
        private void exportarBackup_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo xml |*.xml";

            string nombreArchivoPorDefecto = "backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xml";
            saveFileDialog.FileName = nombreArchivoPorDefecto;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.SerializarXml(saveFileDialog.FileName);
                this.openFileDialog.FileName = saveFileDialog.FileName;
            }
        }

        /// <summary>
        /// Manejador de evento para el evento Click del botón para volver a la base de datos en el formulario principal.
        /// Actualiza la ListBox desde la base de datos y habilita las opciones de eliminar, modificar y agregar.
        /// </summary>
        /// <param name="sender">Objeto que desencadenó el evento (botón para volver a la base de datos).</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void volverABaseDeDatos_Click(object sender, EventArgs e)
        {
            this.ActualizarListBox(true);
            this.eliminar.Enabled = true;
            this.modificar.Enabled = true;
            this.agregarToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// Ordena los productos en el inventario por stock de manera ascendente y actualiza la lista de productos en el listbox.
        /// </summary>
        private void ordenarPorStockAscendente_Click(object sender, EventArgs e)
        {
            this.inventario.Productos.Sort(Inventario<ProductoGamer>.OrdenarProductosPorStockAscendente);
            this.ActualizarListBox(false);
        }

        /// <summary>
        /// Ordena los productos en el inventario por stock de manera descendente y actualiza la lista de productos en el listbox.
        /// </summary>
        private void ordenarPorStockDescendente_Click(object sender, EventArgs e)
        {
            this.inventario.Productos.Sort(Inventario<ProductoGamer>.OrdenarProductosPorStockDescendente);
            this.ActualizarListBox(false);
        }

        /// <summary>
        /// Ordena los productos en el inventario por nombre de manera ascendente y actualiza la lista de productos en el listbox.
        /// </summary>
        private void ordenarPorNombreAscendente_Click(object sender, EventArgs e)
        {
            this.inventario.Productos.Sort(Inventario<ProductoGamer>.OrdenarProductosPorNombreAscendente);
            this.ActualizarListBox(false);
        }

        /// <summary>
        /// Ordena los productos en el inventario por nombre de manera descendente y actualiza la lista de productos en el listbox.
        /// </summary>
        private void ordenarPorNombreDescendente_Click(object sender, EventArgs e)
        {
            this.inventario.Productos.Sort(Inventario<ProductoGamer>.OrdenarProductosPorNombreDescendente);
            this.ActualizarListBox(false);
        }
    }
}
