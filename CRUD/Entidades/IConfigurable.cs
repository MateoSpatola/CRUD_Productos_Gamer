namespace Entidades
{
    /// <summary>
    /// Interfaz que representa productos configurables.
    /// </summary>
    public interface IConfigurable<T>
        where T : class, IProducto
    {
        bool EsInalambrico { get; set; }
        string ConfigurarConexion();
    }
}
