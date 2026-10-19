namespace TiendaApp;

public interface IProducto
{
    string Nombre { get; set; }
    decimal Precio { get; set; }
    string Categoria { get; set; }
    void ActualizarPrecio(decimal nuevoPrecio);
}
public class Producto : IProducto
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public string Categoria { get; set; }

    public Producto(string nombre, decimal precio, string categoria)
    {
        Nombre = nombre;
        Precio = precio;
        Categoria = categoria;
    }
    public void ActualizarPrecio(decimal nuevoPrecio)
    {
        if (nuevoPrecio < 0)
        {
            throw new ArgumentException("El precio no puede ser negativo.");
        }
        Precio = nuevoPrecio;
    }
}