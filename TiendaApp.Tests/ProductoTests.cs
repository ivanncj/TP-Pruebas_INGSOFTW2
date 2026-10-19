using Xunit;
using TiendaApp;

namespace TiendaApp.Tests;

public class ProductoTests
{
    [Fact]
    public void Constructor_DeberiaAsignarAtributosCorrectamente()
    {
        
        var producto = new Producto("Televisor", 500m, "Electrónica");

        Assert.Equal("Televisor", producto.Nombre);
        Assert.Equal(500m, producto.Precio);
        Assert.Equal("Electrónica", producto.Categoria);
    }

    [Fact]
    public void ActualizarPrecio_PrecioNegativo_DeberiaLanzarExcepcion()
    {
        // Arrange
        var producto = new Producto("Televisor", 500m, "Electrónica");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => producto.ActualizarPrecio(-50m));
    }
}