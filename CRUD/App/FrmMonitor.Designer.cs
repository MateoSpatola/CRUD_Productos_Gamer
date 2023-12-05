namespace App
{
    partial class FrmMonitor
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
            labelTasaDeRefresco = new Label();
            textBoxTasaDeRefresco = new TextBox();
            labelPulgadas = new Label();
            textBoxPulgadas = new TextBox();
            labelTipoPanel = new Label();
            comboBoxTipoPanel = new ComboBox();
            SuspendLayout();
            // 
            // labelTasaDeRefresco
            // 
            labelTasaDeRefresco.AutoSize = true;
            labelTasaDeRefresco.Location = new Point(40, 265);
            labelTasaDeRefresco.Margin = new Padding(4, 0, 4, 0);
            labelTasaDeRefresco.Name = "labelTasaDeRefresco";
            labelTasaDeRefresco.Size = new Size(148, 18);
            labelTasaDeRefresco.TabIndex = 12;
            labelTasaDeRefresco.Text = "Tasa de Refresco:";
            // 
            // textBoxTasaDeRefresco
            // 
            textBoxTasaDeRefresco.Location = new Point(40, 285);
            textBoxTasaDeRefresco.Margin = new Padding(4, 3, 4, 3);
            textBoxTasaDeRefresco.Name = "textBoxTasaDeRefresco";
            textBoxTasaDeRefresco.Size = new Size(358, 26);
            textBoxTasaDeRefresco.TabIndex = 13;
            textBoxTasaDeRefresco.KeyPress += textBoxTasaDeRefresco_KeyPress;
            // 
            // labelPulgadas
            // 
            labelPulgadas.AutoSize = true;
            labelPulgadas.Location = new Point(40, 312);
            labelPulgadas.Margin = new Padding(4, 0, 4, 0);
            labelPulgadas.Name = "labelPulgadas";
            labelPulgadas.Size = new Size(89, 18);
            labelPulgadas.TabIndex = 14;
            labelPulgadas.Text = "Pulgadas:";
            // 
            // textBoxPulgadas
            // 
            textBoxPulgadas.Location = new Point(40, 333);
            textBoxPulgadas.Margin = new Padding(4, 3, 4, 3);
            textBoxPulgadas.Name = "textBoxPulgadas";
            textBoxPulgadas.Size = new Size(358, 26);
            textBoxPulgadas.TabIndex = 15;
            textBoxPulgadas.KeyPress += textBoxPulgadas_KeyPress;
            // 
            // labelTipoPanel
            // 
            labelTipoPanel.AutoSize = true;
            labelTipoPanel.Location = new Point(40, 360);
            labelTipoPanel.Margin = new Padding(4, 0, 4, 0);
            labelTipoPanel.Name = "labelTipoPanel";
            labelTipoPanel.Size = new Size(97, 18);
            labelTipoPanel.TabIndex = 16;
            labelTipoPanel.Text = "Tipo Panel:";
            // 
            // comboBoxTipoPanel
            // 
            comboBoxTipoPanel.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipoPanel.FormattingEnabled = true;
            comboBoxTipoPanel.Location = new Point(40, 381);
            comboBoxTipoPanel.Margin = new Padding(4, 3, 4, 3);
            comboBoxTipoPanel.Name = "comboBoxTipoPanel";
            comboBoxTipoPanel.Size = new Size(358, 26);
            comboBoxTipoPanel.TabIndex = 17;
            // 
            // FrmMonitor
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(439, 512);
            Controls.Add(comboBoxTipoPanel);
            Controls.Add(labelTipoPanel);
            Controls.Add(textBoxPulgadas);
            Controls.Add(labelPulgadas);
            Controls.Add(textBoxTasaDeRefresco);
            Controls.Add(labelTasaDeRefresco);
            Name = "FrmMonitor";
            Text = "Agregar Monitor";
            Controls.SetChildIndex(labelTasaDeRefresco, 0);
            Controls.SetChildIndex(textBoxTasaDeRefresco, 0);
            Controls.SetChildIndex(labelPulgadas, 0);
            Controls.SetChildIndex(textBoxPulgadas, 0);
            Controls.SetChildIndex(labelTipoPanel, 0);
            Controls.SetChildIndex(comboBoxTipoPanel, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTasaDeRefresco;
        private TextBox textBoxTasaDeRefresco;
        private Label labelPulgadas;
        private TextBox textBoxPulgadas;
        private Label labelTipoPanel;
        private ComboBox comboBoxTipoPanel;
    }
}