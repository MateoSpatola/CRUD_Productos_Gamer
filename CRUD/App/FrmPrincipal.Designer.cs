namespace App
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            agregarToolStripMenuItem = new ToolStripMenuItem();
            agregarMonitor = new ToolStripMenuItem();
            agregarTeclado = new ToolStripMenuItem();
            agregarMouse = new ToolStripMenuItem();
            modificar = new ToolStripMenuItem();
            eliminar = new ToolStripMenuItem();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            abrirBackup = new ToolStripMenuItem();
            exportarBackup = new ToolStripMenuItem();
            ordenarToolStripMenuItem = new ToolStripMenuItem();
            stockToolStripMenuItem = new ToolStripMenuItem();
            ordenarPorStockAscendente = new ToolStripMenuItem();
            ordenarPorStockDescendente = new ToolStripMenuItem();
            nombreToolStripMenuItem = new ToolStripMenuItem();
            ordenarPorNombreAscendente = new ToolStripMenuItem();
            ordenarPorNombreDescendente = new ToolStripMenuItem();
            verToolStripMenuItem = new ToolStripMenuItem();
            visualizadorLog = new ToolStripMenuItem();
            productoToolStripMenuItem = new ToolStripMenuItem();
            verDisponibilidad = new ToolStripMenuItem();
            acomodarProductosToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            listBoxProductos = new ListBox();
            labelUsuario = new Label();
            labelFecha = new Label();
            panelAcomodar = new Panel();
            buttonCancelarPanel = new Button();
            buttonReiniciarPanel = new Button();
            buttonCerrarPanel = new Button();
            labelAcomodarPanel = new Label();
            labelPorcentajePanel = new Label();
            progressBarPanel = new ProgressBar();
            volverABaseDeDatos = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            panelAcomodar.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(192, 64, 0);
            menuStrip1.BackgroundImageLayout = ImageLayout.None;
            menuStrip1.Font = new Font("Showcard Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { agregarToolStripMenuItem, modificar, eliminar, archivoToolStripMenuItem, ordenarToolStripMenuItem, verToolStripMenuItem, productoToolStripMenuItem, acomodarProductosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 2, 0, 2);
            menuStrip1.Size = new Size(1258, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // agregarToolStripMenuItem
            // 
            agregarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agregarMonitor, agregarTeclado, agregarMouse });
            agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            agregarToolStripMenuItem.Size = new Size(81, 24);
            agregarToolStripMenuItem.Text = "Agregar";
            // 
            // agregarMonitor
            // 
            agregarMonitor.Name = "agregarMonitor";
            agregarMonitor.Size = new Size(153, 26);
            agregarMonitor.Text = "Monitor";
            agregarMonitor.Click += agregarMonitor_Click;
            // 
            // agregarTeclado
            // 
            agregarTeclado.Name = "agregarTeclado";
            agregarTeclado.Size = new Size(153, 26);
            agregarTeclado.Text = "Teclado";
            agregarTeclado.Click += agregarTeclado_Click;
            // 
            // agregarMouse
            // 
            agregarMouse.Name = "agregarMouse";
            agregarMouse.Size = new Size(153, 26);
            agregarMouse.Text = "Mouse";
            agregarMouse.Click += agregarMouse_Click;
            // 
            // modificar
            // 
            modificar.Name = "modificar";
            modificar.Size = new Size(95, 24);
            modificar.Text = "Modificar";
            modificar.Click += modificar_Click;
            // 
            // eliminar
            // 
            eliminar.Name = "eliminar";
            eliminar.Size = new Size(83, 24);
            eliminar.Text = "Eliminar";
            eliminar.Click += eliminar_Click;
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { abrirBackup, exportarBackup, volverABaseDeDatos });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(136, 24);
            archivoToolStripMenuItem.Text = "Archivo Backup";
            // 
            // abrirBackup
            // 
            abrirBackup.Name = "abrirBackup";
            abrirBackup.ShortcutKeys = Keys.Control | Keys.A;
            abrirBackup.Size = new Size(308, 26);
            abrirBackup.Text = "Abrir (Solo Lectura)";
            abrirBackup.Click += abrirBackup_Click;
            // 
            // exportarBackup
            // 
            exportarBackup.Name = "exportarBackup";
            exportarBackup.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            exportarBackup.Size = new Size(308, 26);
            exportarBackup.Text = "Exportar";
            exportarBackup.Click += exportarBackup_Click;
            // 
            // ordenarToolStripMenuItem
            // 
            ordenarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { stockToolStripMenuItem, nombreToolStripMenuItem });
            ordenarToolStripMenuItem.Name = "ordenarToolStripMenuItem";
            ordenarToolStripMenuItem.Size = new Size(84, 24);
            ordenarToolStripMenuItem.Text = "Ordenar";
            // 
            // stockToolStripMenuItem
            // 
            stockToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ordenarPorStockAscendente, ordenarPorStockDescendente });
            stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            stockToolStripMenuItem.Size = new Size(145, 26);
            stockToolStripMenuItem.Text = "Stock";
            // 
            // ordenarPorStockAscendente
            // 
            ordenarPorStockAscendente.Name = "ordenarPorStockAscendente";
            ordenarPorStockAscendente.Size = new Size(180, 26);
            ordenarPorStockAscendente.Text = "Ascendente";
            ordenarPorStockAscendente.Click += ordenarPorStockAscendente_Click;
            // 
            // ordenarPorStockDescendente
            // 
            ordenarPorStockDescendente.Name = "ordenarPorStockDescendente";
            ordenarPorStockDescendente.Size = new Size(180, 26);
            ordenarPorStockDescendente.Text = "Descendente";
            ordenarPorStockDescendente.Click += ordenarPorStockDescendente_Click;
            // 
            // nombreToolStripMenuItem
            // 
            nombreToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ordenarPorNombreAscendente, ordenarPorNombreDescendente });
            nombreToolStripMenuItem.Name = "nombreToolStripMenuItem";
            nombreToolStripMenuItem.Size = new Size(145, 26);
            nombreToolStripMenuItem.Text = "Nombre";
            // 
            // ordenarPorNombreAscendente
            // 
            ordenarPorNombreAscendente.Name = "ordenarPorNombreAscendente";
            ordenarPorNombreAscendente.Size = new Size(180, 26);
            ordenarPorNombreAscendente.Text = "Ascendente";
            ordenarPorNombreAscendente.Click += ordenarPorNombreAscendente_Click;
            // 
            // ordenarPorNombreDescendente
            // 
            ordenarPorNombreDescendente.Name = "ordenarPorNombreDescendente";
            ordenarPorNombreDescendente.Size = new Size(180, 26);
            ordenarPorNombreDescendente.Text = "Descendente";
            ordenarPorNombreDescendente.Click += ordenarPorNombreDescendente_Click;
            // 
            // verToolStripMenuItem
            // 
            verToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { visualizadorLog });
            verToolStripMenuItem.Name = "verToolStripMenuItem";
            verToolStripMenuItem.Size = new Size(46, 24);
            verToolStripMenuItem.Text = "Ver";
            // 
            // visualizadorLog
            // 
            visualizadorLog.Name = "visualizadorLog";
            visualizadorLog.Size = new Size(214, 26);
            visualizadorLog.Text = "Visualizador log";
            visualizadorLog.Click += visualizadorLog_Click;
            // 
            // productoToolStripMenuItem
            // 
            productoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { verDisponibilidad });
            productoToolStripMenuItem.Name = "productoToolStripMenuItem";
            productoToolStripMenuItem.Size = new Size(97, 24);
            productoToolStripMenuItem.Text = "Producto";
            // 
            // verDisponibilidad
            // 
            verDisponibilidad.Name = "verDisponibilidad";
            verDisponibilidad.Size = new Size(226, 26);
            verDisponibilidad.Text = "Ver disponibilidad";
            verDisponibilidad.Click += verDisponibilidad_Click;
            // 
            // acomodarProductosToolStripMenuItem
            // 
            acomodarProductosToolStripMenuItem.Name = "acomodarProductosToolStripMenuItem";
            acomodarProductosToolStripMenuItem.Size = new Size(181, 24);
            acomodarProductosToolStripMenuItem.Text = "Acomodar Productos";
            acomodarProductosToolStripMenuItem.Click += acomodarProductosToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(192, 64, 0);
            label1.Location = new Point(357, 40);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(544, 50);
            label1.TabIndex = 1;
            label1.Text = "INVENTARIO TIENDA GAMER";
            // 
            // listBoxProductos
            // 
            listBoxProductos.BackColor = Color.Black;
            listBoxProductos.Cursor = Cursors.Hand;
            listBoxProductos.Font = new Font("Showcard Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxProductos.ForeColor = Color.White;
            listBoxProductos.FormattingEnabled = true;
            listBoxProductos.ItemHeight = 17;
            listBoxProductos.Location = new Point(13, 106);
            listBoxProductos.Margin = new Padding(4, 3, 4, 3);
            listBoxProductos.Name = "listBoxProductos";
            listBoxProductos.Size = new Size(1230, 531);
            listBoxProductos.TabIndex = 2;
            // 
            // labelUsuario
            // 
            labelUsuario.AutoSize = true;
            labelUsuario.ForeColor = Color.FromArgb(192, 64, 0);
            labelUsuario.Location = new Point(15, 655);
            labelUsuario.Margin = new Padding(4, 0, 4, 0);
            labelUsuario.Name = "labelUsuario";
            labelUsuario.Size = new Size(73, 18);
            labelUsuario.TabIndex = 3;
            labelUsuario.Text = "Usuario";
            // 
            // labelFecha
            // 
            labelFecha.AutoSize = true;
            labelFecha.ForeColor = Color.FromArgb(192, 64, 0);
            labelFecha.Location = new Point(15, 673);
            labelFecha.Margin = new Padding(4, 0, 4, 0);
            labelFecha.Name = "labelFecha";
            labelFecha.Size = new Size(55, 18);
            labelFecha.TabIndex = 4;
            labelFecha.Text = "Fecha";
            // 
            // panelAcomodar
            // 
            panelAcomodar.Controls.Add(buttonCancelarPanel);
            panelAcomodar.Controls.Add(buttonReiniciarPanel);
            panelAcomodar.Controls.Add(buttonCerrarPanel);
            panelAcomodar.Controls.Add(labelAcomodarPanel);
            panelAcomodar.Controls.Add(labelPorcentajePanel);
            panelAcomodar.Controls.Add(progressBarPanel);
            panelAcomodar.Location = new Point(357, 643);
            panelAcomodar.Name = "panelAcomodar";
            panelAcomodar.Size = new Size(886, 50);
            panelAcomodar.TabIndex = 5;
            // 
            // buttonCancelarPanel
            // 
            buttonCancelarPanel.BackColor = Color.Black;
            buttonCancelarPanel.Font = new Font("Showcard Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonCancelarPanel.ForeColor = Color.FromArgb(192, 64, 0);
            buttonCancelarPanel.Location = new Point(663, 2);
            buttonCancelarPanel.Name = "buttonCancelarPanel";
            buttonCancelarPanel.Size = new Size(112, 45);
            buttonCancelarPanel.TabIndex = 5;
            buttonCancelarPanel.Text = "Cancelar";
            buttonCancelarPanel.UseVisualStyleBackColor = false;
            buttonCancelarPanel.Click += buttonCancelarPanel_Click;
            // 
            // buttonReiniciarPanel
            // 
            buttonReiniciarPanel.BackColor = Color.Black;
            buttonReiniciarPanel.Font = new Font("Showcard Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonReiniciarPanel.ForeColor = Color.FromArgb(192, 64, 0);
            buttonReiniciarPanel.Location = new Point(547, 2);
            buttonReiniciarPanel.Name = "buttonReiniciarPanel";
            buttonReiniciarPanel.Size = new Size(112, 45);
            buttonReiniciarPanel.TabIndex = 4;
            buttonReiniciarPanel.Text = "Reiniciar";
            buttonReiniciarPanel.UseVisualStyleBackColor = false;
            buttonReiniciarPanel.Click += buttonReiniciarPanel_Click;
            // 
            // buttonCerrarPanel
            // 
            buttonCerrarPanel.BackColor = Color.Black;
            buttonCerrarPanel.Font = new Font("Showcard Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonCerrarPanel.ForeColor = Color.FromArgb(192, 64, 0);
            buttonCerrarPanel.Location = new Point(779, 2);
            buttonCerrarPanel.Name = "buttonCerrarPanel";
            buttonCerrarPanel.Size = new Size(103, 45);
            buttonCerrarPanel.TabIndex = 3;
            buttonCerrarPanel.Text = "Cerrar";
            buttonCerrarPanel.UseVisualStyleBackColor = false;
            buttonCerrarPanel.Click += buttonCerrarPanel_Click;
            // 
            // labelAcomodarPanel
            // 
            labelAcomodarPanel.AutoSize = true;
            labelAcomodarPanel.BackColor = Color.Transparent;
            labelAcomodarPanel.Font = new Font("Showcard Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            labelAcomodarPanel.ForeColor = Color.White;
            labelAcomodarPanel.Location = new Point(134, 4);
            labelAcomodarPanel.Name = "labelAcomodarPanel";
            labelAcomodarPanel.Size = new Size(345, 21);
            labelAcomodarPanel.TabIndex = 2;
            labelAcomodarPanel.Text = "Acomodando el producto: producto";
            // 
            // labelPorcentajePanel
            // 
            labelPorcentajePanel.AutoSize = true;
            labelPorcentajePanel.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelPorcentajePanel.ForeColor = Color.White;
            labelPorcentajePanel.Location = new Point(11, 11);
            labelPorcentajePanel.Name = "labelPorcentajePanel";
            labelPorcentajePanel.Size = new Size(52, 26);
            labelPorcentajePanel.TabIndex = 1;
            labelPorcentajePanel.Text = "00%";
            // 
            // progressBarPanel
            // 
            progressBarPanel.Location = new Point(78, 30);
            progressBarPanel.Name = "progressBarPanel";
            progressBarPanel.Size = new Size(456, 10);
            progressBarPanel.TabIndex = 0;
            // 
            // volverABaseDeDatos
            // 
            volverABaseDeDatos.Name = "volverABaseDeDatos";
            volverABaseDeDatos.ShortcutKeys = Keys.Control | Keys.B;
            volverABaseDeDatos.Size = new Size(308, 26);
            volverABaseDeDatos.Text = "Volver a base de datos";
            volverABaseDeDatos.Click += volverABaseDeDatos_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1258, 705);
            Controls.Add(panelAcomodar);
            Controls.Add(labelFecha);
            Controls.Add(labelUsuario);
            Controls.Add(listBoxProductos);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu Principal";
            FormClosing += FrmPrincipal_FormClosing;
            Load += FrmPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelAcomodar.ResumeLayout(false);
            panelAcomodar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem agregarToolStripMenuItem;
        private ToolStripMenuItem agregarMonitor;
        private ToolStripMenuItem agregarTeclado;
        private ToolStripMenuItem agregarMouse;
        private ToolStripMenuItem modificar;
        private ToolStripMenuItem eliminar;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem abrirBackup;
        private ToolStripMenuItem guardar;
        private ToolStripMenuItem ordenarToolStripMenuItem;
        private ToolStripMenuItem stockToolStripMenuItem;
        private ToolStripMenuItem ordenarPorStockAscendente;
        private ToolStripMenuItem ordenarPorStockDescendente;
        private ToolStripMenuItem nombreToolStripMenuItem;
        private ToolStripMenuItem ordenarPorNombreAscendente;
        private ToolStripMenuItem ordenarPorNombreDescendente;
        private Label label1;
        private ListBox listBoxProductos;
        private Label labelUsuario;
        private Label labelFecha;
        private ToolStripMenuItem exportarBackup;
        private ToolStripMenuItem verToolStripMenuItem;
        private ToolStripMenuItem visualizadorLog;
        private ToolStripMenuItem productoToolStripMenuItem;
        private ToolStripMenuItem verDisponibilidad;
        private Panel panelAcomodar;
        private Label labelPorcentajePanel;
        private ProgressBar progressBarPanel;
        private Label labelAcomodarPanel;
        private Button buttonCerrarPanel;
        private ToolStripMenuItem acomodarProductosToolStripMenuItem;
        private Button buttonReiniciarPanel;
        private Button buttonCancelarPanel;
        private ToolStripMenuItem volverABaseDeDatos;
    }
}