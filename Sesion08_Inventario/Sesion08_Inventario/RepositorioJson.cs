using System.Text.Json;
using Inventario.Modelos;

namespace Inventario.Datos;

public class RepositorioJson : IRepositorioProductos
{
    private readonly string _ruta;
    public RepositorioJson(string ruta) => _ruta = ruta;

    public List<Producto> ObtenerTodos()
    {
        // Sin archivo: empieza vacío.
        if (!File.Exists(_ruta)) return [];

        try
        {
            string json = File.ReadAllText(_ruta);
            return JsonSerializer.Deserialize<List<Producto>>(json) ?? [];
        }
        catch (Exception ex) when (ex is JsonException or ArgumentException)
        {
            // Archivo dañado: guarda una copia .danado y empieza vacío.
            File.Copy(_ruta, _ruta + ".danado", overwrite: true);
            return [];
        }
    }

    private void Guardar(List<Producto> lista) =>
        File.WriteAllText(_ruta,
            JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true }));

    public Producto? BuscarPorCodigo(string codigo) =>
        ObtenerTodos().FirstOrDefault(p =>
            p.Codigo.Equals(codigo.Trim(), StringComparison.OrdinalIgnoreCase));

    public void Agregar(Producto producto)
    {
        var lista = ObtenerTodos();
        lista.Add(producto);
        Guardar(lista);
    }

    public void Actualizar(Producto producto)
    {
        var lista = ObtenerTodos();
        int i = lista.FindIndex(p => p.Codigo == producto.Codigo);
        if (i >= 0)
        {
            lista[i] = producto;
            Guardar(lista);
        }
    }

    public void Eliminar(string codigo)
    {
        var lista = ObtenerTodos();
        lista.RemoveAll(p => p.Codigo.Equals(codigo.Trim(), StringComparison.OrdinalIgnoreCase));
        Guardar(lista);
    }
}