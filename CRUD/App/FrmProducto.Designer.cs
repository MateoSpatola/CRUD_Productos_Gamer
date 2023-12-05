namespace App
{
    partial class FrmProducto
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
            labelNombre = new Label();
            labelMarca = new Label();
            labelCosto = new Label();
            labelStock = new Label();
            labelGarantia = new Label();
            buttonAceptar = new Button();
            buttonCancelar = new Button();
            textBoxNombre = new TextBox();
            comboBoxMarca = new ComboBox();
            textBoxCosto = new TextBox();
            textBoxStock = new TextBox();
            comboBoxGarantia = new ComboBox();
            SuspendLayout();
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(40, 23);
            labelNombre.Margin = new Padding(4, 0, 4, 0);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(76, 18);
            labelNombre.TabIndex = 0;
            labelNombre.Text = "Nombre:";
            // 
            // labelMarca
            // 
            labelMarca.AutoSize = true;
            labelMarca.Location = new Point(40, 71);
            labelMarca.Margin = new Padding(4, 0, 4, 0);
            labelMarca.Name = "labelMarca";
            labelMarca.Size = new Size(63, 18);
            labelMarca.TabIndex = 1;
            labelMarca.Text = "Marca:";
            // 
            // labelCosto
            // 
            labelCosto.AutoSize = true;
            labelCosto.Location = new Point(40, 120);
            labelCosto.Margin = new Padding(4, 0, 4, 0);
            labelCosto.Name = "labelCosto";
            labelCosto.Size = new Size(61, 18);
            labelCosto.TabIndex = 2;
            labelCosto.Text = "Costo:";
            // 
            // labelStock
            // 
            labelStock.AutoSize = true;
            labelStock.Location = new Point(40, 167);
            labelStock.Margin = new Padding(4, 0, 4, 0);
            labelStock.Name = "labelStock";
            labelStock.Size = new Size(61, 18);
            labelStock.TabIndex = 3;
            labelStock.Text = "Stock:";
            // 
            // labelGarantia
            // 
            labelGarantia.AutoSize = true;
            labelGarantia.Location = new Point(40, 215);
            labelGarantia.Margin = new Padding(4, 0, 4, 0);
            labelGarantia.Name = "labelGarantia";
            labelGarantia.Size = new Size(84, 18);
            labelGarantia.TabIndex = 4;
            labelGarantia.Text = "Garantia:";
            // 
            // buttonAceptar
            // 
            buttonAceptar.BackColor = Color.FromArgb(255, 128, 0);
            buttonAceptar.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAceptar.ForeColor = Color.White;
            buttonAceptar.Location = new Point(40, 443);
            buttonAceptar.Margin = new Padding(4, 3, 4, 3);
            buttonAceptar.Name = "buttonAceptar";
            buttonAceptar.Size = new Size(141, 51);
            buttonAceptar.TabIndex = 5;
            buttonAceptar.Text = "Aceptar";
            buttonAceptar.UseVisualStyleBackColor = false;
            buttonAceptar.Click += buttonAceptar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.BackColor = Color.FromArgb(255, 128, 0);
            buttonCancelar.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonCancelar.ForeColor = Color.White;
            buttonCancelar.Location = new Point(257, 443);
            buttonCancelar.Margin = new Padding(4, 3, 4, 3);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(141, 51);
            buttonCancelar.TabIndex = 6;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = false;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(40, 44);
            textBoxNombre.Margin = new Padding(4, 3, 4, 3);
            textBoxNombre.MaxLength = 30;
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(358, 26);
            textBoxNombre.TabIndex = 7;
            // 
            // comboBoxMarca
            // 
            comboBoxMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMarca.FormattingEnabled = true;
            comboBoxMarca.Location = new Point(40, 92);
            comboBoxMarca.Margin = new Padding(4, 3, 4, 3);
            comboBoxMarca.Name = "comboBoxMarca";
            comboBoxMarca.Size = new Size(358, 26);
            comboBoxMarca.TabIndex = 8;
            // 
            // textBoxCosto
            // 
            textBoxCosto.Location = new Point(40, 140);
            textBoxCosto.Margin = new Padding(4, 3, 4, 3);
            textBoxCosto.Name = "textBoxCosto";
            textBoxCosto.Size = new Size(358, 26);
            textBoxCosto.TabIndex = 9;
            textBoxCosto.KeyPress += textBoxCosto_KeyPress;
            // 
            // textBoxStock
            // 
            textBoxStock.Location = new Point(40, 188);
            textBoxStock.Margin = new Padding(4, 3, 4, 3);
            textBoxStock.Name = "textBoxStock";
            textBoxStock.Size = new Size(358, 26);
            textBoxStock.TabIndex = 10;
            textBoxStock.KeyPress += textBoxStock_KeyPress;
            // 
            // comboBoxGarantia
            // 
            comboBoxGarantia.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGarantia.FormattingEnabled = true;
            comboBoxGarantia.Location = new Point(40, 236);
            comboBoxGarantia.Margin = new Padding(4, 3, 4, 3);
            comboBoxGarantia.Name = "comboBoxGarantia";
            comboBoxGarantia.Size = new Size(358, 26);
            comboBoxGarantia.TabIndex = 11;
            // 
            // FrmProducto
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(439, 512);
            Controls.Add(comboBoxGarantia);
            Controls.Add(textBoxStock);
            Controls.Add(textBoxCosto);
            Controls.Add(comboBoxMarca);
            Controls.Add(textBoxNombre);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonAceptar);
            Controls.Add(labelGarantia);
            Controls.Add(labelStock);
            Controls.Add(labelCosto);
            Controls.Add(labelMarca);
            Controls.Add(labelNombre);
            Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmProducto";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Producto";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNombre;
        private Label labelMarca;
        private Label labelCosto;
        private Label labelStock;
        private Label labelGarantia;
        private Button buttonAceptar;
        private Button buttonCancelar;
        private TextBox textBoxNombre;
        private ComboBox comboBoxMarca;
        private TextBox textBoxCosto;
        private TextBox textBoxStock;
        private ComboBox comboBoxGarantia;
    }
}