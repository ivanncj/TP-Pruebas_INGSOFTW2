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
    public void EliminarProducto_Existente_DeberiaRemoverloDelInventario()
    {
        var tienda = new Tienda();
        var producto = new Producto("Monitor", 300m, "Tecnología");
        tienda.AgregarProducto(producto);

        bool eliminado = tienda.EliminarProducto("Monitor");

        Assert.True(eliminado);
        Assert.Throws<KeyNotFoundException>(() => tienda.BuscarProducto("Monitor"));
    }

    [Fact]
    public void BuscarProducto_NoExistente_DeberiaLanzarKeyNotFoundException()
    {
        // Arrange
        var tienda = new Tienda();

        // Act & Assert
        Assert.Throws<KeyNotFoundException>(() => tienda.BuscarProducto("Teclado Inexistente"));
    }

    [Fact]
    public void EliminarProducto_NoExistente_DeberiaLanzarExcepcion()
    {
        // Arrange
        var tienda = new Tienda();

        // Act & Assert
        Assert.Throws<KeyNotFoundException>(() => tienda.EliminarProducto("ProductoFantasma"));
    }
}
