using System.Text.Json;
using Inventario.Modelos;

namespace Inventario.Datos;

public class RepositorioJson : IRepositorioProductos
{
    private static readonly JsonSerializerOptions _opciones = new() { WriteIndented = true };

    private readonly string _ruta;

    public RepositorioJson(string ruta) => _ruta = ruta;

    public List<Producto> ObtenerTodos()
    {
        if (!File.Exists(_ruta)) return [];

        try
        {
            string json = File.ReadAllText(_ruta);
            return JsonSerializer.Deserialize<List<Producto>>(json) ?? [];
        }

        catch (Exception ex) when (ex is JsonException or ArgumentException)
        {

            File.Copy(_ruta, _ruta + ".danado", overwrite: true);
            return [];
        }
    }

    public Producto? BuscarPorCodigo(string codigo)
    {
        return ObtenerTodos().FirstOrDefault(p => MismoCodigo(p.Codigo, codigo));
    }

    public void Agregar(Producto producto)
    {
        List<Producto> lista = ObtenerTodos();
        lista.Add(producto);
        Guardar(lista);
    }

    public void Actualizar(Producto producto)
    {
        List<Producto> lista = ObtenerTodos();
        int i = lista.FindIndex(p => MismoCodigo(p.Codigo, producto.Codigo));
        if (i >= 0)
        {
            lista[i] = producto;
            Guardar(lista);
        }
    }

    public void Eliminar(string codigo)
    {
        List<Producto> lista = ObtenerTodos();
        int eliminados = lista.RemoveAll(p => MismoCodigo(p.Codigo, codigo));
        if (eliminados > 0) Guardar(lista);
    }

    private void Guardar(List<Producto> lista)
    {
        File.WriteAllText(_ruta, JsonSerializer.Serialize(lista, _opciones));
    }

    private static bool MismoCodigo(string a, string b)
    {
        return string.Equals(a.Trim(), b.Trim(), StringComparison.OrdinalIgnoreCase);
    }
}
