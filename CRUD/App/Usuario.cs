using System.Text;

namespace App
{
    /// <summary>
    /// Clase que representa un usuario con información básica.
    /// </summary>
    public class Usuario
    {

        public string nombre { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }

        public string apellido { get; set; }
        public int legajo { get; set; }
        public string perfil { get; set; }

        /// <summary>
        /// Convierte el objeto Usuario en una representación de cadena con información relevante.
        /// </summary>
        /// <returns>Una cadena que representa el objeto Usuario.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Apellido: {this.apellido}");
            sb.Append($" - Nombre: {this.nombre}");
            sb.Append($" - Legajo: {this.legajo}");
            sb.Append($" - Correo: {this.correo}");
            sb.Append($" - Perfil: {this.perfil}");
            sb.Append($" - Fecha de acceso: {DateTime.Now}");
            return sb.ToString();
        }
    }
}
