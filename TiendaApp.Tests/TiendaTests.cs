using Xunit;
using TiendaApp;
using Moq;

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
        
        var tienda = new Tienda();

        
        Assert.Throws<KeyNotFoundException>(() => tienda.BuscarProducto("Teclado Inexistente"));
    }

    [Fact]
    public void EliminarProducto_NoExistente_DeberiaLanzarExcepcion()
    {
        
        var tienda = new Tienda();

        Assert.Throws<KeyNotFoundException>(() => tienda.EliminarProducto("ProductoFantasma"));
    }

    [Fact]
    public void AplicarDescuento_DeberiaCalcularNuevoPrecioYLlamarActualizarPrecio_UsandoMock()
    {
        
        var tienda = new Tienda();
        
        var mockProducto = new Mock<IProducto>();
        mockProducto.Setup(p => p.Nombre).Returns("Campera");
        mockProducto.Setup(p => p.Precio).Returns(100m);

        tienda.AgregarProducto(mockProducto.Object);

        
        tienda.AplicarDescuento("Campera", 20m);

        mockProducto.Verify(p => p.ActualizarPrecio(80m), Times.Once);
    }
}
