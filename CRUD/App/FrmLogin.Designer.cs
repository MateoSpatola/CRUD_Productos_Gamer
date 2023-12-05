namespace App
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxUsuario = new TextBox();
            textBoxContrasenia = new TextBox();
            buttonLogin = new Button();
            labelUsuario = new Label();
            labelContrasenia = new Label();
            panelIniciandoSesion = new Panel();
            labelIniciandoSesion = new Label();
            progressBarInicioSesion = new ProgressBar();
            panelIniciandoSesion.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxUsuario
            // 
            textBoxUsuario.Font = new Font("Showcard Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxUsuario.Location = new Point(94, 76);
            textBoxUsuario.Margin = new Padding(4, 3, 4, 3);
            textBoxUsuario.Name = "textBoxUsuario";
            textBoxUsuario.PlaceholderText = "Ingrese su usuario";
            textBoxUsuario.Size = new Size(320, 24);
            textBoxUsuario.TabIndex = 0;
            // 
            // textBoxContrasenia
            // 
            textBoxContrasenia.Font = new Font("Showcard Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxContrasenia.Location = new Point(94, 147);
            textBoxContrasenia.Margin = new Padding(4, 3, 4, 3);
            textBoxContrasenia.Name = "textBoxContrasenia";
            textBoxContrasenia.PasswordChar = '*';
            textBoxContrasenia.PlaceholderText = "Ingrese su contraseña";
            textBoxContrasenia.Size = new Size(320, 24);
            textBoxContrasenia.TabIndex = 1;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.FromArgb(255, 192, 128);
            buttonLogin.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonLogin.Location = new Point(152, 196);
            buttonLogin.Margin = new Padding(4, 3, 4, 3);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(218, 49);
            buttonLogin.TabIndex = 2;
            buttonLogin.Text = "INICIAR SESIÓN";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // labelUsuario
            // 
            labelUsuario.AutoSize = true;
            labelUsuario.Location = new Point(94, 56);
            labelUsuario.Margin = new Padding(4, 0, 4, 0);
            labelUsuario.Name = "labelUsuario";
            labelUsuario.Size = new Size(78, 18);
            labelUsuario.TabIndex = 3;
            labelUsuario.Text = "Usuario:";
            // 
            // labelContrasenia
            // 
            labelContrasenia.AutoSize = true;
            labelContrasenia.Location = new Point(94, 126);
            labelContrasenia.Margin = new Padding(4, 0, 4, 0);
            labelContrasenia.Name = "labelContrasenia";
            labelContrasenia.Size = new Size(107, 18);
            labelContrasenia.TabIndex = 4;
            labelContrasenia.Text = "Contraseña:";
            // 
            // panelIniciandoSesion
            // 
            panelIniciandoSesion.Controls.Add(labelIniciandoSesion);
            panelIniciandoSesion.Controls.Add(progressBarInicioSesion);
            panelIniciandoSesion.Location = new Point(0, 0);
            panelIniciandoSesion.Name = "panelIniciandoSesion";
            panelIniciandoSesion.Size = new Size(508, 302);
            panelIniciandoSesion.TabIndex = 6;
            // 
            // labelIniciandoSesion
            // 
            labelIniciandoSesion.AutoSize = true;
            labelIniciandoSesion.BackColor = Color.Transparent;
            labelIniciandoSesion.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelIniciandoSesion.ForeColor = Color.Black;
            labelIniciandoSesion.Location = new Point(140, 170);
            labelIniciandoSesion.Name = "labelIniciandoSesion";
            labelIniciandoSesion.Size = new Size(201, 26);
            labelIniciandoSesion.TabIndex = 1;
            labelIniciandoSesion.Text = "Iniciando sesión...";
            // 
            // progressBarInicioSesion
            // 
            progressBarInicioSesion.Location = new Point(47, 106);
            progressBarInicioSesion.Name = "progressBarInicioSesion";
            progressBarInicioSesion.Size = new Size(415, 47);
            progressBarInicioSesion.TabIndex = 2;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(508, 302);
            Controls.Add(panelIniciandoSesion);
            Controls.Add(labelContrasenia);
            Controls.Add(labelUsuario);
            Controls.Add(buttonLogin);
            Controls.Add(textBoxContrasenia);
            Controls.Add(textBoxUsuario);
            Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            FormClosing += FrmLogin_FormClosing;
            panelIniciandoSesion.ResumeLayout(false);
            panelIniciandoSesion.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxUsuario;
        private TextBox textBoxContrasenia;
        private Button buttonLogin;
        private Label labelUsuario;
        private Label labelContrasenia;
        private Panel panelIniciandoSesion;
        private Label labelIniciandoSesion;
        private ProgressBar progressBarInicioSesion;
    }
}