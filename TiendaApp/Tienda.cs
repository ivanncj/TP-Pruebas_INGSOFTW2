namespace TiendaApp;

public class Tienda
{
    
    public List<Producto> Inventario { get; set; }

    public Tienda()
    {
        Inventario = new List<Producto>();
    }

    public void AgregarProducto(Producto producto)
    {
        if (producto != null)
        {
            Inventario.Add(producto);
        }
    }

    public Producto BuscarProducto(string nombre)
    {
        var producto = Inventario.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        if (producto == null)
        {
            throw new KeyNotFoundException($"El producto '{nombre}' no fue encontrado en el inventario.");
        }
        return producto;
    }

    public bool EliminarProducto(string nombre)
    {
        var producto = BuscarProducto(nombre);
        Inventario.Remove(producto);
        return true;
    }
}