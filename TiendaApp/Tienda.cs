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
        return Inventario.FirstOrDefault(p => p.Nombre == nombre);
    }

    public bool EliminarProducto(string nombre)
    {
        var producto = BuscarProducto(nombre);

        if (producto != null)
        {
            Inventario.Remove(producto);
            return true;
        }
        return false;
    }
}