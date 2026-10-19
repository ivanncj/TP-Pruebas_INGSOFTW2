using Xunit;
using TiendaApp;

namespace TiendaApp.Tests;

public class TiendaTests
{
    [Fact]
    public void AgregarProducto_DeberiaAgregarProductoAlInventario()
    {
        var tienda = new Tienda();
        var producto = new Producto("Laptop", 1200m, "Tecnología");

        tienda.AgregarProducto(producto);

        var resultado = tienda.BuscarProducto("Laptop");
        Assert.NotNull(resultado);
        Assert.Equal("Laptop", resultado.Nombre);
    }

    [Fact]
    public void BuscarProducto_Existente_DeberiaRetornarElProducto()
    {
        var tienda = new Tienda();
        var producto = new Producto("Mouse", 25m, "Accesorios");
        tienda.AgregarProducto(producto);

        var encontrado = tienda.BuscarProducto("Mouse");

        Assert.NotNull(encontrado);
        Assert.Equal("Mouse", encontrado.Nombre);
    }

    [Fact]
    public void BuscarProducto_NoExistente_DeberiaRetornarNull()
    {
        var tienda = new Tienda();

        var encontrado = tienda.BuscarProducto("Teclado Inexistente");

        Assert.Null(encontrado);
    }

    [Fact]
    public void EliminarProducto_Existente_DeberiaRemoverloDelInventario()
    {
        var tienda = new Tienda();
        var producto = new Producto("Monitor", 300m, "Tecnología");
        tienda.AgregarProducto(producto);

        bool eliminado = tienda.EliminarProducto("Monitor");

        Assert.True(eliminado);
        Assert.Null(tienda.BuscarProducto("Monitor"));
    }
}
