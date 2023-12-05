namespace App
{
    partial class FrmMouse
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
            labelBotonesProgramables = new Label();
            labelDpiMaximo = new Label();
            labelInalambrico = new Label();
            comboBoxInalambrico = new ComboBox();
            textBoxDpiMaximo = new TextBox();
            textBoxBotonesProgramables = new TextBox();
            SuspendLayout();
            // 
            // labelBotonesProgramables
            // 
            labelBotonesProgramables.AutoSize = true;
            labelBotonesProgramables.Location = new Point(40, 265);
            labelBotonesProgramables.Name = "labelBotonesProgramables";
            labelBotonesProgramables.Size = new Size(201, 18);
            labelBotonesProgramables.TabIndex = 12;
            labelBotonesProgramables.Text = "Botones Programables:";
            // 
            // labelDpiMaximo
            // 
            labelDpiMaximo.AutoSize = true;
            labelDpiMaximo.Location = new Point(40, 318);
            labelDpiMaximo.Name = "labelDpiMaximo";
            labelDpiMaximo.Size = new Size(104, 18);
            labelDpiMaximo.TabIndex = 13;
            labelDpiMaximo.Text = "Dpi Maximo:";
            // 
            // labelInalambrico
            // 
            labelInalambrico.AutoSize = true;
            labelInalambrico.Location = new Point(40, 371);
            labelInalambrico.Name = "labelInalambrico";
            labelInalambrico.Size = new Size(112, 18);
            labelInalambrico.TabIndex = 14;
            labelInalambrico.Text = "Inalambrico:";
            // 
            // comboBoxInalambrico
            // 
            comboBoxInalambrico.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxInalambrico.FormattingEnabled = true;
            comboBoxInalambrico.Location = new Point(40, 395);
            comboBoxInalambrico.Name = "comboBoxInalambrico";
            comboBoxInalambrico.Size = new Size(358, 26);
            comboBoxInalambrico.TabIndex = 15;
            // 
            // textBoxDpiMaximo
            // 
            textBoxDpiMaximo.Location = new Point(40, 342);
            textBoxDpiMaximo.Name = "textBoxDpiMaximo";
            textBoxDpiMaximo.Size = new Size(358, 26);
            textBoxDpiMaximo.TabIndex = 16;
            textBoxDpiMaximo.KeyPress += textBoxDpiMaximo_KeyPress;
            // 
            // textBoxBotonesProgramables
            // 
            textBoxBotonesProgramables.Location = new Point(40, 289);
            textBoxBotonesProgramables.Name = "textBoxBotonesProgramables";
            textBoxBotonesProgramables.Size = new Size(358, 26);
            textBoxBotonesProgramables.TabIndex = 17;
            textBoxBotonesProgramables.KeyPress += textBoxBotonesProgramables_KeyPress;
            // 
            // FrmMouse
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(439, 512);
            Controls.Add(textBoxBotonesProgramables);
            Controls.Add(textBoxDpiMaximo);
            Controls.Add(comboBoxInalambrico);
            Controls.Add(labelInalambrico);
            Controls.Add(labelDpiMaximo);
            Controls.Add(labelBotonesProgramables);
            Name = "FrmMouse";
            Text = "Agregar Mouse";
            Controls.SetChildIndex(labelBotonesProgramables, 0);
            Controls.SetChildIndex(labelDpiMaximo, 0);
            Controls.SetChildIndex(labelInalambrico, 0);
            Controls.SetChildIndex(comboBoxInalambrico, 0);
            Controls.SetChildIndex(textBoxDpiMaximo, 0);
            Controls.SetChildIndex(textBoxBotonesProgramables, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelBotonesProgramables;
        private Label labelDpiMaximo;
        private Label labelInalambrico;
        private ComboBox comboBoxInalambrico;
        private TextBox textBoxDpiMaximo;
        private TextBox textBoxBotonesProgramables;
    }
}