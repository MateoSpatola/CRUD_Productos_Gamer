namespace App
{
    partial class FrmVisualizadorLog
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
            richTextBoxHistorial = new RichTextBox();
            labelTitulo = new Label();
            buttonSalir = new Button();
            SuspendLayout();
            // 
            // richTextBoxHistorial
            // 
            richTextBoxHistorial.BackColor = Color.Black;
            richTextBoxHistorial.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBoxHistorial.ForeColor = Color.FromArgb(255, 192, 128);
            richTextBoxHistorial.Location = new Point(12, 71);
            richTextBoxHistorial.Name = "richTextBoxHistorial";
            richTextBoxHistorial.ReadOnly = true;
            richTextBoxHistorial.Size = new Size(1216, 527);
            richTextBoxHistorial.TabIndex = 1;
            richTextBoxHistorial.Text = "";
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            labelTitulo.ForeColor = Color.FromArgb(192, 64, 0);
            labelTitulo.Location = new Point(335, 12);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(571, 43);
            labelTitulo.TabIndex = 2;
            labelTitulo.Text = "Historial Usuarios Logueados";
            // 
            // buttonSalir
            // 
            buttonSalir.BackColor = Color.Black;
            buttonSalir.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSalir.ForeColor = Color.Red;
            buttonSalir.Location = new Point(1191, 12);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(37, 40);
            buttonSalir.TabIndex = 3;
            buttonSalir.Text = "X";
            buttonSalir.UseVisualStyleBackColor = false;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // FrmVisualizadorLog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1240, 610);
            Controls.Add(buttonSalir);
            Controls.Add(labelTitulo);
            Controls.Add(richTextBoxHistorial);
            ForeColor = Color.Cyan;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmVisualizadorLog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmVisualizadorLog";
            Load += FrmVisualizadorLog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBoxHistorial;
        private Label labelTitulo;
        private Button buttonSalir;
    }
}