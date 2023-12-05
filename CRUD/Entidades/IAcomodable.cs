namespace Entidades
{
    /// <summary>
    /// Interfaz genérica que representa la capacidad de ser revisado.
    /// </summary>
    /// <typeparam name="T">Tipo de datos del objeto que se revisa.</typeparam>
    public interface IAcomodable<T>
        where T : class, IProducto
    {
        string Acomodar(T objeto);
    }
}
