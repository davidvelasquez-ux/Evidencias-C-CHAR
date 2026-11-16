using Inventario.Datos;
using Inventario.Modelos;
using Inventario.Servicios;

// Ruta fija junto al ejecutable, sin depender de la carpeta desde donde se abra.
string ruta = Path.Combine(AppContext.BaseDirectory, "inventario.json");
var servicio = new ServicioInventario(new RepositorioJson(ruta));

Console.WriteLine($"Datos guardados en: {ruta}");

bool salir = false;
while (!salir)
{
    MostrarMenu();
    string opcion = Console.ReadLine()?.Trim() ?? "";

    try
    {
        switch (opcion)
        {
            case "1": Registrar(); break;
            case "2": AgregarStock(); break;
            case "3": Vender(); break;
            case "4": VerInventario(servicio.Listar(), "INVENTARIO"); break;
            case "5": VerInventario(servicio.StockBajo(), "STOCK BAJO (menos de 5)"); break;
            case "6": Buscar(); break;
            case "7": Eliminar(); break;
            case "8": salir = true; Console.WriteLine("¡Hasta luego!"); break;
            default: Console.WriteLine("Opción no válida. Elige de 1 a 8."); break;
        }
    }
    catch (StockInsuficienteException ex)
    {
        Console.WriteLine($"⚠️ {ex.Message}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"⚠️ {ex.Message}");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"⚠️ {ex.Message}");
    }
    catch (Exception ex)   // siempre al final
    {
        Console.WriteLine($"Error inesperado: {ex.Message}");
    }
}

// ---------- Opciones del menú ----------

void Registrar()
{
    string codigo = LeerTexto("Código: ");
    string nombre = LeerTexto("Nombre: ");
    decimal precio = LeerDecimal("Precio: ");
    int stock = LeerEntero("Stock inicial: ");

    servicio.Agregar(new Producto(codigo, nombre, precio, stock));
    Console.WriteLine("✅ Producto registrado.");
}

void AgregarStock()
{
    string codigo = LeerTexto("Código del producto: ");
    int cantidad = LeerEntero("Cantidad a agregar: ");

    servicio.AgregarStock(codigo, cantidad);
    Console.WriteLine("✅ Stock actualizado.");
}

void Vender()
{
    string codigo = LeerTexto("Código del producto: ");
    int cantidad = LeerEntero("Cantidad a vender: ");

    servicio.Vender(codigo, cantidad);
    Console.WriteLine("✅ Venta realizada.");
}

void VerInventario(List<Producto> productos, string titulo)
{
    Console.WriteLine($"\n--- {titulo} ---");
    if (productos.Count == 0)
    {
        Console.WriteLine("No hay productos para mostrar.");
        return;
    }

    Console.WriteLine($"{"Código",-10}{"Nombre",-25}{"Precio",12}{"Stock",8}");
    foreach (var p in productos)
        Console.WriteLine($"{p.Codigo,-10}{p.Nombre,-25}{p.Precio,12:N0}{p.Stock,8}");
}
void Buscar()
{
    string texto = LeerTexto("Texto a buscar (nombre o código): ");
    VerInventario(servicio.BuscarPorTexto(texto), $"RESULTADOS PARA \"{texto}\"");
}

void Eliminar()
{
    string codigo = LeerTexto("Código del producto a eliminar: ");

    // Muestra el producto antes de pedir confirmación
    var encontrados = servicio.BuscarPorTexto(codigo)
        .Where(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
        .ToList();

    if (encontrados.Count == 0)
    {
        Console.WriteLine($"⚠️ No existe el producto {codigo}.");
        return;
    }

    Producto p = encontrados[0];
    Console.WriteLine($"Vas a eliminar: {p.Codigo} - {p.Nombre} (stock: {p.Stock})");

    if (Confirmar("¿Seguro que deseas eliminarlo? (s/n): "))
    {
        servicio.Eliminar(p.Codigo);
        Console.WriteLine("✅ Producto eliminado.");
    }
    else
    {
        Console.WriteLine("Operación cancelada.");
    }
}

bool Confirmar(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        string respuesta = Console.ReadLine()?.Trim().ToLower() ?? "";
        if (respuesta == "s") return true;
        if (respuesta == "n") return false;
        Console.WriteLine("Escribe 's' para sí o 'n' para no.");
    }
}

// ---------- Entrada segura (TryParse: nunca se cae) ----------

void MostrarMenu()
{
    Console.WriteLine("""

        ===== INVENTARIO =====
        1. Registrar producto
        2. Agregar stock
        3. Vender
        4. Ver inventario
        5. Ver stock bajo
        6. Buscar por texto
        7. Eliminar producto
        8. Salir
        """);
    Console.Write("Elige una opción: ");
}

string LeerTexto(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        string texto = Console.ReadLine()?.Trim() ?? "";
        if (texto != "") return texto;
        Console.WriteLine("Este dato no puede estar vacío.");
    }
}

int LeerEntero(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        if (int.TryParse(Console.ReadLine(), out int valor)) return valor;
        Console.WriteLine("Debes escribir un número entero.");
    }
}

decimal LeerDecimal(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        if (decimal.TryParse(Console.ReadLine(), out decimal valor)) return valor;
        Console.WriteLine("Debes escribir un número.");
    }
}