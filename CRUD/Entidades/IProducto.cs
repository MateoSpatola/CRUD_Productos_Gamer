namespace Entidades
{
    /// <summary>
    /// Interfaz que representa un producto.
    /// </summary>
    public interface IProducto
    {
        int Id { get; }
        string Nombre { get; set; }
        EMarcasAutorizadas Marca { get; set; }
        double Costo { get; set; }
        int Stock { get; set; }
        bool TieneGarantia { get; set; }
        string TipoProducto { get; }

        void CalcularPrecioFinal();
        string Disponibilidad();
    }
}
