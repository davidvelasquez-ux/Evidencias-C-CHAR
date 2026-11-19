using Inventario.Datos;
using Inventario.Modelos;

namespace Inventario.Servicios;

public class ServicioInventario
{
    private const int LimiteStockBajo = 5;

    private readonly IRepositorioProductos _repositorio;

    public ServicioInventario(IRepositorioProductos repositorio) => _repositorio = repositorio;

    public List<Producto> Listar()
    {
        return _repositorio.ObtenerTodos().OrderBy(p => p.Nombre).ToList();
    }

    public void Agregar(Producto producto)
    {
        if (_repositorio.BuscarPorCodigo(producto.Codigo) is not null)
            throw new ArgumentException($"Ya existe un producto con el código {producto.Codigo}.");

        _repositorio.Agregar(producto);
    }

    public void AgregarStock(string codigo, int cantidad)
    {
        Producto producto = BuscarObligatorio(codigo);
        producto.AgregarStock(cantidad);
        _repositorio.Actualizar(producto);
    }

    public void Vender(string codigo, int cantidad)
    {
        Producto producto = BuscarObligatorio(codigo);
        producto.Vender(cantidad);
        _repositorio.Actualizar(producto);
    }

    public List<Producto> StockBajo()
    {
        return _repositorio.ObtenerTodos()
            .Where(p => p.Stock < LimiteStockBajo)
            .OrderBy(p => p.Nombre)
            .ToList();
    }


    public List<Producto> BuscarPorTexto(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto)) return [];

        texto = texto.Trim();
        return _repositorio.ObtenerTodos()
            .Where(p => p.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase)
                     || p.Codigo.Contains(texto, StringComparison.OrdinalIgnoreCase))
            .OrderBy(p => p.Nombre)
            .ToList();
    }


    public void Eliminar(string codigo)
    {
        Producto producto = BuscarObligatorio(codigo);
        _repositorio.Eliminar(producto.Codigo);
    }

    private Producto BuscarObligatorio(string codigo)
    {
        return _repositorio.BuscarPorCodigo(codigo)
            ?? throw new ArgumentException($"No existe el producto {codigo}.");
    }
}
