namespace App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();

            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();


            if (frmLogin.DialogResult == DialogResult.OK)
            {
                Application.Run(new FrmPrincipal(frmLogin.Usuario));
            }

        }
    }
}