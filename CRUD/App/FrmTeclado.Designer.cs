namespace App
{
    partial class FrmTeclado
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
            labelTipoTeclado = new Label();
            comboBoxInalambrico = new ComboBox();
            comboBoxIluminacionRGB = new ComboBox();
            comboBoxTipoTeclado = new ComboBox();
            labelIluminacionRGB = new Label();
            labelInalambrico = new Label();
            SuspendLayout();
            // 
            // labelTipoTeclado
            // 
            labelTipoTeclado.AutoSize = true;
            labelTipoTeclado.Location = new Point(40, 265);
            labelTipoTeclado.Name = "labelTipoTeclado";
            labelTipoTeclado.Size = new Size(117, 18);
            labelTipoTeclado.TabIndex = 12;
            labelTipoTeclado.Text = "Tipo Teclado:";
            // 
            // comboBoxInalambrico
            // 
            comboBoxInalambrico.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxInalambrico.FormattingEnabled = true;
            comboBoxInalambrico.Location = new Point(40, 396);
            comboBoxInalambrico.Name = "comboBoxInalambrico";
            comboBoxInalambrico.Size = new Size(358, 26);
            comboBoxInalambrico.TabIndex = 13;
            // 
            // comboBoxIluminacionRGB
            // 
            comboBoxIluminacionRGB.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxIluminacionRGB.FormattingEnabled = true;
            comboBoxIluminacionRGB.Location = new Point(40, 342);
            comboBoxIluminacionRGB.Name = "comboBoxIluminacionRGB";
            comboBoxIluminacionRGB.Size = new Size(358, 26);
            comboBoxIluminacionRGB.TabIndex = 14;
            // 
            // comboBoxTipoTeclado
            // 
            comboBoxTipoTeclado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipoTeclado.FormattingEnabled = true;
            comboBoxTipoTeclado.Location = new Point(40, 288);
            comboBoxTipoTeclado.Name = "comboBoxTipoTeclado";
            comboBoxTipoTeclado.Size = new Size(358, 26);
            comboBoxTipoTeclado.TabIndex = 15;
            // 
            // labelIluminacionRGB
            // 
            labelIluminacionRGB.AutoSize = true;
            labelIluminacionRGB.Location = new Point(40, 319);
            labelIluminacionRGB.Name = "labelIluminacionRGB";
            labelIluminacionRGB.Size = new Size(142, 18);
            labelIluminacionRGB.TabIndex = 16;
            labelIluminacionRGB.Text = "Iluminacion RGB:";
            // 
            // labelInalambrico
            // 
            labelInalambrico.AutoSize = true;
            labelInalambrico.Location = new Point(40, 373);
            labelInalambrico.Name = "labelInalambrico";
            labelInalambrico.Size = new Size(112, 18);
            labelInalambrico.TabIndex = 17;
            labelInalambrico.Text = "Inalambrico:";
            // 
            // FrmTeclado
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(439, 512);
            Controls.Add(labelInalambrico);
            Controls.Add(labelIluminacionRGB);
            Controls.Add(comboBoxTipoTeclado);
            Controls.Add(comboBoxIluminacionRGB);
            Controls.Add(comboBoxInalambrico);
            Controls.Add(labelTipoTeclado);
            Name = "FrmTeclado";
            Text = "Agregar Teclado";
            Controls.SetChildIndex(labelTipoTeclado, 0);
            Controls.SetChildIndex(comboBoxInalambrico, 0);
            Controls.SetChildIndex(comboBoxIluminacionRGB, 0);
            Controls.SetChildIndex(comboBoxTipoTeclado, 0);
            Controls.SetChildIndex(labelIluminacionRGB, 0);
            Controls.SetChildIndex(labelInalambrico, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTipoTeclado;
        private ComboBox comboBoxInalambrico;
        private ComboBox comboBoxIluminacionRGB;
        private ComboBox comboBoxTipoTeclado;
        private Label labelIluminacionRGB;
        private Label labelInalambrico;
    }
}