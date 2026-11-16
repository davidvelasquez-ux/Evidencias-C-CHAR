using Inventario.Datos;
using Inventario.Modelos;

namespace Inventario.Servicios;

public class ServicioInventario
{
    private readonly IRepositorioProductos _repositorio;

    public ServicioInventario(IRepositorioProductos repositorio) => _repositorio = repositorio;

    public List<Producto> Listar() =>
        _repositorio.ObtenerTodos().OrderBy(p => p.Nombre).ToList();

    public void Agregar(Producto producto)
    {
        if (_repositorio.BuscarPorCodigo(producto.Codigo) is not null)
            throw new InvalidOperationException($"Ya existe un producto con el código {producto.Codigo}.");
        _repositorio.Agregar(producto);
    }

    public void AgregarStock(string codigo, int cantidad)
    {
        Producto producto = BuscarOFallar(codigo);
        producto.AgregarStock(cantidad);
        _repositorio.Actualizar(producto);
    }

    public void Vender(string codigo, int cantidad)
    {
        Producto producto = BuscarOFallar(codigo);
        producto.Vender(cantidad);   // puede lanzar StockInsuficienteException
        _repositorio.Actualizar(producto);
    }

    public List<Producto> StockBajo() =>
        Listar().Where(p => p.Stock < 5).ToList();

    private Producto BuscarOFallar(string codigo) =>
        _repositorio.BuscarPorCodigo(codigo)
            ?? throw new ArgumentException($"No existe el producto {codigo}.");
}