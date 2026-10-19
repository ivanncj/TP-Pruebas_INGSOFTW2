using Xunit;
using TiendaApp;
using Moq;

namespace TiendaApp.Tests;

public class TiendaTests
{
    private readonly Tienda _tienda;
    private readonly IProducto _p1;
    private readonly IProducto _p2;

    public TiendaTests()
    {
        _tienda = new Tienda();
        _p1 = new Producto("Laptop",1200m, "Tecnología");
        _p2 = new Producto("Mouse",25m, "Accesorios");

        _tienda.AgregarProducto(_p1);
        _tienda.AgregarProducto(_p2);
    }
    [Fact]
    public void AgregarProducto_DeberiaAgregarProductoAlInventario()
    {
        var productoNuevo = new Producto("Teclado", 50m, "Accesorio");

        _tienda.AgregarProducto(productoNuevo);

        var resultado = _tienda.BuscarProducto("Teclado");
        Assert.NotNull(resultado);
        Assert.Equal("Teclado", resultado.Nombre);
    }

    [Fact]
    public void BuscarProducto_Existente_DeberiaRetornarElProducto()
    {
        var encontrado = _tienda.BuscarProducto("Mouse");

        Assert.NotNull(encontrado);
        Assert.Equal("Mouse", encontrado.Nombre);
    }

    [Fact]
    public void EliminarProducto_Existente_DeberiaRemoverloDelInventario()
    {
        bool eliminado = _tienda.EliminarProducto("Laptop");

        Assert.True(eliminado);
        Assert.Throws<KeyNotFoundException>(() => _tienda.BuscarProducto("Laptop"));
    }

    [Fact]
    public void BuscarProducto_NoExistente_DeberiaLanzarKeyNotFoundException()
    { 
        Assert.Throws<KeyNotFoundException>(() => _tienda.BuscarProducto("Teclado Inexistente"));
    }

    [Fact]
    public void EliminarProducto_NoExistente_DeberiaLanzarExcepcion()
    {
        Assert.Throws<KeyNotFoundException>(() => _tienda.EliminarProducto("ProductoFantasma"));
    }

    [Fact]
    public void AplicarDescuento_DeberiaCalcularNuevoPrecioYLlamarActualizarPrecio_UsandoMock()
    {
        var mockProducto = new Mock<IProducto>();
        mockProducto.Setup(p => p.Nombre).Returns("Campera");
        mockProducto.Setup(p => p.Precio).Returns(100m);

        _tienda.AgregarProducto(mockProducto.Object);

        
        _tienda.AplicarDescuento("Campera", 20m);

        mockProducto.Verify(p => p.ActualizarPrecio(80m), Times.Once);
    }
}
