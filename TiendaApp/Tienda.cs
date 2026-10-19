namespace TiendaApp;

public class Tienda
{
    
    public List<IProducto> Inventario { get; set; }

    public Tienda()
    {
        Inventario = new List<IProducto>();
    }

    public void AgregarProducto(IProducto producto)
    {
        if (producto != null)
        {
            Inventario.Add(producto);
        }
    }

    public IProducto BuscarProducto(string nombre)
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

    public void AplicarDescuento(string nombreProducto, decimal porcentajeDescuento)
    {
        if (porcentajeDescuento < 0 || porcentajeDescuento > 100)
        {
            throw new ArgumentException("El porcentaje de descuento debe estar entre 0 y 100.");
        }

        var producto = BuscarProducto(nombreProducto);
        
        decimal descuentoMonto = producto.Precio * (porcentajeDescuento / 100m);
        decimal nuevoPrecio = producto.Precio - descuentoMonto;

        producto.ActualizarPrecio(nuevoPrecio);
    }
}